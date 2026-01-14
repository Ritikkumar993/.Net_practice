namespace UltraEnterpriseSDLC
{
    sealed class BuildSnapshot
    {
        public  string Version {get;}
        public  DateTime Timestamp {get;}

        public BuildSnapshot(string version)
        {
            Version =version;
            Timestamp=DateTime.Now;
        }

        
    }

}