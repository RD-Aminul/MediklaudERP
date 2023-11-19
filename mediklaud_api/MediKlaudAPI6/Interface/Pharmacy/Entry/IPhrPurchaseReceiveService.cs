using mediklaud_api.FormQuery.Pharmacy;

namespace mediklaud_api.Interface.Pharmacy
{
    public interface IPhrPurchaseReceiveService
    {
        Task<string> GetConfigaration(GetAllListQuery getAllListQuery);
        Task<string> GetStroeList(GetcmbStoreListQuery getcmbStoreListQuery);
        Task<string> GetSupplierList(GetAllListQuery getAllListQuery);
        Task<string> GetTransationGridDataList(GetTransationGridDataListQuery getTransationGridDataListQuery);
        Task<string> GetMasterDataAndItemGridDataList(GetMasterDataAndItemGridDataListQuery getMasterDataAndItemGridDataListQuery);
        Task<string> GetcmbItemList(GetcmbItemListQuery getcmbItemListQuery);
        Task<string> GetcmbItemSelectData(GetcmbItemListQuery getcmbItemListQuery);
        Task<string> TransactionSave(Transactions transactions);
        Task<string> TransactionApproved(ApproveUnapproveCancelQuery approveUnapproveCancelQuery);
        Task<string> TransactionUnApproved(ApproveUnapproveCancelQuery approveUnapproveCancelQuery);
        Task<string> TransactionCancel(ApproveUnapproveCancelQuery approveUnapproveCancelQuery);
        Task<string> FileUpload(FileUploadQuery fileUploadQuery);
        Task<string> GetFileUploadedData(GetFileUploadedDataQuery getFileUploadedDataQuery);
    }
}
