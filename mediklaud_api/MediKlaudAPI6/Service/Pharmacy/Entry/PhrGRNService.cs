
using mediklaud_api.FormQuery.Pharmacy;
using mediklaud_api.Infrastructure;
using mediklaud_api.Interface.Pharmacy;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Data.Common;
using System.Globalization;

namespace mediklaud_api.Service.Pharmacy.Entry
{
    public class PhrGRNService : IPhrGRNService
    {
        private readonly IMediklaudDBConnection _connection;

        public PhrGRNService(IMediklaudDBConnection connection)
        {
            _connection = connection;
        }

        public async Task<string> GetConfigaration(CommonGID_CID_For_GRN dataQuery)
        {
            try
            {
                OracleConnection oraConn = new OracleConnection(await _connection.getDBConn());

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

        public async Task<string> GetSrcStoreList(StoreList dataQuery)
        {
            try
            {
                OracleConnection oraConn = new OracleConnection(await _connection.getDBConn());

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = oraConn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                cmd.CommandText = "pkg_pharmacy.sp_phr_user_main_store_list";
                cmd.Parameters.Add("p_gid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_cid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_user_no", OracleDbType.Int32, 300);
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

        public async Task<string> GetStoreList(StoreList dataQuery)
        {
            try
            {
                OracleConnection oraConn = new OracleConnection(await _connection.getDBConn());

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = oraConn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                cmd.CommandText = "pkg_pharmacy.sp_phr_user_main_store_list";
                cmd.Parameters.Add("p_gid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_cid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_user_no", OracleDbType.Int32, 300);
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

        public async Task<string> GetSrcSupplierList(CommonGID_CID_For_GRN dataQuery)
        {
            try
            {
                OracleConnection oraConn = new OracleConnection(await _connection.getDBConn());

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

        public async Task<string> GetSupplierList(CommonGID_CID_For_GRN dataQuery)
        {
            try
            {
                OracleConnection oraConn = new OracleConnection(await _connection.getDBConn());

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

        public async Task<string> GetOrderNumberList(OrderNumberList dataQuery)
        {
            try
            {
                OracleConnection oraConn = new OracleConnection(await _connection.getDBConn());

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = oraConn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                cmd.CommandText = "pkg_pharmacy.sp_phr_pur_order_pending_list";
                cmd.Parameters.Add("p_gid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_cid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_start_date", OracleDbType.Varchar2, 30);
                cmd.Parameters.Add("p_end_date", OracleDbType.Varchar2, 30);
                cmd.Parameters.Add("p_store_no", OracleDbType.Varchar2, 30);
                cmd.Parameters.Add("p_supplier_no", OracleDbType.Varchar2, 30);
                cmd.Parameters.Add("p_phr_pur_ord_list", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmd.Parameters["p_gid"].Value = dataQuery.GID;
                cmd.Parameters["p_cid"].Value = dataQuery.CID;
                cmd.Parameters["p_start_date"].Value = dataQuery.StartDate;
                cmd.Parameters["p_end_date"].Value = dataQuery.EndDate;
                cmd.Parameters["p_store_no"].Value = dataQuery.StoreNo;
                cmd.Parameters["p_supplier_no"].Value = dataQuery.SupplierNo;

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

        public async Task<string> GetOrderReceivedItemList(OrderReceivedItemList dataQuery)
        {
            try
            {
                OracleConnection oraConn = new OracleConnection(await _connection.getDBConn());

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = oraConn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                cmd.CommandText = "pkg_pharmacy.sp_phr_pur_ord_rec_item_list";
                cmd.Parameters.Add("p_gid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_cid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_phr_pur_ord_no", OracleDbType.Varchar2, 30);
                cmd.Parameters.Add("p_phr_ord_data", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmd.Parameters["p_gid"].Value = dataQuery.GID;
                cmd.Parameters["p_cid"].Value = dataQuery.CID;
                cmd.Parameters["p_phr_pur_ord_no"].Value = dataQuery.phr_pur_ord_no;

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

        public async Task<string> GetReceivedByList(CommonGID_CID_For_GRN dataQuery)
        {
            try
            {
                OracleConnection oraConn = new OracleConnection(await _connection.getDBConn());

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = oraConn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                cmd.CommandText = "sp_user_list";
                cmd.Parameters.Add("p_gid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_cid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_datalist", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
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

        public async Task<string> GetTransactionList(GetTransactionList getTransactionList)
        {
            try
            {
                OracleConnection oracleConnection = new OracleConnection(await _connection.getDBConn());



                OracleCommand cmd = new OracleCommand();
                cmd.Connection = oracleConnection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                cmd.CommandText = "pkg_pharmacy.sp_phr_transaction_datalist";
                cmd.Parameters.Add("p_gid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_cid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_trntype_no", OracleDbType.Varchar2, 300);
                cmd.Parameters.Add("p_approve_flag", OracleDbType.Varchar2, 300);
                cmd.Parameters.Add("p_store_no", OracleDbType.Varchar2, 300);
                cmd.Parameters.Add("p_supplier_no", OracleDbType.Varchar2, 300);
                cmd.Parameters.Add("p_phr_trn_id", OracleDbType.Varchar2, 300);
                cmd.Parameters.Add("p_start_date", OracleDbType.Date, 300);
                cmd.Parameters.Add("p_end_date", OracleDbType.Date, 300);
                cmd.Parameters.Add("p_phr_trn_list", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                cmd.Parameters["p_gid"].Value = getTransactionList.GID;
                cmd.Parameters["p_cid"].Value = getTransactionList.CID;
                cmd.Parameters["p_trntype_no"].Value = 15;
                cmd.Parameters["p_approve_flag"].Value = getTransactionList.ApproveFlag;
                cmd.Parameters["p_store_no"].Value = getTransactionList.StoreNo;
                cmd.Parameters["p_supplier_no"].Value = getTransactionList.SupplierNo;
                cmd.Parameters["p_phr_trn_id"].Value = getTransactionList.PhrTrnIDForSearch;
                cmd.Parameters["p_start_date"].Value = DateTime.Parse(getTransactionList.StartDate);
                cmd.Parameters["p_end_date"].Value = DateTime.Parse(getTransactionList.EndDate);

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
        private string GetTableTypeJSON(DataTable dt)
        {
            string JSONResult = JsonConvert.SerializeObject(dt);
            return JSONResult;
        }

        public async Task<string> TransactionSave(TransactionSave transactionSave)
        {
            try
            {
                using (OracleConnection oraConn = new OracleConnection(await _connection.getDBConn()))
                {
                    string? btntext = transactionSave.Action_type;
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
                        transactionNo = transactionSave.Phr_trn_no;
                        transactionId = transactionSave.Phr_trn_id;
                        action_type = 2;
                    }


                    oraConn.Open();

                    OracleCommand ora_cmd = new OracleCommand("pkg_pharmacy.sp_phr_transaction_save", oraConn);
                    ora_cmd.BindByName = true;
                    ora_cmd.CommandType = CommandType.StoredProcedure;

                    int size = transactionSave.TranArrList.Count;

                    string[] arr_v_item_no = new string[size];
                    decimal?[] arr_v_item_qty = new decimal?[size];
                    decimal?[] arr_v_bonus_qty = new decimal?[size];
                    decimal?[] arr_v_purchase_price = new decimal?[size];
                    decimal?[] arr_v_sale_price = new decimal?[size];
                    string[] arr_v_supplier_no = new string[size];
                    string[] arr_v_batch_number = new string[size];
                    string[] arr_v_exp_date = new string[size];
                    decimal?[] arr_v_discount_amt = new decimal?[size];
                    decimal?[] arr_v_vat_amt = new decimal?[size];
                    decimal?[] arr_v_tax_amt = new decimal?[size];
                    string[] arr_v_phr_reqdtl_no = new string[size];
                    int[] arr_v_phr_req_qty = new int[size];
                    string[] arr_v_phr_pur_orddtl_no = new string[size];
                    decimal?[] arr_v_phr_pur_ord_qty = new decimal?[size];
                    string[] arr_v_ref_trndtl_no = new string[size];
                    int[] arr_v_ref_trndtl_qty = new int[size];
                    int[] arr_v_stock_qty = new int[size];
                    decimal?[] arr_v_item_box_qty = new decimal?[size];
                    decimal?[] arr_v_pur_ord_price = new decimal?[size];
                    int?[] arr_v_change_no = new int?[size];
                    decimal?[] arr_v_box_qty = new decimal?[size];
                    int?[] arr_v_chk_flag = new int?[size];
                    decimal?[] arr_v_total_amt = new decimal?[size];
                    int?[] arr_v_sl_no = new int?[size];
                    int i = 0;

                    List<TranArrList> TranArrs = transactionSave.TranArrList;

                    foreach (var row in TranArrs)
                    {
                        



                        arr_v_item_no[i] = Convert.ToString(row.ITEM_NO);

                        arr_v_item_qty[i] = row.ITEM_QTY;

                        arr_v_bonus_qty[i] = row.BONUS_QTY;

                        arr_v_purchase_price[i] = row.PURCHASE_PRICE;

                        arr_v_sale_price[i] = row.SALES_PRICE;

                        arr_v_supplier_no[i] = transactionSave.Pur_supplier_no;

                        var batch = row.BATCH_NUMBER;

                        if (batch == "&nbsp;" || batch == "" || batch == "null")
                        {
                            arr_v_batch_number[i] = null;
                        }
                        else
                        {
                            arr_v_batch_number[i] = batch;
                        }

                        var exdate = row.EXP_DATE;

                        if (exdate == "&nbsp;" || exdate == null || exdate == "null")
                        {
                            arr_v_exp_date[i] = null;
                        }
                        else
                        {
                            DateTime originalDate = DateTime.ParseExact(exdate, "yyyy-MM-dd", null);
                            string formattedDate = originalDate.ToString("MM/dd/yyyy");
                            arr_v_exp_date[i] = formattedDate;
                        }

                        arr_v_discount_amt[i] = row.DISCOUNT_AMT;

                        arr_v_vat_amt[i] = row.VAT_AMT;

                        arr_v_total_amt[i] = row.TOTAL_AMOUNT;


                        arr_v_phr_reqdtl_no[i] = "";
                        arr_v_phr_req_qty[i] = 0;
                        arr_v_phr_pur_orddtl_no[i] = Convert.ToString(row.PHR_PUR_ORDDTL_NO);
                        arr_v_phr_pur_ord_qty[i] = row.ORDER_QTY;
                        arr_v_ref_trndtl_no[i] = "";
                        arr_v_ref_trndtl_qty[i] = 0;
                        arr_v_stock_qty[i] = 0;

                        arr_v_item_box_qty[i] = row.ITEM_BOX_QTY;

                        arr_v_pur_ord_price[i] = row.PUR_ORD_PRICE;

                        arr_v_change_no[i] = 0;

                        arr_v_box_qty[i] = row.BOX_QTY;

                        arr_v_chk_flag[i] = 0;
                        arr_v_sl_no[i] = row.SL_NO;

                        i++;
                    }

                    string invoiceDate = null;
                    if (transactionSave.Supp_invoice_date == "")
                    {
                        invoiceDate = null;
                    }
                    else
                    {
                        DateTime parsedDate = DateTime.Parse(transactionSave.Supp_invoice_date);
                        string formattedDate = parsedDate.ToString("MM/dd/yyyy");
                        invoiceDate = formattedDate;
                    }

                    ora_cmd.Parameters.Add("p_action_type", OracleDbType.Int32, action_type, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_trntype_no", OracleDbType.Varchar2, "15", ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_curr_store_no", OracleDbType.Varchar2, transactionSave.Curr_store_no, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_trn_store_no", OracleDbType.Varchar2, "", ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_phr_pur_ord_no", OracleDbType.Varchar2, transactionSave.Phr_pur_ord_no, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_phr_pur_ord_id", OracleDbType.Varchar2, transactionSave.Phr_pur_ord_id, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_pur_supplier_no", OracleDbType.Varchar2, transactionSave.Pur_supplier_no, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_supp_invoice_no", OracleDbType.Varchar2, transactionSave.Supp_invoice_no, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_supp_invoice_date", OracleDbType.Date, invoiceDate, ParameterDirection.Input);
                    //ora_cmd.Parameters.Add("p_supp_exp_pay_date", OracleDbType.Date, null, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_supp_pay_type_no", OracleDbType.Varchar2, transactionSave.Supp_pay_type_no, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_phr_req_no", OracleDbType.Varchar2, "", ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_phr_req_id", OracleDbType.Varchar2, "", ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_ref_trn_no", OracleDbType.Varchar2, "", ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_ref_trn_id", OracleDbType.Varchar2, "", ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_ret_adjustment_amt", OracleDbType.Int32, 0, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_descr", OracleDbType.Varchar2, transactionSave.Descr, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_received_by", OracleDbType.Varchar2, transactionSave.Received_by, ParameterDirection.Input);

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

                    OracleParameter p_total_amt = new OracleParameter("p_total_amt", OracleDbType.Decimal, arr_v_total_amt.Length, arr_v_total_amt, ParameterDirection.Input);
                    p_total_amt.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    ora_cmd.Parameters.Add(p_total_amt);

                    OracleParameter arr_p_phr_reqdtl_no = new OracleParameter("p_phr_reqdtl_no", OracleDbType.Varchar2, arr_v_phr_reqdtl_no.Length, arr_v_phr_reqdtl_no, ParameterDirection.Input);
                    arr_p_phr_reqdtl_no.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    ora_cmd.Parameters.Add(arr_p_phr_reqdtl_no);

                    OracleParameter arr_p_phr_req_qty = new OracleParameter("p_phr_req_qty", OracleDbType.Decimal, arr_v_phr_req_qty.Length, arr_v_phr_req_qty, ParameterDirection.Input);
                    arr_p_phr_req_qty.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    ora_cmd.Parameters.Add(arr_p_phr_req_qty);

                    OracleParameter arr_p_phr_pur_orddtl_no = new OracleParameter("p_phr_pur_orddtl_no", OracleDbType.Varchar2, arr_v_phr_pur_orddtl_no.Length, arr_v_phr_pur_orddtl_no, ParameterDirection.Input);
                    arr_p_phr_pur_orddtl_no.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    ora_cmd.Parameters.Add(arr_p_phr_pur_orddtl_no);

                    OracleParameter arr_p_phr_pur_ord_qty = new OracleParameter("p_phr_pur_ord_qty", OracleDbType.Decimal, arr_v_phr_pur_ord_qty.Length, arr_v_phr_pur_ord_qty, ParameterDirection.Input);
                    arr_p_phr_pur_ord_qty.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    ora_cmd.Parameters.Add(arr_p_phr_pur_ord_qty);

                    OracleParameter arr_p_ref_trndtl_no = new OracleParameter("p_ref_trndtl_no", OracleDbType.Varchar2, arr_v_ref_trndtl_no.Length, arr_v_ref_trndtl_no, ParameterDirection.Input);
                    arr_p_ref_trndtl_no.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    ora_cmd.Parameters.Add(arr_p_ref_trndtl_no);

                    OracleParameter arr_p_ref_trndtl_qty = new OracleParameter("p_ref_trndtl_qty", OracleDbType.Decimal, arr_v_ref_trndtl_qty.Length, arr_v_ref_trndtl_qty, ParameterDirection.Input);
                    arr_p_ref_trndtl_qty.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    ora_cmd.Parameters.Add(arr_p_ref_trndtl_qty);

                    OracleParameter arr_p_stock_qty = new OracleParameter("p_stock_qty", OracleDbType.Decimal, arr_v_stock_qty.Length, arr_v_stock_qty, ParameterDirection.Input);
                    arr_p_stock_qty.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    ora_cmd.Parameters.Add(arr_p_stock_qty);

                    OracleParameter arr_p_item_box_qty = new OracleParameter("p_item_box_qty", OracleDbType.Decimal, arr_v_item_box_qty.Length, arr_v_item_box_qty, ParameterDirection.Input);
                    arr_p_item_box_qty.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    ora_cmd.Parameters.Add(arr_p_item_box_qty);

                    OracleParameter arr_p_pur_ord_price = new OracleParameter("p_pur_ord_price", OracleDbType.Decimal, arr_v_pur_ord_price.Length, arr_v_pur_ord_price, ParameterDirection.Input);
                    arr_p_pur_ord_price.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    ora_cmd.Parameters.Add(arr_p_pur_ord_price);

                    OracleParameter arr_p_change_no = new OracleParameter("p_change_no", OracleDbType.Varchar2, arr_v_change_no.Length, arr_v_change_no, ParameterDirection.Input);
                    arr_p_change_no.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    ora_cmd.Parameters.Add(arr_p_change_no);

                    OracleParameter arr_p_box_qty = new OracleParameter("p_box_qty", OracleDbType.Decimal, arr_v_box_qty.Length, arr_v_box_qty, ParameterDirection.Input);
                    arr_p_box_qty.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    ora_cmd.Parameters.Add(arr_p_box_qty);

                    OracleParameter arr_p_chk_flag = new OracleParameter("p_chk_flag", OracleDbType.Int32, arr_v_chk_flag.Length, arr_v_chk_flag, ParameterDirection.Input);
                    arr_p_chk_flag.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    ora_cmd.Parameters.Add(arr_p_chk_flag);

                    OracleParameter arr_p_sl_no = new OracleParameter("p_sl_no", OracleDbType.Int32, arr_v_sl_no.Length, arr_v_sl_no, ParameterDirection.Input);
                    arr_p_sl_no.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    ora_cmd.Parameters.Add(arr_p_sl_no);

                    ora_cmd.Parameters.Add("p_item_index", OracleDbType.Int32, size, ParameterDirection.Input);

                    ora_cmd.Parameters.Add("p_total_amount", OracleDbType.Decimal, transactionSave.TotalAmount, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_total_vat", OracleDbType.Decimal, transactionSave.TotalVat, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_total_discount", OracleDbType.Decimal, transactionSave.TotalDiscount, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_net_amount", OracleDbType.Decimal, transactionSave.NetAmount, ParameterDirection.Input);



                    ora_cmd.Parameters.Add("p_entryby", OracleDbType.Int32, transactionSave.Entryby, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_cid", OracleDbType.Int32, transactionSave.CID, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_gid", OracleDbType.Int32, transactionSave.GID, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_entryip ", OracleDbType.Varchar2, transactionSave.Entryip, ParameterDirection.Input);

                    ora_cmd.Parameters.Add("p_phr_trn_no", OracleDbType.Varchar2, 300, transactionNo, ParameterDirection.InputOutput);
                    ora_cmd.Parameters.Add("p_phr_trn_id", OracleDbType.Varchar2, 500, transactionId, ParameterDirection.InputOutput);

                    ora_cmd.Parameters.Add("p_error", OracleDbType.Varchar2, 3000).Direction = ParameterDirection.Output;
                    ora_cmd.Parameters.Add("p_action", OracleDbType.Int32, 30).Direction = ParameterDirection.Output;

                    ora_cmd.ExecuteNonQuery();
                    oraConn.Close();

                    string? p_phr_trn_no = ora_cmd.Parameters["p_phr_trn_no"].Value.ToString();
                    string? p_phr_trn_id = ora_cmd.Parameters["p_phr_trn_id"].Value.ToString();
                    string? p_error = ora_cmd.Parameters["p_error"].Value.ToString();
                    string? p_action = ora_cmd.Parameters["p_action"].Value.ToString();

                    ora_cmd.Parameters.Clear();

                    string[] dataArray = new string[] { p_phr_trn_no, p_phr_trn_id, p_error, p_action };
                    return GetTransationJson(dataArray);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        private string GetTransationJson(string[] dataArray)
        {
            string json = $"[{JsonConvert.ToString(dataArray[0])}, {JsonConvert.ToString(dataArray[1])}, {JsonConvert.ToString(dataArray[2])}, {JsonConvert.ToString(dataArray[3])}]";
            return json;
        }

        public async Task<string> SendToAccount(Transaction_acc transaction_Acc)
        {
            try
            {
                using (OracleConnection oraConn = new OracleConnection(await _connection.getDBConn()))
                {
                    oraConn.Open();

                    OracleCommand ora_cmd = new OracleCommand("pkg_pharmacy.sp_phr_transaction_acc", oraConn);
                    ora_cmd.BindByName = true;
                    ora_cmd.CommandType = CommandType.StoredProcedure;

                    ora_cmd.Parameters.Add("p_action_type", OracleDbType.Int32, 1, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_phr_trn_no", OracleDbType.Int32, transaction_Acc.Phr_trn_no, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_trntype_no", OracleDbType.Int32, 15, ParameterDirection.Input);

                    ora_cmd.Parameters.Add("p_entryby", OracleDbType.Int32, transaction_Acc.Entryby, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_cid", OracleDbType.Int32, transaction_Acc.CID, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_gid", OracleDbType.Int32, transaction_Acc.GID, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_entryip ", OracleDbType.Varchar2, transaction_Acc.Entryip, ParameterDirection.Input);

                    ora_cmd.Parameters.Add("p_error", OracleDbType.Varchar2, 3000).Direction = ParameterDirection.Output;
                    ora_cmd.Parameters.Add("p_action", OracleDbType.Int32, 30).Direction = ParameterDirection.Output;

                    ora_cmd.ExecuteNonQuery();
                    oraConn.Close();

                    string? p_error = ora_cmd.Parameters["p_error"].Value.ToString();

                    ora_cmd.Parameters.Clear();

                    return GetCommonJson(p_error);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private static string GetCommonJson(string? p_error)
        {
            string JSONResult = JsonConvert.SerializeObject(p_error);
            return JSONResult;
        }

        public async Task<string> TrnApproved(Approved_Unapproved dataQuery)
        {
            try
            {
                using (OracleConnection oraConn = new OracleConnection(await _connection.getDBConn()))
                {
                    oraConn.Open();

                    OracleCommand ora_cmd = new OracleCommand("pkg_pharmacy.sp_phr_transaction_lgr", oraConn);
                    ora_cmd.BindByName = true;
                    ora_cmd.CommandType = CommandType.StoredProcedure;

                    ora_cmd.Parameters.Add("p_action_type", OracleDbType.Int32, 1, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_curr_store_no", OracleDbType.Int32, dataQuery.Curr_store_no, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_phr_trn_no", OracleDbType.Varchar2, 300, dataQuery.Phr_trn_no, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_trntype_no", OracleDbType.Int32, 15, ParameterDirection.Input);

                    ora_cmd.Parameters.Add("p_entryby", OracleDbType.Int32, dataQuery.Entryby, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_cid", OracleDbType.Int32, dataQuery.CID, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_gid", OracleDbType.Int32, dataQuery.GID, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_entryip ", OracleDbType.Varchar2, dataQuery.Entryip, ParameterDirection.Input);

                    ora_cmd.Parameters.Add("p_error", OracleDbType.Varchar2, 3000).Direction = ParameterDirection.Output;
                    ora_cmd.Parameters.Add("p_action", OracleDbType.Int32, 30).Direction = ParameterDirection.Output;

                    ora_cmd.ExecuteNonQuery();
                    oraConn.Close();

                    string? p_error = ora_cmd.Parameters["p_error"].Value.ToString();

                    ora_cmd.Parameters.Clear();

                    return GetCommonJson(p_error);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> TrnUnApproved(Approved_Unapproved dataQuery)
        {
            try
            {
                using (OracleConnection oraConn = new OracleConnection(await _connection.getDBConn()))
                {
                    oraConn.Open();

                    OracleCommand ora_cmd = new OracleCommand("pkg_pharmacy.sp_phr_transaction_lgr", oraConn);
                    ora_cmd.BindByName = true;
                    ora_cmd.CommandType = CommandType.StoredProcedure;

                    ora_cmd.Parameters.Add("p_action_type", OracleDbType.Int32, 2, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_curr_store_no", OracleDbType.Int32, dataQuery.Curr_store_no, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_phr_trn_no", OracleDbType.Varchar2, 300, dataQuery.Phr_trn_no, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_trntype_no", OracleDbType.Int32, 15, ParameterDirection.Input);

                    ora_cmd.Parameters.Add("p_entryby", OracleDbType.Int32, dataQuery.Entryby, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_cid", OracleDbType.Int32, dataQuery.CID, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_gid", OracleDbType.Int32, dataQuery.GID, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_entryip ", OracleDbType.Varchar2, dataQuery.Entryip, ParameterDirection.Input);

                    ora_cmd.Parameters.Add("p_error", OracleDbType.Varchar2, 3000).Direction = ParameterDirection.Output;
                    ora_cmd.Parameters.Add("p_action", OracleDbType.Int32, 30).Direction = ParameterDirection.Output;

                    ora_cmd.ExecuteNonQuery();
                    oraConn.Close();

                    string? p_error = ora_cmd.Parameters["p_error"].Value.ToString();

                    ora_cmd.Parameters.Clear();

                    return GetCommonJson(p_error);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> TransactionDataMaster(TrnDataMaster dataQuery)
        {
            try
            {
                OracleConnection oraConn = new OracleConnection(await _connection.getDBConn());

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = oraConn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                cmd.CommandText = "pkg_pharmacy.sp_phr_transaction_data";
                cmd.Parameters.Add("p_gid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_cid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_trntype_no", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_phr_trn_no", OracleDbType.Varchar2, 30);
                cmd.Parameters.Add("p_phr_trn", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_phr_trndtl", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmd.Parameters["p_gid"].Value = dataQuery.GID;
                cmd.Parameters["p_cid"].Value = dataQuery.CID;
                cmd.Parameters["p_trntype_no"].Value = 15;
                cmd.Parameters["p_phr_trn_no"].Value = dataQuery.Phr_trn_no;

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

        public async Task<string> FileUpload(PhrOrdRecFileUploadQuery fileUpload)
        {
            try
            {
                using (OracleConnection oraConn = new OracleConnection(await _connection.getDBConn()))
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

                    int size = fileUpload.PhrOrdRecFillUpArr.Count;

                    string[] arr_v_filePath = new string[size];
                    string[] arr_v_fileName = new string[size];

                    int i = 0;

                    List<PhrOrdRecFillUpArr> FillUpArrs = fileUpload.PhrOrdRecFillUpArr;

                    foreach (var row in FillUpArrs)
                    {
                        arr_v_filePath[i] = row.File_path;
                        arr_v_fileName[i] = row.File_path;

                        i++;
                    }

                    ora_cmd.Parameters.Add("p_action_type", OracleDbType.Int32, action_type, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_phr_trn_no", OracleDbType.Varchar2, fileUpload.Phr_trn_no, ParameterDirection.Input);

                    OracleParameter arr_p_filePath = new OracleParameter("p_file_path", OracleDbType.Varchar2, arr_v_filePath.Length, arr_v_filePath, ParameterDirection.Input);
                    arr_p_filePath.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    ora_cmd.Parameters.Add(arr_p_filePath);

                    OracleParameter arr_p_fileName = new OracleParameter("p_file_name", OracleDbType.Varchar2, arr_v_fileName.Length, arr_v_fileName, ParameterDirection.Input);
                    arr_p_fileName.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    ora_cmd.Parameters.Add(arr_p_fileName);

                    ora_cmd.Parameters.Add("p_item_index", OracleDbType.Int32, size, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_entryby", OracleDbType.Int32, fileUpload.Entryby, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_cid", OracleDbType.Int32, fileUpload.CID, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_gid", OracleDbType.Int32, fileUpload.GID, ParameterDirection.Input);
                    ora_cmd.Parameters.Add("p_entryip ", OracleDbType.Varchar2, fileUpload.Entryip, ParameterDirection.Input);

                    ora_cmd.Parameters.Add("p_error", OracleDbType.Varchar2, 3000).Direction = ParameterDirection.Output;
                    ora_cmd.Parameters.Add("p_action", OracleDbType.Int32, 30).Direction = ParameterDirection.Output;

                    ora_cmd.ExecuteNonQuery();
                    oraConn.Close();

                    string? p_error = ora_cmd.Parameters["p_error"].Value.ToString();

                    ora_cmd.Parameters.Clear();

                    return GetCommonJson(p_error);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> GetFileUploadedData(GetPhrOrdRecFileUploadedData dataQuery)
        {
            try
            {
                OracleConnection oraConn = new OracleConnection(await _connection.getDBConn());

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
                return GetTableTypeJSON(dt);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
