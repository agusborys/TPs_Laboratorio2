using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;

        #region Propiedades
        public List<Alumno> Alumnos { get { return this._alumnos; } set { this._alumnos = value; } }
        public Universidad.EClases Clase { get { return this._clase; } set { this._clase = value; } }
        public Profesor Instructor { get { return this._instructor; } set { this._instructor = value; } }
        #endregion

        #region Constructores
        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }
        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CLASE DE {0} POR {1}", this._clase.ToString(), this._instructor.ToString());
            sb.AppendLine("ALUMNOS");
            foreach(Alumno a in this._alumnos)
            {
                sb.AppendLine(a.ToString());
            }
            sb.AppendLine("<---------------------------------------------------------------->");
            return sb.ToString();
        }
        /// <summary>
        /// Crea un archivo de texto "Jornada.txt" con los datos de la jornada
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto archTexto = new Texto();
            return archTexto.guardar("Jornada.txt", jornada.ToString());
        }
        /// <summary>
        /// Lee el contenido del archivo "Jornada.txt" y lo devuelve
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            string datos = "";
            Texto archTexto = new Texto();
            archTexto.leer("Jornada.txt", out datos);
            return datos;
        }
        #endregion

        #region Sobrecargas
        public static Jornada operator +(Jornada j , Alumno a)
        {
            bool flag = false;
            if(j == a)
            {
                flag = true;
            }
            if (!flag)
            {
                j._alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return j;
        }
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno unAlumno in j._alumnos)
            {
                if (unAlumno == a)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Jornada j, Alumno a)
        {
            if(j == a)
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
