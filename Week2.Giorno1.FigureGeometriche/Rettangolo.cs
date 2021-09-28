using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Giorno1.FigureGeometriche
{
    public class Rettangolo : Poligono
    {
        public override void CalcolaArea()
        {
            var area = Base * Altezza;
            Area = area;
        }

        public override string PrintPerimetro()
        {
            var perimetro = (Base + Altezza) * 2;
            return $"Il perimetro e {perimetro}";
        }
    }
}
