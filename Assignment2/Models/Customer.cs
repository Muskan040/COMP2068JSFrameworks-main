/*
 * Name: Karanveer Singh
 * Course: PROG32356 .Net Technologies using C#
 * Date Created: 9th April, 2024
 */
namespace Assignment2.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Room Room { get; set; } 
    }
}
