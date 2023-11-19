using mediklaud_api.Models;

namespace mediklaud_api.FormQuery.Pharmacy
{
    public class CommonGID_CID
    {
        public int? GID { get; set; }
        public int? CID { get; set; }
    }

    public class GetMaxDiscount
    {
        public int? PatientTypeNo { get; set; }
    }

    public class GetCustomerInfo
    {
        public int? GID { get; set; }
        public int? CID { get; set; }
        public string CustomerId { get; set; }
        public string MobileNo { get; set; }
        public string EmployeeId { get; set; }
    }

    public class CustomerInfoSave
    {
        public int? PatientTypeNo { get; set; }
        public string? CustomerName { get; set; }
        public string? GenderValue { get; set; }
        public string? PhoneMobile { get; set; }
        public string? Address { get; set; }
        public string? EmployeeId { get; set; }

        public int? OrganizationNo { get; set; }
        public int? DesignationNo { get; set; }
        public int? DepartmentNo { get; set; }

        public string? NationalId { get; set; }
        public string? PassportNo { get; set; }

        public int? AgeYYY { get; set; }
        public int? AgeMM { get; set; }
        public int? AgeDD { get; set; }
        public string? BirthDate { get; set; }
        public string? MarriageDate { get; set; }
        public int? CreditLimit { get; set; }

        public int? EntryBy { get; set; }
        public int? CID { get; set; }
        public int? GID { get; set; }
        public string? EntryIp { get; set; }
    }
}
