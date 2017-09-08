using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraApp
{
    public class Calculadora
    {
        public double Operar(Numero numero1, Numero numero2, string operador)
        {
            double resultado = 0;
            
            if(operador == "+")
            {
                resultado = numero1.GetNumero() + numero2.GetNumero();
            }
            if(operador == "-")
            {
                resultado = numero1.GetNumero() - numero2.GetNumero();
            }
            if(operador == "*")
            {
                resultado = numero1.GetNumero() * numero2.GetNumero();
            }
            if(operador == "/")
            {
                if(numero2.GetNumero() == 0)
                {
                    resultado = 0;
                }
                else
                {
                    resultado = numero1.GetNumero() / numero2.GetNumero();
                }
            }
            return resultado;
        }
        public string ValidarOperador(string operador)
        {   
            if (operador != "+" && operador != "-" && operador != "/" && operador != "*")
            {
                return "+";
            }
            else
            {
                return operador;
            }
        }
    }
}
