namespace UltraEnterpriseSDLC
{
    sealed class QualityMetric
    {
        public string Name {get;}
        public double Score { get;}

        public QualityMetric(string name, double score)
        {
            Name=name;
            Score=score;
        }
    }

}