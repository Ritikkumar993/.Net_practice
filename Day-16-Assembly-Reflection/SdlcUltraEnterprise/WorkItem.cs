namespace UltraEnterpriseSDLC
{
    sealed class WorkItem
    {


        public  int Id {get;}
        public  string Name { get;}
        public SDLCStage  Stage { get; set;}

        public HashSet<int> DependencyIds{ get; }

        public WorkItem(int id, string name, SDLCStage stage)
        {
            Id=id;
            Name=name;
            Stage = stage;
            DependencyIds=new HashSet<int>();
        }
    }
    
}