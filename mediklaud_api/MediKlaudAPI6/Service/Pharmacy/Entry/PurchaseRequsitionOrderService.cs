using mediklaud_api.FormQuery.Pharmacy;
using mediklaud_api.Infrastructure;
using mediklaud_api.Interface.Pharmacy.Entry;
using mediklaud_api.Models;
using mediklaud_api.Models.Pharmacy.Entry;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace mediklaud_api.Service.Pharmacy.Entry
{
    public class PurchaseRequsitionOrderService : IPurchaseRequsitionOrderService
    {
        private readonly IMediklaudDBConnection _dbConnection;

        public PurchaseRequsitionOrderService(IMediklaudDBConnection DBConnection)
        {
            _dbConnection = DBConnection;
        }

        public async Task<string> GetConfigaration(CommonGID_CID_For_PurReqOrd dataQuery)
        {
            try
            {
                OracleConnection oraConn = new OracleConnection(await _dbConnection.getDBConn());

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = oraConn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                cmd.CommandText = "sp_phr_transaction_config";
                cmd.Parameters.Add("p_gid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_cid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_config", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmd.Parameters["p_gid"].Value = dataQuery.GID;
                cmd.Parameters["p_cid"].Value = dataQuery.CID;

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                DataTable dt = ds.Tables[0];
                return GetTableTypeJSON(dt);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> GetSerStoreList(PurReqOrderStoreList dataQuery)
        {
            try
            {
                OracleConnection oraConn = new OracleConnection(await _dbConnection.getDBConn());

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = oraConn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                cmd.CommandText = "pkg_pharmacy.sp_phr_user_main_store_list";
                cmd.Parameters.Add("p_gid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_cid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_user_no", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_store_list", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmd.Parameters["p_gid"].Value = dataQuery.GID;
                cmd.Parameters["p_cid"].Value = dataQuery.CID;
                cmd.Parameters["p_user_no"].Value = dataQuery.UserNo;

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                DataTable dt = ds.Tables[0];
                return GetTableTypeJSON(dt);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<string> GetStoreList(PurReqOrderStoreList dataQuery)
        {
            try
            {
                OracleConnection oraConn = new OracleConnection(await _dbConnection.getDBConn());

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = oraConn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                cmd.CommandText = "pkg_pharmacy.sp_phr_user_main_store_list";
                cmd.Parameters.Add("p_gid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_cid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_user_no", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_store_list", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmd.Parameters["p_gid"].Value = dataQuery.GID;
                cmd.Parameters["p_cid"].Value = dataQuery.CID;
                cmd.Parameters["p_user_no"].Value = dataQuery.UserNo;

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                DataTable dt = ds.Tables[0];
                return GetTableTypeJSON(dt);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<string> GetForStoreList(PurReqOrderStoreList dataQuery)
        {
            try
            {
                OracleConnection oraConn = new OracleConnection(await _dbConnection.getDBConn());

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = oraConn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                cmd.CommandText = "pkg_pharmacy.sp_phr_user_main_store_list";
                cmd.Parameters.Add("p_gid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_cid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_user_no", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_store_list", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmd.Parameters["p_gid"].Value = dataQuery.GID;
                cmd.Parameters["p_cid"].Value = dataQuery.CID;
                cmd.Parameters["p_user_no"].Value = dataQuery.UserNo;

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                DataTable dt = ds.Tables[0];
                return GetTableTypeJSON(dt);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        private string GetTableTypeJSON(DataTable dt)
        {
            string JSONResult = JsonConvert.SerializeObject(dt);
            return JSONResult;
        }
        public async Task<string> GetSerSupplierList(CommonGID_CID_For_PurReqOrd dataQuery)
        {
            try
            {
                OracleConnection oraConn = new OracleConnection(await _dbConnection.getDBConn());

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = oraConn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                cmd.CommandText = "pkg_pharmacy.sp_phr_supplier_list";
                cmd.Parameters.Add("p_gid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_cid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_supplier_list", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmd.Parameters["p_gid"].Value = dataQuery.GID;
                cmd.Parameters["p_cid"].Value = dataQuery.CID;

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                DataTable dt = ds.Tables[0];
                return GetTableTypeJSON(dt);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<string> GetSupplierList(CommonGID_CID_For_PurReqOrd dataQuery)
        {
            try
            {
                OracleConnection oraConn = new OracleConnection(await _dbConnection.getDBConn());

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = oraConn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                cmd.CommandText = "pkg_pharmacy.sp_phr_supplier_list";
                cmd.Parameters.Add("p_gid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_cid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_supplier_list", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmd.Parameters["p_gid"].Value = dataQuery.GID;
                cmd.Parameters["p_cid"].Value = dataQuery.CID;

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                DataTable dt = ds.Tables[0];
                return GetTableTypeJSON(dt);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<string> GetTransactionList(TransactionListForPhrReqOrd dataQuery)
        {
            try
            {
                OracleConnection oraConn = new OracleConnection(await _dbConnection.getDBConn());

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = oraConn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                cmd.CommandText = "pkg_pharmacy.sp_phr_pur_order_datalist";
                cmd.Parameters.Add("p_gid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_cid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_approve_flag", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_store_no", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_supplier_no", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_phr_pur_ord_id", OracleDbType.Varchar2, 30);
                cmd.Parameters.Add("p_start_date", OracleDbType.Date, 30);
                cmd.Parameters.Add("p_end_date", OracleDbType.Date, 30);

                cmd.Parameters.Add("p_phr_pur_ord_list", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmd.Parameters["p_gid"].Value = dataQuery.GID;
                cmd.Parameters["p_cid"].Value = dataQuery.CID;
                cmd.Parameters["p_approve_flag"].Value = dataQuery.ApproveFlag.Trim();
                cmd.Parameters["p_store_no"].Value = dataQuery.StoreNo.Trim();
                cmd.Parameters["p_supplier_no"].Value = dataQuery.SupplierNo.Trim();

                if (dataQuery.PhrPurOrdId != null)
                {
                    cmd.Parameters["p_phr_pur_ord_id"].Value = dataQuery.PhrPurOrdId.Trim();
                }
                else
                {
                    cmd.Parameters["p_phr_pur_ord_id"].Value = dataQuery.PhrPurOrdId;
                }
                
                cmd.Parameters["p_start_date"].Value = DateTime.Parse(dataQuery.StartDate);
                cmd.Parameters["p_end_date"].Value = DateTime.Parse(dataQuery.EndDate);

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                DataTable dt = ds.Tables[0];
                return GetTableTypeJSON(dt);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> GetItemList(PurReqOrderItemList dataQuery)
        {
            try
            {
                OracleConnection oraConn = new OracleConnection(await _dbConnection.getDBConn());

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = oraConn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                cmd.CommandText = "pkg_pharmacy.sp_phr_pur_order_item_list";
                cmd.Parameters.Add("p_gid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_cid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_supplier_no", OracleDbType.Varchar2, 300);
                cmd.Parameters.Add("p_supp_quot_flag", OracleDbType.Varchar2, 30);
                cmd.Parameters.Add("p_item_list", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmd.Parameters["p_gid"].Value = dataQuery.GID;
                cmd.Parameters["p_cid"].Value = dataQuery.CID;
                cmd.Parameters["p_supplier_no"].Value = dataQuery.SupplierNo;
                cmd.Parameters["p_supp_quot_flag"].Value = dataQuery.SuppQuotFlag;

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                DataTable dt = ds.Tables[0];
                return GetTableTypeJSON(dt);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<string> GetRequisitionList(PurReqOrderRequsitionNo dataQuery)
        {
            try
            {
                OracleConnection oraConn = new OracleConnection(await _dbConnection.getDBConn());

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = oraConn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                cmd.CommandText = "pkg_pharmacy.sp_phr_pur_req_pending_list";
                cmd.Parameters.Add("p_gid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_cid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_start_date", OracleDbType.Varchar2, 30);
                cmd.Parameters.Add("p_end_date", OracleDbType.Varchar2, 30);
                cmd.Parameters.Add("p_store_no", OracleDbType.Varchar2, 30);
                cmd.Parameters.Add("p_supplier_no", OracleDbType.Varchar2, 30);
                cmd.Parameters.Add("p_phr_pur_req_list", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmd.Parameters["p_gid"].Value = dataQuery.GID;
                cmd.Parameters["p_cid"].Value = dataQuery.CID;
                cmd.Parameters["p_start_date"].Value = "";
                cmd.Parameters["p_end_date"].Value = "";
                cmd.Parameters["p_store_no"].Value = dataQuery.StoreNo.Trim();
                cmd.Parameters["p_supplier_no"].Value = dataQuery.SupplierNo.Trim();

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                DataTable dt = ds.Tables[0];
                return GetTableTypeJSON(dt);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


    }
}
