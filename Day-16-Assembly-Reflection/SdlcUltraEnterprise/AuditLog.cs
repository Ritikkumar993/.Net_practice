namespace UltraEnterpriseSDLC
{
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

}