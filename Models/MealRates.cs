using System;
using System.Collections.Generic;

namespace HotelReservation.Models
{
    public partial class MealRates
    {
        public int Id { get; set; }
        public string MealPlan { get; set; }
        public int LowSeasonRate { get; set; }
        public int HighSeasonRate { get; set; }
        public DateTime LowSeasonStart = new DateTime(2022, 1, 1);
        public DateTime LowSeasonEnd = new DateTime(2022, 5, 31);
        public DateTime HighSeasonStart = new DateTime(2022, 6, 1);
        public DateTime HighSeasonEnd = new DateTime(2022, 12, 31);

        public static string GetMealPlanFromEnum(string mealPlanNum)
        {
            if (mealPlanNum == "1")
                return "HalfBoard";
            else if (mealPlanNum == "2")
                return "FullBoard";
            else if (mealPlanNum == "3")
                return "AllInclusive";

            return "";
        }
    }
}
