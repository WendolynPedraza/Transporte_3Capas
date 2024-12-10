using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;
using Capa_acceso_datos;

namespace BLL
{
    public class BLL_Camiones
    {
        //Create
        public static string Insertar_camion(Camiones_VO camion)
        {
            return DAL_Camiones.Insertar_camion(camion);
        }
        //Read
        //se referencia ambos poryectos Capa adatos  Y VO
        public static List<Camiones_VO> Get_Camiones(params object[] parametros)
        {
            return DAL_Camiones.Get_Camiones(parametros);
        }
        //UpDate
        public static string Actualizar_camion(Camiones_VO camion)
        {
            return DAL_Camiones.Actualizar_camion(camion);
        }
        //DELETE
        public static string eliminar_Camion(int id)
        {
            return DAL_Camiones.eliminar_Camion(id);
        }
    }
}
