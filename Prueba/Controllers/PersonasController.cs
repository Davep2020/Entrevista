using Prueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Prueba.Controllers
{
    public class PersonasController : Controller
    {
        EntrevistaEntities modeloBD = new EntrevistaEntities();
        #region Json
        public ActionResult RetornaProvincias()
        {
            List<sp_RetornaProvincias_Result> provincias = this.modeloBD.sp_RetornaProvincias(null).ToList();
            return Json(provincias);
        }
        public ActionResult RetornaCantones(int id_Provincia)
        {
            List<sp_RetornaCantones_Result> cantones = this.modeloBD.sp_RetornaCantones(null, id_Provincia).ToList();
            return Json(cantones);
        }

        public ActionResult RetornaDistritos(int id_Canton)
        {
            List<sp_RetornaDistritos_Result> distritos = this.modeloBD.sp_RetornaDistritos(null, id_Canton).ToList();
            return Json(distritos);
        }
        #endregion
        #region Listar
        public ActionResult PersonaLista()
        {
            List<sp_RetornaPersona_Result> modeloVista =
                new List<sp_RetornaPersona_Result>();

            modeloVista = modeloBD.sp_RetornaPersona().ToList();
            return View(modeloVista);
        }
        #endregion

        #region Eliminar
        public ActionResult PersonaEliminar(int id_Persona)
        {
            sp_RetornaPersonaID_Result modelovista = new sp_RetornaPersonaID_Result();
            modelovista = this.modeloBD.sp_RetornaPersonaID(id_Persona).FirstOrDefault();
            ProvinciasViewbag();
            CantonViewbag();
            DistritoViewbag();
            return View(modelovista);
        }

        [HttpPost]
        public ActionResult PersonaEliminar(sp_RetornaPersonaID_Result modelovista)
        {
            int cantRegistrosAfectados = 0;
            string resultado = "";
            try
            {
                cantRegistrosAfectados = this.modeloBD.sp_EliminaPersona(
                    modelovista.Id_Persona);
            }
            catch (Exception error)
            {
                resultado = "Ocurrio un error: " + error.Message;
            }
            finally
            {
                if (cantRegistrosAfectados > 0)
                {
                    resultado += "Registro Eliminado";
                }
                else
                {
                    resultado += "No se pudo Eliminado";
                }

            }
            Response.Write("<script language=javascript>alert('" + resultado + "')</script>");
            ProvinciasViewbag();
            CantonViewbag();
            DistritoViewbag();
            return View(modelovista);


        }
        #endregion

        #region Registrar
        public ActionResult PersonaNueva()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PersonaNueva(sp_RetornaPersonas_Result modeloVista)
        {
            int cantRegistroAfectados = 0;
            string resultado = "";
            try
            {
                cantRegistroAfectados = this.modeloBD.sp_RegistraPersona(
                                        modeloVista.Nombre,
                                        modeloVista.Correo,
                                        modeloVista.id_Provincia,
                                        modeloVista.id_Canton,
                                        modeloVista.id_Distrito);
            }
            catch (Exception error)
            {
                resultado = "Ocurrio un error: " + error.Message;
            }
            finally
            {
                if (cantRegistroAfectados > 0)
                {
                    resultado += "Registro Insertado";
                }
                else
                {
                    resultado += "No se pudo insertar";
                }
            }

            Response.Write("<script language=javascript>alert('" + resultado + "');</script>");
            return View();
        }
        #endregion

        #region Modificar
        /// <summary>
        /// Función Para modificar Datos 
        /// </summary>
        /// <param name="Id_Cliente_P"></param>
        /// <returns></returns>
        public ActionResult PersonaModifica(int id_Persona)
        {
            sp_RetornaPersonaID_Result modelovista = new sp_RetornaPersonaID_Result();
            modelovista = this.modeloBD.sp_RetornaPersonaID(id_Persona).FirstOrDefault();
            
            ProvinciasViewbag();
            CantonViewbag();
            DistritoViewbag();
            return View(modelovista);

        }

        [HttpPost]
        public ActionResult PersonaModifica(sp_RetornaPersonaID_Result modelovista)
        {
            int cantRegistrosAfectados = 0;
            string resultado = "";
            try
            {
                cantRegistrosAfectados = this.modeloBD.sp_ModificaPersona(
                    modelovista.Id_Persona,
                    modelovista.Nombre,
                    modelovista.Correo,
                    modelovista.Id_Provincia,
                    modelovista.Id_Canton,
                    modelovista.Id_Distrito
                    );
            }
            catch (Exception error)
            {
                resultado = "Ocurrio un error: " + error.Message;
            }
            finally
            {
                if (cantRegistrosAfectados > 0)
                {
                    resultado += "Registro modificado";
                }
                else
                {
                    resultado += "No se pudo modificar";
                }

            }
            Response.Write("<script language=javascript>alert('" + resultado + "')</script>");
            ProvinciasViewbag();
            CantonViewbag();
            DistritoViewbag();
            return View(modelovista);


        }

        #endregion


        #region Metodos
        void ProvinciasViewbag()
        {
            this.ViewBag.ListaProvincia = this.modeloBD.sp_RetornaProvincias("");
        }
        void CantonViewbag()
        {
            this.ViewBag.ListaCanton = this.modeloBD.sp_RetornaCantones("", null);
        }
        void DistritoViewbag()
        {
            this.ViewBag.ListaDistrito = this.modeloBD.sp_RetornaDistritos("", null);
        }
        #endregion
    }
}