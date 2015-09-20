using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using FibroscanProcessor;

namespace ImageLoader
{
    public partial class Form1 : Form
    {
        Image MemForImage;

        private void LoadImage(bool jpg)
        {
            if (jpg)
                openFileDialog1.Filter = "image (JPEG) files (*.jpg)|*.jpg|All files (*.*)|*.*";
            else
                openFileDialog1.Filter = "image (PNG) files (*.png)|*.png|All files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MemForImage = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = MemForImage;
            }
            pictureBox2.Image = null;
            pictureBox2.Invalidate();
            pictureBox3.Image = null;
            pictureBox3.Invalidate();
            pictureBox4.Image = null;
            pictureBox4.Invalidate();
            pictureBox5.Image = null;
            pictureBox5.Invalidate();
            pictureBox6.Image = null;
            pictureBox6.Invalidate();
            pictureBox7.Image = null;
            pictureBox7.Invalidate();
            pictureBox8.Image = null;
            pictureBox8.Invalidate();
            pictureBox9.Image = null;
            pictureBox9.Invalidate();
            pictureBox10.Image = null;
            pictureBox10.Invalidate();
            pictureBox11.Image = null;
            pictureBox11.Invalidate();
            pictureBox12.Image = null;
            pictureBox12.Invalidate();
            pictureBox13.Image = null;
            pictureBox13.Invalidate();
            pictureBox14.Image = null;
            pictureBox14.Invalidate();
            pictureBox15.Image = null;
            pictureBox15.Invalidate();
            pictureBox16.Image = null;
            pictureBox16.Invalidate();
        }
        private void StartImageVerification()
        {
            if (pictureBox1.Image == null)
                LoadImage(true);
            else
            {
                logBox.Items.Clear();
                FibroscanProcessor.FibroscanImage image = new FibroscanProcessor.FibroscanImage(MemForImage, true);
                long timer = 0;
                pictureBox2.Image = image.Step1LoadElastogram(ref timer);
                //logBox.Items.Add("Loading time: " + timer.ToString());
                image.Step2ElastoWithoutLine(ref timer);
                //logBox.Items.Add("Fibroline feeling time: " + timer.ToString());
                pictureBox3.Image = image.Step3KuwaharaElasto(ref timer, (int)numericUpDown1.Value);
                //logBox.Items.Add("Kuwahara time: " + timer.ToString());

                if (radioButton4.Checked)
                    pictureBox4.Image = image.Step4SimpleBinarization(ref timer, (byte)numericUpDown10.Value);
                if (radioButton1.Checked)
                    pictureBox4.Image = image.Step4NiblackBinarization(ref timer, (double)numericUpDown11.Value, (int)numericUpDown6.Value);
                if (radioButton2.Checked)
                    pictureBox4.Image = image.Step4SauvolaBinarization(ref timer, (double)numericUpDown11.Value, (int)numericUpDown6.Value);
                if (radioButton3.Checked)
                    pictureBox4.Image = image.Step4WolfJoulionBinarization(ref timer, (double)numericUpDown11.Value, (int)numericUpDown6.Value);
                if (radioButton5.Checked)
                    pictureBox4.Image = image.Step4LgbtBinarization(ref timer, (double)numericUpDown11.Value, (int)numericUpDown6.Value,
                                                                    (int)numericUpDown7.Value, (byte)numericUpDown10.Value);
                //logBox.Items.Add("Binarization time: " + timer.ToString());

                pictureBox5.Image = image.Step5EdgeRemoving(ref timer, (int)numericUpDown2.Value, (int)numericUpDown8.Value, (int)numericUpDown9.Value,
                    (int)numericUpDown12.Value, (int)numericUpDown13.Value, (int)numericUpDown14.Value);
                //logBox.Items.Add("EdgeRemoving time: " + timer.ToString());

                pictureBox6.Image = image.Step6Morphology(ref timer,(int)numericUpDown3.Value);
                //logBox.Items.Add("Morphology time: " + timer.ToString());

                image.Step7CropObjects(ref timer, (int)numericUpDown4.Value, (int)numericUpDown5.Value);
                //logBox.Items.Add("Crop time: " + timer.ToString());

                pictureBox7.Image = image.Step8ChooseOneObject(ref timer, 0.55, 0.65);
                //logBox.Items.Add("Object choosing time: " + timer.ToString());

                pictureBox8.Image = image.Step9Approximation(ref timer);
                //logBox.Items.Add("OLS time: " + timer.ToString());

                logBox.Items.Add("Elastogram is " + image.Step10Classify().ToString());

                pictureBox9.Image = image.Step11LoadUltrasoundM(ref timer);

                VerificationStatus umms = VerificationStatus.NotCalculated;
                pictureBox10.Image = image.Step12DrawBadLines(ref timer, ref  umms);
                logBox.Items.Add("UltraSoundModM is " + umms);

                pictureBox11.Image = image.Step13LoadUltrasoundA(ref timer);

                VerificationStatus umas = VerificationStatus.NotCalculated;
                pictureBox12.Image = image.Step14DrawUltraSoundApproximation(ref timer, ref umas);
                logBox.Items.Add("UltraSoundModA is " + umas);

                //Production code
                FibroscanImage prod = new FibroscanImage(MemForImage);
                pictureBox16.Image = prod.Merged;
            }
        }
        private void SaveImages()
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                String folderName = folderBrowserDialog1.SelectedPath;
                if (pictureBox1.Image != null)
                    pictureBox1.Image.Save(folderName + "//1.jpg");
                if (pictureBox2.Image != null)
                    pictureBox2.Image.Save(folderName + "//2.jpg");
                if (pictureBox3.Image != null)
                    pictureBox3.Image.Save(folderName + "//3.jpg");
                if (pictureBox4.Image != null)
                    pictureBox4.Image.Save(folderName + "//4.jpg");
                if (pictureBox5.Image != null)
                    pictureBox5.Image.Save(folderName + "//5.jpg");
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rsl = MessageBox.Show("Не смей уходить, когда я анализирую изображения!", "Одумайся!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rsl == DialogResult.Yes)
                Application.Exit();
        }
        #region Casual methods
        public Form1()
        {
            InitializeComponent();
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            LoadImage(true);
        }
        private void loadToolStripMenuItem_Click_1(object sender, EventArgs e)
            {
                LoadImage(true);
            }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            StartImageVerification();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SaveImages();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveImages();
        }
        private void processingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartImageVerification();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            BigImage fBigImage = new BigImage(((PictureBox)sender).Image);
            fBigImage.ShowDialog();
        }
        #endregion
    }
}
