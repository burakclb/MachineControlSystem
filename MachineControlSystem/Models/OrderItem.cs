namespace MachineControlSystem.Models
{
    public class OrderItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string TubeId { get; set; }
        public string MotorId { get; set; }
        public string SensorId { get; set; }
        public int Amount { get; set; }
    }
}
