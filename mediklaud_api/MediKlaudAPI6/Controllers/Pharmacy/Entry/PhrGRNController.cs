using mediklaud_api.FormQuery.Pharmacy;
using mediklaud_api.Interface.Pharmacy;
using mediklaud_api.Service.Pharmacy;
using Microsoft.AspNetCore.Mvc;

namespace mediklaud_api.Controllers.Pharmacy.Entry
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhrGRNController : Controller
    {
        private readonly IPhrGRNService _phrGRNService;
        public PhrGRNController(IPhrGRNService phrGRNService)
        {
            _phrGRNService = phrGRNService;
        }

        [HttpGet("GetConfigaration")]
        public async Task<string> GetConfigaration([FromQuery] CommonGID_CID_For_GRN commonGID_CID_For_GRN)
        {
            return await _phrGRNService.GetConfigaration(commonGID_CID_For_GRN);
        }

        [HttpGet("GetStoreList")]
        public async Task<string> GetStoreList([FromQuery] StoreList storeList)
        {
            return await _phrGRNService.GetStoreList(storeList);
        }

        [HttpGet("GetSrcStoreList")]
        public async Task<string> GetSrcStoreList([FromQuery] StoreList storeList)
        {
            return await _phrGRNService.GetSrcStoreList(storeList);
        }

        [HttpGet("GetSrcSupplierList")]
        public async Task<string> GetSrcSupplierList([FromQuery] CommonGID_CID_For_GRN commonGID_CID_For_GRN)
        {
            return await _phrGRNService.GetSrcSupplierList(commonGID_CID_For_GRN);
        }

        [HttpGet("GetSupplierList")]
        public async Task<string> GetSupplierList([FromQuery] CommonGID_CID_For_GRN commonGID_CID_For_GRN)
        {
            return await _phrGRNService.GetSupplierList(commonGID_CID_For_GRN);
        }

        [HttpGet("GetOrderNumberList")]
        public async Task<string> GetOrderNumberList([FromQuery] OrderNumberList orderNumberList)
        {
            return await _phrGRNService.GetOrderNumberList(orderNumberList);
        }


        [HttpGet("GetOrderReceivedItemList")]
        public async Task<string> GetOrderReceivedItemList([FromQuery] OrderReceivedItemList orderReceivedItemList)
        {
            return await _phrGRNService.GetOrderReceivedItemList(orderReceivedItemList);
        }

        [HttpGet("GetReceivedByList")]
        public async Task<string> GetReceivedByList([FromQuery] CommonGID_CID_For_GRN commonGID_CID_For_GRN)
        {
            return await _phrGRNService.GetReceivedByList(commonGID_CID_For_GRN);
        }

        [HttpGet("GetTransactionList")]
        public async Task<string> GetTransactionList([FromQuery] GetTransactionList getTransactionList)
        {
            return await _phrGRNService.GetTransactionList(getTransactionList);
        }

        [HttpPost("TransactionSave")]
        public async Task<IActionResult> TransactionSave(TransactionSave transactionSave)
        {
            return Ok(await _phrGRNService.TransactionSave(transactionSave));
        }

        [HttpPost("SendToAccount")]
        public async Task<IActionResult> SendToAccount(Transaction_acc transaction_Acc)
        {
            return Ok(await _phrGRNService.SendToAccount(transaction_Acc));
        }

        [HttpPost("TrnApproved")]
        public async Task<IActionResult> TrnApproved(Approved_Unapproved approved_Unapproved)
        {
            return Ok(await _phrGRNService.TrnApproved(approved_Unapproved));
        }

        [HttpPost("TrnUnApproved")]
        public async Task<IActionResult> TrnUnApproved(Approved_Unapproved approved_Unapproved)
        {
            return Ok(await _phrGRNService.TrnUnApproved(approved_Unapproved));
        }

        [HttpGet("TransactionDataMaster")]
        public async Task<string> TransactionDataMaster([FromQuery] TrnDataMaster trnDataMaster)
        {
            return await _phrGRNService.TransactionDataMaster(trnDataMaster);
        }

        [HttpPost("FileUpload")]
        public async Task<IActionResult> FileUpload(PhrOrdRecFileUploadQuery phrOrdRecFileUploadQuery)
        {
            return Ok(await _phrGRNService.FileUpload(phrOrdRecFileUploadQuery));
        }

        [HttpGet("GetFileUploadedData")]
        public async Task<string> GetFileUploadedData([FromQuery] GetPhrOrdRecFileUploadedData getPhrOrdRecFileUploadedData)
        {
            return await _phrGRNService.GetFileUploadedData(getPhrOrdRecFileUploadedData);
        }
    }
}
