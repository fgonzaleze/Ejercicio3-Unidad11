using DAL;
using Ejercicio3_Unidad11.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3_Unidad11.DAL
{
    public static class clsDepartamentosDAL
    {
        public async static Task<List<clsDepartamento>> ListadoCompletoDepartamentosDAL()
        {
            string miCadenaURL = clsConnection.connection();
            Uri miUri = new Uri($"{miCadenaURL}Departamentos");

            List<clsDepartamento> listadoDepartamentos = new List<clsDepartamento>();
            HttpClient client = new HttpClient();
            HttpResponseMessage message;
            string mensajeJSON;

            try
            {
                message = await client.GetAsync(miUri);

                if (message.IsSuccessStatusCode)
                {
                    mensajeJSON = await client.GetStringAsync(miUri);
                    listadoDepartamentos = JsonConvert.DeserializeObject<List<clsDepartamento>>(mensajeJSON);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listadoDepartamentos;
        }

        public async static Task<clsDepartamento> readDetailsDepartamentoDAL(int idDepartamento)
        {
            string miCadenaURL = "";

            Uri miUri = new Uri($"{miCadenaURL}Departamentos/{idDepartamento}");

            clsDepartamento oDepartamento = new clsDepartamento();
            HttpClient client = new HttpClient();
            HttpResponseMessage message;
            string mensajeJSON;

            try
            {
                message = await client.GetAsync(miUri);

                if (message.IsSuccessStatusCode)
                {
                    mensajeJSON = await client.GetStringAsync(miUri);
                    oDepartamento = JsonConvert.DeserializeObject<clsDepartamento>(mensajeJSON);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return oDepartamento;


        }
    }
}
    

