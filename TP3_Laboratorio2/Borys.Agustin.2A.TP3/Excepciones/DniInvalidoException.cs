using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private static string mensajeBase = "DNI Invalido";

        public DniInvalidoException() : base(mensajeBase)
        { }
        public DniInvalidoException(Exception e) : this(e, mensajeBase)
        { }
        public DniInvalidoException(string message)
            : base(message)
        { }
        public DniInvalidoException(Exception e, string message)
            : base(message, e)
        { }
      
    }
}
