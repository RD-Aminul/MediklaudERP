using mediklaud_api.FormQuery.Pharmacy;

namespace mediklaud_api.Interface.Pharmacy
{

    public interface IPhrBillingService
    {
        Task<string> GetPatientTypeList(CommonGID_CID commonGID_CID);
        Task<string> GetMaxDiscount(GetMaxDiscount getMaxDiscount);
        Task<string> GetCustomerInfo(GetCustomerInfo getCustomerInfo);
        Task<string> OrganizationList(CommonGID_CID commonGID_CID);
        Task<string> DepartmentList(CommonGID_CID commonGID_CID);
        Task<string> DesignationList(CommonGID_CID commonGID_CID);
        Task<string> CustomerInfoSave(CustomerInfoSave customerInfoSave);
    }
    
}
