using System.Drawing;

namespace Po1300_SVGAnimace.Models
{
    public class Ctverec : Obrazec
    {
        public Ctverec(Globals.TypObrazce typObrazce, int pozX, int pozY, Color barva, int stranaA) : base(typObrazce, pozX, pozY, barva)
        {
            StranaA = stranaA;
        }
        public int StranaA { get; set; }
    }
}
