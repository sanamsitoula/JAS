﻿
using JAS.Services;
using JAS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JAS.Controllers
{
    [Authorize]
    public class JournalEntryController : ApiController
    {
        private IJournalEntryServices _journalentryservices;
        public JournalEntryController()
        {

        }
        public JournalEntryController(IJournalEntryServices journalentryservices)
        {
            _journalentryservices = journalentryservices;
        }


        [HttpPost]
        [Route("api/journal/getjournaldetails")]
        public IHttpActionResult GetJournalEntryList([FromBody]SearchViewModel m)
        {
          //  var data = "sanam";
         var data = _journalentryservices.ListJournalEntry(m);
            //listNotice which comes from interfaces.
            return Ok(data);

        }


        //[HttpPost]
        //[Route("api/item/getFilterPurchaseData")]
        //public IHttpActionResult getFilterPurchaseData(SearchViewModel m)
        //{
        //    //  var data = "sanam";
        //    var data = _purchaseservices.ListPurchaseFromSearch(m);
        //    //listNotice which comes from interfaces.
        //    return Ok(data);

        //}






        [HttpPost]
        [Route("api/journal/addjournal")]
        public IHttpActionResult AddJournalEntry(List<JournalEntryViewModel> m)
        {
            var result = _journalentryservices.AddJournalEntry(m);
            return Ok(result);
        }


        //[HttpGet]
        //[Route("api/group/GetGroupById")]
        //public IHttpActionResult GetGroupById(int id)
        //{
        //    var result = _itemservices.GetGroupById(id);
        //    return Ok(result);
        //}

        //[HttpPost]
        //[Route("api/group/updategroup")]
        //public IHttpActionResult EditGroup(GroupViewModel model)
        //{
        //    var result = _itemservices.EditGroup(model);
        //    return Ok(result);
        //}

        //[HttpPost]
        //[Route("api/group/DeleteGroup")]
        //public IHttpActionResult DeleteGroup([FromBody] int? id)
        //{
        //    var data = _itemservices.DeleteGroup(id ?? 0);
        //    return Ok(data);
        //}


    }
}
