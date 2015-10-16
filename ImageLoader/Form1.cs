using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Eklekto.Helpers;
using FibroscanProcessor;

namespace ImageLoader
{
    public partial class Form1 : Form
    {
        Image sourceImage;
        private List<PictureBox> pictures;

        public Form1()
        {
            InitializeComponent();
            pictures = new List<PictureBox>
            {
                sourcePicture, elastoPicture, kuwaharaPicture, binarizationPicture, edgePicture, morphologyPicture,cropPicture,
                choosingPicture, approximationPicture, sourceModMPicture, outModMPicture, sourceModAPicture, outModAPicture, productionPicture
            };
        }



        private void LoadImage()
        {
            openFileDialog.Filter = "image (JPEG) files (*.jpg)|*.jpg|All files (*.*)|*.*";
            AllClear();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                sourceImage = Image.FromFile(openFileDialog.FileName);
                sourcePicture.Image = sourceImage;
                imagePath.Text = openFileDialog.FileName;
            }
        }

        private void StartImageVerification()
        {
            if (sourcePicture.Image == null)
                LoadImage();
            if (sourcePicture.Image != null)
            {
                BoxClear();
                FibroscanImage image = new FibroscanImage(sourceImage, true);
                VerificationStatus elastoStatus = ElastogramVerification(image);
                Ultrasoundverification(image);

                //Production code
                if (productionCheckBox.Checked)
                {
                    FibroscanImage prod = new FibroscanImage(sourceImage);
                    productionPicture.Image = prod.Merged;
                }
                //else
                  //  productionPicture.Image = image.Step15DrawBrightLines(240,20);

                if (savingStepsCheckBox.Checked)
                    SaveSteps();
                if (saveClassificationCheckBox.Checked)
                    SaveClassification(elastoStatus);
            }
        }

        private VerificationStatus ElastogramVerification(FibroscanImage image)
        {
            long timer = 0;

            elastoPicture.Image = image.Step1LoadElastogram();

            image.Step2ElastoWithoutLine();

            kuwaharaPicture.Image = image.Step3KuwaharaElasto((int)numericUpDown1.Value);

            if (simpleBinRadioButton.Checked)
                binarizationPicture.Image = image.Step4SimpleBinarization(ref timer, (byte)upDownBinarThreshold.Value);
            if (niblackRadioButton.Checked)
                binarizationPicture.Image = image.Step4NiblackBinarization(ref timer, (double)upDownBinarizationK.Value, (int)upDownBinarLocalRadius.Value);
            if (sauvolaRadioButton.Checked)
                binarizationPicture.Image = image.Step4SauvolaBinarization(ref timer, (double)upDownBinarizationK.Value, (int)upDownBinarLocalRadius.Value);
            if (wolfRadioButton.Checked)
                binarizationPicture.Image = image.Step4WolfJoulionBinarization(ref timer, (double)upDownBinarizationK.Value, (int)upDownBinarLocalRadius.Value);
            if (morphNiblackRadioButton.Checked)
                binarizationPicture.Image = image.Step4MorphologyNiblackBinarization(ref timer, (double)upDownBinarizationK.Value, (int)upDownBinarLocalRadius.Value,
                                                                (int)upDownBinarGlobalRadius.Value, (byte)upDownBinarThreshold.Value);
            if (morphOtsuRadioButton.Checked)
                binarizationPicture.Image = image.Step4SimpleMorphologyBinarization(ref timer, (int)upDownBinarGlobalRadius.Value, (byte)upDownBinarThreshold.Value);
            resultBox.Items.Add("Binarization time:       " + timer);

            edgePicture.Image = image.Step5EdgeRemoving(ref timer, (int)upDownEdgeLeft1.Value, (int)upDownEdgeLeft1Central.Value, (int)upDownEdgeLeft2.Value,
                (int)upDownEdgeLeft2Central.Value, (int)upDownEdgeRight.Value, (int)upDownEdgeRightCentral.Value);

            morphologyPicture.Image = image.Step6Morphology((int)numericUpDown3.Value);

            cropPicture.Image = image.Step7CropObjects((int)upDownCropStep.Value, (int)upDownCropDistance.Value);

            choosingPicture.Image = image.Step8ChooseOneObject(ref timer, 0.55, 0.65);

            approximationPicture.Image = image.Step9Approximation(ref timer, (double)upDownRansacSample.Value, (double)upDownRansacOutliers.Value,
                (int)upDownRansacIterations.Value);

            resultBox.Items.Add("RANSAC time:        " + timer);

            signatureBox.Items.Add("Fibroline Angle:      " + Math.Round(image.Fibroline.Equation.Angle, 2));
            signatureBox.Items.Add("Left Angle:              " + Math.Round(image.WorkingBlob.LeftApproximation.Angle, 2));
            signatureBox.Items.Add("Right Angle:            " + Math.Round(image.WorkingBlob.RightApproximation.Angle, 2));
            signatureBox.Items.Add("Left RSquare:         " + Math.Round(image.WorkingBlob.RSquareLeft, 2));
            signatureBox.Items.Add("Right RSquare:        " + Math.Round(image.WorkingBlob.RSquareRight, 2));
            signatureBox.Items.Add("Left Relative Est:      " + Math.Round(image.WorkingBlob.RelativeEstimationLeft, 2));
            signatureBox.Items.Add("Right Relative Est:     " + Math.Round(image.WorkingBlob.RelativeEstimationRight, 2));
            signatureBox.Items.Add("Blob Area:                " + image.WorkingBlob.Blob.Area);

            VerificationStatus elastoStatus = image.Step10Classify();
            resultBox.Items.Add("Elastogram is " + elastoStatus);
            return elastoStatus;
        }

