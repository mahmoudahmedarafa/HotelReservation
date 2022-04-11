using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotelReservation.Models;
using HotelReservation.ViewModels;

namespace HotelReservation.Controllers
{
    public class HomeController : Controller
    {
        private readonly HotelReservationContext context;
        public HomeController(HotelReservationContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FreeRooms()
        {
            foreach(Rooms r in context.Rooms)
            {
                if(r.CheckOutDate < DateTime.Now.Date)
                {
                    r.IsReserved = false;
                    r.CheckInDate = null;
                    r.CheckOutDate = null;

                    context.SaveChanges();
                }
            }

            ViewBag.Message = "Freeing Up Rooms is done.";

            return View("index");
        }

        private double GetOverlappingDays(DateTime checkInDate, DateTime checkOutDate,
                                   DateTime intervalStart, DateTime intervalEnd)
        {
            if (intervalStart > checkOutDate || checkInDate > intervalEnd)
                return 0;

            DateTime intersectionStart = checkInDate > intervalStart ? checkInDate : intervalStart;
            DateTime intersectionEnd = checkOutDate < intervalEnd ? checkOutDate : intervalEnd;

            return (intersectionEnd - intersectionStart).TotalDays + 1;
        }

        public IActionResult GetReservationTotal(ReservationViewModel model)
        {
            if (model.CheckInDate > model.CheckOutDate || model.CheckInDate.Date < DateTime.Now.Date)
            {
                //return error
                ModelState.AddModelError("InvalidDateRange", "Invalid CheckIn Date");
            }

            if (ModelState.IsValid)
            {
                int noRoomsAdults = (model.NoOfAdults + 1) / 2;
                int noRoomsChildren = (model.NoOfChildren + 1) / 2;

                if(noRoomsChildren > model.NoOfAdults)
                {
                    ModelState.AddModelError("InvalidChildRooms", "Number of children is too high than number of adults");
                }

                int reservedRooms = Math.Max(noRoomsChildren, noRoomsAdults);

                string selectedRoomType = Rooms.GetRoomTypeFromEnum(model.RoomType);
                var availableRooms = context.Rooms.Where(r => r.RoomType == selectedRoomType && r.IsReserved == false).ToList();
                if(availableRooms.Count() < reservedRooms)
                {
                    ModelState.AddModelError("InsufficientRooms", "Number of available " + selectedRoomType + " is not enough");
                }

                //mark first reservedRooms as taken
                List<int> reservedRoomNumbers = new List<int>();
                for(int i = 0; i < reservedRooms; i++)
                {
                    availableRooms[i].IsReserved = true;
                    availableRooms[i].CheckInDate = model.CheckInDate;
                    availableRooms[i].CheckOutDate = model.CheckOutDate;
                    context.SaveChanges();

                    reservedRoomNumbers.Add(availableRooms[i].Id);
                }

                int roomsPrice = 0;
                var matchingRoomRates = context.RoomRates.Where(r => r.RoomType == selectedRoomType).ToList();

                foreach(var rate in matchingRoomRates)
                {
                    int result = (int)GetOverlappingDays(model.CheckInDate, model.CheckOutDate, rate.DateFrom, rate.DateTo);

                    if (result > 0)
                        roomsPrice += result * rate.RatePerRoom * reservedRooms;
                }

                string selectedMealPlan = MealRates.GetMealPlanFromEnum(model.MealPlan);
                var matchingMealPlan = context.MealRates.Where(m => m.MealPlan == selectedMealPlan).ToList();
                int mealsPrice = 0;

                int lowSeasonDays = (int)GetOverlappingDays(model.CheckInDate, model.CheckOutDate,
                                           matchingMealPlan[0].LowSeasonStart, matchingMealPlan[0].LowSeasonEnd);
                mealsPrice += lowSeasonDays * (model.NoOfAdults + model.NoOfChildren) * matchingMealPlan[0].LowSeasonRate;

                int HighSeasonDays = (int)GetOverlappingDays(model.CheckInDate, model.CheckOutDate,
                                           matchingMealPlan[0].HighSeasonStart, matchingMealPlan[0].HighSeasonEnd);
                mealsPrice += HighSeasonDays * (model.NoOfAdults + model.NoOfChildren) * matchingMealPlan[0].HighSeasonRate;


                int totalCost = roomsPrice + mealsPrice;
                model.TotalReservationCost = totalCost;

                return View("index", model);
            }

            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
