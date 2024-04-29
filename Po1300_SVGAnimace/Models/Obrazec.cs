using System.Drawing;

namespace Po1300_SVGAnimace.Models
{
    public abstract class Obrazec
    {
        public Obrazec(Globals.TypObrazce typObrazce, int pozX, int pozY, Color barva) 
        { 
            TypObrazce = typObrazce;
            PozX = pozX;
            PozY = pozY;
            Barva = barva;
        }
        public int PozX { get; set; }
        public int PozY { get; set; }
        public Color Barva { get; set; }
        public Globals.TypObrazce TypObrazce { get; set; }
    }
}
