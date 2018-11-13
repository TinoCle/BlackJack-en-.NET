using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Carta
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
                    nom = "Dos";
                    break;
                case 3:
                    nom = "Tres";
                    break;
                case 4:
                    nom = "Cuatro";
                    break;
                case 5:
                    nom = "Cinco";
                    break;
                case 6:
                    nom = "Seis";
                    break;
                case 7:
                    nom = "Siete";
                    break;
                case 8:
                    nom = "Ocho";
                    break;
                case 9:
                    nom = "Nueve";
                    break;
                case 10:
                    nom = "Diez";
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
                    nom += " de tréboles";
                    break;
            }
            return nom;
        }
    }
}
