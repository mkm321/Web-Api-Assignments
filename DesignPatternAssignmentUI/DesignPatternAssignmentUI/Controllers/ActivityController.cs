using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using DesignPatternAssignmentUI.Models;
using System.Web.Mvc;

namespace DesignPatternAssignmentUI.Controllers
{
    public class ActivityController : Controller
    {
        // GET: Activity
        public ActionResult GetValues()
        {
            List<Activity> carList = new List<Activity>();
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync("http://localhost:57903/api/activity").Result;
            carList = response.Content.ReadAsAsync<List<Activity>>().Result;
            ViewBag.name = "Activity";
            return View(carList);
        }
        public ActionResult AddValues()
        {
            ViewBag.name = "Activity";
            return View();
        }
        public ActionResult SendPostRequest()
        {
            Activity activity = new Activity();
            int price = Convert.ToInt16(Request.Params["activityPrice"]);
            string name = Request.Params["activityName"];
            string saved = Request.Params["isSaved"];
            string booked = Request.Params["isBooked"];
            string type = Request.Params["activityType"];

            activity.ActivityPrice = price;
            activity.ActivityName = name;
            activity.IsSaved = saved;
            activity.IsBooked = booked;
            activity.ActivityType = type;

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:57903/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var uri = "http://localhost:57903/api/activity";
            var response = httpClient.PostAsJsonAsync(uri, activity);

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
            var uri = "http://localhost:57903/api/activity/" + query[0];
            var response = httpClient.PutAsJsonAsync(uri, operation);
            return RedirectToAction("GetValues");
        }
        public ActionResult Saved()
        {
            List<Activity> activityList = new List<Activity>();
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync("http://localhost:57903/api/activity").Result;
            activityList = response.Content.ReadAsAsync<List<Activity>>().Result;
            List<Activity> newActivityList = new List<Activity>();
            foreach (Activity activity in activityList)
            {
                if (activity.IsSaved.Equals("true"))
                {
                    newActivityList.Add(activity);
                }
            }
            return View(newActivityList);
        }
        public ActionResult Booked()
        {
            List<Activity> activityList = new List<Activity>();
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync("http://localhost:57903/api/activity").Result;
            activityList = response.Content.ReadAsAsync<List<Activity>>().Result;
            List<Activity> newActivityList = new List<Activity>();
            foreach (Activity activity in activityList)
            {
                if (activity.IsBooked.Equals("true"))
                {
                    newActivityList.Add(activity);
                }
            }
            return View(newActivityList);
        }
    }
}