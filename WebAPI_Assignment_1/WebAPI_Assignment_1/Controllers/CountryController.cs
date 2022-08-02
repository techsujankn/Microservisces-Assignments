using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_Assignment_1.Models;

namespace WebAPI_Assignment_1.Controllers
{
    public class CountryController : ApiController
    {
        static List<Country> countrylist = new List<Country>()
        {
            new Country{Id=1, Name="India",CapitalCity="New Dehli"},
            new Country{Id=2, Name="Australia",CapitalCity="Canberra"},
            new Country{Id=3, Name="United Kingdom",CapitalCity="London"},
            new Country{Id=4, Name="US",CapitalCity="Washington D.C"},
        };
        [HttpGet]
        [Route("details")]

        public IEnumerable<Country> Get()
        {
            return countrylist;
        }
        [HttpGet]
        [Route("countrylist")]

        public HttpResponseMessage GetCountryList()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK,countrylist);
            return response;
        }
        [Route("Name")]
        public IHttpActionResult GetName(int pid)
        {
            string country = countrylist.Where(x => x.Id == pid).SingleOrDefault()?.Name;

            if (country != null)
            {
                return Ok(country);
            }
            return NotFound();
            //return new MyResult(person, Request);


        }
    }
}
