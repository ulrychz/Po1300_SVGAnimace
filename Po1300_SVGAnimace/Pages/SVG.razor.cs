using Newtonsoft.Json;
using Po1300_SVGAnimace.Models;
using System.Diagnostics;
using System.Drawing;

namespace Po1300_SVGAnimace.Pages
{
    public partial class SVG
    {
       
        public int SvgWidth { get; set; } = 1600;
        public int SvgHeight { get; set;} = 800;
        public int MinRozmer { get; } = 20;
        public int MaxRozmer { get; } = 80;
        public bool AnimaceBezi { get; set; } = false;
        public List<Obrazec> SvgObrazceList { get; set; } = new List<Obrazec>();
        public int PosunKrok { get; set; } = 1;

        private Random random = new Random();
        private int typObrazcePocet = Enum.GetNames(typeof(Globals.TypObrazce)).Length;
        private void PridatObrazec(Microsoft.AspNetCore.Components.Web.MouseEventArgs e)
        {
            Globals.TypObrazce typ;
            typ = (Globals.TypObrazce)random.Next(typObrazcePocet);
            Obrazec obrazec = null;
            var rozmer1 = random.Next(MinRozmer,MaxRozmer);
            Color barva = Color.FromArgb(random.Next(256),random.Next(256),random.Next(256));
            switch (typ)
            {
                case Globals.TypObrazce.ctverec:
                    obrazec = new Ctverec(typ,random.Next(0, SvgWidth - rozmer1),random.Next(0, SvgHeight - rozmer1), barva,rozmer1);
                    break;
                case Globals.TypObrazce.obdelnik:
                    var rozmer2 = random.Next(MinRozmer, MaxRozmer);
                    obrazec = new Obdelnik(typ, random.Next(0, SvgWidth - rozmer1), random.Next(0, SvgHeight - rozmer2), 
                        barva, rozmer1,rozmer2);
                    break;
                case Globals.TypObrazce.kruh:
                    obrazec = new Kruh(typ, random.Next(0, SvgWidth - rozmer1), random.Next(0, SvgHeight - rozmer1), barva, rozmer1);
                    break;
            }
            if (obrazec!= null)
            {
                SvgObrazceList.Add(obrazec);
            }
        }
        private void OdebratObrazec(Microsoft.AspNetCore.Components.Web.MouseEventArgs e)
        {
            if (SvgObrazceList.Any())
            {
                SvgObrazceList.RemoveAt(SvgObrazceList.Count - 1);
            }
        }

        private async Task Ulozit()
        {
            string output = JsonConvert.SerializeObject(SvgObrazceList, 
                new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.Auto, Formatting = Formatting.Indented });

            await localStorage.SetItemAsync("data", output);
        }
        private async Task NacistData(Microsoft.AspNetCore.Components.Web.MouseEventArgs e)
        {
           var jsonString = await localStorage.GetItemAsync<string>("data");
            if ( !string.IsNullOrEmpty(jsonString))
            {
                var output = JsonConvert.DeserializeObject<List<Obrazec>>(jsonString,
                    new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });

                if (output != null)
                {
                    SvgObrazceList.AddRange(output);
                }
            }
           

        }


        private async Task SmazatData(Microsoft.AspNetCore.Components.Web.MouseEventArgs e)
        {
            await localStorage.RemoveItemAsync("data");
        }

        private async Task Posun()
        {
            AnimaceBezi = true;
            do 
            {
                foreach (var item in SvgObrazceList)
                {
                    item.PosunObjekt(PosunKrok, SvgWidth, SvgHeight, -MaxRozmer);
                }
                StateHasChanged();
                await Task.Delay(10);
            } while (AnimaceBezi);
        }

        private void PosunZastavit()
        {
            AnimaceBezi = false;
        }
    }
}
