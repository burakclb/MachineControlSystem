using System;

namespace MachineControlSystem.Controllers
{
    public class MotorController
    {
        public void ActivateMotor(int motorId, int grams)
        {
            // Motoru aktifleştirme işlemi
            Console.WriteLine($"{motorId} motoru {grams} gram için aktifleştirildi.");
        }
    }
}
