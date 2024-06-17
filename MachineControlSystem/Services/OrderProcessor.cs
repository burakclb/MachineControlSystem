using System;
using MachineControlSystem.Controllers;
using MachineControlSystem.Models;

namespace MachineControlSystem.Services
{
    public class OrderProcessor
    {
        private readonly SensorController _sensorController;

        public OrderProcessor(SensorController sensorController)
        {
            _sensorController = sensorController;
        }

        public void ProcessOrder(Order order)
        {
            // Sipariş işleme mantığı burada yer alacak
        }
    }
}
