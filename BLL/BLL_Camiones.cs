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
        //Read
        //se referencia ambos poryectos Capa adatos  Y VO
        public static List<Camiones_VO> Get_Camiones(params object[] parametros)
        {
            return DAL_Camiones.Get_Camiones(parametros);
        }
        //UpDate
        //DELETE
    }
}
