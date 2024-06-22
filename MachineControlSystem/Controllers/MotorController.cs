using System;

namespace MachineControlSystem.Controllers
{
    public class MotorController
    {
        public void StartMotor()
        {
            Console.WriteLine("Motor çalıştırıldı.");
        }

        public void StopMotor()
        {
            Console.WriteLine("Motor durduruldu.");
        }

        public void ActivateMotor(string motorId, int grams)
        {
            Console.WriteLine($"Motor {motorId} {grams} gram için aktifleştirildi.");
        }
    }
}
