using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MachineControlSystem.Controllers
{
    public class CoolerController
    {
        private readonly SensorController _sensorController;
        private readonly MotorController _motorController;
        private const int CoolingDuration = 75000; // ms (75 seconds)

        private readonly List<Cooler> _coolers = new List<Cooler>
        {
            new Cooler { Id = "Cooler1", Name = "Cooler 1", Description = "Soğutma Alanı 1" },
            new Cooler { Id = "Cooler2", Name = "Cooler 2", Description = "Soğutma Alanı 2" },
            new Cooler { Id = "Cooler3", Name = "Cooler 3", Description = "Soğutma Alanı 3" },
            new Cooler { Id = "Cooler4", Name = "Cooler 4", Description = "Soğutma Alanı 4" }
        };

        public CoolerController(SensorController sensorController, MotorController motorController)
        {
            _sensorController = sensorController;
            _motorController = motorController;
        }

        public async Task CoolPortion(string coolerId, int minutes)
        {
            var cooler = _coolers.Find(c => c.Id == coolerId);
            if (cooler != null)
            {
                Console.WriteLine($"{cooler.Name} soğutuluyor: {minutes} dakika.");
                _motorController.StartMotor();
                await Task.Delay(CoolingDuration); // Soğutma işlemi burada gerçekleşir
                _motorController.StopMotor();
                Console.WriteLine($"{cooler.Name} soğutma tamamlandı.");

                bool isCorrectPosition = _sensorController.IsPlatePositionedCorrectly(coolerId);
                if (!isCorrectPosition)
                {
                    Console.WriteLine($"Hata: {cooler.Name} doğru konumda değil.");
                    // Hata yönetimi yapılabilir
                }
            }
            else
            {
                Console.WriteLine($"Soğutma alanı {coolerId} bulunamadı.");
            }
        }
    }

    public class Cooler
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
