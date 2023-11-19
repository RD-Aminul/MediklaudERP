using mediklaud_api.FormQuery.SignIn;
using mediklaud_api.Infrastructure;
using mediklaud_api.Interface.SignIn;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace mediklaud_api.Service.SignIn
{
    public class SignInService : ISignInService
    {
        private readonly IMediklaudDBConnection _dbConnection;
        public SignInService(IMediklaudDBConnection dbConn)
        {
            _dbConnection = dbConn;
        }

        public async Task<String> getUser(GetUserDataQuery dataQuery)
        {
            try
            {
                OracleConnection oracleConnection = new OracleConnection(await _dbConnection.getDBConn());

                oracleConnection.Open();

                OracleCommand cmd = new OracleCommand("sp_checkUserAccess", oracleConnection);
                cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;

                string loginid = dataQuery.LoginId.Trim();

                cmd.Parameters.Add("p_loginid", OracleDbType.Varchar2, dataQuery.LoginId.Trim(), ParameterDirection.Input);
                cmd.Parameters.Add("p_password", OracleDbType.Varchar2, dataQuery.Password.Trim(), ParameterDirection.Input);

                cmd.Parameters.Add("p_username", OracleDbType.Varchar2, 300).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_usertype", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_companyname", OracleDbType.Varchar2, 300).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_url", OracleDbType.Varchar2, 1000).Direction = ParameterDirection.Output;

                cmd.Parameters.Add("p_pin", OracleDbType.Int32).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_cid", OracleDbType.Int32).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_gid", OracleDbType.Int32).Direction = ParameterDirection.Output;

                cmd.Parameters.Add("p_access", OracleDbType.Int32).Direction = ParameterDirection.Output;


                cmd.ExecuteNonQuery();

                string? p_username = cmd.Parameters["p_username"].Value.ToString();
                string? p_usertype = cmd.Parameters["p_usertype"].Value.ToString();
                string? p_companyname = cmd.Parameters["p_companyname"].Value.ToString();
                string? p_url = cmd.Parameters["p_url"].Value.ToString();

                string? p_pin = cmd.Parameters["p_pin"].Value.ToString();
                string? p_cid = cmd.Parameters["p_cid"].Value.ToString();
                string? p_gid = cmd.Parameters["p_gid"].Value.ToString();
                string? paccess = cmd.Parameters["p_access"].Value.ToString();

                string[] acessValue = { p_username, p_usertype, p_companyname, p_url, p_pin, p_cid, p_gid, paccess };



                return GetUserJson(acessValue);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static String GetUserJson(Array acessValue)
        {
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(acessValue);
            return JSONresult;
        }
    }
}
