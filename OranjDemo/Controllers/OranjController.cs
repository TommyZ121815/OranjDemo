using OranjDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace OranjDemo.Controllers
{
    [HandleError]
    public class OranjController : Controller
    {
        Uri WebApiAddress = new Uri("https://kkuwbyropc.execute-api.us-east-1.amazonaws.com/internexam/");
        // GET: Oranj
        public async Task<ActionResult> Index()
        {
            // make get request once post request is Successful
           
            OranjDemoAlbum _oranjAlbum = new OranjDemoAlbum();
            using (HttpClient _httpClient = new HttpClient())
            {
                _httpClient.BaseAddress = WebApiAddress;
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await _httpClient.GetAsync("https://kkuwbyropc.execute-api.us-east-1.amazonaws.com/internexam/");

                //Check if the response is corrected. 

                if (response.IsSuccessStatusCode)
                {
                    var getResponse = await response.Content.ReadAsAsync<OranjDemoAlbum>();
                    return View(getResponse);
                }
                else
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }
        }

        // GET: Oranj/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Oranj/Create
        public ActionResult Create()
        {
            // this action method willtake album details from UI
            return View();
        }

        // POST: Oranj/Create
        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> Create(DemoAlbum album)
        {
            using (HttpClient _httpClient = new HttpClient())
            {
                // generating random ID as per requirement
                album.PlaylistId = Guid.NewGuid().ToString();
                _httpClient.BaseAddress = WebApiAddress;
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                
                var _HttpResponse = await _httpClient.PostAsJsonAsync("https://kkuwbyropc.execute-api.us-east-1.amazonaws.com/internexam", album);
                _HttpResponse.EnsureSuccessStatusCode();
               
                if (_HttpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    // go to index method that will make get request
                    return RedirectToAction("Index");
                }
                else
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }
        }

       
    }
}
