using System;

namespace MachineControlSystem.Controllers
{
    public class SensorController
    {
        public bool IsPlatePositionedCorrectly(int positionId)
        {
            // Sensör kontrolü örneği
            Console.WriteLine($"Pozisyon {positionId} kontrol ediliyor.");
            return true; // Örnek olarak her zaman doğru konumda olduğunu varsayıyoruz
        }
    }
}
