using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;

namespace CalorieCounter
{
    
    
    class Transporter
    {

        public static string userName;
        public static string path = Path.GetTempPath();
        public static string appPath = Directory.GetCurrentDirectory();

        public static string usernameDefault = appPath + @"\usernames.txt";
        public static string passwordDefault = appPath + @"\usernames.txt";

        public static string usernamePath = path + @"\usernames.txt";
        public static string[] usernameDefaultArray = new string[File.ReadLines(usernameDefault).Count()];
        public static string[] usernameArray;

        public static string passwordsPath = path + @"\passwords.txt";
        public static string[] passwordsDefaultArray = new string[File.ReadLines(passwordDefault).Count()];
        public static string[] passwordsArray;


        public static void createLocalData()
        {

            int i = 0;

            if(!File.Exists(usernamePath))
            {
                
                if (File.Exists(usernameDefault))
                {

                    foreach (string s in File.ReadAllLines(usernameDefault))
                    {
                        usernameDefaultArray[i] = s;
                        i++;
                    }


                    i = 0;
                }

                using (var writer = new StreamWriter(usernamePath, false))
                {
                    foreach (string s in usernameDefaultArray)
                    {
                        writer.WriteLine(s);
                    }
                }
            }

            if (!File.Exists(passwordsPath))
            {

                if (File.Exists(passwordDefault))
                {

                    foreach (string s in File.ReadAllLines(passwordDefault))
                    {
                        passwordsDefaultArray[i] = s;
                        i++;
                    }

                    i = 0;

                }

                using (var writer = new StreamWriter(passwordsPath, false))
                {
                    foreach (string s in passwordsDefaultArray)
                    {
                        writer.WriteLine(s);
                    }
                }
            }
        }
        
        public static void loadUsers()
        {
            int i = 0;

            if (File.Exists(usernamePath))
            {
                
                usernameArray = new string[File.ReadLines(usernamePath).Count() +1];

                foreach (string s in File.ReadAllLines(usernamePath))
                {
                    usernameArray[i] = s;
                    i++;
                }

                usernameArray[i] = "BLANK";

                i = 0;
            }

            if (File.Exists(passwordsPath))
            {

                passwordsArray = new string[File.ReadLines(passwordsPath).Count() + 1];

                foreach (string s in File.ReadAllLines(passwordsPath))
                {
                    passwordsArray[i] = s;
                    i++;
                }

                passwordsArray[i] = "BLANK";

                i = 0;
            }


        }

        public static int checkUsernames(string s)
        {
            for (int i = 0; i < usernameArray.Length; i++)
            {
                if (usernameArray[i] == s)
                {
                    return i;
                }
            }

            return -1;
        }

        public static Boolean checkPassword(string s, int i)
        {
            if(passwordsArray[i] == s)
            {
                return true;
            }

                return false;
        }

        public static void addNewUser(string user, string pass)
        {
            int i = usernameArray.Length -1;

            usernameArray[i] = user;
            passwordsArray[i] = pass;

            i = 0;

            updateUserFiles();
            loadUsers();

        }

        public static void updateUserFiles()
        {

            using (var writer = new StreamWriter(usernamePath, false))
            {
                foreach(string s in usernameArray)
                {
                    
                   if(s != "BLANK")
                    { 
                        writer.WriteLine(s);
                    }
                        
                }
            }

            using (var writer = new StreamWriter(passwordsPath, false))
            {
                foreach (string s in passwordsArray)
                {
                    if (s != "BLANK")
                    {
                        writer.WriteLine(s);
                    }
                }
            }

        }

    }
}