        private void Ultrasoundverification(FibroscanImage image)
        {
            long timer = 0;
            sourceModMPicture.Image = image.Step11LoadUltrasoundM((double)upDownBrightPixelLimit.Value, (int)upDownUsDeviationStreak.Value);

            VerificationStatus umms = VerificationStatus.NotCalculated;
            outModMPicture.Image = image.Step15DrawBrightLines(ref umms, (int)upDownLimitUsBrightness.Value, (int)upDownBrightPixelLimit.Value, (int)upDownBrightLinesLimit.Value);
            resultBox.Items.Add("UltraSoundModM is " + umms);

            signatureBox.Items.Add("Mod M bright lines:  " +
                                   image.WorkingUltrasoundModM.getBrightLines((int)upDownLimitUsBrightness.Value, (int)upDownBrightPixelLimit.Value).Count);

            sourceModAPicture.Image = image.Step13LoadUltrasoundA();

            VerificationStatus umas = VerificationStatus.NotCalculated;
            outModAPicture.Image = image.Step14DrawUltraSoundApproximation(ref umas, (int)upDownRelativeEstimationLimit.Value);
            resultBox.Items.Add("UltraSoundModA is " + umas);
            signatureBox.Items.Add("ModA Estimation:   " + Math.Round(image.WorkingUltrasoundModA.RelativeEstimation, 2));
            signatureBox.Items.Add("ModA RSquare        : " + Math.Round(image.WorkingUltrasoundModA.RSquare));
        }

        private void FolderVerification()
        {
            var firstFiles = Directory.EnumerateFiles(Path.GetDirectoryName(imagePath.Text)).ToList();
            int filesNumber = Math.Min(firstFiles.Count(), (int)upDownFilesNumber.Value);
            for (int i = 0; i < filesNumber; i++)
            {
                BoxClear();
                if (Path.GetExtension(firstFiles[i]) == ".jpg")
                {
                    imagePath.Text = firstFiles[i];
                    sourceImage = Image.FromFile(imagePath.Text);
                    sourcePicture.Image = sourceImage;
                    StartImageVerification();
                }
                commonStatBox.Items.Add(i + 1 + " files processed");
            }
        }

        private void groupProcessingButton_Click(object sender, EventArgs e)
        {
            if (sourcePicture.Image == null)
                LoadImage();
            if (sourcePicture.Image != null)
                FolderVerification();
        }
       
