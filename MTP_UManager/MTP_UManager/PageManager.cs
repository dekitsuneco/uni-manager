using System;
/*
 * This class describes creating pages.
 */
namespace MTP_UManager
{
    static class PageManager
    {
        // 1. Login Page:
        public static void MakeLoginPage ()
        {
            bool isLoginSuccessfull = true;

            Render.NewPage();
            Render.LoginPageMessage();

            isLoginSuccessfull = Handler.Login();
            if (!isLoginSuccessfull)
            {
                Environment.Exit(0);
            }
        }

        // 2. Login Page -> Main Page:
        public static void MakeMainPage ()
        {
            do
            {
                Render.NewPage();
                Render.MainPageMessage();
                Render.MainPage();
                Handler.CheckUserChoiceInMainPageMenu();
            } while (Handler.UserChoice != ConsoleKey.Escape);
            // To close the application.
            Database.SaveDataBeforeClose();
            Environment.Exit(0);
        }

        // 3.1 Login Page -> Main Page -> Course List Page:
        public static void MakeCourseListPage ()
        {
            do
            {
                Render.NewPage();
                Render.CoursesListPageMessage();
                Render.CoursesListPage();
                Handler.CheckUserChoiceInCoursesListPageMenu();
            } while (Handler.UserChoice != ConsoleKey.Escape);
            PageManager.MakeMainPage();
        }

        // 4.1 Login Page -> Main Page -> Course List Page -> Sign Up Page:
        public static void MakeSignUpPage ()
        {
            do
            {
                Render.NewPage();
                Render.SignUpForCoursePageMessage();
            } while (Handler.UserChoice != ConsoleKey.Escape);
            PageManager.MakeCourseListPage();
        }

        // 4.2 Login Page -> Main Page -> Course List Page -> Leave Course Page:
        public static void MakeLeaveCoursePage ()
        {
            do
            {
                Render.NewPage();
                Render.LeaveCoursePageMessage();
            } while (Handler.UserChoice != ConsoleKey.Escape);
            PageManager.MakeCourseListPage();
        }

        // 3.2 Login Page -> Main Page -> Student Stats:
        public static void MakeStudentStatsPage ()
        {
            do
            {
                Render.NewPage();
                Render.StudentStatsPageMessage();
                Render.StudentStatsPage();
                Handler.CheckUserChoiceInStudentStatsPageMenu();
            } while (Handler.UserChoice != ConsoleKey.Escape);
            PageManager.MakeMainPage();
        }
    }
}
