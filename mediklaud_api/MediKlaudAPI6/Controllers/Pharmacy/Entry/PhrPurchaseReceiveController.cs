using mediklaud_api.FormQuery.Pharmacy;
using mediklaud_api.Interface.Pharmacy;
using Microsoft.AspNetCore.Mvc;

namespace mediklaud_api.Controllers.Pharmacy
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhrPurchaseReceiveController : Controller
    {
        private readonly IPhrPurchaseReceiveService _phrPurchaseReceiveService;
        public PhrPurchaseReceiveController(IPhrPurchaseReceiveService phrPurchaseReceiveService)
        {
            _phrPurchaseReceiveService = phrPurchaseReceiveService;
        }

        [HttpGet("GetConfigaration")]
        public async Task<string> GetConfigaration([FromQuery] GetAllListQuery getAllListQuery)
        {
            return await _phrPurchaseReceiveService.GetConfigaration(getAllListQuery);
        }

        [HttpGet("GetStroeList")]
        public async Task<string> GetStroeList([FromQuery] GetcmbStoreListQuery getcmbStoreListQuery)
        {
            return await _phrPurchaseReceiveService.GetStroeList(getcmbStoreListQuery);
        }

        [HttpGet("GetSupplierList")]
        public async Task<string> GetSupplierList([FromQuery] GetAllListQuery getAllListQuery)
        {
            return await _phrPurchaseReceiveService.GetSupplierList(getAllListQuery);
        }

        [HttpGet("GetTransationGridDataList")]
        public async Task<string> GetTransationGridDataList([FromQuery] GetTransationGridDataListQuery getTransationGridDataListQuery)
        {
            return await _phrPurchaseReceiveService.GetTransationGridDataList(getTransationGridDataListQuery);
        }

        [HttpGet("GetMasterDataAndItemGridDataList")]
        public async Task<string> GetMasterDataAndItemGridDataList([FromQuery] GetMasterDataAndItemGridDataListQuery getMasterDataAndItemGridDataListQuery)
        {
            return await _phrPurchaseReceiveService.GetMasterDataAndItemGridDataList(getMasterDataAndItemGridDataListQuery);
        }

        [HttpGet("GetcmbItemList")]
        public async Task<string> GetcmbItemList([FromQuery] GetcmbItemListQuery getcmbItemListQuery)
        {
            return await _phrPurchaseReceiveService.GetcmbItemList(getcmbItemListQuery);
        }

        [HttpGet("GetcmbItemSelectData")]
        public async Task<string> GetcmbItemSelectData([FromQuery] GetcmbItemListQuery getcmbItemListQuery)
        {
            return await _phrPurchaseReceiveService.GetcmbItemSelectData(getcmbItemListQuery);
        }

        [HttpPost("TransactionSave")]
        public async Task<IActionResult> TransactionSave(Transactions transactions)
        {
            return Ok(await _phrPurchaseReceiveService.TransactionSave(transactions));
        }

        [HttpPost("TransactionApproved")]
        public async Task<IActionResult> TransactionApproved(ApproveUnapproveCancelQuery approveUnapproveCancelQuery)
        {
            return Ok(await _phrPurchaseReceiveService.TransactionApproved(approveUnapproveCancelQuery));
        }

        [HttpPost("TransactionUnApproved")]
        public async Task<IActionResult> TransactionUnApproved(ApproveUnapproveCancelQuery approveUnapproveCancelQuery)
        {
            return Ok(await _phrPurchaseReceiveService.TransactionUnApproved(approveUnapproveCancelQuery));
        }

        [HttpPost("TransactionCancel")]
        public async Task<IActionResult> TransactionCancel(ApproveUnapproveCancelQuery approveUnapproveCancelQuery)
        {
            return Ok(await _phrPurchaseReceiveService.TransactionCancel(approveUnapproveCancelQuery));
        }

        [HttpPost("FileUpload")]
        public async Task<IActionResult> FileUpload(FileUploadQuery fileUploadQuery)
        {
            return Ok(await _phrPurchaseReceiveService.FileUpload(fileUploadQuery));
        }

        [HttpGet("GetFileUploadedData")]
        public async Task<string> GetFileUploadedData([FromQuery] GetFileUploadedDataQuery getFileUploadedDataQuery)
        {
            return await _phrPurchaseReceiveService.GetFileUploadedData(getFileUploadedDataQuery);
        }
    }
}
