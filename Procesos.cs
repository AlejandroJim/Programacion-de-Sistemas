using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea_1
{
    class Procesos
    {
        public string ExtraerIniciales(string cadena)
        {
            String Ini=cadena.Substring(0,1);
            for (int i=0;i<cadena.Length;i++)
            {
                if (cadena.Substring(i,1).Equals(" "))
                {
                    Ini += (""+ cadena.Substring(i+1,1));
                }
            }
            return Ini;
        }
        public int CalculoMinimo(int n1,int n2)
        {
            return Math.Min(n1, n2);
        }
        public int CalculoMaximo(int n1, int n2)
        {
            return Math.Max(n1, n2);
        }
    }
}
