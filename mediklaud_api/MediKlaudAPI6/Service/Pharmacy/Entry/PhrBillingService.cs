
using mediklaud_api.FormQuery.Pharmacy;
using mediklaud_api.Infrastructure;
using mediklaud_api.Interface.Pharmacy;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Reflection;

namespace mediklaud_api.Service.Pharmacy.Entry
{
    public class PhrBillingService : IPhrBillingService
    {
        private readonly IMediklaudDBConnection _connection;

        public PhrBillingService(IMediklaudDBConnection connection)
        {
            _connection = connection;
        }


        public async Task<string> GetPatientTypeList(CommonGID_CID commonGID_CID)
        {
            try
            {
                OracleConnection oracleConnection = new OracleConnection(await _connection.getDBConn());



                OracleCommand cmd = new OracleCommand();
                cmd.Connection = oracleConnection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                cmd.CommandText = "pkg_pharmacy.sp_phr_patient_type_list";
                cmd.Parameters.Add("p_gid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_cid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_patient_type_list", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmd.Parameters["p_gid"].Value = commonGID_CID.GID;
                cmd.Parameters["p_cid"].Value = commonGID_CID.CID;


                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);



                DataTable dt;
                dt = ds.Tables[0];
                return GetTableTypeJSON(dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> GetMaxDiscount(GetMaxDiscount getMaxDiscount)
        {
            try
            {
                OracleConnection oracleConnection = new OracleConnection(await _connection.getDBConn());


                string dsc_qry = @"select nvl(h.phr_max_disc_pct,0)max_disc_pct from patienttype h where pat_type_no =" + getMaxDiscount.PatientTypeNo + " ";

                OracleCommand cmd = new OracleCommand(dsc_qry, oracleConnection);

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                DataTable dt = ds.Tables[0];

                return GetTableTypeJSON(dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> GetCustomerInfo(GetCustomerInfo getCustomerInfo)
        {
            try
            {
                OracleConnection oracleConnection = new OracleConnection(await _connection.getDBConn());



                OracleCommand cmd = new OracleCommand();
                cmd.Connection = oracleConnection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                cmd.CommandText = "pkg_pharmacy.sp_phr_patient_type_list";
                cmd.Parameters.Add("p_gid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_cid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_ser_hospital_number", OracleDbType.Varchar2, 30);
                cmd.Parameters.Add("p_ser_phone_mobile", OracleDbType.Varchar2, 30);
                cmd.Parameters.Add("p_ser_emp_id", OracleDbType.Varchar2, 30);

                cmd.Parameters["p_gid"].Value = getCustomerInfo.GID.ToString();
                cmd.Parameters["p_cid"].Value = getCustomerInfo.CID.ToString();
                cmd.Parameters["p_ser_hospital_number"].Value = getCustomerInfo.CustomerId.ToString();
                cmd.Parameters["p_ser_phone_mobile"].Value = getCustomerInfo.MobileNo.ToString();
                cmd.Parameters["p_ser_emp_id"].Value = getCustomerInfo.EmployeeId.ToString();

                cmd.Parameters.Add("p_pat_type_no", OracleDbType.Varchar2, 30).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_pat_type_name", OracleDbType.Varchar2, 300).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_reg_no", OracleDbType.Varchar2, 300).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_hospital_number", OracleDbType.Varchar2, 300).Direction = ParameterDirection.Output;


                cmd.Parameters.Add("p_patient_name", OracleDbType.Varchar2, 300).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_gender", OracleDbType.Varchar2, 300).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_gender_data", OracleDbType.Varchar2, 300).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_phone_mobile", OracleDbType.Varchar2, 300).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_address", OracleDbType.Varchar2, 300).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_age", OracleDbType.Varchar2, 300).Direction = ParameterDirection.Output;

                cmd.Parameters.Add("p_emp_id", OracleDbType.Varchar2, 300).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_organisation_no", OracleDbType.Varchar2, 300).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_organisation_name", OracleDbType.Varchar2, 300).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_designation_no", OracleDbType.Varchar2, 300).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_designation_name", OracleDbType.Varchar2, 300).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_department_no", OracleDbType.Varchar2, 300).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_department_name", OracleDbType.Varchar2, 300).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_national_id", OracleDbType.Varchar2, 300).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_passport_no", OracleDbType.Varchar2, 300).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_credit_limit", OracleDbType.Varchar2, 300).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_credit_balance", OracleDbType.Varchar2, 300).Direction = ParameterDirection.Output;

                cmd.Parameters.Add("p_action", OracleDbType.Varchar2, 3000).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_error", OracleDbType.Varchar2, 3000).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                string p_action = cmd.Parameters["p_action"].Value.ToString();
                string p_error = cmd.Parameters["p_error"].Value.ToString();

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);



