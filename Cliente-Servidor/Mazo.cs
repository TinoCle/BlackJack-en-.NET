using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente_Servidor
{
	/// <summary>
	/// Clase Mazo que contendrá las 52 cartas utilizadas para jugar al BlackJack
	/// </summary>
	public class Mazo
    {
        private ArrayList mazo;
        public Mazo()
        {
            mazo = new ArrayList();
            CargarMazo();
            Mezclar();
        }

		/// <summary>
		/// Añade las Cartas a la Colección Mazo
		/// </summary>
        private void CargarMazo()
        {
            for(int x = 1; x <= 4; x++)
            {
                for(int y = 1; y <= 13; y++)
                {
                    Carta carta = new Carta(x, y);
                    mazo.Add(carta);
                }
            }
        }
        
		/// <summary>
		/// Saca la primer carta del Mazo
		/// </summary>
		/// <returns>Devuelve la Carta o null si el mazo está vacío</returns>
        public Carta SacarCarta()
        {
            if (mazo.Count > 0)
            {
                Carta sacada = (Carta)mazo[0];
                mazo.RemoveAt(0);
                return sacada;
            }
            return null;
        }

		/// <summary>
		/// Luego de Terminar la Ronda se mezcla el mazo
		/// </summary>
        private void Mezclar()
        {
            ArrayList mazoMezclado = new ArrayList();

            Random r = new Random();
            int randomIndex = 0;
            while (mazo.Count > 0)
            {
                randomIndex = r.Next(0, mazo.Count); //Elige una carta al azar
                mazoMezclado.Add(mazo[randomIndex]); //La agrega al nuevo mazo mezclado
                mazo.RemoveAt(randomIndex); //La quito para prevenir duplicados
            }
            mazo = mazoMezclado;
        }
    }
}
