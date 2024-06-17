using System;
using System.Collections.Generic;
using MachineControlSystem.Models;

namespace MachineControlSystem.Controllers
{
    public class PortionHeatingController
    {
        private readonly List<PortionHeatingContainer> _portionHeatingContainers = new List<PortionHeatingContainer>
        {
            new PortionHeatingContainer { Id = "PHC7-1", Location = "Basmati Rice Tüpü 7 - Kab 1" },
            new PortionHeatingContainer { Id = "PHC7-2", Location = "Basmati Rice Tüpü 7 - Kab 2" },
            new PortionHeatingContainer { Id = "PHC8-1", Location = "Basmati Rice Tüpü 8 - Kab 1" },
            new PortionHeatingContainer { Id = "PHC8-2", Location = "Basmati Rice Tüpü 8 - Kab 2" },
            new PortionHeatingContainer { Id = "PHC9-1", Location = "Et Döner Tüpü 9 - Kab 1" },
            new PortionHeatingContainer { Id = "PHC9-2", Location = "Et Döner Tüpü 9 - Kab 2" },
            new PortionHeatingContainer { Id = "PHC10-1", Location = "Et Döner Tüpü 10 - Kab 1" },
            new PortionHeatingContainer { Id = "PHC10-2", Location = "Et Döner Tüpü 10 - Kab 2" },
            new PortionHeatingContainer { Id = "PHC11-1", Location = "Tavuk Döner Tüpü 11 - Kab 1" },
            new PortionHeatingContainer { Id = "PHC11-2", Location = "Tavuk Döner Tüpü 11 - Kab 2" },
            new PortionHeatingContainer { Id = "PHC12-1", Location = "Tavuk Döner Tüpü 12 - Kab 1" },
            new PortionHeatingContainer { Id = "PHC12-2", Location = "Tavuk Döner Tüpü 12 - Kab 2" },
            new PortionHeatingContainer { Id = "PHC13-1", Location = "Köfte Tüpü 13 - Kab 1" },
            new PortionHeatingContainer { Id = "PHC13-2", Location = "Köfte Tüpü 13 - Kab 2" },
            new PortionHeatingContainer { Id = "PHC14-1", Location = "Falafel Tüpü 14 - Kab 1" },
            new PortionHeatingContainer { Id = "PHC14-2", Location = "Falafel Tüpü 14 - Kab 2" }
        };

        public void HeatPortion(string portionId)
        {
            var portion = _portionHeatingContainers.Find(p => p.Id == portionId);
            if (portion != null)
            {
                // Mikrodalgada ısıtma işlemi
                Console.WriteLine($"{portion.Location} konumundaki porsiyon ısıtma kabı ısıtılıyor.");
            }
            else
            {
                Console.WriteLine($"{portionId} ID'li porsiyon ısıtma kabı bulunamadı.");
            }
        }
    }
}
