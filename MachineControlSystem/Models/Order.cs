using System.Collections.Generic;

namespace MachineControlSystem.Models
{
    public class Order
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<OrderItem> Items { get; set; }
        public List<Sauce> Sauces { get; set; }
    }
}
