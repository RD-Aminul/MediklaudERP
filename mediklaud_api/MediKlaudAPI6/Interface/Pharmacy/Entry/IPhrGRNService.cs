using mediklaud_api.FormQuery.Pharmacy;

namespace mediklaud_api.Interface.Pharmacy
{

    public interface IPhrGRNService
    {
        Task<string> GetConfigaration(CommonGID_CID_For_GRN commonGID_CID_For_GRN);
        Task<string> GetStoreList(StoreList storeList);
        Task<string> GetSrcStoreList(StoreList storeList);
        Task<string> GetSrcSupplierList(CommonGID_CID_For_GRN commonGID_CID_For_GRN);
        Task<string> GetSupplierList(CommonGID_CID_For_GRN commonGID_CID_For_GRN);
        Task<string> GetOrderNumberList(OrderNumberList orderNumberList);
        Task<string> GetOrderReceivedItemList(OrderReceivedItemList orderReceivedItemList);
        Task<string> GetReceivedByList(CommonGID_CID_For_GRN commonGID_CID_For_GRN);
        Task<string> GetTransactionList(GetTransactionList getTransactionList);
        Task<string> TransactionSave(TransactionSave transactionSave);
        Task<string> SendToAccount(Transaction_acc transaction_Acc);
        Task<string> TrnApproved(Approved_Unapproved approved_Unapproved);
        Task<string> TrnUnApproved(Approved_Unapproved approved_Unapproved);
        Task<string> TransactionDataMaster(TrnDataMaster trnDataMaster);
        Task<string> FileUpload(PhrOrdRecFileUploadQuery phrOrdRecFileUploadQuery);
        Task<string> GetFileUploadedData(GetPhrOrdRecFileUploadedData getPhrOrdRecFileUploadedData);
    }

}
