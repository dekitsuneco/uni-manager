using System.Collections.Generic;
/*
 * This class describes the work with our database, pulling the data from it.
 */
namespace MTP_UManager
{
    static class Database
    {
        public static bool CheckIfUserExist (string username, string password) /**/
        {
            if (/*Query from database is*/ true)
                // Test data:
                if ((username == "Yui") && (password == "12345"))
                {
                    return true;
                }
                else if ((username == "Sachi") && (password == "56"))
                {
                    return true;
                }
                // End of test data.
                else
                {
                    return false;
                }
        }

        public static Dictionary<string, string> GetUserFromDatabase (string username,
            out List<string> coursesUserTook,
            out List<string> coursesUserSee,
            out List<string> coursesUserEnded,
            out List<string> coursesBlockedForUser)
        {
            Dictionary<string, string> userProfle = new Dictionary<string, string>(2)
            {
                /*Queries from database*/
                { "username", username },
                { "status", "студент" }
            };

            // Below is real algorithm of taking courses from database:
            ////CoursesManger.courses = new List<string[]>();
            ////for (int i = 0; i < /*Amount of courses*/ 3; i++)
            ////{
            ////    string[] temp = new string[4];
            ////    for (int j = 0; j < 4; j++)
            ////    {
            ////        /*Queries from database*/
            ////        temp[0] = "1";
            ////        temp[1] = "Math";
            ////        temp[2] = "Курс высшей математики";
            ////        temp[3] = "З.Звежншский";
            ////    }
            ////    CoursesManger.courses.Add(temp);
            ////}
            /// This is for test:
            CoursesManger.courses = new List<string[]>(4);
            CoursesManger.courses.Add(new string[]
            { "1", "Math", "Курс высшей математики", "З.Звежншский" });
            CoursesManger.courses.Add(new string[]
            {"2", "English",  "Курс английского уровня intermidiate", "Д.Сэм"});
            CoursesManger.courses.Add(new string[]
            {"3", "Physics",  "Курс квантовой механики", "К.Варков"});
            CoursesManger.courses.Add(new string[]
            { "4", "Chemistry",  "Курс теории врзывчатых веществ", "Р.Эволюцион"});
            /// End of test data.

            coursesUserSee = new List<string> {/*Query from database*/ "1", "2", "3" , "4"};
            coursesUserTook = new List<string> {/*Query from database*/ "1" };
            coursesUserEnded = new List<string> {/*Query from database*/ "2" };
            coursesBlockedForUser = new List<string> {/*Query from database*/ "4" };

            return userProfle;
        }

        public static void SaveDataBeforeClose ()
        {
            // Save all changes about taken, signed up end ended courses.
        }
    }
}
