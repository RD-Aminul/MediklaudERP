using mediklaud_api.FormQuery.Pharmacy.Entry;
using mediklaud_api.Interface.Pharmacy.Entry;
using Microsoft.AspNetCore.Mvc;

namespace mediklaud_api.Controllers.Pharmacy.Entry
{
    [Route("api/[Controller]")]
    [ApiController]

    public class PhrPurchaseRequisitionController : Controller
    {
        private readonly IPhrPurchaseRequisitionService _phrPurchaseRequisitionService;
        public PhrPurchaseRequisitionController(IPhrPurchaseRequisitionService phrPurchaseRequisitionService)
        {
            _phrPurchaseRequisitionService = phrPurchaseRequisitionService;
        }

        [HttpGet]
        [Route("GetConfiguration")]
        public async Task<string> GetConfigurationList([FromQuery] Common_Gid_Cid_For_Requisition common_Gid_Cid_For_Requisition)
        {
            return await _phrPurchaseRequisitionService.GetConfiguration(common_Gid_Cid_For_Requisition);
        }


        [HttpGet]
        [Route("GetSrcFormStoreList")]
        public async Task<string> GetSrcFromStoreList([FromQuery] FromStorList fromStorList)
        {
            return await _phrPurchaseRequisitionService.GetSrcFromStorList(fromStorList);
        }

        [HttpGet]
        [Route("GetFormStoreList")]
        public async Task<string> GetFromStoreList([FromQuery] FromStorList fromStorList)
        {
            return await _phrPurchaseRequisitionService.GetFromStorList(fromStorList);
        }

        [HttpGet]
        [Route("GetToStoreList")]
        public async Task<string> GetToStoreList([FromQuery] ToStorList toStorList)
        {
            return await _phrPurchaseRequisitionService.GetToStorList(toStorList);
        }

        [HttpGet]
        [Route("GetSrcSupplierList")]
        public async Task<string> GetSrcSupplierList([FromQuery] Common_Gid_Cid_For_Requisition common_Gid_Cid_For_Requisition)
        {
            return await _phrPurchaseRequisitionService.GetSrcSupplierList(common_Gid_Cid_For_Requisition);
        }

        [HttpGet]
        [Route("GetSupplierList")]
        public async Task<string> GetSupplierList([FromQuery] Common_Gid_Cid_For_Requisition common_Gid_Cid_For_Requisition)
        {
            return await _phrPurchaseRequisitionService.GetSupplierList(common_Gid_Cid_For_Requisition);
        }

        [HttpGet]
        [Route("GetPhrRequsitionList")]
        public async Task<string> GetPhrRequsitionList([FromQuery] PhrRequisitionList PhrRequisitionList)
        {
            return await _phrPurchaseRequisitionService.GetRequisitionList(PhrRequisitionList);
        }

        [HttpGet]
        [Route("GetPhrItemList")]
        public async Task<string> GetPhrItemList([FromQuery] ItemList itemList)
        {
            return await _phrPurchaseRequisitionService.GetPhrItemList(itemList);
        }
















        //[HttpGet]
        //[Route("GetCmbToStoreList")]
        //public async Task<string> GetCmbToStoreList([FromQuery] GetCmbToStoreListQuery getCmbToStoreListQuery)
        //{
        //    return await _phrPurchaseRequisitionService.GetCmbToStoreList(getCmbToStoreListQuery);
        //}

        //[HttpGet]
        //[Route("GetCmbItemList")]
        //public async Task<string> GetCmbItemLIst([FromQuery] GetCmbItemListQuery getCmbItemListQuery)
        //{
        //    return await _phrPurchaseRequisitionService.GetCmbItemList(getCmbItemListQuery);
        //}

        //[HttpGet]
        //[Route("GetCmbItemSelectedList")]
        //public async Task<string> GetCmbItemSelectedLIst([FromQuery] GetCmbItemSelectedListQuery getCmbItemSelectedListQuery)
        //{
        //    return await _phrPurchaseRequisitionService.GetCmbItemSelectedList(getCmbItemSelectedListQuery);
        //}

        //[HttpPost]
        //[Route("AddPharmacyRequisition")]
        //public async Task<IActionResult> AddPhrPurchaseRequisition(PhrPurchaseRequisitionSave phrPurchaseRequisitionSave)
        //{
        //    return Ok(await _phrPurchaseRequisitionService.AddPhrPurchaseRequisition(phrPurchaseRequisitionSave));
        //}


        //[HttpPost]
        //[Route("ApprovePhrPurchaseRequisition")]
        //public async Task<IActionResult> ApprovePhrPurchaseRequisition(PhrPurRequisitionApprove phrPurRequisitionApprove)
        //{
        //    return Ok(await _phrPurchaseRequisitionService.ApprovePhrPurchaseRequisition(phrPurRequisitionApprove));
        //}

        //[HttpPost]
        //[Route("UnApprovePhrPurchaseRequisition")]
        //public async Task<IActionResult> UnApprovePhrPurchaseRequisition(PhrPurRequisitionUnApprove phrPurRequisitionUnApprove)
        //{
        //    return Ok(await _phrPurchaseRequisitionService.UnApprovePhrPurchaseRequisition(phrPurRequisitionUnApprove));
        //}

        //[HttpPost]
        //[Route("CancelPhrPurchaseRequisition")]
        //public async Task<IActionResult> CancelPhrPurchaseRequisition(PhrPurRequisitionCancel phrPurRequisitionCancel)
        //{
        //    return Ok(await _phrPurchaseRequisitionService.CancelPhrPurchaseRequisition(phrPurRequisitionCancel));
        //}
    }
}
