using System.Drawing;

namespace Po1300_SVGAnimace.Models
{
    public class Kruh : Obrazec
    {
        public Kruh(Globals.TypObrazce typObrazce, int pozX, int pozY, Color barva, int polomer) : base(typObrazce, pozX, pozY, barva)
        {
            Polomer = polomer;
        }
        public int Polomer { get; set; }
    }
}
