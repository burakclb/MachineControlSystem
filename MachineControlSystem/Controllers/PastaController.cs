using System;

namespace MachineControlSystem.Controllers
{
    public class PastaController
    {
        private readonly InductionCooker _inductionCooker;

        public PastaController(InductionCooker inductionCooker)
        {
            _inductionCooker = inductionCooker;
        }

        public void PreparePasta()
        {
            _inductionCooker.CookPasta();
            Console.WriteLine("Makarna hazırlandı.");
        }

        public void CleanPastaPot()
        {
            _inductionCooker.CleanPot();
            Console.WriteLine("Makarna tenceresi temizlendi.");
        }
    }
}