                DataTable dt;
                dt = ds.Tables[0];
                return GetTableTypeJSON(dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> OrganizationList(CommonGID_CID commonGID_CID)
        {
            try
            {
                OracleConnection oracleConnection = new OracleConnection(await _connection.getDBConn());



                OracleCommand cmd = new OracleCommand();
                cmd.Connection = oracleConnection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                cmd.CommandText = "sp_organisation_list";
                cmd.Parameters.Add("p_gid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_cid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_organisation_list", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmd.Parameters["p_gid"].Value = commonGID_CID.GID;
                cmd.Parameters["p_cid"].Value = commonGID_CID.CID;


                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);



                DataTable dt;
                dt = ds.Tables[0];
                return GetTableTypeJSON(dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> DepartmentList(CommonGID_CID commonGID_CID)
        {
            try
            {
                OracleConnection oracleConnection = new OracleConnection(await _connection.getDBConn());



                OracleCommand cmd = new OracleCommand();
                cmd.Connection = oracleConnection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                cmd.CommandText = "sp_hr_Department_list";
                cmd.Parameters.Add("p_gid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_cid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_bu_list", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmd.Parameters["p_gid"].Value = commonGID_CID.GID;
                cmd.Parameters["p_cid"].Value = commonGID_CID.CID;


                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);



                DataTable dt;
                dt = ds.Tables[0];
                return GetTableTypeJSON(dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> DesignationList(CommonGID_CID commonGID_CID)
        {
            try
            {
                OracleConnection oracleConnection = new OracleConnection(await _connection.getDBConn());



                OracleCommand cmd = new OracleCommand();
                cmd.Connection = oracleConnection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                cmd.CommandText = "sp_designation_list";
                cmd.Parameters.Add("p_gid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_cid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_jobtitle_list", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmd.Parameters["p_gid"].Value = commonGID_CID.GID;
                cmd.Parameters["p_cid"].Value = commonGID_CID.CID;


                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);



                DataTable dt;
                dt = ds.Tables[0];
                return GetTableTypeJSON(dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> CustomerInfoSave(CustomerInfoSave customerInfoSave)
        {
            try
            {
                using (OracleConnection oracleConnection = new OracleConnection(await _connection.getDBConn()))
                {
                    oracleConnection.Open();

                    OracleCommand ora_cmd = new OracleCommand();
                    ora_cmd.Connection = oracleConnection;
                    ora_cmd.CommandType = CommandType.StoredProcedure;
                    ora_cmd.BindByName = true;

                    ora_cmd.CommandText = "pkg_pharmacy.sp_registration_save";

                    ora_cmd.Parameters.Add("p_action_type", OracleDbType.Int32, 1, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_pat_type_no", OracleDbType.Int32, customerInfoSave.PatientTypeNo, ParameterDirection.Input);

                    ora_cmd.Parameters.Add("p_fname", OracleDbType.Varchar2, customerInfoSave.CustomerName, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_gender", OracleDbType.Varchar2, customerInfoSave.GenderValue, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_phone_mobile", OracleDbType.Varchar2, customerInfoSave.PhoneMobile, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_address", OracleDbType.Varchar2, customerInfoSave.Address, ParameterDirection.Input);

                    ora_cmd.Parameters.Add("p_emp_id", OracleDbType.Varchar2, customerInfoSave.EmployeeId, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_organisation_no", OracleDbType.Varchar2, customerInfoSave.OrganizationNo, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_designation_no", OracleDbType.Varchar2, customerInfoSave.DesignationNo, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_department_no", OracleDbType.Varchar2, customerInfoSave.DepartmentNo, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_national_id", OracleDbType.Varchar2, customerInfoSave.NationalId, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_passport_no", OracleDbType.Varchar2, customerInfoSave.PassportNo, ParameterDirection.Input);

                    ora_cmd.Parameters.Add("p_age_yy", OracleDbType.Int32, customerInfoSave.AgeYYY, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_age_mm", OracleDbType.Int32, customerInfoSave.AgeMM, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_age_dd", OracleDbType.Int32, customerInfoSave.AgeDD, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_bday", OracleDbType.Date, null, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_mday", OracleDbType.Date, null, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_credit_limit", OracleDbType.Int32, customerInfoSave.CreditLimit, ParameterDirection.Input);


                    ora_cmd.Parameters.Add("p_entryby", OracleDbType.Int32, customerInfoSave.EntryBy, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_cid", OracleDbType.Int32, customerInfoSave.CID, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_gid", OracleDbType.Int32, customerInfoSave.GID, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_entryip ", OracleDbType.Varchar2, customerInfoSave.EntryIp, ParameterDirection.Input);

                    ora_cmd.Parameters.Add("p_reg_no", OracleDbType.Varchar2, 300, "", ParameterDirection.InputOutput);
                    ora_cmd.Parameters.Add("p_hospital_number", OracleDbType.Varchar2, 500, "", ParameterDirection.InputOutput);


                    ora_cmd.Parameters.Add("p_error", OracleDbType.Varchar2, 3000).Direction = ParameterDirection.Output;
                    ora_cmd.Parameters.Add("p_action", OracleDbType.Int32, 100).Direction = ParameterDirection.Output;

                    ora_cmd.ExecuteNonQuery();
                    oracleConnection.Close();


                    string p_reg_no = ora_cmd.Parameters["p_reg_no"].Value.ToString();
                    string p_hospital_number = ora_cmd.Parameters["p_hospital_number"].Value.ToString();

                    string p_error = ora_cmd.Parameters["p_error"].Value.ToString();
                    string p_action = ora_cmd.Parameters["p_action"].Value.ToString();

                    ora_cmd.Parameters.Clear();
                    string[] dataArray = new string[] { p_reg_no, p_hospital_number, p_error, p_action };
                    return GetStringArrayJSON(dataArray);
                }
                

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GetStringArrayJSON(string[] dataArray)
        {
            if (dataArray.Length < 3)
            {
                throw new ArgumentException("dataArray must have at least 3 elements.");
            }

            string json = $"[{JsonConvert.ToString(dataArray[0])}, {JsonConvert.ToString(dataArray[1])}, {JsonConvert.ToString(dataArray[2])}, {JsonConvert.ToString(dataArray[3])}]";
            return json;
        }

        private string GetTableTypeJSON(DataTable dt)
        {
            string JSONresult;
            JSONresult = JsonConvert.SerializeObject(dt);
            return JSONresult;
        }


    }
}
