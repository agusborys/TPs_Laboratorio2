using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraApp
{
    public class Numero
    {
        private double numero;
        public Numero()
        {
            this.numero = 0;
        }
        public Numero(double numero)
        {
            this.numero = numero;
        }
        public Numero(string numero)
        {
            setNumero(numero);
        }
        public double GetNumero()
        {
            return this.numero;
        }
        private double ValidarNumero(string numeroString)
        {
            double numeroValidado = 0;
            if (!double.TryParse(numeroString, out numeroValidado))
            {
                numeroValidado = 0;
            }
            return numeroValidado;
        }
        private void setNumero(string numero)
        {
            if (ValidarNumero(numero) != 0)
            {
                this.numero = ValidarNumero(numero);
            }
        }
    }
}
