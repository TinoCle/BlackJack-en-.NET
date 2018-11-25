using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente_Servidor
{
    [Serializable]
    public class Carta
    {
        int tipo;
        int numero;
        string nombre;
        public Carta(int t, int n)
        {
            tipo = t;
            numero = n;
            nombre = SetNombre();
        }

        public string Nombre { get => nombre;}

        private string SetNombre()
        {
            string nom = "";
            switch (numero)
            {
                case 1:
                    nom = "As";
                    break;
                case 2:
                    nom = "2";
                    break;
                case 3:
                    nom = "3";
                    break;
                case 4:
                    nom = "4";
                    break;
                case 5:
                    nom = "5";
                    break;
                case 6:
                    nom = "6";
                    break;
                case 7:
                    nom = "7";
                    break;
                case 8:
                    nom = "8";
                    break;
                case 9:
                    nom = "9";
                    break;
                case 10:
                    nom = "10";
                    break;
                case 11:
                    nom = "Jack";
                    break;
                case 12:
                    nom = "Reina";
                    break;
                case 13:
                    nom = "Rey";
                    break;
            }
            switch (tipo)
            {
                case 1:
                    nom += " de picas";
                    break;
                case 2:
                    nom += " de corazones";
                    break;
                case 3:
                    nom += " de diamantes";
                    break;
                case 4:
                    nom += " de treboles";
                    break;
            }
            return nom;
        }
    }
}
