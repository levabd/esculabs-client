namespace FibroscanProcessor.Elasto
{
    class LearningInfo
    {
        public readonly int Count;
        public int Errors;
        public int Teaching;

        LearningInfo(int count, int error, int teaching)
        {
            Count = count;
            Errors = error;
            Teaching = teaching;
        }
    }
}
