using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace Capa_acceso_datos
{
    public class DAL_Camiones
    {
        ///create 
        ///Read
        ///Se debe referencias el proyecto VO: DAMOS CLIC DERECHO EN CAPA DATOS=> REFERENCIAS => PROYECTOS=>VO=>ACEPTAR
        public static List<Camiones_VO> Get_Camiones(params object[] parametros)
        {
            List<Camiones_VO> list = new List<Camiones_VO>();
            try
            {
                //creo un DataSet el cual recibira lo que devuelva la EJECUCION DEL METODO "execute_dataSet" de la classe "metodos_datos"
                DataSet ds_camiones = metodos_datos.execute_DataSet("SP_listar_camiones", parametros);
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
        ///delete
    }
}