        #region Saving
        private void SaveOneImageToFolder()
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                for (int i = 0; i < pictures.Count; i++)
                    if (pictures[i].Image != null)
                        pictures[i].Image.Save(folderBrowserDialog.SelectedPath + "//"+ i + ".jpg");
        }

        private void SaveSteps()
        {
            String savingFolder = Path.GetDirectoryName(imagePath.Text) + "//ResultSteps//" +Path.GetFileNameWithoutExtension(imagePath.Text);
            Directory.CreateDirectory(savingFolder);
            for (int i = 0; i < pictures.Count; i++)
                if (pictures[i].Image != null)
                    pictures[i].Image.Save(savingFolder + "//" + i + ".jpg");
        }

        private void SaveClassification(VerificationStatus status)
        {
            String savingFolder = Path.GetDirectoryName(imagePath.Text) + "//Classification//" + status;
            Directory.CreateDirectory(savingFolder);
            pictures[0].Image.Save(savingFolder + "//" + Path.GetFileName(imagePath.Text));
        }

        #endregion
 
        #region buttons
        private void buttonNextImage_Click(object sender, EventArgs e)
        {
            try
            {
                AllClear();
                imagePath.Text = Directory.EnumerateFiles(Path.GetDirectoryName(imagePath.Text))
                        .Skip(GetCurrentFileImdex(imagePath.Text) + 1)
                        .First();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sourceImage = Image.FromFile(imagePath.Text);
            sourcePicture.Image = sourceImage;
            StartImageVerification();
        }

        private void buttonPrevImage_Click(object sender, EventArgs e)
        {
            try
            {
                AllClear();
                imagePath.Text = Directory.EnumerateFiles(Path.GetDirectoryName(imagePath.Text))
                        .Skip(GetCurrentFileImdex(imagePath.Text) - 1)
                        .First();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sourceImage = Image.FromFile(imagePath.Text);
            sourcePicture.Image = sourceImage;
            StartImageVerification();
        }

        #endregion

        #region Helpers
        private int GetCurrentFileImdex(string text)
        {
            var filesEnumerator = Directory.EnumerateFiles(Path.GetDirectoryName(text));
            int fileIndex = 0;

            foreach (var file in filesEnumerator)
            {
                if (file == imagePath.Text)
                    break;
                fileIndex++;
            }
            return fileIndex;
        }
        private void AllClear()
        {
            pictures.ForEach(picture =>
            {
                picture.Image = null;
                picture.Invalidate();
            });
            BoxClear();
        }

        private void BoxClear()
        {
            signatureBox.Items.Clear();
            resultBox.Items.Clear();
            commonStatBox.Items.Clear();
        }
        #endregion

        #region Hotkeys

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Right))
            {
                try
                {
                    AllClear();
                    imagePath.Text = Directory.EnumerateFiles(Path.GetDirectoryName(imagePath.Text))
                            .Skip(GetCurrentFileImdex(imagePath.Text) + 1)
                            .First();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sourceImage = Image.FromFile(imagePath.Text);
                sourcePicture.Image = sourceImage;
                StartImageVerification();
                return true;
            }

            if (keyData == (Keys.Left))
            {
                try
                {
                    AllClear();
                    imagePath.Text = Directory.EnumerateFiles(Path.GetDirectoryName(imagePath.Text))
                            .Skip(GetCurrentFileImdex(imagePath.Text) - 1)
                            .First();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sourceImage = Image.FromFile(imagePath.Text);
                sourcePicture.Image = sourceImage;
                StartImageVerification();
                return true;
            }

            if (keyData == (Keys.Escape))
            {
                {
                    DialogResult rsl = MessageBox.Show("Ты не посмеешь уйти, когда я анализирую изображения!", "Одумайся!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rsl == DialogResult.No)
                        Application.Exit();
                }
                return true;
            }
            if (keyData == (Keys.Space))
            {
                LoadImage();
                return true;
            }
            if (keyData == (Keys.Enter))
            {
                StartImageVerification();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region Casual methods

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rsl = MessageBox.Show("Не смей уходить, когда я анализирую изображения!", "Одумайся!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rsl == DialogResult.No)
                Application.Exit();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            LoadImage();
        }
        private void loadToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            LoadImage();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoadImage();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            StartImageVerification();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SaveOneImageToFolder();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveOneImageToFolder();
        }
        private void processingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartImageVerification();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            StartImageVerification();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            BigImage fBigImage = new BigImage(((PictureBox)sender).Image);
            fBigImage.ShowDialog();
        }

        private void pictureBox_Saving(object sender, EventArgs e)
        {
            //fBigImage.ShowDialog();
            Image img = ((PictureBox) sender).Image;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    if (img != null)
                        img.Save(saveFileDialog.FileName + ".jpg");
        }
        #endregion
    }
}
