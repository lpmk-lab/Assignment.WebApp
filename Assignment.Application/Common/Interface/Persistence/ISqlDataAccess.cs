namespace Assignment.Application.Common.Interface.Persistence
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> GetData<T, P>(string spName, P parameters, string connectionId = "Connection");
        Task SaveData<T>(string spName, T parameters, string connectionId = "Connection");
    }
}