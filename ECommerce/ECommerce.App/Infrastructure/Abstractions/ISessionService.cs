namespace ECommerce.App.Infrastructure.Abstractions
{
    public interface ISessionService
    {
        void SetSessionValue(string key, string value);
        string GetSessionValue(string key);
        void RemoveSessionValue(string key);
    }
}