using mediklaud_api.FormQuery.Pharmacy.Entry;

namespace mediklaud_api.Interface.Pharmacy.Entry
{
    public interface IPhrPurchaseRequisitionService
    {
        Task<string> GetConfiguration(Common_Gid_Cid_For_Requisition common_Gid_Cid_For_Requisition);
        Task<string> GetSrcFromStorList(FromStorList fromStorList);
        Task<string> GetFromStorList(FromStorList fromStorList);
        Task<string> GetToStorList(ToStorList toStorList);
        Task<string> GetSrcSupplierList(Common_Gid_Cid_For_Requisition common_Gid_Cid_For_Requisition);
        Task<string> GetSupplierList(Common_Gid_Cid_For_Requisition common_Gid_Cid_For_Requisition);
        Task<string> GetRequisitionList(PhrRequisitionList requisitionList);
        Task<string> GetPhrItemList(ItemList itemList);
        Task<string> GetPhrSuppItemList(SuppItemList suppItemList);

    }
}
