using System;
using System.Collections.Generic;

namespace _4devStudio.FiveOfGold
{
    public class Sorteo
    {
        private static Sorteo _instancia;
        private Sorteo()
        {
        }

        private int vCantidad = 0;

        public static Sorteo Instancia
        {
            get
            {
                if(_instancia == null)
                {
                    _instancia = new Sorteo();
                }
                return _instancia;
            }
        }

        public List<Jugada> Simular(int pCantidadSorteos)
        { 
            List<Jugada> vRetorno = new List<Jugada>();
            //pCantidadSorteos = pCantidadSorteos > 1000 ? 1000 : pCantidadSorteos;
            for (int i = 0; i < pCantidadSorteos; i++)
            {
                Jugada vJugada = new Jugada();
                for (int j = 0; vJugada.Numeros.Count < 5; j++)
                {
                    int vNumeroSorteado = this.SortearNumero();
                    if (!vJugada.Numeros.Contains(vNumeroSorteado))
                    {
                        vJugada.Numeros.Add(vNumeroSorteado);
                    }
                }
                vRetorno.Add(vJugada);
            }
            return vRetorno;
        }

        private int SortearNumero()
        {
            vCantidad++;
            Random vRandom = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            return vRandom.Next(1, 48);
        }
    }
}
