namespace mediklaud_api.Infrastructure
{
    public class MediklaudDBConnection : IMediklaudDBConnection
    {

        private readonly string _connectionString;
        public MediklaudDBConnection(IConfiguration _configuration)
        {
            _connectionString = _configuration.GetConnectionString("MediklaudDBConn");
        }
        public async Task<string> getDBConn()
        {
            return _connectionString;
        }
    }
}
