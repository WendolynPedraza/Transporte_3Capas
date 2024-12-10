using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VO;

namespace Capa_acceso_datos
{
    public class DAL_Camiones
    {
        ///create 
        public static string accion_camion(Camiones_VO camion)
        {
            string salidas = "";
            int respuesta = 0;
            try
            {
                respuesta = metodos_datos.execute_nonQuery("SP_Insert_Camiones2",
                    "@Matricula", camion.Matricula,
                    "@Tipo_Camion", camion.Tipo_Camion,
                    "@Marca", camion.Marca,
                    "@Modelo", camion.Modelo,
                    "@Capacidad", camion.Capacidad1,
                    "@Kilometraje", camion.Kilometraje,
                    "@UrlFoto", camion.UrlFoto,
                    "@Disponibilidad", camion.Disponibilidad);
                if (respuesta != 0)
                {
                    salidas = "Camion registrado con exito";
                }
                else
                {
                    salidas = "Ha ocurrido un error";
                }
            }
            catch (Exception e)
            {
                //salida="Error: " + e.Message
                salidas = $"Error: {e.Message}";
            }
            return salidas;
        }
        ///Read
        ///Se debe referencias el proyecto VO: DAMOS CLIC DERECHO EN CAPA DATOS=> REFERENCIAS => PROYECTOS=>VO=>ACEPTAR
        public static List<Camiones_VO> Get_Camiones(params object[] parametros)
        {
            List<Camiones_VO> list = new List<Camiones_VO>();
            try
            {
                //creo un DataSet el cual recibira lo que devuelva la EJECUCION DEL METODO "execute_dataSet" de la classe "metodos_datos"
                DataSet ds_camiones = metodos_datos.execute_DataSet("SP_Lista_Camiones", parametros);
                //recorro cada renglon existente de nuestro ds crando objetos del tipo VO y añadiendolos a la lista 
                foreach(DataRow dr in ds_camiones.Tables[0].Rows)
                {
                    list.Add(new Camiones_VO(dr));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        ///Uodate
        public static string Actualizar_camion(Camiones_VO camion)
        {
            string salidas = "";
            int respuesta = 0;
            try
            {
                respuesta = metodos_datos.execute_nonQuery("SP_Actualizar_Camiones",
                    "@Matricula", camion.Matricula,
                    "@Tipo_Camion", camion.Tipo_Camion,
                    "@Marca", camion.Marca,
                    "@Modelo", camion.Modelo,
                    "@Capacidad", camion.Capacidad1,
                    "@Kilometraje", camion.Kilometraje,
                    "@UrlFoto", camion.UrlFoto,
                    "@Disponibilidad", camion.Disponibilidad);
                if (respuesta != 0)
                {
                    salidas = "Camion registrado con exito";
                }
                else
                {
                    salidas = "Ha ocurrido un error";
                }
            }
            catch (Exception e)
            {
                //salida="Error: " + e.Message
                salidas = $"Error: {e.Message}";
            }
            return salidas;
        }
        ///delete
        public static string eliminar_Camion(int id)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = metodos_datos.execute_nonQuery("SP_Eliminar_Camiones", "@Id", id);
                if(respuesta !=0)
                {
                    salida = "Camion eliminado con exito";
                }
                else
                {
                    salida = "Ha ocurrido un error";
                }
            }
            catch (Exception e)
            {
                salida = $"Error: {e.Message}";
            }
        }
    }
}
