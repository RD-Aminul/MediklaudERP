namespace mediklaud_api.FormQuery.Pharmacy.Entry
{
    public class Common_Gid_Cid_For_Requisition
    {
        public int? GID { get; set; }
        public int? CID { get; set; }
    }

    public class FromStorList
    {
        public int? GID { get; set; }
        public int? CID { get; set; }
        public int? UserNo { get; set; }
    }
    public class ToStorList
    {
        public int? GID { get; set; }
        public int? CID { get; set; }
        public int? TypeNo { get; set; }
    }

    public class PhrRequisitionList
    {
        public int? GID { get; set; }
        public int? CID { get; set; }
        public int? ApproveFlag { get; set; }
        public string? StoreNo { get; set; }
        public string? ToStoreNo { get; set; }
        public string? SupplierNo { get; set; }
        public string? PurchaseRequisitionId { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class ItemList
    {
        public int? GID { get; set; }
        public int? CID { get; set; }
        public string? SupplierNo { get; set; }
        public string? SuppQuotFlag { get; set; }
    }

    public class SuppItemList
    {
        public int? GID { get; set; }
        public int? CID { get; set; }
        public string? SuppQuotFalag { get; set; }
        public string? ReOrderFlag { get; set; }
        public string? SupplierNo { get; set; }
        public string? StoreNo { get; set; }

    }

    //public class GetCmbItemSelectedListQuery
    //{
    //    public int? GID { get; set; }
    //    public int? CID { get; set; }
    //    public string? SupplierNo { get; set; }
    //    public string? StoreNo { get; set; }
    //    public string? ItemNo { get; set; }
    //    public string? SuppQuotFlag { get; set; }
    //}

    //public class PhrPurchaseRequisitionSave
    //{
    //    public string? ActionType { get; set; }
    //    public string? StoreNo { get; set; }
    //    public int? ToStoreNo { get; set; }
    //    public int? SupplierNO { get; set; }
    //    public string? PurReqType { get; set; }

    //    public DateTime ExpectedDate { get; set; }
    //    public string? Description { get; set; }
    //    public string? TotalAmount { get; set; }

    //    public int? ItemIndex { get; set; }

    //    public int? EntryBy { get; set; }
    //    public int? GID { get; set; }
    //    public int? CID { get; set; }
    //    public string? EntryIp { get; set; }

    //    public string? PhrPurReqNO { get; set; }
    //    public string? PhrPurReqId { get; set; }

    //    public List<RequisitionArray>? RequisitionArray { get; set; }
    //}

    //public class RequisitionArray
    //{
    //    public string? ItemNo { get; set; }
    //    public decimal PurchasePrice { get; set; }
    //    public decimal PurchaseQty { get; set; }
    //    public decimal PurchaseBoxQty { get; set; }

    //    public decimal? SalesPrice { get; set; }
    //    public int? StockQty { get; set; }
    //    public int? ConsumeQty { get; set; }
    //    public int? ReorderLblQty { get; set; }
    //    public int? ConsumeLmQty { get; set; }

    //}

    //public class PhrPurRequisitionApprove
    //{
    //    public int? ActionType { get; set; }
    //    public int? PhrPurRequisitionNo { get; set; }
    //    public int EntryBy { get; set; }
    //    public int? CID { get; set; }
    //    public int? GID { get; set; }
    //    public string? EntryIp { get; set; }
    //}

    //public class PhrPurRequisitionUnApprove
    //{
    //    public int? ActionType { get; set; }
    //    public int? PhrPurRequisitionNo { get; set; }
    //    public int EntryBy { get; set; }
    //    public int? CID { get; set; }
    //    public int? GID { get; set; }
    //    public string? EntryIp { get; set; }
    //}

    //public class PhrPurRequisitionCancel
    //{
    //    public int? ActionType { get; set; }
    //    public int? PhrPurRequisitionNo { get; set; }
    //    public int EntryBy { get; set; }
    //    public int? CID { get; set; }
    //    public int? GID { get; set; }
    //    public string? EntryIp { get; set; }
    //}

    //public class PhrPurRequisitionBtnSuppAdd
    //{
    //    public int? GID { get; set; }
    //    public int? CID { get; set; }
    //    public string? SuppQuotFlag { get; set; }
    //    public string? ReOrderFlag { get; set; }
    //    public string? SupplierNo { get; set; }
    //    public string? StoreNo { get; set; }

    //    public List<RequisitionArraySupplier>? RequisitionArraySupplier { get; set; }        

    //}

    //public class RequisitionArraySupplier
    //{
    //    public string? ItemId { get; set; }
    //    public string? ItemName { get; set; }
    //    public string? GenericName { get; set; }
    //    public string? UnitName { get; set; }
    //    public string? BoxQty { get; set; }
    //    public string? ReOrderLevel { get; set; }
    //    public string? StockQty { get; set; }
    //    public string? ConsumeQty { get; set; }
    //    public string? ConsumeBoxQty { get; set; }

    //    public string? ItemBoxQty { get; set; }
    //    public string? ItemQty { get; set; }
    //    public string? PurchasePrice { get; set; }

    //    public string? TotalAmount { get; set; }
    //    public string? SalesPrice { get; set; }
    //    public string? ProfitAmt { get; set; }
    //    public string? ProfitPct { get; set; }
    //    public string? ItemNo { get; set; }

    //}
}


