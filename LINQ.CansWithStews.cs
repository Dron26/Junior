using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ.CansWithStews
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Warehouse warehouse = new Warehouse();
            warehouse.Work();
        }
    }

    class Warehouse
    {
        private List<CanWithStews> _cansStews = new List<CanWithStews>();
        public Warehouse()
        {
            Random random = new Random();
            int numberName;
            int countCans = 15;
            int maxProductionDay = 10;
            int productionDay;
            int maxExpirationDate = 150;
            DateTime expirationDate = new DateTime();
            DateTime productionDate = new DateTime(2022,01,01);

            List<string> names = new List<string>()
            {
                "Тушенка Кубанская",
                "Тушенка мясной край",
                "Игнатьевское подворье"
            };

            for (int i = 0; i < countCans; i++)
            {
                numberName = random.Next(names.Count);
                productionDay = random.Next(maxProductionDay);
                productionDate = productionDate.AddDays(productionDay);
                expirationDate = productionDate.AddDays(maxExpirationDate);

                _cansStews.Add(new CanWithStews(names[numberName], productionDate, expirationDate));
            }
        }

        public void Work()
        {
            ShowExpiredProduct(SortByExpirationDate());
            Console.Clear();
        }

        private void ShowExpiredProduct(List<CanWithStews> cansStews)
        {
            Console.Clear();
            DateTime moment = DateTime.Now;

            if (cansStews != null & cansStews.Count > 0)
            {
                foreach (CanWithStews cans in cansStews)
                {
                    Console.WriteLine($"\n  Name: {cans.Name}  ExpirationDate: {cans.ExpirationDate.ToString("D")} ProductionDate: {cans.ProductionDate.ToString("D")} Expired on {((int)(moment-cans.ExpirationDate).TotalDays)} day" );
                }
            }
            else
            {
                Console.WriteLine($"Overdue product was not found");
            }

            Console.ReadLine();
        }

        private List<CanWithStews> SortByExpirationDate()
        {
            DateTime moment = DateTime.Now;

            var sortCanWithStewsByExpirationDate = from cans in _cansStews
                                                   where cans.ExpirationDate<moment
                                                   select cans;
            return sortCanWithStewsByExpirationDate.ToList();
        }
    }

    class Can
    {
        public string Name { get; private set; }
        public DateTime ProductionDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }

        public Can(string name, DateTime productionDate, DateTime expirationDate)
        {
            Name = name;
            ProductionDate = productionDate;
            ExpirationDate = expirationDate;
        }
    }

    class CanWithStews : Can
    {
        public CanWithStews(string name, DateTime roductionDate, DateTime expirationDate) :base(name, roductionDate, expirationDate)
        {            
        }
    }
}
