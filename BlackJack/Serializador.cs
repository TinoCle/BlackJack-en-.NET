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
		public void Serialize(Dictionary<string, int> ranking)
		{
			BinaryFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream("ranking.dat", FileMode.Create, FileAccess.Write, FileShare.Read);
			formatter.Serialize(stream, ranking);
			stream.Close();
		}

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
