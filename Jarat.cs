using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telekocsi
{
    public class Jarat
    {

        public string indulas { get; set; }
        public string cel { get; set; }
        public string rendszam { get; set; }
        public string telszam { get; set; }
        public int ferohely { get; set; }
        public Jarat(string line)
        {
            this.cel = line.Split(';')[0].Trim();
            this.indulas = line.Split(';')[1].Trim();
            this.telszam = line.Split(';')[3].Trim();
            this.rendszam = line.Split(';')[2].Trim();
            this.ferohely = int.Parse(line.Split(';')[4].Trim());
        }


    }
}
