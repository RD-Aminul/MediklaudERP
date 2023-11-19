using mediklaud_api.Models;

namespace mediklaud_api.FormQuery.Pharmacy
{
    public class CommonGID_CID_For_GRN
    {
        public int? GID { get; set; }
        public int? CID { get; set; }
    }

    public class StoreList
    {
        public int? GID { get; set; }
        public int? CID { get; set; }
        public int? UserNo { get; set; }
    }

    public class OrderNumberList
    {
        public int? GID { get; set; }
        public int? CID { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? StoreNo { get; set; }
        public string? SupplierNo { get; set; }
    }

    public class OrderReceivedItemList
    {
        public int? GID { get; set; }
        public int? CID { get; set; }
        public string? phr_pur_ord_no { get; set; }
    }

    public class GetTransactionList
    {
        public int? GID { get; set; }
        public int? CID { get; set; }
        public string? ApproveFlag { get; set; }
        public string? StoreNo { get; set; }
        public string? SupplierNo { get; set; }
        public string? PhrTrnIDForSearch { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
    }

    public class TransactionSave
    {
        public string? Action_type { get; set; }
        public string? Curr_store_no { get; set; }
        public string? Trn_store_no { get; set; }
        public string? Phr_pur_ord_no { get; set; }
        public string? Phr_pur_ord_id { get; set; }
        public string? Pur_supplier_no { get; set; }
        public string? Supp_invoice_no { get; set; }
        public string? Supp_invoice_date { get; set; }
        public string? Supp_exp_pay_date { get; set; }
        public int? Supp_pay_type_no { get; set; }
        public string? Phr_req_no { get; set; }
        public string? Phr_req_id { get; set; }
        public string? Ref_trn_no { get; set; }
        public string? Ref_trn_id { get; set; }
        public string? Ret_adjustment_amt { get; set; }
        public string? Descr { get; set; }
        public int? Received_by { get; set; }

        public decimal? TotalAmount { get; set; }
        public decimal? TotalVat { get; set; }
        public decimal? TotalDiscount { get; set; }
        public decimal? NetAmount { get; set; }




        public List<TranArrList>? TranArrList { get; set; }

        public string? Entryby { get; set; }
        public int? CID { get; set; }
        public int? GID { get; set; }
        public string? Entryip { get; set; }
        public string? Phr_trn_no { get; set; }
        public string? Phr_trn_id { get; set; }

    }
    public class TranArrList
    {
       
        public string? BATCH_NUMBER { get; set; }
        public int? BONUS_QTY { get; set; }
        public int? BOX_QTY { get; set; }
        public string? CATEGORY_NAME { get; set; }
        public decimal? DISCOUNT_AMT { get; set; }
        public string? EXP_DATE { get; set; }

        public int? ITEM_BOX_QTY { get; set; }

        public string? ITEM_NAME { get; set; }
        public int? ITEM_NO { get; set; }
        public int? ITEM_QTY { get; set; }
        public int? ORDER_QTY { get; set; }
        public long? PHR_PUR_ORDDTL_NO { get; set; }
        public decimal? PROFIT_AMT { get; set; }
        public string? PROFIT_PCT { get; set; }
        public decimal? PURCHASE_PRICE { get; set; }
        public decimal? PUR_ORD_PRICE { get; set; }
        public int? PUR_VAT_FLAG { get; set; }
        public decimal? SALES_PRICE { get; set; }
        public int? SL_NO { get; set; }
        public decimal? TOTAL_AMOUNT { get; set; }
        public int? TOTAL_QTY { get; set; }
        public decimal? VAT_AMT { get; set; }





        //25
    }

    public class Transaction_acc
    {
        public string? Action_type { get; set; }
        public int? Phr_trn_no { get; set; }
        public int? Trntype_no { get; set; }

        public int? Entryby { get; set; }
        public int? CID { get; set; }
        public int? GID { get; set; }
        public string? Entryip { get; set; }
    }

    public class Approved_Unapproved
    {
        public int? Action_type { get; set; }
        public string? Curr_store_no { get; set; }
        public string? Phr_trn_no { get; set; }

        public int? Entryby { get; set; }
        public int? CID { get; set; }
        public int? GID { get; set; }
        public string? Entryip { get; set; }
    }

    public class TrnDataMaster
    {
        public int? CID { get; set; }
        public int? GID { get; set; }
        public string? Phr_trn_no { get; set; }
    }

    public class PhrOrdRecFileUploadQuery
    {
        public string? Action_type { get; set; }
        public string? Phr_trn_no { get; set; }

        public List<PhrOrdRecFillUpArr>? PhrOrdRecFillUpArr { get; set; }

        public int? Item_index { get; set; }
        public int? Entryby { get; set; }
        public int? CID { get; set; }
        public int? GID { get; set; }
        public string? Entryip { get; set; }
    }

    public class PhrOrdRecFillUpArr
    {
        public string? File_path { get; set; }
        public string? File_name { get; set; }
    }

    public class GetPhrOrdRecFileUploadedData
    {
        public int? GID { get; set; }
        public int? CID { get; set; }
        public long? phr_trn_no { get; set; }
    }
}
