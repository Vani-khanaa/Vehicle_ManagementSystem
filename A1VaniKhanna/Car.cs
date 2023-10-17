using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1VaniKhanna
{
    public class Car : Vehicle
    {
        public Car(int id, string name, double rentalPrice, string category, string type, string isReserved)
        : base(id, name, rentalPrice, category, type, isReserved)
        {

        }
        public override string ToString()
        {
            return base.ToString(); 
        }

    }
}
