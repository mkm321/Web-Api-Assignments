using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using DesignPatternAssignmentUI.Models;
using System.Web.Mvc;

namespace DesignPatternAssignmentUI.Controllers
{
    public class CarController : Controller
    {
        // GET: Car
        public ActionResult GetValues()
        {
            List<Car> carList = new List<Car>();
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync("http://localhost:57903/api/car").Result;
            carList = response.Content.ReadAsAsync<List<Car>>().Result;
            ViewBag.name = "Car";
            return View(carList);
        }
        public ActionResult AddValues()
        {
            ViewBag.name = "Car";
            return View();
        }
        public ActionResult SendPostRequest()
        {
            Car car = new Car();
            int price = Convert.ToInt16(Request.Params["carPrice"]);
            string name = Request.Params["carName"];
            string model = Request.Params["carModel"];
            string saved = Request.Params["isSaved"];
            string booked = Request.Params["isBooked"];
            string colour = Request.Params["carColour"];
            string type = Request.Params["carType"];
            string brand = Request.Params["carBrand"];

            car.CarPrice = price;
            car.CarName = name;
            car.CarModel = model;
            car.IsSaved = saved;
            car.IsBooked = booked;
            car.CarColour = colour;
            car.CarType = type;
            car.CarBrandName = brand;

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:57903/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var uri = "http://localhost:57903/api/car";
            var response = httpClient.PostAsJsonAsync(uri, car);

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
            var uri = "http://localhost:57903/api/car/" + query[0];
            var response = httpClient.PutAsJsonAsync(uri,operation);
            return RedirectToAction("GetValues");
        }
        public ActionResult Saved()
        {
            List<Car> carList = new List<Car>();
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync("http://localhost:57903/api/car").Result;
            carList = response.Content.ReadAsAsync<List<Car>>().Result;
            List<Car> newCarList = new List<Car>();
            foreach(Car car in carList)
            {
                if (car.IsSaved.Equals("true"))
                {
                    newCarList.Add(car);
                }
            }
            return View(newCarList);
        }
        public ActionResult Booked()
        {
            List<Car> carList = new List<Car>();
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync("http://localhost:57903/api/car").Result;
            carList = response.Content.ReadAsAsync<List<Car>>().Result;
            List<Car> newCarList = new List<Car>();
            foreach (Car car in carList)
            {
                if (car.IsBooked.Equals("true"))
                {
                    newCarList.Add(car);
                }
            }
            return View(newCarList);
        }
    }
}