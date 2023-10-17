using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1VaniKhanna
{
    public class Vehicle
    {
        private int id;
        public int  ID { get; set; }

        private string name;
        public string Name { get; set; }

        private double rentalPrice;
        public double RentalPrice { get; set; }

        private string category;
        public string Category { get; set;}

        private string type;
        public string Type { get; set; }

        private string isReserved;
        public string IsReserved { get; set; }

        public Vehicle(int id, string name, double rentalPrice, string category, string type, string isReserved)
        {
            ID = id;
            Name = name;
            RentalPrice = rentalPrice;
            Category = category;
            Type = type;
            IsReserved = isReserved;
        }

        public override string ToString()
        {
            return base.ToString();
        }


    }
}
