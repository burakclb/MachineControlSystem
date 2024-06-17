using System;
using System.Collections.Generic;
using MachineControlSystem.Models;

namespace MachineControlSystem.Controllers
{
    public class SauceController
    {
        private readonly MotorController _motorController;
        private readonly SensorController _sensorController;

        public SauceController(MotorController motorController, SensorController sensorController)
        {
            _motorController = motorController;
            _sensorController = sensorController;
        }

        private readonly List<Sauce> _sauces = new List<Sauce>
        {
            new Sauce { Id = "1", Name = "Lemon Dressing", Description = "Lemon Dressing Sosu", MotorId = 1, SensorId = 1 },
            new Sauce { Id = "2", Name = "Pomegranate Dressing", Description = "Pomegranate Dressing Sosu", MotorId = 2, SensorId = 2 },
            new Sauce { Id = "3", Name = "Mustard Dressing", Description = "Mustard Dressing Sosu", MotorId = 3, SensorId = 3 },
            new Sauce { Id = "4", Name = "Ginger Dressing", Description = "Ginger Dressing Sosu", MotorId = 4, SensorId = 4 },
            new Sauce { Id = "5", Name = "Garlic Dressing", Description = "Garlic Dressing Sosu", MotorId = 5, SensorId = 5 },
            new Sauce { Id = "6", Name = "Hot Sauce", Description = "Hot Sauce", MotorId = 6, SensorId = 6 }
        };

        public void DispenseSauce(int sauceId, int amount)
        {
            var sauce = _sauces.Find(s => s.Id == sauceId.ToString());
            if (sauce != null)
            {
                if (_sensorController.IsPlatePositionedCorrectly(sauce.SensorId))
                {
                    _motorController.ActivateMotor(sauce.MotorId, amount);
                    Console.WriteLine($"{sauce.Name} tüpünden {amount} ml sos dağıtıldı.");
                }
                else
                {
                    Console.WriteLine($"{sauce.Name} tüpünde plaka doğru konumda değil.");
                }
            }
            else
            {
                Console.WriteLine($"Sos ID'si {sauceId} olan sos bulunamadı.");
            }
        }
    }
}
