namespace mediklaud_api.Models.Pharmacy.Entry
{
    public class CommonGID_CID_For_PurReqOrd
    {
        public int? GID { get; set; }
        public int? CID { get; set; }
    }

    public class PurReqOrderStoreList
    {
        public int? GID { get; set; }
        public int? CID { get; set; }
        public int? UserNo { get; set; }
    }

    public class TransactionListForPhrReqOrd
    {
        public int? GID { get; set; }
        public int? CID { get; set; }
        public string? ApproveFlag { get; set; }
        public string? StoreNo { get; set; }
        public string? SupplierNo { get; set; }
        public string? PhrPurOrdId { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
    }
}
