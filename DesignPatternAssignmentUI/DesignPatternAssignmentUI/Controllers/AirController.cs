using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using DesignPatternAssignmentUI.Models;
using System.Web.Mvc;

namespace DesignPatternAssignmentUI.Controllers
{
    public class AirController : Controller
    {
        // GET: Air
        public ActionResult GetValues()
        {
            List<Air> carList = new List<Air>();
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync("http://localhost:57903/api/air").Result;
            carList = response.Content.ReadAsAsync<List<Air>>().Result;
            ViewBag.name = "Air";
            return View(carList);
        }
        public ActionResult AddValues()
        {
            return View();
        }
        public ActionResult SendPostRequest()
        {
            Air air = new Air();
            int price = Convert.ToInt16(Request.Params["airPrice"]);
            string name = Request.Params["airName"];
            string saved = Request.Params["isSaved"];
            string booked = Request.Params["isBooked"];
            string from = Request.Params["airFrom"];
            string to = Request.Params["airTo"];
            string clas = Request.Params["airClass"];

            air.AirPrice = price;
            air.AirName = name;
            air.IsSaved = saved;
            air.IsBooked = booked;
            air.AirFromCity = from;
            air.AirToCity = to;
            air.AirClass = clas;

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:57903/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var uri = "http://localhost:57903/api/air";
            var response = httpClient.PostAsJsonAsync(uri, air);

            return View();
        }
        public ActionResult SendPutRequest()
        {
            string values = Request.Params["Save"];
            string[] query = values.Split(',');
            string operation = query[1];
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:57903/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var uri = "http://localhost:57903/api/air/" + query[0];
            var response = httpClient.PutAsJsonAsync(uri, operation);
            return RedirectToAction("GetValues");
        }
        public ActionResult Saved()
        {
            List<Air> airList = new List<Air>();
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync("http://localhost:57903/api/air").Result;
            airList = response.Content.ReadAsAsync<List<Air>>().Result;
            List<Air> newAirList = new List<Air>();
            foreach (Air air in airList)
            {
                if (air.IsSaved.Equals("true"))
                {
                    newAirList.Add(air);
                }
            }
            return View(newAirList);
        }
        public ActionResult Booked()
        {
            List<Air> airList = new List<Air>();
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync("http://localhost:57903/api/air").Result;
            airList = response.Content.ReadAsAsync<List<Air>>().Result;
            List<Air> newAirList = new List<Air>();
            foreach (Air air in airList)
            {
                if (air.IsBooked.Equals("true"))
                {
                    newAirList.Add(air);
                }
            }
            return View(newAirList);
        }
    }
}