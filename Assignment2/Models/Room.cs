/*
 * Name: Karanveer Singh
 * Course: PROG32356 .Net Technologies using C#
 * Date Created: 9th April, 2024
 */
using System.Collections.Generic;

namespace Assignment2.Models
{
    public class Room
    {
        public int RoomID { get; set; }

        public string RoomNumber { get; set; }

        public string RoomType { get; set; }

        public int Capacity { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
