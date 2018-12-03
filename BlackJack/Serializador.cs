using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace BlackJack
{
	class Serializador
	{

		/// <summary>
		/// Método que se utiliza para serializar el Diccionario DineroJugadores del Server
		/// </summary>
		/// <param name="ranking"></param>
		public void Serialize(Dictionary<string, int> ranking)
		{
			BinaryFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream("ranking.dat", FileMode.Create, FileAccess.Write, FileShare.Read);
			formatter.Serialize(stream, ranking);
			stream.Close();
		}

		/// <summary>
		/// Método que Deserializa el archivo de ranking para así poder mandarlo al cliente que solicitó la información
		/// del Ranking
		/// </summary>
		/// <returns></returns>
		public Dictionary<string, int> Deserializar()
		{
			BinaryFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream("ranking.dat", FileMode.Open, FileAccess.Read, FileShare.Read);
			Dictionary<string, int> aux = (Dictionary<string, int>) formatter.Deserialize(stream);
			stream.Close();
			return aux;
		}
	}
}
