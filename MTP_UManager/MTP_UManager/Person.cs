using System.Collections.Generic;
/*
 * This class is the abstract class for all user's classes.
 */
namespace MTP_UManager
{
    class Person
    {
        public string Username { get; }
        public string Status { get; }

        public List<string> AvailableCoursesID { get; set; }

        public Person (string username, string status)
        {
            this.Username = username;
            this.Status = status;
        }
    }
}
