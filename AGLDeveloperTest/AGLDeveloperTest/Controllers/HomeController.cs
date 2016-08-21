using AGLDeveloperTest.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace AGLprogram.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            string AGLUrl = ConfigurationManager.AppSettings["JSONURL"];

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(AGLUrl);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var myResponse = new JavaScriptSerializer().Deserialize<List<Owner>>(responseBody);

                var data = myResponse
                           .Where(m => m.pets != null)
                           .GroupBy(m => m.gender)
                           .Select(m => new { gender = m.Key, pets = m })
                           .Select(m => new { gender = m.gender, pets = m.pets.SelectMany(p => p.pets).Where(p => p.type.ToLower() == "cat") })
                           .Select(m => new ResultData() { gender = m.gender, cats = m.pets.Select(p => p.name).ToList() })
                           .ToList();

                return View(data);
            }
        }
    }
}