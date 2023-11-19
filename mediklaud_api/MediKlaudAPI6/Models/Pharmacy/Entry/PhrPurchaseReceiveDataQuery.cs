using mediklaud_api.Models;

namespace mediklaud_api.FormQuery.Pharmacy
{
    public class GetcmbStoreListQuery
    {
        public int? GID { get; set; }
        public int? CID { get; set; }
        public int? UserNo { get; set; }
    }

    public class GetAllListQuery
    {
        public int? GID { get; set; }
        public int? CID { get; set; }
    }

    public class GetTransationGridDataListQuery
    {
        public int? GID { get; set; }
        public int? CID { get; set; }
        public int? approve_flag { get; set; }
        public int? store_no { get; set; }
        public int? supplier_no { get; set; }
        public string? phr_trn_id { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
    }

    public class GetMasterDataAndItemGridDataListQuery
    {
        public int? GID { get; set; }
        public int? CID { get; set; }
        public long? phr_trn_no { get; set; }
    }

    public class GetcmbItemListQuery
    {
        public int? GID { get; set; }
        public int? CID { get; set; }
        public string? supp_quot_apply_flag { get; set; }
        public string? store_no { get; set; }
        public string? item_no { get; set; }
        public string? supplier_no { get; set; }
    }

    public class Transactions
    {
        public string? Action_type { get; set; }
        public string? trntype_no { get; set; }
        public string? curr_store_no { get; set; }
        public string? trn_store_no { get; set; }
        public string? phr_pur_ord_no { get; set; }
        public string? phr_pur_ord_id { get; set; }
        public string? pur_supplier_no { get; set; }
        public string? supp_invoice_no { get; set; }
        public DateTime supp_invoice_date { get; set; }
        public DateTime supp_exp_pay_date { get; set; }
        public string? supp_pay_type_no { get; set; }
        public string? phr_req_no { get; set; }
        public string? phr_req_id { get; set; }
        public string? ref_trn_no { get; set; }
        public string? ref_trn_id { get; set; }
        public string? descr { get; set; }

        public List<TranArr>? TranArr { get; set; }

        public int? item_index { get; set; }
        public int? entryby { get; set; }
        public int? CID { get; set; }
        public int? GID { get; set; }
        public string? entryip { get; set; }

        public string? phr_trn_no { get; set; }
        public string? phr_trn_id { get; set; }
    }

    public class TranArr
    {
        public string? item_no { get; set; }
        public int? item_qty { get; set; }
        public int? bonus_qty { get; set; }
        public decimal purchase_price { get; set; }
        public decimal sale_price { get; set; }
        public string? supplier_no { get; set; }
        public string? batch_number { get; set; }
        public string? exp_date { get; set; }
        public decimal discount_amt { get; set; }
        public decimal vat_amt { get; set; }
        public decimal tax_amt { get; set; }
        public string? phr_reqdtl_no { get; set; }
        public int? phr_req_qty { get; set; }
        public string? phr_pur_orddtl_no { get; set; }
        public int? phr_pur_ord_qty { get; set; }
        public string? ref_trndtl_no { get; set; }
        public int? ref_trndtl_qty { get; set; }
        public int? stock_qty { get; set; }
    }

    public class ApproveUnapproveCancelQuery
    {
        public int? action_type { get; set; }
        public int? curr_store_no { get; set; }
        public string? phr_trn_no { get; set; }
        public int? trntype_no { get; set; }

        public int? entryby { get; set; }
        public int? CID { get; set; }
        public int? GID { get; set; }
        public string? entryip { get; set; }
    }
    public class FileUploadQuery
    {
        public string? Action_type { get; set; }
        public string? phr_trn_no { get; set; }

        public List<FillUpArr>? FillUpArr { get; set; }

        public int? item_index { get; set; }
        public int? entryby { get; set; }
        public int? CID { get; set; }
        public int? GID { get; set; }
        public string? entryip { get; set; }
    }

    public class FillUpArr
    {
        public string? file_path { get; set; }
        public string? file_name { get; set; }
    }

    public class GetFileUploadedDataQuery
    {
        public int? GID { get; set; }
        public int? CID { get; set; }
        public long? phr_trn_no { get; set; }
    }
}
