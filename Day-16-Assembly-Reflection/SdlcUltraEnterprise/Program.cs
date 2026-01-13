

namespace UltraEnterpriseSDLC
{
    public enum RiskLevel
    {
        Low,
        Medium,
        High,
        Critical

    }

    public enum SDLCStage
    {
        Backlog,
        Requirement,
        Design,
        Development,
        CodeReview,
        Testing,
        UAT,
        Deployment,
        Maintenance

    }

    sealed class Requirement
    {
        public readonly int Id{ get;}
        public readonly string Title{ get;}
        public readonly RiskLevel Risk{ get; }

        public Requirement(int id, string title, RiskLevel risk)
        {
            Id=id;
            Title=title;
            Risk=risk;
        }
    }

    sealed class WorkItem
    {
        public readonly int Id {get;}
        public readonly string Name {get;}
        public readonly SDLCStage  Stage {get;}

        public readonly HashSet<int> DependencyIds{get; }

        public WorkItem(int id, string name, SDLCStage stage)
        {
            Id=id;
            Name=name;
            Stage = stage;
            DependencyIds=new HashSet<int>();
        }
    }
    sealed class BuildSnapshot
    {
        public readonly string Version {get;}
        public readonly DateTime Timestamp {get;}

        public BuildSnapshot(string version)
        {
            Version =version;
            Timestamp=DateTime.Now;
        }

        
    }

    sealed class AuditLog
    {
        public DateTime Time{get;}
        public string Action{get;}
        public AuditLog(string action)
        {
            Time=DateTime.Now;
            Action=action;
        }

    }

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

    class EnterpriseSDLCEngine
    {
        private List<Requirement> _requirements;
        private Dictionary<int,WorkItem> _workItemRegistry;
        private SortedDictionary<SDLCStage,WorkItem> _stageBoard;
        private Queue<WorkItem> _executionQueue;
        private Stack<BuildSnapshot> _rollbackStack;
        private HashSet<string> _uniqueTestSuites;
        private LinkedList<AuditLog> _auditLedger;
        private SortedList<double, QualityMetric> _releaseScoreboard;
        private int _requirementCounter;
        private int _workItemCounter;

        public EnterpriseSDLCEngine()
        {
            _requirements=new List<Requirement>();
            _workItemRegistry = new Dictionary<int,WorkItem>();
            _stageBoard = new SortedDictionary<SDLCStage, List<WorkItem>>();

            foreach (var stage in SDLCStage)
            {
                _stageBoard[stage]=new List<WorkItem>();
            }

            _executionQueue = new Queue<WorkItem>();
            _rollbackStack  = new Stack<BuildSnapshot>();
            _uniqueTestSuites  = new HashSet<string>();
            _auditLedger  = new LinkedList<AuditLog>();
            _releaseScoreboard  = new SortedList<double, QualityMetric>();
        }

        
        public void AddRequirement(string title, RiskLevel risk)
        {
            Requirement req = new Requirement(_requirementCounter,title,risk);
            _requirementCounter++;
            _requirements.Add(req);

            AuditLog alog = new AuditLog($" Title {title} RiskLeevel {risk}");
            _auditLedger.Append(alog);
        }

        public WorkItem CreateWorkItem(string name, SDLCStage stage)
        {
            WorkItem workItem =new WorkItem(_workItemCounter,name, stage);
            _workItemCounter++;
            _workItemRegistry[workItem.Id]=workItem;

            _stageBoard[workItem.stage].Add(workItem);

            AuditLog auditLog= new AuditLog($"WorkItem is created {workItem.Name} stage {workItem.Stage} ");
            _auditLedger.Append(auditLog);

            return workItem;
        }

        public void AddDependency(int workItemId, int dependsOnId)
        {
            if(_workItemRegistry.ContainsKey(workItemId) && _workItemRegistry.ContainsKey(dependsOnId))
            {
                WorkItem workItem = _workItemRegistry[workItemId];
                workItem.DependencyIds.Add(dependsOnId);
            }
            AuditLog auditlog = new AuditLog($"workItem {workItemId} is dependds upon {dependsOnId}");
            _auditLedger.Append(auditlog);
        }

        public void PlanStage(SDLCStage stage)
        {
            List<WorkItem> AllWorkItem = _stageBoard[stage];

            var FilteredWorkItem = AllWorkItem.Where(w => _workItemRegistry.ContainsKey(w.DependencyIds) && );
               
        }



    }
}