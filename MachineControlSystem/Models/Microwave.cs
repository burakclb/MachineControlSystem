using System;

namespace MachineControlSystem.Models
{
    public class Microwave
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MotorId { get; set; }
        public int SensorId { get; set; }
    }
}
