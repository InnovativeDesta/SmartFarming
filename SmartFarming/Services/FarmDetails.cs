using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFarming.Services
{
    // Models/FarmDetails.cs
    public class FarmDetails
    {
        public string VegetationType { get; set; }
        public string Location { get; set; }
        public double WaterUsage { get; set; }  // in liters or any other preferred unit
    }
}
