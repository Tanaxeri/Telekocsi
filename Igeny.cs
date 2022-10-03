using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telekocsi
{
    public class Igeny
    {


        public string indulas { get; set; }
        public string cel { get; set; }
        public string azonosito { get; set; }
        public string telszam { get; set; }
        public int szemlyek { get; set; }
        public Igeny(string line)
        {
            this.cel = line.Split(';')[2].Trim();
            this.indulas = line.Split(';')[1].Trim();
            this.azonosito = line.Split(';')[0].Trim();
            this.szemlyek = int.Parse(line.Split(';')[3].Trim());
        }



    }
}
