using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Giorno1.FigureGeometriche
{
    public class Triangolo : Poligono
    {       
        public double Lato1 { get; set; }
        public double Lato2 { get; set; }

        public override void CalcolaArea()
        {
            var area = Base * Altezza / 2;
            Area = area;
        }

        public override string PrintPerimetro()
        {
            var perimetro = Lato1 * Lato2 + Base;
            return $"Il perimetro e {perimetro}";
        }
    }
}
