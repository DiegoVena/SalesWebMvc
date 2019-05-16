using SalesWebMvc.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;
        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }
        public void Seed()
        {
            if(_context.Department.Any() ||
                _context.Seller.Any()||
                _context.SalesRecord.Any())
            {
                return;
            }
            Department d1 = new Department(1, "computers");
            Department d2 = new Department(2, "books");
            Department d3 = new Department(3, "market");
            Department d4 = new Department(4, "fast food ");

            Seller s1 = new Seller(1, "bab brow", "bab@gmail.com", new System.DateTime(1998, 04, 20), 1000.0, d1);
            Seller s2 = new Seller(2, "beb brow", "beb@gmail.com", new System.DateTime(1998, 04, 20), 1000.0, d2);
            Seller s3 = new Seller(3, "bob brow", "bob@gmail.com", new System.DateTime(1998, 04, 20), 1000.0, d3);
            Seller s4 = new Seller(4, "bub brow", "bub@gmail.com", new System.DateTime(1998, 04, 20), 1000.0, d4);

            SalesRecord r1 = new SalesRecord(1,new DateTime(2018,09,25),11000.0,SalesStatus.Billed,s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2018, 09, 25), 1100.0, SalesStatus.Billed, s2);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2018, 09, 25), 112000.0, SalesStatus.Billed, s3);
            SalesRecord r4 = new SalesRecord(4, new DateTime(2018, 09, 25), 11300.0, SalesStatus.Billed, s4);

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s3);
            _context.SalesRecord.AddRange(r1, r2, r3, r4);
            _context.SaveChanges();
        }
    }
}
