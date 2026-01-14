namespace UltraEnterpriseSDLC
{
    
    class EnterpriseSDLCEngine
    {
        private List<Requirement> _requirements;
        private Dictionary<int,WorkItem> _workItemRegistry;
        private SortedDictionary<SDLCStage,List<WorkItem>> _stageBoard;
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

            foreach (SDLCStage stage in Enum.GetValues(typeof(SDLCStage)))
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

            AuditLog alog = new AuditLog($"Title {title} RiskLeevel {risk}");
            _auditLedger.AddLast(alog);
        }

        public WorkItem CreateWorkItem(string name, SDLCStage stage)
        {
            WorkItem workItem =new WorkItem(_workItemCounter,name, stage);
            _workItemCounter++;
            _workItemRegistry[workItem.Id]=workItem;

            _stageBoard[workItem.Stage].Add(workItem);

            AuditLog auditLog= new AuditLog($"WorkItem is created {workItem.Name} stage {workItem.Stage} ");
            _auditLedger.AddLast(auditLog);

            return workItem;
        }

        public void AddDependency(int workItemId, int dependsOnId)
        {
            if(_workItemRegistry.ContainsKey(workItemId) && _workItemRegistry.ContainsKey(dependsOnId))
            {
                WorkItem workItem = _workItemRegistry[workItemId];
                workItem.DependencyIds.Add(dependsOnId);
                AuditLog auditlog = new AuditLog($"workItem {workItemId} is dependds upon {dependsOnId}");
                _auditLedger.AddLast(auditlog);
            }
        }

        public void PlanStage(SDLCStage stage)
        {
            List<WorkItem> AllWorkItem = _stageBoard[stage];

            var filteredWorkItem = AllWorkItem
                .Where(w => 
                    w.DependencyIds.All(depId => 
                    _workItemRegistry.ContainsKey(depId) && 
                    _workItemRegistry[depId].Stage > stage
                    )
                )
                .ToList(); 

            foreach(var workItem in filteredWorkItem)
            {
                _executionQueue.Enqueue(workItem);
            } 

            AuditLog entry = new AuditLog($"{stage} has been planned.");
            _auditLedger.AddLast(entry);

        }

        public void ExecuteNext()
        {
            if (_executionQueue.Count==0)
                return;
            
            WorkItem nextWorkItem =_executionQueue.Dequeue();
            SDLCStage prevstage = nextWorkItem.Stage;
            SDLCStage newStage =prevstage+1;

            nextWorkItem.Stage=newStage;

            _stageBoard[prevstage].Remove(nextWorkItem);
            _stageBoard[newStage].Add(nextWorkItem);

             AuditLog entry = new AuditLog( $"WorkItem {nextWorkItem.Id} executed: " +$"Stage changed from {prevstage} to {newStage}.");
            _auditLedger.AddLast(entry);
        }

        public void RegisterTestSuite(string suiteId)
        {
               _uniqueTestSuites.Add(suiteId);

               AuditLog entry = new AuditLog($"test suit {suiteId} has been registered");
               _auditLedger.AddLast(entry);
        }

        public void DeployRelease(string version)
        {
            BuildSnapshot buildSnapshot = new BuildSnapshot(version);
            _rollbackStack.Push(buildSnapshot);

            AuditLog entry = new AuditLog($"the deployment has been completed for version {version}.");
            _auditLedger.AddLast(entry);

        }

        public void RollbackRelease()
        {
            if(_rollbackStack.Count==0)
                return;
            
            BuildSnapshot retrievedSnapshort = _rollbackStack.Pop();

            string version = retrievedSnapshort.Version;

            AuditLog entry = new AuditLog($"a rollback hasbeen executed. of Version: {version}");
            _auditLedger.AddLast(entry);
        }

        public void RecordQualityMetric(string metricName, double score)
        {
            if (!_releaseScoreboard.ContainsKey(score))
            {
                QualityMetric newMetric = new QualityMetric(metricName, score);
                _releaseScoreboard.Add(score,newMetric);


            }
        }

        public void PrintAuditLedger()
        {
            foreach(var log in _auditLedger)
            {
                Console.WriteLine($"Time:{log.Time} | Action: {log.Action}");
                
            }
        }
        
        public void PrintReleaseScoreboard()
        {
            
            foreach(var entry in _releaseScoreboard.Reverse())
            {
                Console.WriteLine($"Name: {entry.Value.Name} | Score: {entry.Key:F2} ");
            }
        }


    }

}