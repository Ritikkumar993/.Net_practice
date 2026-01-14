namespace UltraEnterpriseSDLC
{
    sealed class Requirement
    {
        public  int Id{ get;}
        public  string Title{ get;}
        public  RiskLevel Risk{ get; }

        public Requirement(int id, string title, RiskLevel risk)
        {
            Id=id;
            Title=title;
            Risk=risk;
        }
    }

}