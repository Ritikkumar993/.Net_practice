

namespace UltraEnterpriseSDLC
{
    
    
    
    


    class Program
    {
        static void Main()
        {

            EnterpriseSDLCEngine engine = new EnterpriseSDLCEngine();

            engine.AddRequirement("Single Sign-On",RiskLevel.High);
            engine.AddRequirement("Fraud Detection",RiskLevel.Critical);

            var degin = engine.CreateWorkItem("Single Sign-On Desgin",SDLCStage.Design);
            var dev = engine.CreateWorkItem("Single Sign-On Deployment",SDLCStage.Deployment);
            var test = engine.CreateWorkItem("Single Sign-On Testing",SDLCStage.Testing);

            engine.AddDependency(dev.Id,degin.Id);
            engine.AddDependency(test.Id,dev.Id);

            engine.RegisterTestSuite("Sign-On Desgin Regression");
            engine.RegisterTestSuite("Sign-On Desgin Security");

            engine.PlanStage(SDLCStage.Design);

            engine.ExecuteNext();
            engine.ExecuteNext();
            
            engine.DeployRelease("v3.4.1");

            engine.RecordQualityMetric("code coverage",91.7);
            engine.RecordQualityMetric("security score",97.3);
            
            engine.RollbackRelease();

            engine.PrintAuditLedger();

            engine.PrintReleaseScoreboard();



        }
    }
}