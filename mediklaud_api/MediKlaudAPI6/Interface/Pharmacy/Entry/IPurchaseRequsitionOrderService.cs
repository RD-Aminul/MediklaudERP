using mediklaud_api.Models.Pharmacy.Entry;

namespace mediklaud_api.Interface.Pharmacy.Entry
{
    public interface IPurchaseRequsitionOrderService
    {
        Task<string> GetSerStoreList(PurReqOrderStoreList purReqOrderStoreList);
        Task<string> GetStoreList(PurReqOrderStoreList purReqOrderStoreList);
        Task<string> GetForStoreList(PurReqOrderStoreList purReqOrderStoreList);
        Task<string> GetSerSupplierList(CommonGID_CID_For_PurReqOrd commonGID_CID_For_PurReqOrd);
        Task<string> GetSupplierList(CommonGID_CID_For_PurReqOrd commonGID_CID_For_PurReqOrd);
        Task<string> GetTransactionList(TransactionListForPhrReqOrd transactionListForPhrReqOrd);
    }
}
