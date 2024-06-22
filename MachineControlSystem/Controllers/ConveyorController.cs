using System;
using System.Threading.Tasks;

namespace MachineControlSystem.Controllers
{
    public class ConveyorController
    {
        private readonly SensorController _sensorController;
        private readonly MotorController _motorController;
        private const double ConveyorSpeed = 0.1; // m/s
        private const int StopDuration = 4000; // ms (4 seconds)

        public ConveyorController(SensorController sensorController, MotorController motorController)
        {
            _sensorController = sensorController;
            _motorController = motorController;
        }

        public async Task StartConveyor()
        {
            Console.WriteLine("Konveyör sistemi başlatıldı.");
            _motorController.StartMotor();
            await Task.CompletedTask;
        }

        public async Task StopConveyor()
        {
            Console.WriteLine("Konveyör sistemi durduruldu.");
            _motorController.StopMotor();
            await Task.CompletedTask;
        }

        public async Task MoveToPosition(int positionId)
        {
            Console.WriteLine($"Konveyör pozisyon {positionId} için hareket ediyor.");
            double distance = CalculateDistanceToPosition(positionId);
            int travelTime = (int)(distance / ConveyorSpeed * 1000); // ms cinsinden süre

            _motorController.StartMotor();
            await Task.Delay(travelTime);
            _motorController.StopMotor();

            // Tabağın doğru pozisyonda olduğunu kontrol et
            bool isCorrectPosition = _sensorController.IsPlatePositionedCorrectly(positionId);
            if (!isCorrectPosition)
            {
                Console.WriteLine($"Hata: Tabak pozisyon {positionId} doğru konumda değil.");
                // Hata yönetimi yapılabilir
            }

            // Duraklama süresi (ürünün alınması için)
            await Task.Delay(StopDuration);
        }

        private double CalculateDistanceToPosition(int positionId)
        {
            // Örnek olarak, her pozisyon arası mesafeyi 1 metre olarak alalım
            return positionId * 1.0; // metre cinsinden mesafe
        }
    }
}
