using mediklaud_api.FormQuery.Pharmacy;
using mediklaud_api.Infrastructure;
using mediklaud_api.Interface.Pharmacy;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Globalization;
using System.Transactions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace mediklaud_api.Service.Pharmacy
{
    public class PhrPurchaseReceiveService : IPhrPurchaseReceiveService
    {
        private readonly IMediklaudDBConnection _dbConnection;

        public PhrPurchaseReceiveService(IMediklaudDBConnection dbConn)
        {
            _dbConnection = dbConn;
        }

        public async Task<string> GetConfigaration(GetAllListQuery dataQuery)
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
                return GetJsonData(dt);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private static string GetJsonData(DataTable dt)
        {
            string JSONResult = JsonConvert.SerializeObject(dt);
            return JSONResult;
        }

        public async Task<string> GetStroeList(GetcmbStoreListQuery dataQuery)
        {
            try
            {
                OracleConnection oraConn = new OracleConnection(await _dbConnection.getDBConn());

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = oraConn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                cmd.CommandText = "pkg_pharmacy.sp_phr_user_wise_store_list";
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
                return GetJsonData(dt);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> GetSupplierList(GetAllListQuery dataQuery)
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
                return GetJsonData(dt);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> GetTransationGridDataList(GetTransationGridDataListQuery dataQuery)
        {
            try
            {
                DateTime start_date = dataQuery.start_date;
                string formattedS_Date = start_date.ToString("MM/dd/yy", CultureInfo.InvariantCulture);


                DateTime end_date = dataQuery.end_date;
                string formattedE_Date = end_date.ToString("MM/dd/yy", CultureInfo.InvariantCulture);


                OracleConnection oraConn = new OracleConnection(await _dbConnection.getDBConn());

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = oraConn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                cmd.CommandText = "pkg_pharmacy.sp_phr_transaction_datalist";
                cmd.Parameters.Add("p_gid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_cid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_trntype_no", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_approve_flag", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_store_no", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_supplier_no", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_phr_trn_id", OracleDbType.Varchar2, 30);
                cmd.Parameters.Add("p_start_date", OracleDbType.Date, 30);
                cmd.Parameters.Add("p_end_date", OracleDbType.Date, 30);
                cmd.Parameters.Add("p_phr_trn_list", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                cmd.Parameters["p_gid"].Value = dataQuery.GID;
                cmd.Parameters["p_cid"].Value = dataQuery.CID;
                cmd.Parameters["p_trntype_no"].Value = 14;
                cmd.Parameters["p_approve_flag"].Value = dataQuery.approve_flag;
                cmd.Parameters["p_store_no"].Value = dataQuery.store_no;
                cmd.Parameters["p_supplier_no"].Value = dataQuery.supplier_no;
                cmd.Parameters["p_phr_trn_id"].Value = dataQuery.phr_trn_id;
                cmd.Parameters["p_start_date"].Value = DateTime.Parse(formattedS_Date);
                cmd.Parameters["p_end_date"].Value = DateTime.Parse(formattedE_Date);

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                DataTable dt = ds.Tables[0];
                return GetJsonData(dt);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> GetMasterDataAndItemGridDataList(GetMasterDataAndItemGridDataListQuery dataQuery)
        {
            try
            {
                OracleConnection oraConn = new OracleConnection(await _dbConnection.getDBConn());

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = oraConn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                cmd.CommandText = "pkg_pharmacy.sp_phr_transaction_data";
                cmd.Parameters.Add("p_gid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_cid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_trntype_no", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_phr_trn_no", OracleDbType.Int64, 30);
                cmd.Parameters.Add("p_phr_trn", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_phr_trndtl", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmd.Parameters["p_gid"].Value = dataQuery.GID;
                cmd.Parameters["p_cid"].Value = dataQuery.CID;
                cmd.Parameters["p_trntype_no"].Value = 14;
                cmd.Parameters["p_phr_trn_no"].Value = dataQuery.phr_trn_no;

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                DataTable dt = ds.Tables[0];
                DataTable dt_detail = ds.Tables[1];
                string jsonData = GetJsonMasterData(dt, dt_detail);

                return jsonData;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private static string GetJsonMasterData(DataTable dt, DataTable dt_detail)
        {
            List<DataTable> dataTableList = new List<DataTable>
            {
                dt, dt_detail
            };

            string jsonData = JsonConvert.SerializeObject(dataTableList);
            return jsonData;
        }

        public async Task<string> GetcmbItemList(GetcmbItemListQuery dataQuery)
        {
            try
            {
                OracleConnection oraConn = new OracleConnection(await _dbConnection.getDBConn());

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = oraConn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                cmd.CommandText = "pkg_pharmacy.sp_phr_transaction_item_list";
                cmd.Parameters.Add("p_gid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_cid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_supp_quot_apply_flag", OracleDbType.Varchar2, 30);
                cmd.Parameters.Add("p_trntype_no", OracleDbType.Varchar2, 30);
                cmd.Parameters.Add("p_store_no", OracleDbType.Varchar2, 30);
                cmd.Parameters.Add("p_supplier_no", OracleDbType.Varchar2, 30);
                cmd.Parameters.Add("p_item_list", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmd.Parameters["p_gid"].Value = dataQuery.GID;
                cmd.Parameters["p_cid"].Value = dataQuery.CID;
                cmd.Parameters["p_supp_quot_apply_flag"].Value = dataQuery.supp_quot_apply_flag;
                cmd.Parameters["p_trntype_no"].Value = 14;
                cmd.Parameters["p_store_no"].Value = dataQuery.store_no;
                cmd.Parameters["p_supplier_no"].Value = dataQuery.supplier_no;

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                DataTable dt = ds.Tables[0];
                return GetJsonData(dt);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> GetcmbItemSelectData(GetcmbItemListQuery dataQuery)
        {
            try
            {
                OracleConnection oraConn = new OracleConnection(await _dbConnection.getDBConn());

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = oraConn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                cmd.CommandText = "pkg_pharmacy.sp_phr_transaction_item_data";
                cmd.Parameters.Add("p_gid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_cid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_supp_quot_apply_flag", OracleDbType.Varchar2, 30);
                cmd.Parameters.Add("p_trntype_no", OracleDbType.Varchar2, 30);
                cmd.Parameters.Add("p_store_no", OracleDbType.Varchar2, 30);
                cmd.Parameters.Add("p_item_no", OracleDbType.Varchar2, 30);
                cmd.Parameters.Add("p_supplier_no", OracleDbType.Varchar2, 30);
                cmd.Parameters.Add("p_item_data", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmd.Parameters["p_gid"].Value = dataQuery.GID;
                cmd.Parameters["p_cid"].Value = dataQuery.CID;
                cmd.Parameters["p_supp_quot_apply_flag"].Value = dataQuery.supp_quot_apply_flag;
                cmd.Parameters["p_trntype_no"].Value = 14;
                cmd.Parameters["p_store_no"].Value = dataQuery.store_no;
                cmd.Parameters["p_item_no"].Value = dataQuery.item_no;
                cmd.Parameters["p_supplier_no"].Value = dataQuery.supplier_no;


                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                DataTable dt = ds.Tables[0];
                return GetJsonData(dt);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> TransactionSave(Transactions transactions)
        {
            try
            {
                using (OracleConnection oraConn = new OracleConnection(await _dbConnection.getDBConn()))
                {
                    string? btntext = transactions.Action_type;
                    int action_type = 0;

                    string transactionNo = "", transactionId = "";

                    if (btntext == "SUBMIT")
                    {
                        transactionNo = null;
                        transactionId = null;
                        action_type = 1;
                    }
                    else if (btntext == "UPDATE")
                    {
                        transactionNo = transactions.phr_trn_no;
                        transactionId = transactions.phr_trn_id;
                        action_type = 2;
                    }


                    oraConn.Open();

                    OracleCommand ora_cmd = new OracleCommand("pkg_pharmacy.sp_phr_transaction_save", oraConn);
                    ora_cmd.BindByName = true;
                    ora_cmd.CommandType = CommandType.StoredProcedure;

                    int size = transactions.TranArr.Count;

                    string[] arr_v_item_no = new string[size];
                    int?[] arr_v_item_qty = new int?[size];
                    int?[] arr_v_bonus_qty = new int?[size];
                    decimal[] arr_v_purchase_price = new decimal[size];
                    decimal[] arr_v_sale_price = new decimal[size];
                    string[] arr_v_supplier_no = new string[size];
                    string[] arr_v_batch_number = new string[size];
                    string[] arr_v_exp_date = new string[size];
                    decimal[] arr_v_discount_amt = new decimal[size];
                    decimal[] arr_v_vat_amt = new decimal[size];
                    decimal[] arr_v_tax_amt = new decimal[size];

                    string[] arr_v_phr_reqdtl_no = new string[size];
                    int[] arr_v_phr_req_qty = new int[size];
                    string[] arr_v_phr_pur_orddtl_no = new string[size];
                    int[] arr_v_phr_pur_ord_qty = new int[size];
                    string[] arr_v_ref_trndtl_no = new string[size];
                    int[] arr_v_ref_trndtl_qty = new int[size];
                    int[] arr_v_stock_qty = new int[size];

                    int i = 0;

                    List<TranArr> TranArrs = transactions.TranArr;

                    foreach (var row in TranArrs)
                    {
                        arr_v_item_no[i] = row.item_no; 
                        arr_v_item_qty[i] = row.item_qty; 
                        arr_v_bonus_qty[i] = row.bonus_qty;
                        arr_v_purchase_price[i] = row.purchase_price; 
                        arr_v_sale_price[i] = row.sale_price;
                        arr_v_supplier_no[i] = row.supplier_no;

                        var batch = row.batch_number;

                        if (batch == "&nbsp;" || batch == "" || batch == "null")
                        {
                            arr_v_batch_number[i] = null;
                        }
                        else
                        {
                            arr_v_batch_number[i] = batch;
                        }

                        var exdate = row.exp_date;
                        DateTime date = Convert.ToDateTime(exdate);

                        if (exdate == "&nbsp;" || exdate == null || exdate == "null")
                        {
                            arr_v_exp_date[i] = null;
                        }
                        else
                        {
                            arr_v_exp_date[i] = date.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                        }

                        arr_v_discount_amt[i] = row.discount_amt; 
                        arr_v_vat_amt[i] = row.vat_amt;
                        arr_v_tax_amt[i] = 0;

                        arr_v_phr_reqdtl_no[i] = "0";
                        arr_v_phr_req_qty[i] = 0;
                        arr_v_phr_pur_orddtl_no[i] = "0";
                        arr_v_phr_pur_ord_qty[i] = 0;
                        arr_v_ref_trndtl_no[i] = "0";
                        arr_v_ref_trndtl_qty[i] = 0;
                        arr_v_stock_qty[i] = 0;

                        i++;
                    }

                    ora_cmd.Parameters.Add("p_action_type", OracleDbType.Int32, action_type, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_trntype_no", OracleDbType.Varchar2, "14", ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_curr_store_no", OracleDbType.Varchar2, transactions.curr_store_no, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_trn_store_no", OracleDbType.Varchar2, "", ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_phr_pur_ord_no", OracleDbType.Varchar2, "", ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_phr_pur_ord_id", OracleDbType.Varchar2, "", ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_pur_supplier_no", OracleDbType.Varchar2, transactions.pur_supplier_no, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_supp_invoice_no", OracleDbType.Varchar2, transactions.supp_invoice_no, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_supp_invoice_date", OracleDbType.Date, transactions.supp_invoice_date, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_supp_exp_pay_date", OracleDbType.Date, null, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_supp_pay_type_no", OracleDbType.Varchar2, transactions.supp_pay_type_no, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_phr_req_no", OracleDbType.Varchar2, "", ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_phr_req_id", OracleDbType.Varchar2, "", ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_ref_trn_no", OracleDbType.Varchar2, "", ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_ref_trn_id", OracleDbType.Varchar2, "", ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_descr", OracleDbType.Varchar2, transactions.descr, ParameterDirection.Input);


                    OracleParameter arr_p_item_no = new OracleParameter("p_item_no", OracleDbType.Varchar2, arr_v_item_no.Length, arr_v_item_no, ParameterDirection.Input);
                    arr_p_item_no.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    ora_cmd.Parameters.Add(arr_p_item_no);

                    OracleParameter arr_p_item_qty = new OracleParameter("p_item_qty", OracleDbType.Decimal, arr_v_item_qty.Length, arr_v_item_qty, ParameterDirection.Input);
                    arr_p_item_qty.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    ora_cmd.Parameters.Add(arr_p_item_qty);

                    OracleParameter arr_p_bonus_qty = new OracleParameter("p_bonus_qty", OracleDbType.Decimal, arr_v_bonus_qty.Length, arr_v_bonus_qty, ParameterDirection.Input);
                    arr_p_bonus_qty.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    ora_cmd.Parameters.Add(arr_p_bonus_qty);

                    OracleParameter arr_p_purchase_price = new OracleParameter("p_purchase_price", OracleDbType.Decimal, arr_v_purchase_price.Length, arr_v_purchase_price, ParameterDirection.Input);
                    arr_p_purchase_price.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    ora_cmd.Parameters.Add(arr_p_purchase_price);

                    OracleParameter arr_p_sale_price = new OracleParameter("p_sale_price", OracleDbType.Decimal, arr_v_sale_price.Length, arr_v_sale_price, ParameterDirection.Input);
                    arr_p_sale_price.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    ora_cmd.Parameters.Add(arr_p_sale_price);

                    OracleParameter arr_p_supplier_no = new OracleParameter("p_supplier_no", OracleDbType.Varchar2, arr_v_supplier_no.Length, arr_v_supplier_no, ParameterDirection.Input);
                    arr_p_supplier_no.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    ora_cmd.Parameters.Add(arr_p_supplier_no);

                    OracleParameter arr_p_batch_number = new OracleParameter("p_batch_number", OracleDbType.Varchar2, arr_v_batch_number.Length, arr_v_batch_number, ParameterDirection.Input);
                    arr_p_batch_number.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    ora_cmd.Parameters.Add(arr_p_batch_number);

                    OracleParameter arr_p_exp_date = new OracleParameter("p_exp_date", OracleDbType.Varchar2, arr_v_exp_date.Length, arr_v_exp_date, ParameterDirection.Input);
                    arr_p_exp_date.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    ora_cmd.Parameters.Add(arr_p_exp_date);

                    OracleParameter arr_p_discount_amt = new OracleParameter("p_discount_amt", OracleDbType.Decimal, arr_v_discount_amt.Length, arr_v_discount_amt, ParameterDirection.Input);
                    arr_p_discount_amt.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    ora_cmd.Parameters.Add(arr_p_discount_amt);

                    OracleParameter arr_p_vat_amt = new OracleParameter("p_vat_amt", OracleDbType.Decimal, arr_v_vat_amt.Length, arr_v_vat_amt, ParameterDirection.Input);
                    arr_p_vat_amt.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    ora_cmd.Parameters.Add(arr_p_vat_amt);

                    OracleParameter arr_p_tax_amt = new OracleParameter("p_tax_amt", OracleDbType.Decimal, arr_v_tax_amt.Length, arr_v_tax_amt, ParameterDirection.Input);
                    arr_p_tax_amt.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    ora_cmd.Parameters.Add(arr_p_tax_amt);

                    OracleParameter arr_p_phr_reqdtl_no = new OracleParameter("p_phr_reqdtl_no", OracleDbType.Varchar2, arr_v_phr_reqdtl_no.Length, arr_v_phr_reqdtl_no, ParameterDirection.Input);
                    arr_p_phr_reqdtl_no.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    ora_cmd.Parameters.Add(arr_p_phr_reqdtl_no);

                    OracleParameter arr_p_phr_req_qty = new OracleParameter("p_phr_req_qty", OracleDbType.Int32, arr_v_phr_req_qty.Length, arr_v_phr_req_qty, ParameterDirection.Input);
                    arr_p_phr_req_qty.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    ora_cmd.Parameters.Add(arr_p_phr_req_qty);

                    OracleParameter arr_p_phr_pur_orddtl_no = new OracleParameter("p_phr_pur_orddtl_no", OracleDbType.Varchar2, arr_v_phr_pur_orddtl_no.Length, arr_v_phr_pur_orddtl_no, ParameterDirection.Input);
                    arr_p_phr_pur_orddtl_no.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    ora_cmd.Parameters.Add(arr_p_phr_pur_orddtl_no);

                    OracleParameter arr_p_phr_pur_ord_qty = new OracleParameter("p_phr_pur_ord_qty", OracleDbType.Int32, arr_v_phr_pur_ord_qty.Length, arr_v_phr_pur_ord_qty, ParameterDirection.Input);
                    arr_p_phr_pur_ord_qty.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    ora_cmd.Parameters.Add(arr_p_phr_pur_ord_qty);

                    OracleParameter arr_p_ref_trndtl_no = new OracleParameter("p_ref_trndtl_no", OracleDbType.Varchar2, arr_v_ref_trndtl_no.Length, arr_v_ref_trndtl_no, ParameterDirection.Input);
                    arr_p_ref_trndtl_no.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    ora_cmd.Parameters.Add(arr_p_ref_trndtl_no);

                    OracleParameter arr_p_ref_trndtl_qty = new OracleParameter("p_ref_trndtl_qty", OracleDbType.Int32, arr_v_ref_trndtl_qty.Length, arr_v_ref_trndtl_qty, ParameterDirection.Input);
                    arr_p_ref_trndtl_qty.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    ora_cmd.Parameters.Add(arr_p_ref_trndtl_qty);

                    OracleParameter arr_p_stock_qty = new OracleParameter("p_stock_qty", OracleDbType.Int32, arr_v_stock_qty.Length, arr_v_stock_qty, ParameterDirection.Input);
                    arr_p_stock_qty.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    ora_cmd.Parameters.Add(arr_p_stock_qty);

                    ora_cmd.Parameters.Add("p_item_index", OracleDbType.Int32, size, ParameterDirection.Input);

                    ora_cmd.Parameters.Add("p_entryby", OracleDbType.Int32, transactions.entryby, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_cid", OracleDbType.Int32, transactions.CID, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_gid", OracleDbType.Int32, transactions.GID, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_entryip", OracleDbType.Varchar2, transactions.entryip, ParameterDirection.Input);

                    ora_cmd.Parameters.Add("p_phr_trn_no", OracleDbType.Varchar2, 300, transactionNo, ParameterDirection.InputOutput);
                    ora_cmd.Parameters.Add("p_phr_trn_id", OracleDbType.Varchar2, 500, transactionId, ParameterDirection.InputOutput);

                    ora_cmd.Parameters.Add("p_error", OracleDbType.Varchar2, 3000).Direction = ParameterDirection.Output;
                    ora_cmd.Parameters.Add("p_action", OracleDbType.Int32, 30).Direction = ParameterDirection.Output;

                    ora_cmd.ExecuteNonQuery();

                    string? p_phr_trn_no = ora_cmd.Parameters["p_phr_trn_no"].Value.ToString();
                    string? p_phr_trn_id = ora_cmd.Parameters["p_phr_trn_id"].Value.ToString();
                    string? p_error = ora_cmd.Parameters["p_error"].Value.ToString();
                    Int32 p_action = Convert.ToInt32(ora_cmd.Parameters["p_action"].Value.ToString());

                    ora_cmd.Parameters.Clear();

                    return GetTransationJson(p_phr_trn_no);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private static string GetTransationJson(string p_phr_trn_no)
        {
            string JSONResult = JsonConvert.SerializeObject(p_phr_trn_no);
            return JSONResult;
        }

        public async Task<string> TransactionApproved(ApproveUnapproveCancelQuery dataQuery)
        {
            try
            {
                using (OracleConnection oraConn = new OracleConnection(await _dbConnection.getDBConn()))
                {
                    oraConn.Open();

                    OracleCommand ora_cmd = new OracleCommand("pkg_pharmacy.sp_phr_transaction_lgr", oraConn);
                    ora_cmd.BindByName = true;
                    ora_cmd.CommandType = CommandType.StoredProcedure;


                    ora_cmd.Parameters.Add("p_action_type", OracleDbType.Int32, 1, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_curr_store_no", OracleDbType.Int32, dataQuery.curr_store_no, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_phr_trn_no", OracleDbType.Varchar2, 300, dataQuery.phr_trn_no, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_trntype_no", OracleDbType.Int32, 14, ParameterDirection.Input);

                    ora_cmd.Parameters.Add("p_entryby", OracleDbType.Int32, dataQuery.entryby, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_cid", OracleDbType.Int32, dataQuery.CID, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_gid", OracleDbType.Int32, dataQuery.GID, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_entryip ", OracleDbType.Varchar2, dataQuery.entryip, ParameterDirection.Input);

                    ora_cmd.Parameters.Add("p_error", OracleDbType.Varchar2, 3000).Direction = ParameterDirection.Output;
                    ora_cmd.Parameters.Add("p_action", OracleDbType.Int32, 30).Direction = ParameterDirection.Output;

                    ora_cmd.ExecuteNonQuery();
                    oraConn.Close();

                    string? p_error = ora_cmd.Parameters["p_error"].Value.ToString();
                    string? p_action = ora_cmd.Parameters["p_action"].Value.ToString();

                    ora_cmd.Parameters.Clear();

                    string[] acessValue = { p_error, p_action };
                    return GetApproveUnapproveCancelJson(acessValue);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private static string GetApproveUnapproveCancelJson(string[] acessValue)
        {
            string JSONResult = JsonConvert.SerializeObject(acessValue);
            return JSONResult;
        }

        public async Task<string> TransactionUnApproved(ApproveUnapproveCancelQuery dataQuery)
        {
            try
            {
                using (OracleConnection oraConn = new OracleConnection(await _dbConnection.getDBConn()))
                {
                    oraConn.Open();

                    OracleCommand ora_cmd = new OracleCommand("pkg_pharmacy.sp_phr_transaction_lgr", oraConn);
                    ora_cmd.BindByName = true;
                    ora_cmd.CommandType = CommandType.StoredProcedure;


                    ora_cmd.Parameters.Add("p_action_type", OracleDbType.Int32, 2, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_curr_store_no", OracleDbType.Int32, dataQuery.curr_store_no, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_phr_trn_no", OracleDbType.Varchar2, 300, dataQuery.phr_trn_no, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_trntype_no", OracleDbType.Int32, 14, ParameterDirection.Input);

                    ora_cmd.Parameters.Add("p_entryby", OracleDbType.Int32, dataQuery.entryby, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_cid", OracleDbType.Int32, dataQuery.CID, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_gid", OracleDbType.Int32, dataQuery.GID, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_entryip ", OracleDbType.Varchar2, dataQuery.entryip, ParameterDirection.Input);

                    ora_cmd.Parameters.Add("p_error", OracleDbType.Varchar2, 3000).Direction = ParameterDirection.Output;
                    ora_cmd.Parameters.Add("p_action", OracleDbType.Int32, 30).Direction = ParameterDirection.Output;

                    ora_cmd.ExecuteNonQuery();
                    oraConn.Close();

                    string? p_error = ora_cmd.Parameters["p_error"].Value.ToString();
                    string? p_action = ora_cmd.Parameters["p_action"].Value.ToString();

                    ora_cmd.Parameters.Clear();

                    string[] acessValue = { p_error, p_action };
                    return GetApproveUnapproveCancelJson(acessValue);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> TransactionCancel(ApproveUnapproveCancelQuery dataQuery)
        {
            try
            {
                using (OracleConnection oraConn = new OracleConnection(await _dbConnection.getDBConn()))
                {
                    oraConn.Open();

                    OracleCommand ora_cmd = new OracleCommand("pkg_pharmacy.sp_phr_transaction_lgr", oraConn);
                    ora_cmd.BindByName = true;
                    ora_cmd.CommandType = CommandType.StoredProcedure;


                    ora_cmd.Parameters.Add("p_action_type", OracleDbType.Int32, 3, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_curr_store_no", OracleDbType.Int32, dataQuery.curr_store_no, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_phr_trn_no", OracleDbType.Varchar2, 300, dataQuery.phr_trn_no, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_trntype_no", OracleDbType.Int32, 14, ParameterDirection.Input);

                    ora_cmd.Parameters.Add("p_entryby", OracleDbType.Int32, dataQuery.entryby, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_cid", OracleDbType.Int32, dataQuery.CID, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_gid", OracleDbType.Int32, dataQuery.GID, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_entryip ", OracleDbType.Varchar2, dataQuery.entryip, ParameterDirection.Input);

                    ora_cmd.Parameters.Add("p_error", OracleDbType.Varchar2, 3000).Direction = ParameterDirection.Output;
                    ora_cmd.Parameters.Add("p_action", OracleDbType.Int32, 30).Direction = ParameterDirection.Output;

                    ora_cmd.ExecuteNonQuery();
                    oraConn.Close();

                    string? p_error = ora_cmd.Parameters["p_error"].Value.ToString();
                    string? p_action = ora_cmd.Parameters["p_action"].Value.ToString();

                    ora_cmd.Parameters.Clear();

                    string[] acessValue = { p_error, p_action };
                    return GetApproveUnapproveCancelJson(acessValue);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> FileUpload(FileUploadQuery fileUpload)
        {
            try
            {
                using (OracleConnection oraConn = new OracleConnection(await _dbConnection.getDBConn()))
                {
                    string? btntext = fileUpload.Action_type;
                    int action_type = 0;

                    if (btntext == "Upload Files")
                    {
                        action_type = 1;
                    }
                    else if (btntext == "Update Files")
                    {
                        action_type = 2;
                    }

                    oraConn.Open();

                    OracleCommand ora_cmd = new OracleCommand("pkg_pharmacy.sp_phr_tran_attachment_save", oraConn);
                    ora_cmd.BindByName = true;
                    ora_cmd.CommandType = CommandType.StoredProcedure;

                    int size = fileUpload.FillUpArr.Count;

                    string[] arr_v_filePath = new string[size];
                    string[] arr_v_fileName = new string[size];

                    int i = 0;

                    List<FillUpArr> FillUpArrs = fileUpload.FillUpArr;

                    foreach (var row in FillUpArrs)
                    {
                        arr_v_filePath[i] = row.file_path;
                        arr_v_fileName[i] = row.file_name;

                        i++;
                    }

                    ora_cmd.Parameters.Add("p_action_type", OracleDbType.Int32, action_type, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_phr_trn_no", OracleDbType.Varchar2, fileUpload.phr_trn_no, ParameterDirection.Input);

                    OracleParameter arr_p_filePath = new OracleParameter("p_file_path", OracleDbType.Varchar2, arr_v_filePath.Length, arr_v_filePath, ParameterDirection.Input);
                    arr_p_filePath.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    ora_cmd.Parameters.Add(arr_p_filePath);

                    OracleParameter arr_p_fileName = new OracleParameter("p_file_name", OracleDbType.Varchar2, arr_v_fileName.Length, arr_v_fileName, ParameterDirection.Input);
                    arr_p_fileName.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    ora_cmd.Parameters.Add(arr_p_fileName);

                    ora_cmd.Parameters.Add("p_item_index", OracleDbType.Int32, size, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_entryby", OracleDbType.Int32, fileUpload.entryby, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_cid", OracleDbType.Int32, fileUpload.CID, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_gid", OracleDbType.Int32, fileUpload.GID, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_entryip ", OracleDbType.Varchar2, fileUpload.entryip, ParameterDirection.Input);

                    ora_cmd.Parameters.Add("p_error", OracleDbType.Varchar2, 3000).Direction = ParameterDirection.Output;
                    ora_cmd.Parameters.Add("p_action", OracleDbType.Int32, 30).Direction = ParameterDirection.Output;

                    ora_cmd.ExecuteNonQuery();
                    oraConn.Close();

                    string? p_error = ora_cmd.Parameters["p_error"].Value.ToString();
                    string? p_action = ora_cmd.Parameters["p_action"].Value.ToString();

                    ora_cmd.Parameters.Clear();

                    string[] acessValue = { p_error, p_action };
                    return GetFileUploadJson(acessValue);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private static string GetFileUploadJson(string[] acessValue)
        {
            string JSONResult = JsonConvert.SerializeObject(acessValue);
            return JSONResult;
        }

        public async Task<string> GetFileUploadedData(GetFileUploadedDataQuery dataQuery)
        {
            try
            {
                OracleConnection oraConn = new OracleConnection(await _dbConnection.getDBConn());

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = oraConn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                cmd.CommandText = "pkg_pharmacy.sp_phr_tran_attachment_data";
                cmd.Parameters.Add("p_gid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_cid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_phr_trn_no", OracleDbType.Int64, 30);
                cmd.Parameters.Add("p_attachment", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmd.Parameters["p_gid"].Value = dataQuery.GID;
                cmd.Parameters["p_cid"].Value = dataQuery.CID;
                cmd.Parameters["p_phr_trn_no"].Value = dataQuery.phr_trn_no;

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                DataTable dt = ds.Tables[0];
                return GetJsonData(dt);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
