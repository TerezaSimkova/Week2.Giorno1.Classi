using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Giorno1.FigureGeometriche
{
    public class Cerchio : FiguraGeometrica
    {
        public double Raggio { get; set; }
        public Centro CoordCentro { get; set; }

        public override void CalcolaArea()
        {
            var area = Raggio * Raggio * Math.PI;
            Area = area;
        }

        public override string PrintPerimetro()
        {
            var perimetro = Raggio * 2 * 3.14; // Math.PI;
            return $"La circonferenza: {perimetro}";
        }
    }
    public struct Centro
    {
        public double x { get; set; }
        public double y { get; set; }
    }
}
