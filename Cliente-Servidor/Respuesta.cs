using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using System.Runtime.Serialization;

namespace Cliente_Servidor
{
    [Serializable]
    public class Respuesta
    {
        [NonSerialized]
        public Socket Socket;
        [NonSerialized]
        public List<byte> TransmissionBuffer = new List<byte>();
        [NonSerialized]
        public byte[] buffer = new byte[1024];



		public int tipo;
		public int puntos;
		public bool SetearNombres;
		
		public bool turno;
		//Bool para decir si la conexion se establecio
		public bool conexion;
        //Valores servdor --> cliente
        public Carta carta;
        //Valores cliente --> servidor
        public bool otra;
        public string nombre;
        public int puerto;

        public byte[] Serialize()
        {
            SoapFormatter formatter = new SoapFormatter();
            MemoryStream mem = new MemoryStream();
            formatter.Serialize(mem, this);
            return mem.GetBuffer();
        }

        public Respuesta DeSerialize()
        {
            try
            {
                byte[] dataBuffer = TransmissionBuffer.ToArray();
                SoapFormatter formatter = new SoapFormatter();
                MemoryStream mem = new MemoryStream();
                mem.Write(dataBuffer, 0, dataBuffer.Length);
                mem.Seek(0, 0);
                return (Respuesta)formatter.Deserialize(mem);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                return null;
            }
        }
    }
}
