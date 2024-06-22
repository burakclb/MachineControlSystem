using System;
using System.Collections.Generic;
using MachineControlSystem.Controllers;
using MachineControlSystem.Models;
using MachineControlSystem.Services;

namespace MachineControlSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Motor ve sensör kontrolleri oluşturuluyor
            SensorController sensorController = new SensorController();
            MotorController motorController = new MotorController();
            ConveyorController conveyorController = new ConveyorController(sensorController, motorController);
            TubeController tubeController = new TubeController(motorController, sensorController);
            SauceController sauceController = new SauceController(motorController, sensorController);
            OrderProcessor orderProcessor = new OrderProcessor(sensorController);

            // Sipariş örneği
            var order = new Order
            {
                Name = "Müşteri Siparişi",
                Description = "Bir sipariş açıklaması",
                Items = new List<OrderItem>
                {
                    new OrderItem { Name = "Pilav", Description = "Beyaz pilav", TubeId = "7", MotorId = "7", SensorId = "7", Amount = 2 },
                    new OrderItem { Name = "Köfte", Description = "Izgara köfte", TubeId = "13", MotorId = "13", SensorId = "13", Amount = 3 }
                },
                Sauces = new List<Sauce>
                {
                    new Sauce { Id = "1", Name = "Lemon Dressing", Description = "Tatlı ketçap", Amount = 1 },
                    new Sauce { Id = "2", Name = "Pomegranate Dressing", Description = "Yoğun mayonez", Amount = 2 }
                }
            };

            // İşlem başlatma
            conveyorController.StartConveyor().Wait();

            foreach (var item in order.Items)
            {
                tubeController.DispenseProduct(item.TubeId, item.Amount * 60); // Örneğin 60 gram olarak belirledik
            }

            foreach (var sauce in order.Sauces)
            {
                sauceController.DispenseSauce(int.Parse(sauce.Id), sauce.Amount * 45); // Örneğin 45 ml olarak belirledik
            }

            conveyorController.StopConveyor().Wait();

            Console.WriteLine("Sipariş işlendi.");
        }
    }
}
