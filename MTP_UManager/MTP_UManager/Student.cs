using System.Collections.Generic;
/*
 * This class contains the info about students.
 */
namespace MTP_UManager
{
    class Student : Person
    {
        public List<string> TakenCoursesID { get; set; } 
        public List<string> FinishedCoursesID { get; set; } 
        public List<string> BlockedCoursesID { get; set; }

        public Student (string username, string status): base (username, status)
        { }
    }
}
