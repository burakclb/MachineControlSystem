using System;
using System.Collections.Generic;
using MachineControlSystem.Controllers;

namespace MachineControlSystem
{
    public class TubeController
    {
        private readonly MotorController _motorController;
        private readonly SensorController _sensorController;

        public TubeController(MotorController motorController, SensorController sensorController)
        {
            _motorController = motorController;
            _sensorController = sensorController;
        }

        private readonly List<Tube> _tubes = new List<Tube>
        {
            new Tube { Id = "1", Name = "Ana Yemek Tabağı", Description = "Ana Yemek Tabağı Tüpü", MotorId = 1, SensorId = 1 },
            new Tube { Id = "2", Name = "Crispy Bread", Description = "Crispy Bread Tüpü", MotorId = 2, SensorId = 2 },
            new Tube { Id = "3", Name = "Mix Greens", Description = "Mix Greens Tüpü", MotorId = 3, SensorId = 3 },
            new Tube { Id = "4", Name = "Mix Greens", Description = "Mix Greens Tüpü", MotorId = 4, SensorId = 4 },
            new Tube { Id = "5", Name = "Romaine", Description = "Romaine Tüpü", MotorId = 5, SensorId = 5 },
            new Tube { Id = "6", Name = "Romaine", Description = "Romaine Tüpü", MotorId = 6, SensorId = 6 },
            new Tube { Id = "7", Name = "Basmati Rice", Description = "Basmati Rice Tüpü", MotorId = 7, SensorId = 7, HeatingContainers = new List<HeatingContainer>
                {
                    new HeatingContainer { Id = "7A", Description = "Basmati Rice Heating Container 1" },
                    new HeatingContainer { Id = "7B", Description = "Basmati Rice Heating Container 2" }
                }
            },
            new Tube { Id = "8", Name = "Basmati Rice", Description = "Basmati Rice Tüpü", MotorId = 8, SensorId = 8, HeatingContainers = new List<HeatingContainer>
                {
                    new HeatingContainer { Id = "8A", Description = "Basmati Rice Heating Container 1" },
                    new HeatingContainer { Id = "8B", Description = "Basmati Rice Heating Container 2" }
                }
            },
            new Tube { Id = "9", Name = "Et Döner", Description = "Et Döner Tüpü", MotorId = 9, SensorId = 9, HeatingContainers = new List<HeatingContainer>
                {
                    new HeatingContainer { Id = "9A", Description = "Et Döner Heating Container 1" },
                    new HeatingContainer { Id = "9B", Description = "Et Döner Heating Container 2" }
                }
            },
            new Tube { Id = "10", Name = "Et Döner", Description = "Et Döner Tüpü", MotorId = 10, SensorId = 10, HeatingContainers = new List<HeatingContainer>
                {
                    new HeatingContainer { Id = "10A", Description = "Et Döner Heating Container 1" },
                    new HeatingContainer { Id = "10B", Description = "Et Döner Heating Container 2" }
                }
            },
            new Tube { Id = "11", Name = "Tavuk Döner", Description = "Tavuk Döner Tüpü", MotorId = 11, SensorId = 11, HeatingContainers = new List<HeatingContainer>
                {
                    new HeatingContainer { Id = "11A", Description = "Tavuk Döner Heating Container 1" },
                    new HeatingContainer { Id = "11B", Description = "Tavuk Döner Heating Container 2" }
                }
            },
            new Tube { Id = "12", Name = "Tavuk Döner", Description = "Tavuk Döner Tüpü", MotorId = 12, SensorId = 12, HeatingContainers = new List<HeatingContainer>
                {
                    new HeatingContainer { Id = "12A", Description = "Tavuk Döner Heating Container 1" },
                    new HeatingContainer { Id = "12B", Description = "Tavuk Döner Heating Container 2" }
                }
            },
            new Tube { Id = "13", Name = "Köfte", Description = "Köfte Tüpü", MotorId = 13, SensorId = 13, HeatingContainers = new List<HeatingContainer>
                {
                    new HeatingContainer { Id = "13A", Description = "Köfte Heating Container 1" },
                    new HeatingContainer { Id = "13B", Description = "Köfte Heating Container 2" }
                }
            },
            new Tube { Id = "14", Name = "Falafel", Description = "Falafel Tüpü", MotorId = 14, SensorId = 14, HeatingContainers = new List<HeatingContainer>
                {
                    new HeatingContainer { Id = "14A", Description = "Falafel Heating Container 1" },
                    new HeatingContainer { Id = "14B", Description = "Falafel Heating Container 2" }
                }
            },
            new Tube { Id = "15", Name = "Diced Cucumber", Description = "Diced Cucumber Tüpü", MotorId = 15, SensorId = 15 },
            new Tube { Id = "16", Name = "Pickled Onion", Description = "Pickled Onion Tüpü", MotorId = 16, SensorId = 16 },
            new Tube { Id = "17", Name = "Feta Cheese", Description = "Feta Cheese Tüpü", MotorId = 17, SensorId = 17 },
            new Tube { Id = "18", Name = "Corn", Description = "Corn Tüpü", MotorId = 18, SensorId = 18 },
            new Tube { Id = "19", Name = "Arugula", Description = "Arugula Tüpü", MotorId = 19, SensorId = 19 },
            new Tube { Id = "20", Name = "Cherry Tomato", Description = "Cherry Tomato Tüpü", MotorId = 20, SensorId = 20 },
            new Tube { Id = "21", Name = "Diced Bell Pepper", Description = "Diced Bell Pepper Tüpü", MotorId = 21, SensorId = 21 },
            new Tube { Id = "22", Name = "Mini Sos Kabı", Description = "Mini Sos Kabı Tüpü", MotorId = 22, SensorId = 22 },
            new Tube { Id = "23", Name = "Mini Sos Kapağı", Description = "Mini Sos Kapağı Tüpü", MotorId = 23, SensorId = 23 },
            new Tube { Id = "24", Name = "Ana Yemek Tabak Kapağı", Description = "Ana Yemek Tabak Kapağı Tüpü", MotorId = 24, SensorId = 24 },
        };

        public void DispenseProduct(int tubeId, int grams)
        {
            var tube = _tubes.Find(t => t.Id == tubeId.ToString());
            if (tube != null)
            {
                if (_sensorController.IsPlatePositionedCorrectly(tube.SensorId))
                {
                    _motorController.ActivateMotor(tube.MotorId, grams);
                    Console.WriteLine($"{tube.Name} tüpünden {grams} gram ürün dağıtıldı.");
                }
                else
                {
                    Console.WriteLine($"{tube.Name} tüpünde plaka doğru konumda değil.");
                }
            }
            else
            {
                Console.WriteLine($"Tüp ID'si {tubeId} olan tüp bulunamadı.");
            }
        }
    }

    public class Tube
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MotorId { get; set; }
        public int SensorId { get; set; }
        public List<HeatingContainer> HeatingContainers { get; set; }
    }

    public class HeatingContainer
    {
        public string Id { get; set; }
        public string Description { get; set; }
    }
}
