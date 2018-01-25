using System;
using System.Collections.Generic;

namespace _4devStudio.FiveOfGold
{
    public static class Logica
    {
        private static Jugada ObtenerMejorJugada(List<Jugada> pJugadas)
        {
            List<Tuple<int, int>> vMejoresResultados = new List<Tuple<int, int>>();
            
            for(int i = 1; i < 49; i++)
            {
                Tuple<int, int> vTupla = new Tuple<int, int>(i, Logica.ObtenerRepeticion(pJugadas, i));
                vMejoresResultados.Add(vTupla);
            }
            return Logica.ObtenerMejorJugada(vMejoresResultados);
        }

        private static Jugada ObtenerMejorJugada(List<Tuple<int, int>> vMejoresResultados)
        {
            Jugada vRetorno = new Jugada();
            vMejoresResultados.Sort((x, y) => y.Item2.CompareTo(x.Item2));
            int j = 0;
            while (vRetorno.Numeros.Count < 5 && j < vMejoresResultados.Count)
            {
                if (!vRetorno.Numeros.Contains(vMejoresResultados[j].Item1))
                {
                    vRetorno.Numeros.Add(vMejoresResultados[j].Item1);
                }
                j++;
            }
            return vRetorno;
        }

        private static int ObtenerRepeticion(List<Jugada> pJugadas, int i)
        {
            int vRetorno = 0;
            foreach (Jugada j in pJugadas)
            {
                if (j.Numeros.Contains(i))
                {
                    vRetorno++;
                }
            }
            return vRetorno;
        }

        public static Jugada Jugar(int pCantidadSorteos)
        {
            return Logica.ObtenerMejorJugada(Sorteo.Instancia.Simular(pCantidadSorteos));
        }
    }
}
