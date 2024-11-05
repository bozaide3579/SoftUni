﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models.Interfaces
{
    public interface IVehicle
    {
        double FuelQunatity { get; }
        double FuelConsumption { get; }

        bool Drive(double distance);
        void Refuel(double amount);
    }
}
