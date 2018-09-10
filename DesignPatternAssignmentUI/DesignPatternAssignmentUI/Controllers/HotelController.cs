using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using DesignPatternAssignmentUI.Models;
using System.Web.Mvc;

namespace DesignPatternAssignmentUI.Controllers
{
    public class HotelController : Controller
    {
        // GET: Hotel
        public ActionResult GetValues()
        {
            List<Hotel> carList = new List<Hotel>();
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync("http://localhost:57903/api/hotel").Result;
            carList = response.Content.ReadAsAsync<List<Hotel>>().Result;
            ViewBag.name = "Hotel";
            return View(carList);
        }
        public ActionResult AddValues()
        {
            return View();
        }
        public ActionResult SendPostRequest()
        {
            Hotel hotel = new Hotel();
            int price = Convert.ToInt16(Request.Params["hotelPrice"]);
            string name = Request.Params["hotelName"];
            string saved = Request.Params["isSaved"];
            string booked = Request.Params["isBooked"];
            string city = Request.Params["hotelCity"];
            int rooms = Convert.ToInt16(Request.Params["hotelRooms"]);
            string type = Request.Params["hotelType"];

            hotel.HotelPrice = price;
            hotel.HotelName = name;
            hotel.IsSaved = saved;
            hotel.IsBooked = booked;
            hotel.HotelCity = city;
            hotel.HotelAvailableRooms = rooms;
            hotel.HotelRoomType = type;

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:57903/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var uri = "http://localhost:57903/api/hotel";
            var response = httpClient.PostAsJsonAsync(uri, hotel);

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
            var uri = "http://localhost:57903/api/hotel/" + query[0];
            var response = httpClient.PutAsJsonAsync(uri, operation);
            return RedirectToAction("GetValues");
        }
        public ActionResult Saved()
        {
            List<Hotel> hotelList = new List<Hotel>();
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync("http://localhost:57903/api/hotel").Result;
            hotelList = response.Content.ReadAsAsync<List<Hotel>>().Result;
            List<Hotel> newHotelList = new List<Hotel>();
            foreach (Hotel hotel in hotelList)
            {
                if (hotel.IsSaved.Equals("true"))
                {
                    newHotelList.Add(hotel);
                }
            }
            return View(newHotelList);
        }
        public ActionResult Booked()
        {
            List<Hotel> hotelList = new List<Hotel>();
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync("http://localhost:57903/api/hotel").Result;
            hotelList = response.Content.ReadAsAsync<List<Hotel>>().Result;
            List<Hotel> newHotelList = new List<Hotel>();
            foreach (Hotel hotel in hotelList)
            {
                if (hotel.IsBooked.Equals("true"))
                {
                    newHotelList.Add(hotel);
                }
            }
            return View(newHotelList);
        }
    }
}