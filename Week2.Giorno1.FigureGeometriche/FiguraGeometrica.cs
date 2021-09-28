using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Giorno1.FigureGeometriche
{
    public abstract class FiguraGeometrica // la faccio astratta, non la voglio istanziare 
    {
        public string Nome { get; set; }
        public double Area { get; set; } //la metto come proprieta

        public string PrintNome()
        {
            return $"{Nome}";
        }
        //sono astratte tutte due per poter ereditarle
        public abstract string PrintPerimetro();
        public abstract void CalcolaArea();

        public string PrintArea()
        {
            return $"Area: {Area}";
        }
    }
}
