using System;
using System.Collections.Generic;
using System.Drawing;
using MachineControlSystem.Models;

namespace MachineControlSystem.Controllers
{
    public class CoolerController
    {
        private readonly List<Cooler> _coolers = new List<Cooler>
        {
            new Cooler { Id = "Cooler1", Name = "Cooler 1", Description = "Soğutma Alanı 1" },
            new Cooler { Id = "Cooler2", Name = "Cooler 2", Description = "Soğutma Alanı 2" },
            new Cooler { Id = "Cooler3", Name = "Cooler 3", Description = "Soğutma Alanı 3" },
            new Cooler { Id = "Cooler4", Name = "Cooler 4", Description = "Soğutma Alanı 4" }
        };

        public void CoolPortion(string coolerId, int minutes)
        {
            var cooler = _coolers.Find(c => c.Id == coolerId);
            if (cooler != null)
            {
                Console.WriteLine($"{cooler.Name} soğutuluyor: {minutes} dakika.");
                // Soğutma işlemi burada gerçekleşir
            }
            else
            {
                Console.WriteLine($"Soğutma alanı {coolerId} bulunamadı.");
            }
        }
    }
}
