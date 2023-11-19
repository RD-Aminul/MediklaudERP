using mediklaud_api.FormQuery.Pharmacy;
using mediklaud_api.Interface.Pharmacy;
using mediklaud_api.Service.Pharmacy.Entry;
using Microsoft.AspNetCore.Mvc;

namespace mediklaud_api.Controllers.Pharmacy.Entry
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhrBillingController : Controller
    {
        private readonly IPhrBillingService _phrBillingService;
        public PhrBillingController(IPhrBillingService phrBillingService)
        {
            _phrBillingService = phrBillingService;
        }


        [HttpGet("GetPatientTypeList")]
        public async Task<string> GetPatientTypeList([FromQuery] CommonGID_CID commonGID_CID)
        {
            return await _phrBillingService.GetPatientTypeList(commonGID_CID);
        }        
        
        [HttpGet("GetMaxDiscount")]
        public async Task<string> GetMaxDiscount([FromQuery] GetMaxDiscount getMaxDiscount)
        {
            return await _phrBillingService.GetMaxDiscount(getMaxDiscount);
        }

        [HttpGet("GetCustomerInfo")]
        public async Task<string> GetCustomerInfo([FromQuery] GetCustomerInfo getCustomerInfo)
        {
            return await _phrBillingService.GetCustomerInfo(getCustomerInfo);
        }

        [HttpGet("OrganizationList")]
        public async Task<string> OrganizationList([FromQuery] CommonGID_CID commonGID_CID)
        {
            return await _phrBillingService.OrganizationList(commonGID_CID);
        }

        [HttpGet("DepartmentList")]
        public async Task<string> DepartmentList([FromQuery] CommonGID_CID commonGID_CID)
        {
            return await _phrBillingService.DepartmentList(commonGID_CID);
        }

        [HttpGet("DesignationList")]
        public async Task<string> DesignationList([FromQuery] CommonGID_CID commonGID_CID)
        {
            return await _phrBillingService.DesignationList(commonGID_CID);
        }

        [HttpPost("CustomerInfoSave")]
        public async Task<IActionResult> TransactionSave(CustomerInfoSave customerInfoSave)
        {
            return Ok(await _phrBillingService.CustomerInfoSave(customerInfoSave));
        }
    }
}
