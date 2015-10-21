using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibroscanProcessor.Elasto
{
    internal class LearningElastoClassificator
    {
        public List<ElastogramSignatura> TrainingSignatura;
        public List<ElastogramSignatura> Precedents;
        public List<double> SignatureRadiuses;

        LearningElastoClassificator(List<ElastogramSignatura> trainingSignatura, List<ElastogramSignatura> precedents, 
            List<double> signatureRadiuses)
        {
            TrainingSignatura = trainingSignatura;
            Precedents = precedents;
            SignatureRadiuses = signatureRadiuses;
        }

        public bool TrainOneAge()
        {
            return true;
        }

        public bool ShufleTrain(int ageSize, int maxAgeIterations, double goodTeachingPiece, double errorPiece)
        {
            return true;
        }
        /// <summary>
        /// Adding new precedents
        /// </summary>
        /// <param name="ageSize">Size of one age</param>
        /// <param name="maxAgeIterations">Limit count of ages</param>
        /// <param name="goodTeachingRatio">convergence condition</param>
        /// <param name="errorPiece">maximum piece of errors</param>
        /// <returns>train successeful? </returns>
        public bool TrainClassificator(int ageSize, int maxAgeIterations, double goodTeachingPiece, double errorPiece  )
        {
            int iterations = Math.Min(maxAgeIterations, TrainingSignatura.Count / ageSize);
            int errorLimitPerAge = (int) errorPiece*ageSize;
            int convergenceNum = (int) errorPiece*ageSize;
            //run for ages
            for (int i = 0; i < iterations; i++)
            {
                int errors = 0;
                int suсcess = 0;
                int precedentAdding = 0;
                //run for TrainingSignatures
                for (int a = 0; a < ageSize; a++)
                {
                    int trainingIndex = i * ageSize + a;
                    //run for precedents
                    bool isClassifiedSignature = false;
                    foreach (ElastogramSignatura precedent in Precedents)
                    {
                        if (IsSignatureCloseness(precedent, TrainingSignatura[trainingIndex]) &&
                            (precedent.Answer != TrainingSignatura[trainingIndex].Answer))
                        {
                            errors++;
                            isClassifiedSignature = true;
                            break;
                        }
                        if (IsSignatureCloseness(precedent, TrainingSignatura[trainingIndex]) &&
                            (precedent.Answer == TrainingSignatura[trainingIndex].Answer))
                        {
                            suсcess++;
                            isClassifiedSignature = true;
                            break;
                        }
                    }
                    if (!isClassifiedSignature)
                    {
                        Precedents.Add(TrainingSignatura[trainingIndex]);
                        precedentAdding++;
                    }
                }
                if (errors > errorLimitPerAge)
                    return false;
                if (precedentAdding < convergenceNum)
                    return true;
            }
            return false;
        } 

        /// <summary>
        /// Run on all precedents and search first closing
        /// </summary>
        /// <param name="workingSignatura"></param>
        /// <returns> verification status of trained classificator</returns>
        public VerificationStatus Classiffy(ElastogramSignatura workingSignatura)
        {
            if (Precedents.Count==0)
                return VerificationStatus.NotCalculated;

            return
                (from precedent in Precedents
                    where IsSignatureCloseness(precedent, workingSignatura)
                    select precedent.Answer).
                    DefaultIfEmpty(VerificationStatus.NotCalculated).First();

            /*for (int p = 0; p < Precedents.Count; p++)
            {
                if (IsSignatureCloseness(Precedents[p], workingSignatura))
                    return Precedents[p].Answer;
            }
            return VerificationStatus.NotCalculated;
            */
        }

        /// <summary>
        /// Check out a couple of signatures to closeness
        /// </summary>
        /// <param name="firstSign"></param>
        /// <param name="secondSign"></param>
        /// <returns></returns>
        public bool IsSignatureCloseness(ElastogramSignatura firstSign, ElastogramSignatura secondSign)
        {
            List<double> firstNormalizedSign = firstSign.NormalizedSignatura;
            List<double> secondNormalizedSign = secondSign.NormalizedSignatura;
            for (int i = 0; i < ElastogramSignatura.Size; i++)
                if (Math.Abs(firstNormalizedSign[i] - secondNormalizedSign[i]) >= SignatureRadiuses[i])
                    return false;
            return true;
        }
    }
}
