using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * This class contains the items of all menus.
 */
namespace MTP_UManager
{
    static class MenuItems
    {
        public static string[] MainPage ()
        {
            return new string[] {
                "Показать список доступных курсов",
                "Показать персональную статистику по учебным курсам",
                "Нажмите еscape, чтобы вернуться на предыдущую страницу"
            };
        }

        public static string[] CoursesListPage ()
        {
            return new string[] {
                "Записаться на курс",
                "Уйти с курса",
                "Нажмите еscape, чтобы вернуться на предыдущую страницу"
            };
        }

        public static string[] StudentStatsPage ()
        {
            return new string[] {
                "Нажмите еscape, чтобы вернуться на предыдущую страницу"
        };
        }
    }
}