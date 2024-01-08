using Ejercicio3_Unidad11.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3_Unidad11.BL
{
    internal class clsListadoDepartamentosBL
    {
        public async static Task<List<clsDepartamento>> ListadoCompletoDepartamentosBL()
        {
            //llamamos a la lista de personas de la capa DAL
            List<clsDepartamento> listadosDepartamentosBL = await clsListadoDepartamentosDAL.ListadoCompletoDepartamentosDAL();


            return listadosDepartamentosBL;
        }

        public async static Task<clsDepartamento> readDetailsDepartamentoBL(int idDepartamento)
        {
            //Ponemos await porque está función deberá esperar que la capa DAL haga el request
            clsDepartamento oDepartamento = await clsListadoDepartamentosDAL.readDetailsDepartamentoDAL(idDepartamento);

            return oDepartamento;

        }


    }
}
