using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;


namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Enum
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion

        #region Atributos
        private int _dni;
        private string _apellido;
        private string _nombre;
        private ENacionalidad _nacionalidad; 
        #endregion
        
        #region Propiedades
        public string Apellido
        {
            get { return this.ValidarNombreApellido(this._apellido); }
            set { this._apellido = ValidarNombreApellido(value); }
        }
        public int DNI
        {
            get { return this.ValidarDni(this._nacionalidad, this._dni.ToString()); }
            set { this._dni = this.ValidarDni(this._nacionalidad, value);}
        }
        public ENacionalidad Nacionalidad { get { return this._nacionalidad; } set { this._nacionalidad = value; } }
        public string Nombre
        {
            get { return this.ValidarNombreApellido(this._nombre); }
            set { this._nombre = this.ValidarNombreApellido(value); }
        }
        public string StringToDNI { set { this._dni = this.ValidarDni(this._nacionalidad, value); } }
        #endregion

        #region Constructores
        public Persona()
        {
        }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Apellido = apellido;
            this.Nombre = nombre;
            this._nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra todos los atributos de la clase
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}", this._apellido, this._nombre);
            sb.AppendLine("NACIONALIDAD: " + this._nacionalidad);
            return sb.ToString();
        }
        /// <summary>
        /// Valida que el dni coincida con la nacionalidad dada
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            bool flag = true;

            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato < 1 || dato > 89999999)
                    {
                        flag = false;
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if (dato <= 89999999)
                    {
                        flag = false;
                    }
                    break;
                default:
                    throw new NacionalidadInvalidaException();
            }
            if (!flag)
            {
                throw new NacionalidadInvalidaException();
            }
            else
            {
                return dato;
            }
        }
        /// <summary>
        /// Verifica que el dni sea valido y que coincida con su nacionalidad
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
              return this.ValidarDni(nacionalidad, int.Parse(dato));    
        }
        /// <summary>
        /// Valida una cadena para que reciba solo caracteres, si no, la formatea
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            Regex reg = new Regex(@"^[a-zA-Z]+$");
            if (reg.IsMatch(dato))
            {
                return dato;
            }
            else
            {
                return null;
            }
        }

        #endregion
    }
}
