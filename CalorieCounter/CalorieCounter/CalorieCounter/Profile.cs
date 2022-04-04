using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace CalorieCounter
{
    class Profile
    {
        public static string username;
        public static int dailyCals = 0;
        public static int weeklyCals = 0;
        public static int dailyGoals = 2000;
        public static int weeklyGoals = 14000;

        public static DateTime todaysDate = DateTime.Today;
        public static string[] profileArray = new string[3];
        public static string[] dateArray;
        public static int[] calArray;

        public static string path = Transporter.path;
        public static string profilePath;
        public static string datePath;
        public static string calPath;

        public static string dateString = todaysDate.ToString("d");

        public static void createProfile()
        {
            username = Transporter.userName;
            //public static string usernameDefault = appPath + @"\usernames.txt";
            profilePath = path + @"\" + username + "Profile.txt";
            datePath = path + @"\" + username + "Dates.txt";
            calPath = path + @"\" + username + "Cals.txt";

            if(!File.Exists(profilePath))
            {
                createProfileFile();
            }

            loadProfile();

            if (!File.Exists(datePath))
            {
                createDateFile();
            }

            loadDates();

            if (!File.Exists(calPath))
            {
                createCalFile();
            }

            loadCals();

            if (!dateArray.Contains(dateString))
            {
                dateArray[dateArray.Length - 1] = dateString;
                calArray[dateArray.Length - 1] = 0;
                dailyCals = calArray[dateArray.Length - 1];

                saveAll();
                loadAll();
            }

        }

        public static void createProfileFile()
        {

            using (var writer = new StreamWriter(profilePath, false))
            {
                writer.WriteLine(username);
                writer.WriteLine(dailyGoals);
                writer.WriteLine(weeklyGoals);             
            }

        }

        public static void createDateFile()
        {
            using (var writer = new StreamWriter(datePath, false))
            {
                writer.WriteLine(dateString);
            }
        }

        public static void createCalFile()
        {
            using (var writer = new StreamWriter(calPath, false))
            {
                writer.WriteLine(dailyCals);
            }
        }

        public static void loadProfile()
        {
            int i = 0;

            foreach (string s in File.ReadAllLines(profilePath))
            {
                profileArray[i] = s;
                i++;
            }

            i = 0;

            username = profileArray[0];
            dailyGoals = Convert.ToInt32(profileArray[1]);
            weeklyGoals = Convert.ToInt32(profileArray[2]);



        }

        public static void loadDates()
        {
            int i = 0;
            
            dateArray = new string[File.ReadLines(datePath).Count() + 1];

            foreach (string s in File.ReadAllLines(datePath))
            {
                dateArray[i] = s;
                i++;
            }

            dateArray[i] = "BLANK";

            i = 0;
            
        }

        public static void loadCals()
        {
            int i = 0;

            calArray = new int[File.ReadLines(calPath).Count() +1];

            foreach (string s in File.ReadAllLines(calPath))
            {
                calArray[i] = Convert.ToInt32(s);
                i++;
            }

            calArray[i] = -123;

            i = 0;
        }

        public static void loadAll()
        {
            loadProfile();
            loadDates();
            loadCals();
        }

        public static void saveProfile()
        {

            if(File.Exists(profilePath))
            { 
                using (var writer = new StreamWriter(profilePath, false))
                {
                    foreach (string s in profileArray)
                    {
                        writer.WriteLine(s);
                    }
                }
            }
        }

        public static void saveDates()
        {

            if (File.Exists(datePath))
            {
                using (var writer = new StreamWriter(datePath, false))
                {
                    foreach (string s in dateArray)
                    {
                        if(s != "BLANK")
                        {
                            writer.WriteLine(s);
                        }
                        
                    }
                }
            }
        }

        public static void saveCals()
        {

            if (File.Exists(calPath))
            {
                using (var writer = new StreamWriter(calPath, false))
                {
                    foreach (int s in calArray)
                    {
                        if (s != -123)
                        {
                            writer.WriteLine(s);
                        }
                    }
                }
            }
        }

        public static void saveAll()
        {
            saveProfile();
            saveDates();
            saveCals();
        }

        public static void checkDailyCals()
        {
            for(int i = 0; i < calArray.Length; i++)
            {
                if(dateArray[i] == dateString)
                {
                    dailyCals = calArray[i];
                }

            }
        }

        public static void checkWeeklyCals()
        {
            int i;
            int weeklyTotal = 0;
            string searchDate;
            DateTime curDate = DateTime.Today;

            for(i = 0; i < 7; i++)
            {
                curDate = DateTime.Now.Date.AddDays(-i);
                searchDate = curDate.ToString("d");

                for (int j = 0; j < dateArray.Length; j++)
                {
                    if (dateArray[j] == searchDate)
                    {
                        weeklyTotal = weeklyTotal + calArray[j];
                    }
                }
            }

            weeklyCals = weeklyTotal;

        }

        public static void addCalories(string cals)
        {
            try
            {

                int c = Convert.ToInt32(cals);

                for (int i = 0; i < calArray.Length; i++)
                {
                    if (dateArray[i] == dateString)
                    {
                        dailyCals = calArray[i] + c;
                        calArray[i] = dailyCals;
                        saveAll();
                        loadAll();
                    }
                }
            }

            catch
            {

            }
        }       

        public static void updateGoals(int i, string s)
        {
            try
            {

                int c = Convert.ToInt32(s);

                profileArray[i] = Convert.ToString(s);

                if(i == 1)
                {
                    dailyGoals = c;
                }

                else
                {
                    weeklyGoals = c;
                }

                saveAll();
                loadAll();
            }

            catch
            {

            }
        }

        public static string displayYesterdayCals()
        {
            string yesterdaysDate = DateTime.Now.Date.AddDays(-1).ToString("d");

            for(int i = 0; i < dateArray.Length; i++)
            {
                if(dateArray[i] == yesterdaysDate)
                {
                    return "Yesterdays Calories: " + calArray[i];
                }
            }

            return "No Data Availabe For This Date";
        }

        public static string displayDateCals(string searchDate)
        {
            try
            {
                DateTime date = DateTime.Parse(searchDate);

                for (int i = 0; i < dateArray.Length; i++)
                {
                    if (dateArray[i] == searchDate)
                    {
                        return searchDate + " Calories: " + calArray[i];
                    }
                }

                return "No Data Availabe For This Date";
            }

            catch
            {
                return "Incorrect Date Format Entered";
            }
        }

    }
}
