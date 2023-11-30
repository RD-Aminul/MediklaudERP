using mediklaud_api.Interface.Pharmacy.Entry;
using mediklaud_api.Models.Pharmacy.Entry;
using Microsoft.AspNetCore.Mvc;

namespace mediklaud_api.Controllers.Pharmacy.Entry
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseRequsitionOrderController : Controller
    {
        private readonly IPurchaseRequsitionOrderService _purchaseRequsitionOrder;
        public PurchaseRequsitionOrderController(IPurchaseRequsitionOrderService purchaseRequsitionOrder)
        {
            _purchaseRequsitionOrder = purchaseRequsitionOrder;
        }

        [HttpGet("GetConfigaration")]
        public async Task<string> GetConfigaration([FromQuery] CommonGID_CID_For_PurReqOrd commonGID_CID_For_PurReqOrd)
        {
            return await _purchaseRequsitionOrder.GetConfigaration(commonGID_CID_For_PurReqOrd);
        }

        [HttpGet("GetSerStoreList")]
        public async Task<string> GetSerStoreList([FromQuery] PurReqOrderStoreList purReqOrderStoreList)
        {
            return await _purchaseRequsitionOrder.GetSerStoreList(purReqOrderStoreList);
        }

        [HttpGet("GetStoreList")]
        public async Task<string> GetStoreList([FromQuery] PurReqOrderStoreList purReqOrderStoreList)
        {
            return await _purchaseRequsitionOrder.GetStoreList(purReqOrderStoreList);
        }

        [HttpGet("GetForStoreList")]
        public async Task<string> GetForStoreList([FromQuery] PurReqOrderStoreList purReqOrderStoreList)
        {
            return await _purchaseRequsitionOrder.GetForStoreList(purReqOrderStoreList);
        }

        [HttpGet("GetSerSupplierList")]
        public async Task<string> GetSerSupplierList([FromQuery] CommonGID_CID_For_PurReqOrd commonGID_CID_For_PurReqOrd)
        {
            return await _purchaseRequsitionOrder.GetSerSupplierList(commonGID_CID_For_PurReqOrd);
        }

        [HttpGet("GetSupplierList")]
        public async Task<string> GetSupplierList([FromQuery] CommonGID_CID_For_PurReqOrd commonGID_CID_For_PurReqOrd)
        {
            return await _purchaseRequsitionOrder.GetSupplierList(commonGID_CID_For_PurReqOrd);
        }

        [HttpGet("GetTransactionList")]
        public async Task<string> GetTransactionList([FromQuery] TransactionListForPhrReqOrd transactionListForPhrReqOrd)
        {
            return await _purchaseRequsitionOrder.GetTransactionList(transactionListForPhrReqOrd);
        }

        [HttpGet("GetItemList")]
        public async Task<string> GetItemList([FromQuery] PurReqOrderItemList purReqOrderItemList)
        {
            return await _purchaseRequsitionOrder.GetItemList(purReqOrderItemList);
        }

        [HttpGet("GetRequisitionList")]
        public async Task<string> GetRequisitionList([FromQuery] PurReqOrderRequsitionNo purReqOrderRequsitionNo)
        {
            return await _purchaseRequsitionOrder.GetRequisitionList(purReqOrderRequsitionNo);
        }
    }
}
