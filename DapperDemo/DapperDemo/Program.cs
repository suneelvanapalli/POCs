using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DapperDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Dapper!");

            using (IDbConnection db = new SqlConnection("Server=.;Database=Demo;Integrated Security=true"))

            {

                var  list =  db.Query<Vendor>("Select * From Vendor").ToList();

            }
            Console.ReadKey();
        }
    }

    class Vendor
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}