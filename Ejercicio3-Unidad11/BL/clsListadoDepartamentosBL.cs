using Ejercicio3_Unidad11.DAL;
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
            List<clsDepartamento> listadosDepartamentosBL = await clsDepartamentosDAL.ListadoCompletoDepartamentosDAL();


            return listadosDepartamentosBL;
        }

        public async static Task<clsDepartamento> readDetailsDepartamentoBL(int idDepartamento)
        {
            clsDepartamento oDepartamento = await clsDepartamentosDAL.readDetailsDepartamentoDAL(idDepartamento);

            return oDepartamento;

        }


    }
}
