using System;
/*
 * This class describes the UI part of program.
 */
namespace MTP_UManager
{

    static class Render
    {
        public static void NewPage()
        {
            Console.Clear();
            Console.WriteLine("[Университет]");
            Console.WriteLine();
        }

        public static void Menu(string[] menuItems)
        {
            Console.WriteLine("Меню:");
            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {menuItems[i]}");
            }
            Console.WriteLine();
            Console.Write("Ввод: ");
            Handler.UserChoice = Console.ReadKey(true).Key;
        }

        // Login 
        public static void LoginPageMessage()
        {
            Console.WriteLine("Введите данные для входа в приложение");
            Console.WriteLine();
        }

        public static void LoginFailedError()
        {
            Console.WriteLine("Введённой вами комбинации логина и пароля не существует!");
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }

        // Login -> Main Menu
        public static void MainPageMessage()
        {
            Console.WriteLine($"Добро пожаловать, {Handler.user.Username}");
            Console.WriteLine($"Ваш статус: {Handler.user.Status}");
            Console.WriteLine();
        }

        public static void MainPage()
        {
            Render.Menu(MenuItems.MainPage());
        }

        // Login -> Main Menu -> Courses List
        public static void CoursesListPageMessage()
        {
            Console.WriteLine($"Список курсов для {Handler.user.Username}:");
            Console.WriteLine();
        }

        public static void CoursesListPage()
        {
            foreach (string courseID in Handler.user.AvailableCoursesID)
            {
                Render.GetCourseInfo(courseID);
            }

            Render.Menu(MenuItems.CoursesListPage());
        }

        public static void GetCourseInfo(string courseID)
        {
            string name = CoursesManger.courses[Convert.ToInt32(courseID) - 1][1],
                description = CoursesManger.courses[Convert.ToInt32(courseID) - 1][2],
                teacher = CoursesManger.courses[Convert.ToInt32(courseID) - 1][3],
                status = "None";
            if (Handler.user.FinishedCoursesID.Contains(courseID))
            {
                status = "Завершен";
            }
            else if (Handler.user.TakenCoursesID.Contains(courseID))
            {
                status = "Изучается";
            }
            else if (Handler.user.BlockedCoursesID.Contains(courseID))
            {
                status = "Заблокирован";
            }
            else
            {
                status = "Доступен";
            }

            Console.WriteLine($"[{courseID}] {name}");
            Console.WriteLine($"---ОПИСАНИЕ: {description}");
            Console.WriteLine($"---ПРЕПОДАВАТЕЛЬ: {teacher}");
            Console.WriteLine($"---СТАТУС: {status}");
        }

        // Login -> Main Menu -> Courses List -> Sign Up For Course
        public static void SignUpForCoursePageMessage()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Запись на учебный курс");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Введите ID курса или return, чтобы вернуться назад");
            Console.Write("Ввод: ");

            string whatCourse = Console.ReadLine();
            Handler.SignUpForCoursePage(whatCourse);
        }

        public static void CourseSignUpError(string errorType)
        {
            Render.NewPage();

            if (errorType == "existingError")
            {
                Console.WriteLine("Введённого вами курса не существует.. ;(");
                Console.WriteLine("Нажмите любую клавишу...");
                Console.ReadKey();
            }
            else if (errorType == "blockedError")
            {
                Console.WriteLine("К сожалению, доступ к данному курсу был ограничен для вас");
                Console.WriteLine("Нажмите любую клавишу...");
                Console.ReadKey();
            }
            else if (errorType == "alreadyFinishedError")
            {
                Console.WriteLine("Вы уже окончили данный курс");
                Console.WriteLine("Нажмите любую клавишу...");
                Console.ReadKey();
            }
            else if (errorType == "alreadyTakenError")
            {
                Console.WriteLine("Вы уже проходите данный курс");
                Console.WriteLine("Нажмите любую клавишу...");
                Console.ReadKey();
            }
        }

        public static void SignedUpForCourseMessage()
        {
            Render.NewPage();
            Console.WriteLine("Поздравляем! Вы успешно записались на курс");
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }

        // Login -> Main Menu -> Courses List -> Leave Course
        public static void LeaveCoursePageMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Покинуть учебный курс");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Введите ID курса или return, чтобі вернуться назад");
            Console.Write("Ввод: ");

            string whatCourse = Console.ReadLine();
            Handler.LeaveCoursePage(whatCourse);
        }

        public static void CourseLeaveError(string errorType)
        {
            Render.NewPage();

            if (errorType == "existingError")
            {
                Console.WriteLine("Введённого вами курса не существует.. ;(");
                Console.WriteLine("Нажмите любую клавишу...");
                Console.ReadKey();
            }
            else if (errorType == "notLearningError")
            {
                Console.WriteLine("Вы не были записаны на данный курс");
                Console.WriteLine("Нажмите любую клавишу...");
                Console.ReadKey();
            }
        }

        public static void CourseLeavedMessage()
        {
            Render.NewPage();
            Console.WriteLine("Вы успешно покинули курс =(");
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }

        // Login -> Main Menu -> Courses Stats
        public static void StudentStatsPageMessage()
        {
            Console.WriteLine($"Статистика студента {Handler.user.Username}");
            Console.WriteLine();
        }

        public static void StudentStatsPage()
        {
            Console.WriteLine($"|Курсов на изучении   |   {Handler.user.TakenCoursesID.Count}|");
            Console.WriteLine($"|Завершенных kурсов   |   {Handler.user.FinishedCoursesID.Count}|");

            Render.Menu(MenuItems.StudentStatsPage());
        }
    }
}