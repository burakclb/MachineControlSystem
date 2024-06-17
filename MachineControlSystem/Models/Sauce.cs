namespace MachineControlSystem.Models
{
    public class Sauce
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public int MotorId { get; set; } // Bu satırı ekleyin
        public int SensorId { get; set; } // Bu satırı ekleyin
    }
}
