using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inicio!");

            Salesman salesman = new Salesman { Id = 1, Name= "Marcelo"};

            List<Product> products = new List<Product>
            {
                new Product { Id = 1 , Description = "Coletor de dados", UnitaryValue = 400},
                new Product { Id = 2, Description="Impressora Termica" ,UnitaryValue = 450 }
            };

            List<Sales> sales = new List<Sales>
            {
                new Sales {Id=1, Value= 400, IdSalesman=1},
                new Sales {Id=2, Value= 900, IdSalesman=1},
                new Sales {Id=3, Value= 100, IdSalesman=2},
                new Sales {Id=4, Value= 200, IdSalesman=3},
            };

            List<SalesProduct> salesProducts = new List<SalesProduct>
            {
                new SalesProduct {IdProduct=1, IdSales=1, Quantity=1},
                new SalesProduct {IdProduct=2, IdSales=2, Quantity=2}
            };

            //var x = sales.Where(s => s.Id==1);
            // show groupby sum  by saleman
            var xSales = from sale in sales group sale by sale.Value into salesByMan select salesByMan.Count();

            var sumSales = sales.GroupBy(s => s.IdSalesman)
                .Select(s => new {
                    IdSalesman = s.Key,
                    Values = s.Sum(s1 => s1.Value)
                })
                .ToList();
             
            //var sumSales = sales.GroupBy(s => s.IdSalesman)
            //    .Select(s => new
            //    {
            //        IdSaleman = s.Key,
            //        Values = s.Count(),
            //    }).OrderBy(s => s.Values);

            var y = xSales.Max();

            foreach (Object s in sumSales) {
                Console.WriteLine(s);
            }

            //foreach (Sales s in xSales) {
            //    Console.WriteLine(s);
            //};
        }
    }

    class Salesman
    { 
        public int Id { get; set; }
        public String CPF { get; set; }
        public String Name { get; set; }
    }

    class Sales
    {
        public int Id { get; set; }
        public Decimal Value { get; set; }
        public int IdSalesman { get; set; }
    }

    class Product
    {
        public int Id { get; set; }
        public String Description { get; set; }
        public Decimal UnitaryValue { get; set; }
    }
    class SalesProduct
    {
        public int IdProduct { get; set; }
        public int IdSales { get; set; }
        public long Quantity { get; set; }
    }
}
