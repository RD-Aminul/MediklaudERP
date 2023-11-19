namespace mediklaud_api.Infrastructure
{
    public interface IMediklaudDBConnection
    {
        Task<string> getDBConn();
    }
}
