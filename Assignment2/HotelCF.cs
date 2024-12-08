using Assignment2.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Xml.Linq;

namespace Assignment2
{
    public class HotelCF : DbContext
    {
        // Your context has been configured to use a 'HotelCF' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Assignment2.HotelCF' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'HotelCF' 
        // connection string in the application configuration file.
        public HotelCF()
            : base("name=HotelCF")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}