using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Archivos;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Test para validar la excepcion AlumnoRepetidoException
        /// </summary>
        [TestMethod]
        public void ValidarAlumnoRepetidoException()
        {
            Universidad gim = new Universidad();
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456",
           EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
           Alumno.EEstadoCuenta.Becado);
            gim += a1;
            //Pruebo con igual dni y diferente legajo
            Alumno a2 = new Alumno(2, "Marcelo", "Asus", "12234456",
           EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
           Alumno.EEstadoCuenta.Becado);
            try
            {
                gim += a2;
                Assert.Fail("Deberia lanzar excepcion AlumnoRepetido");
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
            //Pruebo con igual legajo y diferente dni
            Alumno a3 = new Alumno(1, "Marcelo", "Asus", "12234555",
           EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
           Alumno.EEstadoCuenta.Becado);
            try
            {
                gim += a3;
                Assert.Fail("Deberia lanzar excepcion AlumnoRepetido");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }
        /// <summary>
        /// Test para validar la excepcion NacionalidadInvalidaException
        /// </summary>
        [TestMethod]
        public void ValidarNacionalidadInvalidaException()
        {
            
            Universidad gim = new Universidad();
            //Pruebo con dni argentino y nacionalidad extrangera
            try
            {
                Alumno a2 = new Alumno(2, "Juana", "Martinez", "12234458",
                    EntidadesAbstractas.Persona.ENacionalidad.Extranjero, 
                    Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Deudor);
                gim += a2;
                Assert.Fail("Deberia lanzar excepcion NacionalidadInvalida");
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
            //Pruebo con dni extrangero y nacionalidad argentina
            try
            {
                Alumno a2 = new Alumno(2, "Juan", "Lopez", "92264456",
          EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
          Alumno.EEstadoCuenta.Becado);
                gim += a2;
                Assert.Fail("Deberia lanzar excepion Nacionalidad invalida");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }
        /// <summary>
        /// Test para ver si los atributos de una clase no son nulos
        /// </summary>
        [TestMethod]
        public void ValidaAtributosNulos()
        {
            Universidad uni = new Universidad();

            Assert.IsNotNull(uni.Alumnos);
            Assert.IsNotNull(uni.Instructores);
            Assert.IsNotNull(uni.Jornadas);
        }

    }
}
