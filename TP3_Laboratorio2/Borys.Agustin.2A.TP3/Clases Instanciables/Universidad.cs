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
    public class Universidad
    {
        #region Enum
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        #region Propiedades
        public List<Alumno> Alumnos { get { return this.alumnos; } set { this.alumnos = value; } }
        public List<Profesor> Instructores { get { return this.profesores; } set { this.profesores = value; } }
        public List<Jornada> Jornadas { get { return this.jornada; } set { this.jornada = value; } }
        public Jornada this[int i]
        {
            get
            {
                if (i >= this.jornada.Count || i < 0)
                {
                    return null;
                }
                else
                {
                    return this.jornada[i];
                }
            }
            set
            {
                this.jornada[i] = value;
            }
        }

        #endregion

        #region Constructor
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los datos de la universidad: Jornadas, profesores, alumnos
        /// </summary>
        /// <param name="gim"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad gim)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADAS: ");
            foreach(Jornada unaJornada in gim.jornada)
            {
                sb.AppendLine(unaJornada.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// Hace publicos los datos de la Universidad
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        /// <summary>
        /// Crea un archivo "Universidad.xml" con los datos de la universidad
        /// </summary>
        /// <param name="gim"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad gim)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            return xml.guardar("Universidad.xml", gim);
        }
        /// <summary>
        /// Lee los datos del archivo "Universidad.xml"
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {
            Universidad uni;
            Xml<Universidad> xml = new Xml<Universidad>();
            xml.leer("Universidad.xml", out uni);
            return uni;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Una Universidad será igual a un Alumno si éste esta inscripta en ella
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach(Alumno unAlumno in g.alumnos)
            {
                if(unAlumno == a)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Una Universiadad será diferente de un Alumno si éste no esta inscripto en ella
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            if(g == a)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// Una Universidad será igual a un Profesor si éste esta dando clases en ella
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach(Profesor unProfe in g.profesores)
            {
                if(unProfe == i)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Una Universidad será diferente a un Profesor si este no esta dando clases en ella
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            if (g == i)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// Si Universidad es igual a una EClase devolverá el primer profesor capaz de dar esa clase
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach(Profesor unProfe in g.profesores)
            {
                if(unProfe == (EClases)clase)
                {
                    return unProfe;
                }
            }
            throw new SinProfesorException();
            
        }
        /// <summary>
        /// Si Universidad es diferente a EClase devolverá el primer profesor que no pueda dar esa clase
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach(Profesor unProfe in g.profesores)
            {
                if(unProfe != clase)
                {
                    return unProfe;
                }
            }
            return null;
        }
        /// <summary>
        /// Agrega un Alumno a la Universidad si es que éste no está en ella
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if(g != a)
            {
                g.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return g;
        }
        /// <summary>
        /// Agrega un Profesor a la Universidad si es que este no esta cargado en ella
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if(g != i)
            {
                g.profesores.Add(i);
            }
            return g;
        }
        /// <summary>
        /// Al sumar una EClase a una Universidad agrega una jornada con un profesor que pueda dar la clase y una lista de alumnos que puedan cursarla
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor p = (g == (EClases)clase);
            Jornada jornada = new Jornada((EClases)clase, p);
            foreach (Alumno unAlu in g.alumnos)
            {
                if(unAlu == (EClases)clase)
                {
                    jornada += unAlu;
                }
            }
            g.jornada.Add(jornada);
            return g;
        }

        #endregion
    }
}
