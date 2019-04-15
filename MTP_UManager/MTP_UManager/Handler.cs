using System;
using System.Collections.Generic;
/*
 * This class describes data operating.
 */
namespace MTP_UManager
{
    static class Handler
    {
        // Initializating.
        public static Student user;
        public static ConsoleKey UserChoice;

        // Login part.
        public static bool Login ()
        {
            string username = "",
                password = "";
            bool isLoginSuccessfull;

            Console.Write("Пользователь: ");
            username = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Пароль: ");
            password = Console.ReadLine();

            Handler.LoginCheck(username, password, out isLoginSuccessfull);

            return isLoginSuccessfull;
        }

        private static void LoginCheck (string username, string password,
            out bool isLoginSuccessfull)
        {
            if (Database.CheckIfUserExist(username, password))
            {
                isLoginSuccessfull = true;
                Handler.SetUpCurrentUser(username);
            }
            else
            {
                isLoginSuccessfull = false;
                Render.LoginFailedError();
            }
        }

        private static void SetUpCurrentUser (string username)
        {
            Dictionary<string, string> userData =
                Database.GetUserFromDatabase(username,
                out List<string> coursesUserTook,
                out List<string> coursesUserSee,
                out List<string> coursesUserEnded,
                out List<string> coursesBlockedForUser);

            string status = userData["status"];
            if (status == "студент")
            {
                user = new Student(username, "студент")
                {
                    AvailableCoursesID = coursesUserSee,
                    TakenCoursesID = coursesUserTook,
                    FinishedCoursesID = coursesUserEnded,
                    BlockedCoursesID = coursesBlockedForUser
                };
            }
            else if (/*Status is teacher*/ false)
            {
                //TODO
            }
            else if (/*Status is rector*/false)
            {
                //TODO
            }
        }

        // Courses part.
        public static void SignUpForCoursePage (string whatCourse)
        {
            List<string> coursesIDArray = Handler.user.AvailableCoursesID;
            bool doesCourseExist = false;
            // Does the user want to return or else does exist the course he choosed?
            if (whatCourse == "return")
            {
                Render.CoursesListPage();
                Handler.UserChoice = ConsoleKey.Escape;
                return;
            }
            else
            {
                foreach (string courseID in coursesIDArray)
                {
                    if (whatCourse == courseID)
                    {
                        doesCourseExist = true;
                        break;
                    }
                }
            }
            // Let's sign up for that course!
            if (doesCourseExist)
            {
                // Sign up and return to the previous page.
                Handler.SignUpForCourse(whatCourse);
                Handler.UserChoice = ConsoleKey.Escape;
            }
            else
            {
                Render.CourseSignUpError("existingError");
            }
        }

        public static void SignUpForCourse(string courseID)
        {
            if (Handler.user.BlockedCoursesID.Contains(courseID))
            {
                Render.CourseSignUpError("blockedError");
            }
            else if (Handler.user.FinishedCoursesID.Contains(courseID))
            {
                Render.CourseSignUpError("alreadyFinishedError");
            }
            else if (Handler.user.TakenCoursesID.Contains(courseID))
            {
                Render.CourseSignUpError("alreadyTakenError");
            }
            else
            {
                Handler.user.TakenCoursesID.Add(courseID);
                Render.SignedUpForCourseMessage();
            }
        }

        public static void LeaveCoursePage (string whatCourse)
        {
            List<string> coursesIDArray = Handler.user.AvailableCoursesID;
            bool doesCourseExist = false;
            // Does the user want to return or else does exist the course he choosed?
            if (whatCourse == "return")
            {
                Handler.UserChoice = ConsoleKey.Escape;
                return;
            }
            else
            {
                foreach (string courseID in coursesIDArray)
                {
                    if (whatCourse == courseID)
                    {
                        doesCourseExist = true;
                        break;
                    }
                }
            }
            // Let's leave that course!
            if (doesCourseExist)
            {
                Handler.LeaveCourse(whatCourse);
                Handler.UserChoice = ConsoleKey.Escape;
            }
            else
            {
                Render.CourseLeaveError("existingError");
            }
        }

        public static void LeaveCourse(string courseID)
        {
            if (!Handler.user.TakenCoursesID.Contains(courseID))
            {
                Render.CourseLeaveError("notLearningError");
            }
            else
            {
                Handler.user.TakenCoursesID.Remove(courseID);
                Render.CourseLeavedMessage();
            }
        }

        // Main Page Menu.
        public static void CheckUserChoiceInMainPageMenu ()
        {
            switch (Handler.UserChoice)
            {
                case ConsoleKey.D1:
                    PageManager.MakeCourseListPage();
                    break;
                case ConsoleKey.D2:
                    PageManager.MakeStudentStatsPage();
                    break;
                default:
                    // We'll rerender this page again in this case.
                    break;
            }
        }

        // Course List Page.
        public static void CheckUserChoiceInCoursesListPageMenu ()
        {
            switch (Handler.UserChoice)
            {
                case ConsoleKey.D1:
                    PageManager.MakeSignUpPage();
                    break;
                case ConsoleKey.D2:
                    PageManager.MakeLeaveCoursePage();
                    break;
                default:
                    // We'll rerender this page again in this case.
                    break;
            }
        }

        // Course Student Stats.
        public static void CheckUserChoiceInStudentStatsPageMenu ()
        {
            switch (Handler.UserChoice)
            {
                case ConsoleKey.Escape:
                    Handler.UserChoice = ConsoleKey.Escape;
                    break;
                default:
                    // We'll rerender this page again in this case.
                    break;
            }
        }
    }
}
