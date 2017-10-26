using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        #region Constructores
        public Universitario()
        { } 
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra todos los datos de un Univeristario
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            return base.ToString() + "\nLEGAJO NUMERO: " + this.legajo.ToString();
        }
        protected abstract string ParticiparEnClase();
        /// <summary>
        /// Son iguales si son del mismo tipo
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return (obj is Universitario);
        }

        #endregion

        #region Sobrecargas
        /// <summary>
        /// Searán iguales mientras sean del mismo tipo y coincidan sus dni o legajos
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if( pg1.Equals(pg2) && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Son diferentes si no son del mismo tipo o difieren sus dni o legajos
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator != (Universitario pg1, Universitario pg2)
        {
            if(pg1 == pg2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}
