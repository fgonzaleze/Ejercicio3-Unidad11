using Ejercicio3_Unidad11.DAL;
using Ejercicio3_Unidad11.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3_Unidad11.BL
{
    public static class clsListadosPersonasBL
    {
        // TODO: Agregar las normas de la empresa
        public async static Task<List<clsPersona>> ListadoCompletoPersonasBL()
            {
                List<clsPersona> listadoPersonasBL = await clsListadoPersonasDAL.ListadoCompletoPersonasDAL();


                return listadoPersonasBL;
            }

            public async static Task<clsPersona> DetailsPersona(int id)
            {
                clsPersona persona = await clsListadoPersonasDAL.DetailsPersonaDAL(id);

                return persona;

            }


        
    }
}
