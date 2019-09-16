namespace UserManagementAPIs.Models
{
    public interface ILog
    {
        void Debug(string message);
        void Error(string message);
        void Information(string message);
        void Warning(string message);
    }
}