
using mediklaud_api.FormQuery.Pharmacy.Entry;
using mediklaud_api.Infrastructure;
using mediklaud_api.Interface.Pharmacy.Entry;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Data.Common;

namespace mediklaud_api.Service.Pharmacy.Entry
{
    public class PharPurchaseRequisitionService : IPhrPurchaseRequisitionService
    {
        private readonly IMediklaudDBConnection _connection;
        public PharPurchaseRequisitionService(IMediklaudDBConnection connection)
        {
            _connection = connection;
        }

        public async Task<string> GetConfiguration(Common_Gid_Cid_For_Requisition common_Gid_Cid_For_Requisition)
        {
            try
            {
                OracleConnection oracleConnection = new OracleConnection(await _connection.getDBConn());

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = oracleConnection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;

                cmd.CommandText = "sp_phr_transaction_config";
                cmd.Parameters.Add("p_gid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_cid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_config", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmd.Parameters["p_gid"].Value = common_Gid_Cid_For_Requisition.GID;
                cmd.Parameters["p_cid"].Value = common_Gid_Cid_For_Requisition.CID;

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
        public async Task<string> GetSrcFromStorList(FromStorList fromStorList)
        {
            try
            {
                OracleConnection oracleConnection = new OracleConnection(await _connection.getDBConn());

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = oracleConnection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                cmd.CommandText = "pkg_pharmacy.sp_phr_user_sub_store_list";
                cmd.Parameters.Add("p_gid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_cid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_user_no", OracleDbType.Int32, 300);
                cmd.Parameters.Add("p_store_list", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmd.Parameters["p_gid"].Value = fromStorList.GID;
                cmd.Parameters["p_cid"].Value = fromStorList.CID;
                cmd.Parameters["p_user_no"].Value = fromStorList.UserNo;

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
        public async Task<string> GetFromStorList(FromStorList fromStorList)
        {
            try
            {
                OracleConnection oracleConnection = new OracleConnection(await _connection.getDBConn());

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = oracleConnection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                cmd.CommandText = "pkg_pharmacy.sp_phr_user_sub_store_list";
                cmd.Parameters.Add("p_gid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_cid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_user_no", OracleDbType.Int32, 300);
                cmd.Parameters.Add("p_store_list", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmd.Parameters["p_gid"].Value = fromStorList.GID;
                cmd.Parameters["p_cid"].Value = fromStorList.CID;
                cmd.Parameters["p_user_no"].Value = fromStorList.UserNo;

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
        public async Task<string> GetToStorList(ToStorList toStorList)
        {
            try
            {
                OracleConnection oracleConnection = new OracleConnection(await _connection.getDBConn());

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = oracleConnection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;

                cmd.CommandText = "pkg_pharmacy.sp_phr_warehouse_list";
                cmd.Parameters.Add("p_gid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_cid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_type_no", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_store_list", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmd.Parameters["p_gid"].Value = toStorList.GID;
                cmd.Parameters["p_cid"].Value = toStorList.CID;
                cmd.Parameters["p_type_no"].Value = toStorList.TypeNo;

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
        public async Task<string> GetSrcSupplierList(Common_Gid_Cid_For_Requisition common_Gid_Cid_For_Requisition)
        {
            try
            {
                OracleConnection oracleConnection = new OracleConnection(await _connection.getDBConn());

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = oracleConnection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;

                cmd.CommandText = "pkg_pharmacy.sp_phr_supplier_list";
                cmd.Parameters.Add("p_gid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_cid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_supplier_list", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmd.Parameters["p_gid"].Value = common_Gid_Cid_For_Requisition.GID;
                cmd.Parameters["p_cid"].Value = common_Gid_Cid_For_Requisition.CID;

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
        public async Task<string> GetSupplierList(Common_Gid_Cid_For_Requisition common_Gid_Cid_For_Requisition)
        {
            try
            {
                OracleConnection oracleConnection = new OracleConnection(await _connection.getDBConn());

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = oracleConnection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;

                cmd.CommandText = "pkg_pharmacy.sp_phr_supplier_list";
                cmd.Parameters.Add("p_gid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_cid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_supplier_list", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmd.Parameters["p_gid"].Value = common_Gid_Cid_For_Requisition.GID;
                cmd.Parameters["p_cid"].Value = common_Gid_Cid_For_Requisition.CID;

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
        public async Task<string> GetRequisitionList(PhrRequisitionList requisitionList)
        {
            try
            {
                OracleConnection oracleConnection = new OracleConnection(await _connection.getDBConn());

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = oracleConnection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;
                cmd.CommandText = "pkg_pharmacy.sp_phr_pur_req_datalist";
                cmd.Parameters.Add("p_gid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_cid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_approve_flag", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_store_no", OracleDbType.Varchar2, 30);
                cmd.Parameters.Add("p_to_store_no", OracleDbType.Varchar2, 30);
                cmd.Parameters.Add("p_supplier_no", OracleDbType.Varchar2, 30);
                cmd.Parameters.Add("p_phr_pur_req_id", OracleDbType.Varchar2, 30);
                cmd.Parameters.Add("p_start_date", OracleDbType.Date, 30);
                cmd.Parameters.Add("p_end_date", OracleDbType.Date, 30);

                cmd.Parameters.Add("p_phr_pur_req_list", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmd.Parameters["p_gid"].Value = requisitionList.GID;
                cmd.Parameters["p_cid"].Value = requisitionList.CID;
                cmd.Parameters["p_approve_flag"].Value = requisitionList.ApproveFlag;
                cmd.Parameters["p_store_no"].Value = requisitionList.StoreNo;
                cmd.Parameters["p_to_store_no"].Value = requisitionList.ToStoreNo;
                cmd.Parameters["p_supplier_no"].Value = requisitionList.SupplierNo;
                cmd.Parameters["p_phr_pur_req_id"].Value = requisitionList.PurchaseRequisitionId;
                cmd.Parameters["p_start_date"].Value = requisitionList.StartDate;
                cmd.Parameters["p_end_date"].Value = requisitionList.EndDate;

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
        public async Task<string> GetPhrItemList(ItemList itemList)
        {
            try
            {
                OracleConnection oracleConnection = new OracleConnection(await _connection.getDBConn());

                OracleCommand cmd = oracleConnection.CreateCommand();
                cmd.Connection = oracleConnection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.BindByName = true;

                cmd.CommandText = "pkg_pharmacy.sp_phr_pur_order_item_list";
                cmd.Parameters.Add("p_gid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_cid", OracleDbType.Int32, 30);
                cmd.Parameters.Add("p_supplier_no", OracleDbType.Varchar2, 300);
                cmd.Parameters.Add("p_supp_quot_flag", OracleDbType.Varchar2, 30);
                cmd.Parameters.Add("p_item_list", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmd.Parameters["p_gid"].Value = itemList.GID;
                cmd.Parameters["p_cid"].Value = itemList.CID;
                cmd.Parameters["p_supplier_no"].Value = itemList.SupplierNo;
                cmd.Parameters["p_supp_quot_flag"].Value = itemList.SuppQuotFlag;


                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                DataTable dt;
                dt = ds.Tables[0];
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

        public Task<string> GetPhrSuppItemList(SuppItemList suppItemList)
        {
            throw new NotImplementedException();
        }




















        //public async Task<string> GetCmbItemSelectedList(GetCmbItemSelectedListQuery getCmbItemSelectedListQuery)
        //{
        //    try
        //    {
        //        OracleConnection oracleConnection = new OracleConnection(await _connection.getDBConn());

        //        OracleCommand cmd = oracleConnection.CreateCommand();
        //        cmd.Connection = oracleConnection;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.BindByName = true;

        //        cmd.CommandText = "pkg_pharmacy.sp_phr_pur_order_item_data";
        //        cmd.Parameters.Add("p_gid", OracleDbType.Int32, 30);
        //        cmd.Parameters.Add("p_cid", OracleDbType.Int32, 30);
        //        cmd.Parameters.Add("p_supplier_no", OracleDbType.Varchar2, 300);
        //        cmd.Parameters.Add("p_store_no", OracleDbType.Varchar2, 30);
        //        cmd.Parameters.Add("p_item_no", OracleDbType.Varchar2, 30);
        //        cmd.Parameters.Add("p_supp_quot_flag", OracleDbType.Varchar2, 30);
        //        cmd.Parameters.Add("p_item_list", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
        //        cmd.Parameters["p_gid"].Value = getCmbItemSelectedListQuery.GID;
        //        cmd.Parameters["p_cid"].Value = getCmbItemSelectedListQuery.CID;
        //        cmd.Parameters["p_supplier_no"].Value = getCmbItemSelectedListQuery.SupplierNo;
        //        cmd.Parameters["p_store_no"].Value = getCmbItemSelectedListQuery.StoreNo;
        //        cmd.Parameters["p_item_no"].Value = getCmbItemSelectedListQuery.ItemNo;
        //        cmd.Parameters["p_supp_quot_flag"].Value = getCmbItemSelectedListQuery.SuppQuotFlag;


        //        OracleDataAdapter da = new OracleDataAdapter(cmd);
        //        DataSet ds = new DataSet();
        //        da.Fill(ds);

        //        DataTable dt;
        //        dt = ds.Tables[0];
        //        return GetCmbItemSelectedListJson(dt);

        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }

        //}

        //private string GetCmbItemSelectedListJson(DataTable dt)
        //{
        //    string JSONresult;
        //    JSONresult = JsonConvert.SerializeObject(dt);
        //    return JSONresult;
        //}

        //public async Task<string> AddPhrPurchaseRequisition(PhrPurchaseRequisitionSave phrPurchaseRequisitionSave)
        //{
        //    OracleConnection oracleConnection = new OracleConnection(await _connection.getDBConn());
        //    try
        //    {
        //        using (oracleConnection = new OracleConnection(await _connection.getDBConn()))
        //        {

        //            string? btntext = phrPurchaseRequisitionSave.ActionType;
        //            int action_type = 0;

        //            string purchaseRequisitionNo = "", purchaseRequisitionId = "";

        //            if (btntext == "SUBMIT")
        //            {
        //                purchaseRequisitionNo = null;
        //                purchaseRequisitionId = null;
        //                action_type = 1;
        //            }
        //            else if (btntext == "UPDATE")
        //            {
        //                purchaseRequisitionNo = phrPurchaseRequisitionSave.PhrPurReqNO;
        //                purchaseRequisitionId = phrPurchaseRequisitionSave.PhrPurReqId;
        //                action_type = 2;

        //            }

        //            oracleConnection.Open();
        //            using (OracleCommand ora_cmd = new OracleCommand("pkg_pharmacy.sp_phr_pur_requisition_save", oracleConnection))
        //            {

        //                ora_cmd.BindByName = true;
        //                ora_cmd.CommandType = CommandType.StoredProcedure;

        //                int size = phrPurchaseRequisitionSave.RequisitionArray.Count;

        //                string[] arr_v_item_no = new string[size];
        //                decimal[] arr_v_purchase_price = new decimal[size];
        //                decimal[] arr_v_purchase_qty = new decimal[size];
        //                decimal[] arr_v_purchase_box_qty = new decimal[size];
        //                decimal[] arr_v_sales_price = new decimal[size];
        //                int[] arr_v_stock_qty = new int[size];
        //                int[] arr_v_consume_qty = new int[size];
        //                decimal[] arr_v_lm_consume_qty = new decimal[size];
        //                int[] arr_v_re_order_level_qty = new int[size];


        //                int i = 0;

        //                List<RequisitionArray> RequisitonArrays = phrPurchaseRequisitionSave.RequisitionArray;

        //                foreach (var row in RequisitonArrays)
        //                {
        //                    arr_v_item_no[i] = row.ItemNo ?? ""; // or another default value of your choice
        //                    arr_v_purchase_price[i] = row.PurchasePrice;
        //                    arr_v_purchase_qty[i] = row.PurchaseQty;
        //                    arr_v_purchase_box_qty[i] = row.PurchaseBoxQty;

        //                    var salesPrice = Convert.ToString(row.SalesPrice);

        //                    if (salesPrice == "0" || salesPrice == "&nbsp;")
        //                    {
        //                        salesPrice = "0";
        //                    }
        //                    else
        //                    {
        //                        salesPrice = Convert.ToString(row.SalesPrice);
        //                    }
        //                    arr_v_sales_price[i] = (decimal?)row.SalesPrice ?? 0M;


        //                    arr_v_stock_qty[i] = (int?)row.StockQty ?? 0;
        //                    arr_v_consume_qty[i] = (int?)row.ConsumeQty??0;


        //                    var stockQty = Convert.ToString(row.StockQty);

        //                    if (stockQty == "0" || stockQty == "&nbsp;")
        //                    {
        //                        stockQty = "0";
        //                    }
        //                    else
        //                    {
        //                        stockQty = Convert.ToString(row.StockQty);
        //                    }
        //                    arr_v_stock_qty[i] = Convert.ToInt32(stockQty);



        //                    arr_v_consume_qty[i] = 0;


        //                    var lmConsumeQty = Convert.ToString(row.ConsumeLmQty);

        //                    if (lmConsumeQty == "" || lmConsumeQty == "&nbsp;")
        //                    {
        //                        lmConsumeQty = "0";
        //                    }
        //                    else
        //                    {
        //                        lmConsumeQty = Convert.ToString(row.ConsumeLmQty);
        //                    }
        //                    arr_v_lm_consume_qty[i] = (int?)row.ConsumeLmQty ?? 0;

        //                    arr_v_re_order_level_qty[i] = (int?)row.ReorderLblQty ?? 0;

        //                    i++;
        //                }

        //                ora_cmd.Parameters.Add("p_action_type", OracleDbType.Int32, action_type, ParameterDirection.Input);
        //                ora_cmd.Parameters.Add("p_store_no", OracleDbType.Varchar2, phrPurchaseRequisitionSave.StoreNo, ParameterDirection.Input);
        //                ora_cmd.Parameters.Add("p_to_store_no", OracleDbType.Varchar2, phrPurchaseRequisitionSave.ToStoreNo, ParameterDirection.Input);
        //                ora_cmd.Parameters.Add("p_supplier_no", OracleDbType.Varchar2, phrPurchaseRequisitionSave.SupplierNO, ParameterDirection.Input);
        //                ora_cmd.Parameters.Add("p_pur_req_type", OracleDbType.Varchar2, phrPurchaseRequisitionSave.PurReqType, ParameterDirection.Input);
        //                ora_cmd.Parameters.Add("p_expected_date", OracleDbType.Date, null, ParameterDirection.Input);
        //                ora_cmd.Parameters.Add("p_descr", OracleDbType.Varchar2, phrPurchaseRequisitionSave.Description, ParameterDirection.Input); ;

        //                OracleParameter arr_p_item_no = new OracleParameter("p_item_no", OracleDbType.Varchar2, arr_v_item_no.Length, arr_v_item_no, ParameterDirection.Input);
        //                arr_p_item_no.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        //                ora_cmd.Parameters.Add(arr_p_item_no);

        //                OracleParameter arr_p_purchase_price = new OracleParameter("p_purchase_price", OracleDbType.Decimal, arr_v_purchase_price.Length, arr_v_purchase_price, ParameterDirection.Input);
        //                arr_p_purchase_price.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        //                ora_cmd.Parameters.Add(arr_p_purchase_price);

        //                OracleParameter arr_p_purchase_qty = new OracleParameter("p_pur_req_qty", OracleDbType.Decimal, arr_v_purchase_qty.Length, arr_v_purchase_qty, ParameterDirection.Input);
        //                arr_p_purchase_qty.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        //                ora_cmd.Parameters.Add(arr_p_purchase_qty);

        //                OracleParameter arr_p_purchase_box_qty = new OracleParameter("p_pur_req_box_qty", OracleDbType.Decimal, arr_v_purchase_box_qty.Length, arr_v_purchase_box_qty, ParameterDirection.Input);
        //                arr_p_purchase_box_qty.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        //                ora_cmd.Parameters.Add(arr_p_purchase_box_qty);

        //                OracleParameter arr_p_sales_price = new OracleParameter("p_sales_price", OracleDbType.Decimal, arr_v_sales_price.Length, arr_v_sales_price, ParameterDirection.Input);
        //                arr_p_sales_price.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        //                ora_cmd.Parameters.Add(arr_p_sales_price);

        //                OracleParameter arr_p_stock_qty = new OracleParameter("p_stock_qty", OracleDbType.Int32, arr_v_stock_qty.Length, arr_v_stock_qty, ParameterDirection.Input);
        //                arr_p_stock_qty.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        //                ora_cmd.Parameters.Add(arr_p_stock_qty);

        //                OracleParameter arr_p_consume_qty = new OracleParameter("p_consume_qty", OracleDbType.Int32, arr_v_consume_qty.Length, arr_v_consume_qty, ParameterDirection.Input);
        //                arr_p_consume_qty.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        //                ora_cmd.Parameters.Add(arr_p_consume_qty);

        //                OracleParameter arr_p_lm_consume_qty = new OracleParameter("p_consume_lm_qty", OracleDbType.Int32, arr_v_lm_consume_qty.Length, arr_v_lm_consume_qty, ParameterDirection.Input);
        //                arr_p_lm_consume_qty.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        //                ora_cmd.Parameters.Add(arr_p_lm_consume_qty);

        //                OracleParameter arr_p_re_order_level_qty = new OracleParameter("p_re_order_level_qty", OracleDbType.Int32, arr_v_re_order_level_qty.Length, arr_v_re_order_level_qty, ParameterDirection.Input);
        //                arr_p_re_order_level_qty.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        //                ora_cmd.Parameters.Add(arr_p_re_order_level_qty);


        //                ora_cmd.Parameters.Add("p_item_index", OracleDbType.Int32, size, ParameterDirection.Input);

        //                ora_cmd.Parameters.Add("p_entryby", OracleDbType.Int32, phrPurchaseRequisitionSave.EntryBy, ParameterDirection.Input);
        //                ora_cmd.Parameters.Add("p_cid", OracleDbType.Int32, phrPurchaseRequisitionSave.CID, ParameterDirection.Input);
        //                ora_cmd.Parameters.Add("p_gid", OracleDbType.Int32, phrPurchaseRequisitionSave.GID, ParameterDirection.Input);
        //                ora_cmd.Parameters.Add("p_entryip ", OracleDbType.Varchar2, phrPurchaseRequisitionSave.EntryIp, ParameterDirection.Input);

        //                ora_cmd.Parameters.Add("p_phr_pur_req_no", OracleDbType.Varchar2, 300, purchaseRequisitionNo, ParameterDirection.InputOutput);
        //                ora_cmd.Parameters.Add("p_phr_pur_req_id", OracleDbType.Varchar2, 500, purchaseRequisitionId, ParameterDirection.InputOutput);

        //                ora_cmd.Parameters.Add("p_error", OracleDbType.Varchar2, 3000).Direction = ParameterDirection.Output;
        //                ora_cmd.Parameters.Add("p_action", OracleDbType.Int32, 30).Direction = ParameterDirection.Output;

        //                ora_cmd.ExecuteNonQuery();
        //                oracleConnection.Close();

        //                string p_phr_pur_req_no = ora_cmd.Parameters["p_phr_pur_req_no"].Value.ToString();
        //                string p_phr_pur_req_id = ora_cmd.Parameters["p_phr_pur_req_id"].Value.ToString();
        //                string p_error = ora_cmd.Parameters["p_error"].Value.ToString();
        //                Int32 p_action = Convert.ToInt32(ora_cmd.Parameters["p_action"].Value.ToString());


        //                return AddPhrPurchaseRequisitionJson(p_phr_pur_req_no);

        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        //private static String AddPhrPurchaseRequisitionJson(string p_phr_pur_req_no)
        //{
        //    string JSONresult;
        //    JSONresult = JsonConvert.SerializeObject(p_phr_pur_req_no);
        //    return JSONresult;
        //}

        ////public async Task<string> SuppAddPhrPurchaseRequisition(PhrPurRequisitionBtnSuppAdd phrPurRequisitionBtnSuppAdd)
        ////{

        ////    try
        ////    {
        ////        using (OracleConnection conn = new OracleConnection(await _connection.getDBConn()))
        ////        {
        ////            OracleCommand objCmd = new OracleCommand();
        ////            objCmd.Connection = conn;
        ////            conn.Open();

        ////            objCmd.CommandText = "pkg_pharmacy.sp_phr_pur_req_supp_item_add";
        ////            objCmd.BindByName = true;
        ////            objCmd.CommandType = CommandType.StoredProcedure;

        ////            objCmd.Parameters.Add("p_gid", OracleDbType.Int32, phrPurRequisitionBtnSuppAdd.GID, ParameterDirection.Input);
        ////            objCmd.Parameters.Add("p_cid", OracleDbType.Int32, phrPurRequisitionBtnSuppAdd.CID, ParameterDirection.Input);

        ////            objCmd.Parameters.Add("p_supp_quot_flag", OracleDbType.Varchar2, phrPurRequisitionBtnSuppAdd.SuppQuotFlag, ParameterDirection.Input);
        ////            objCmd.Parameters.Add("p_re_order_flag", OracleDbType.Varchar2, phrPurRequisitionBtnSuppAdd.ReOrderFlag, ParameterDirection.Input);
        ////            objCmd.Parameters.Add("p_supplier_no", OracleDbType.Varchar2, phrPurRequisitionBtnSuppAdd.SupplierNo, ParameterDirection.Input);
        ////            objCmd.Parameters.Add("p_store_no", OracleDbType.Varchar2, phrPurRequisitionBtnSuppAdd.StoreNo, ParameterDirection.Input);

        ////            var p_item_id = objCmd.Parameters.Add("p_item_id", OracleDbType.Varchar2);
        ////            p_item_id.Direction = ParameterDirection.Output;
        ////            p_item_id.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        ////            p_item_id.Size = 1000;
        ////            p_item_id.ArrayBindSize = Enumerable.Repeat(1000, 2000).ToArray();
        ////            p_item_id.ArrayBindStatus = Enumerable.Repeat(OracleParameterStatus.Success, 1000).ToArray();

        ////            var p_item_name = objCmd.Parameters.Add("p_item_name", OracleDbType.Varchar2);
        ////            p_item_name.Direction = ParameterDirection.Output;
        ////            p_item_name.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        ////            p_item_name.Size = 1000;
        ////            p_item_name.ArrayBindSize = Enumerable.Repeat(1000, 2000).ToArray();
        ////            p_item_name.ArrayBindStatus = Enumerable.Repeat(OracleParameterStatus.Success, 1000).ToArray();

        ////            var p_generic_name = objCmd.Parameters.Add("p_generic_name", OracleDbType.Varchar2);
        ////            p_generic_name.Direction = ParameterDirection.Output;
        ////            p_generic_name.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        ////            p_generic_name.Size = 1000;
        ////            p_generic_name.ArrayBindSize = Enumerable.Repeat(1000, 2000).ToArray();
        ////            p_generic_name.ArrayBindStatus = Enumerable.Repeat(OracleParameterStatus.Success, 1000).ToArray();

        ////            var p_unit_name = objCmd.Parameters.Add("p_unit_name", OracleDbType.Varchar2);
        ////            p_unit_name.Direction = ParameterDirection.Output;
        ////            p_unit_name.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        ////            p_unit_name.Size = 1000;
        ////            p_unit_name.ArrayBindSize = Enumerable.Repeat(1000, 2000).ToArray();
        ////            p_unit_name.ArrayBindStatus = Enumerable.Repeat(OracleParameterStatus.Success, 1000).ToArray();

        ////            var p_box_qty = objCmd.Parameters.Add("p_box_qty", OracleDbType.Varchar2);
        ////            p_box_qty.Direction = ParameterDirection.Output;
        ////            p_box_qty.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        ////            p_box_qty.Size = 1000;
        ////            p_box_qty.ArrayBindSize = Enumerable.Repeat(1000, 2000).ToArray();
        ////            p_box_qty.ArrayBindStatus = Enumerable.Repeat(OracleParameterStatus.Success, 1000).ToArray();

        ////            var p_re_order_level = objCmd.Parameters.Add("p_re_order_level", OracleDbType.Varchar2);
        ////            p_re_order_level.Direction = ParameterDirection.Output;
        ////            p_re_order_level.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        ////            p_re_order_level.Size = 1000;
        ////            p_re_order_level.ArrayBindSize = Enumerable.Repeat(1000, 2000).ToArray();
        ////            p_re_order_level.ArrayBindStatus = Enumerable.Repeat(OracleParameterStatus.Success, 1000).ToArray();

        ////            var p_stock_qty = objCmd.Parameters.Add("p_stock_qty", OracleDbType.Varchar2);
        ////            p_stock_qty.Direction = ParameterDirection.Output;
        ////            p_stock_qty.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        ////            p_stock_qty.Size = 1000;
        ////            p_stock_qty.ArrayBindSize = Enumerable.Repeat(1000, 2000).ToArray();
        ////            p_stock_qty.ArrayBindStatus = Enumerable.Repeat(OracleParameterStatus.Success, 1000).ToArray();

        ////            var p_consume_qty = objCmd.Parameters.Add("p_consume_qty", OracleDbType.Varchar2);
        ////            p_consume_qty.Direction = ParameterDirection.Output;
        ////            p_consume_qty.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        ////            p_consume_qty.Size = 1000;
        ////            p_consume_qty.ArrayBindSize = Enumerable.Repeat(1000, 2000).ToArray();
        ////            p_consume_qty.ArrayBindStatus = Enumerable.Repeat(OracleParameterStatus.Success, 1000).ToArray();

        ////            var p_consume_box_qty = objCmd.Parameters.Add("p_consume_box_qty", OracleDbType.Varchar2);
        ////            p_consume_box_qty.Direction = ParameterDirection.Output;
        ////            p_consume_box_qty.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        ////            p_consume_box_qty.Size = 1000;
        ////            p_consume_box_qty.ArrayBindSize = Enumerable.Repeat(1000, 2000).ToArray();
        ////            p_consume_box_qty.ArrayBindStatus = Enumerable.Repeat(OracleParameterStatus.Success, 1000).ToArray();


        ////            var p_item_box_qty = objCmd.Parameters.Add("p_item_box_qty", OracleDbType.Varchar2);
        ////            p_item_box_qty.Direction = ParameterDirection.Output;
        ////            p_item_box_qty.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        ////            p_item_box_qty.Size = 1000;
        ////            p_item_box_qty.ArrayBindSize = Enumerable.Repeat(1000, 2000).ToArray();
        ////            p_item_box_qty.ArrayBindStatus = Enumerable.Repeat(OracleParameterStatus.Success, 1000).ToArray();

        ////            var p_item_qty = objCmd.Parameters.Add("p_item_qty", OracleDbType.Varchar2);
        ////            p_item_qty.Direction = ParameterDirection.Output;
        ////            p_item_qty.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        ////            p_item_qty.Size = 1000;
        ////            p_item_qty.ArrayBindSize = Enumerable.Repeat(1000, 2000).ToArray();
        ////            p_item_qty.ArrayBindStatus = Enumerable.Repeat(OracleParameterStatus.Success, 1000).ToArray();

        ////            var p_purchase_price = objCmd.Parameters.Add("p_purchase_price", OracleDbType.Varchar2);
        ////            p_purchase_price.Direction = ParameterDirection.Output;
        ////            p_purchase_price.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        ////            p_purchase_price.Size = 1000;
        ////            p_purchase_price.ArrayBindSize = Enumerable.Repeat(1000, 2000).ToArray();
        ////            p_purchase_price.ArrayBindStatus = Enumerable.Repeat(OracleParameterStatus.Success, 1000).ToArray();

        ////            var p_total_amount = objCmd.Parameters.Add("p_total_amount", OracleDbType.Varchar2);
        ////            p_total_amount.Direction = ParameterDirection.Output;
        ////            p_total_amount.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        ////            p_total_amount.Size = 1000;
        ////            p_total_amount.ArrayBindSize = Enumerable.Repeat(1000, 2000).ToArray();
        ////            p_total_amount.ArrayBindStatus = Enumerable.Repeat(OracleParameterStatus.Success, 1000).ToArray();

        ////            var p_sales_price = objCmd.Parameters.Add("p_sales_price", OracleDbType.Varchar2);
        ////            p_sales_price.Direction = ParameterDirection.Output;
        ////            p_sales_price.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        ////            p_sales_price.Size = 1000;
        ////            p_sales_price.ArrayBindSize = Enumerable.Repeat(1000, 2000).ToArray();
        ////            p_sales_price.ArrayBindStatus = Enumerable.Repeat(OracleParameterStatus.Success, 1000).ToArray();

        ////            var p_profit_amt = objCmd.Parameters.Add("p_profit_amt", OracleDbType.Varchar2);
        ////            p_profit_amt.Direction = ParameterDirection.Output;
        ////            p_profit_amt.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        ////            p_profit_amt.Size = 1000;
        ////            p_profit_amt.ArrayBindSize = Enumerable.Repeat(1000, 2000).ToArray();
        ////            p_profit_amt.ArrayBindStatus = Enumerable.Repeat(OracleParameterStatus.Success, 1000).ToArray();

        ////            var p_profit_pct = objCmd.Parameters.Add("p_profit_pct", OracleDbType.Varchar2);
        ////            p_profit_pct.Direction = ParameterDirection.Output;
        ////            p_profit_pct.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        ////            p_profit_pct.Size = 1000;
        ////            p_profit_pct.ArrayBindSize = Enumerable.Repeat(1000, 2000).ToArray();
        ////            p_profit_pct.ArrayBindStatus = Enumerable.Repeat(OracleParameterStatus.Success, 1000).ToArray();

        ////            var p_item_no = objCmd.Parameters.Add("p_item_no", OracleDbType.Varchar2);
        ////            p_item_no.Direction = ParameterDirection.Output;
        ////            p_item_no.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        ////            p_item_no.Size = 1000;
        ////            p_item_no.ArrayBindSize = Enumerable.Repeat(1000, 2000).ToArray();
        ////            p_item_no.ArrayBindStatus = Enumerable.Repeat(OracleParameterStatus.Success, 1000).ToArray();

        ////            objCmd.ExecuteNonQuery();
        ////            conn.Close();

        ////            Oracle.ManagedDataAccess.Types.OracleString[] oraostat_msg_x = (Oracle.ManagedDataAccess.Types.OracleString[])(objCmd.Parameters[6].Value);
        ////            Oracle.ManagedDataAccess.Types.OracleString[] oraostat_msg_x1 = (Oracle.ManagedDataAccess.Types.OracleString[])(objCmd.Parameters[7].Value);
        ////            Oracle.ManagedDataAccess.Types.OracleString[] oraostat_msg_x2 = (Oracle.ManagedDataAccess.Types.OracleString[])(objCmd.Parameters[8].Value);
        ////            Oracle.ManagedDataAccess.Types.OracleString[] oraostat_msg_x3 = (Oracle.ManagedDataAccess.Types.OracleString[])(objCmd.Parameters[9].Value);
        ////            Oracle.ManagedDataAccess.Types.OracleString[] oraostat_msg_x4 = (Oracle.ManagedDataAccess.Types.OracleString[])(objCmd.Parameters[10].Value);
        ////            Oracle.ManagedDataAccess.Types.OracleString[] oraostat_msg_x5 = (Oracle.ManagedDataAccess.Types.OracleString[])(objCmd.Parameters[11].Value);
        ////            Oracle.ManagedDataAccess.Types.OracleString[] oraostat_msg_x6 = (Oracle.ManagedDataAccess.Types.OracleString[])(objCmd.Parameters[12].Value);

        ////            Oracle.ManagedDataAccess.Types.OracleString[] oraostat_msg_x7 = (Oracle.ManagedDataAccess.Types.OracleString[])(objCmd.Parameters[13].Value);
        ////            Oracle.ManagedDataAccess.Types.OracleString[] oraostat_msg_x8 = (Oracle.ManagedDataAccess.Types.OracleString[])(objCmd.Parameters[14].Value);
        ////            Oracle.ManagedDataAccess.Types.OracleString[] oraostat_msg_x9 = (Oracle.ManagedDataAccess.Types.OracleString[])(objCmd.Parameters[15].Value);
        ////            Oracle.ManagedDataAccess.Types.OracleString[] oraostat_msg_x10 = (Oracle.ManagedDataAccess.Types.OracleString[])(objCmd.Parameters[16].Value);
        ////            Oracle.ManagedDataAccess.Types.OracleString[] oraostat_msg_x11 = (Oracle.ManagedDataAccess.Types.OracleString[])(objCmd.Parameters[17].Value);

        ////            Oracle.ManagedDataAccess.Types.OracleString[] oraostat_msg_x12 = (Oracle.ManagedDataAccess.Types.OracleString[])(objCmd.Parameters[18].Value);
        ////            Oracle.ManagedDataAccess.Types.OracleString[] oraostat_msg_x13 = (Oracle.ManagedDataAccess.Types.OracleString[])(objCmd.Parameters[19].Value);
        ////            Oracle.ManagedDataAccess.Types.OracleString[] oraostat_msg_x14 = (Oracle.ManagedDataAccess.Types.OracleString[])(objCmd.Parameters[20].Value);
        ////            Oracle.ManagedDataAccess.Types.OracleString[] oraostat_msg_x15 = (Oracle.ManagedDataAccess.Types.OracleString[])(objCmd.Parameters[21].Value);
        ////            Oracle.ManagedDataAccess.Types.OracleString[] oraostat_msg_x16 = (Oracle.ManagedDataAccess.Types.OracleString[])(objCmd.Parameters[22].Value);

        ////            String[,] item = new string[oraostat_msg_x.Length, 17];

        ////            for (int i = 0; i < oraostat_msg_x.Length; i++)
        ////            {
        ////                for (int j = 0; j < 23; j++)
        ////                {
        ////                    item[i, 0] = Convert.ToString(oraostat_msg_x[i].Value);
        ////                    item[i, 1] = Convert.ToString(oraostat_msg_x1[i].Value);
        ////                    item[i, 2] = Convert.ToString(oraostat_msg_x2[i].Value);
        ////                    item[i, 3] = Convert.ToString(oraostat_msg_x3[i].Value);
        ////                    item[i, 4] = Convert.ToString(oraostat_msg_x4[i].Value);
        ////                    item[i, 5] = Convert.ToString(oraostat_msg_x5[i].Value);
        ////                    item[i, 6] = Convert.ToString(oraostat_msg_x6[i].Value);
        ////                    item[i, 7] = Convert.ToString(oraostat_msg_x7[i].Value);
        ////                    item[i, 8] = Convert.ToString(oraostat_msg_x8[i].Value);
        ////                    item[i, 9] = Convert.ToString(oraostat_msg_x9[i].Value);
        ////                    item[i, 10] = Convert.ToString(oraostat_msg_x10[i].Value);
        ////                    item[i, 11] = Convert.ToString(oraostat_msg_x11[i].Value);

        ////                    item[i, 12] = Convert.ToString(oraostat_msg_x12[i].Value);
        ////                    item[i, 13] = Convert.ToString(oraostat_msg_x13[i].Value);
        ////                    item[i, 14] = Convert.ToString(oraostat_msg_x14[i].Value);
        ////                    item[i, 15] = Convert.ToString(oraostat_msg_x15[i].Value);
        ////                    item[i, 16] = Convert.ToString(oraostat_msg_x16[i].Value);
        ////                }
        ////            }


        ////        }
        ////    }
        ////    catch (Exception)
        ////    {
        ////        throw;
        ////    }
        ////}

        //public async Task<string> ApprovePhrPurchaseRequisition(PhrPurRequisitionApprove phrPurRequisitionApprove)
        //{
        //    OracleConnection oracleConnection = new OracleConnection(await _connection.getDBConn());
        //    try
        //    {
        //        using (oracleConnection = new OracleConnection(await _connection.getDBConn()))
        //        {

        //            oracleConnection.Open();
        //            using (OracleCommand ora_cmd = new OracleCommand("pkg_pharmacy.sp_phr_pur_req_approve", oracleConnection))
        //            {
        //                ora_cmd.BindByName = true;
        //                ora_cmd.CommandType = CommandType.StoredProcedure;


        //                ora_cmd.Parameters.Add("p_action_type", OracleDbType.Int32, 1, ParameterDirection.Input);
        //                ora_cmd.Parameters.Add("p_phr_pur_req_no", OracleDbType.Int64, 300, phrPurRequisitionApprove.PhrPurRequisitionNo, ParameterDirection.Input);

        //                ora_cmd.Parameters.Add("p_entryby", OracleDbType.Int32, phrPurRequisitionApprove.EntryBy, ParameterDirection.Input);
        //                ora_cmd.Parameters.Add("p_cid", OracleDbType.Int32, phrPurRequisitionApprove.CID, ParameterDirection.Input);
        //                ora_cmd.Parameters.Add("p_gid", OracleDbType.Int32, phrPurRequisitionApprove.GID, ParameterDirection.Input);
        //                ora_cmd.Parameters.Add("p_entryip ", OracleDbType.Varchar2, phrPurRequisitionApprove.EntryIp, ParameterDirection.Input);

        //                ora_cmd.Parameters.Add("p_error", OracleDbType.Varchar2, 3000).Direction = ParameterDirection.Output;
        //                ora_cmd.Parameters.Add("p_action", OracleDbType.Int32, 30).Direction = ParameterDirection.Output;

        //                ora_cmd.ExecuteNonQuery();
        //                oracleConnection.Close();

        //                string? p_error = ora_cmd.Parameters["p_error"].Value.ToString();
        //                string? p_action = ora_cmd.Parameters["p_action"].Value.ToString();

        //                string?[] accessValue = { p_error, p_action };
        //                return ApprovePhrPurchaseRequisitionJson(accessValue);

        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //private string ApprovePhrPurchaseRequisitionJson(Array accessValue)
        //{
        //    string JSONresult;
        //    JSONresult = JsonConvert.SerializeObject(accessValue);
        //    return JSONresult;
        //}

        //public async Task<string> UnApprovePhrPurchaseRequisition(PhrPurRequisitionUnApprove phrPurRequisitionUnApprove)
        //{
        //    OracleConnection oracleConnection = new OracleConnection(await _connection.getDBConn());
        //    try
        //    {
        //        using (oracleConnection = new OracleConnection(await _connection.getDBConn()))
        //        {

        //            oracleConnection.Open();
        //            using (OracleCommand ora_cmd = new OracleCommand("pkg_pharmacy.sp_phr_pur_req_approve", oracleConnection))
        //            {
        //                ora_cmd.BindByName = true;
        //                ora_cmd.CommandType = CommandType.StoredProcedure;


        //                ora_cmd.Parameters.Add("p_action_type", OracleDbType.Int32, 2, ParameterDirection.Input);
        //                ora_cmd.Parameters.Add("p_phr_pur_req_no", OracleDbType.Int64, 300, phrPurRequisitionUnApprove.PhrPurRequisitionNo, ParameterDirection.Input);

        //                ora_cmd.Parameters.Add("p_entryby", OracleDbType.Int32, phrPurRequisitionUnApprove.EntryBy, ParameterDirection.Input);
        //                ora_cmd.Parameters.Add("p_cid", OracleDbType.Int32, phrPurRequisitionUnApprove.CID, ParameterDirection.Input);
        //                ora_cmd.Parameters.Add("p_gid", OracleDbType.Int32, phrPurRequisitionUnApprove.GID, ParameterDirection.Input);
        //                ora_cmd.Parameters.Add("p_entryip ", OracleDbType.Varchar2, phrPurRequisitionUnApprove.EntryIp, ParameterDirection.Input);

        //                ora_cmd.Parameters.Add("p_error", OracleDbType.Varchar2, 3000).Direction = ParameterDirection.Output;
        //                ora_cmd.Parameters.Add("p_action", OracleDbType.Int32, 30).Direction = ParameterDirection.Output;

        //                ora_cmd.ExecuteNonQuery();
        //                oracleConnection.Close();

        //                string? p_error = ora_cmd.Parameters["p_error"].Value.ToString();
        //                string? p_action = ora_cmd.Parameters["p_action"].Value.ToString();

        //                string?[] accessValue = { p_error, p_action };
        //                return UnApprovePhrPurchaseRequisitionJson(accessValue);

        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //private string UnApprovePhrPurchaseRequisitionJson(string?[] accessValue)
        //{
        //    string JSONresult;
        //    JSONresult = JsonConvert.SerializeObject(accessValue);
        //    return JSONresult;
        //}

        //public async Task<string> CancelPhrPurchaseRequisition(PhrPurRequisitionCancel phrPurRequisitionCancel)
        //{
        //    OracleConnection oracleConnection = new OracleConnection(await _connection.getDBConn());
        //    try
        //    {
        //        using (oracleConnection = new OracleConnection(await _connection.getDBConn()))
        //        {

        //            oracleConnection.Open();
        //            using (OracleCommand ora_cmd = new OracleCommand("pkg_pharmacy.sp_phr_pur_req_approve", oracleConnection))
        //            {
        //                ora_cmd.BindByName = true;
        //                ora_cmd.CommandType = CommandType.StoredProcedure;


        //                ora_cmd.Parameters.Add("p_action_type", OracleDbType.Int32, 3, ParameterDirection.Input);
        //                ora_cmd.Parameters.Add("p_phr_pur_req_no", OracleDbType.Int64, 300, phrPurRequisitionCancel.PhrPurRequisitionNo, ParameterDirection.Input);

        //                ora_cmd.Parameters.Add("p_entryby", OracleDbType.Int32, phrPurRequisitionCancel.EntryBy, ParameterDirection.Input);
        //                ora_cmd.Parameters.Add("p_cid", OracleDbType.Int32, phrPurRequisitionCancel.CID, ParameterDirection.Input);
        //                ora_cmd.Parameters.Add("p_gid", OracleDbType.Int32, phrPurRequisitionCancel.GID, ParameterDirection.Input);
        //                ora_cmd.Parameters.Add("p_entryip ", OracleDbType.Varchar2, phrPurRequisitionCancel.EntryIp, ParameterDirection.Input);

        //                ora_cmd.Parameters.Add("p_error", OracleDbType.Varchar2, 3000).Direction = ParameterDirection.Output;
        //                ora_cmd.Parameters.Add("p_action", OracleDbType.Int32, 30).Direction = ParameterDirection.Output;

        //                ora_cmd.ExecuteNonQuery();
        //                oracleConnection.Close();

        //                string? p_error = ora_cmd.Parameters["p_error"].Value.ToString();
        //                string? p_action = ora_cmd.Parameters["p_action"].Value.ToString();

        //                string?[] accessValue = { p_error, p_action };
        //                return CancelPhrPurchaseRequisitionJson(accessValue);

        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //private string CancelPhrPurchaseRequisitionJson(string?[] accessValue)
        //{
        //    string JSONresult;
        //    JSONresult = JsonConvert.SerializeObject(accessValue);
        //    return JSONresult;
        //}
    }
}
