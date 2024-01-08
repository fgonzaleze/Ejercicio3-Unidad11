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
        /// <summary>
        /// Método que se conecta con una api y devuelve un listado de personas.
        /// </summary>
        public async static Task<List<clsDepartamento>> ListadoCompletoDepartamentosDAL()
        {
            //Pedimos la uri
            string miCadenaURL = clsConnection.connection();

            //Esto es para que el enrutamiento salga bien
            Uri miUri = new Uri($"{miCadenaURL}Departamentos");

            List<clsDepartamento> listadoDepartamentos = new List<clsDepartamento>();
            HttpClient client = new HttpClient();
            HttpResponseMessage message;
            string textoJSONRespuesta;

            try
            {
                //Hacemos el request del listado
                message = await client.GetAsync(miUri);

                //En caso de que salga bien
                if (message.IsSuccessStatusCode)
                {
                    //Guardamos el resultado en un JSON
                    textoJSONRespuesta = await client.GetStringAsync(miUri);

                    //Instalamos el NuGet de NewtonSoft para poder de-serializar el JSON.
                    listadoDepartamentos = JsonConvert.DeserializeObject<List<clsDepartamento>>(textoJSONRespuesta);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listadoDepartamentos;
        }

        /// <summary>
        /// Método que lee los detalles de un departamento.
        /// 
        /// Pre: recibe un id de un departamento.
        /// Post: 
        /// </summary>
        /// <param name="idDepartamento"></param>
        /// <returns></returns>
        public async static Task<clsDepartamento> readDetailsDepartamentoDAL(int idDepartamento)
        {

            //Pedimos la uri
            string miCadenaURL = "";

            //Esto es para que el enrutamiento salga bien
            Uri miUri = new Uri($"{miCadenaURL}Departamentos/{idDepartamento}");

            clsDepartamento oDepartamento = new clsDepartamento();
            HttpClient client = new HttpClient();
            HttpResponseMessage message;
            string textoJSONRespuesta;

            try
            {
                //Hacemos el request del listado
                message = await client.GetAsync(miUri);

                //En caso de que salga bien
                if (message.IsSuccessStatusCode)
                {
                    //Guardamos el resultado en un JSON
                    textoJSONRespuesta = await client.GetStringAsync(miUri);

                    //Instalamos el NuGet de NewtonSoft para poder de-serializar el JSON.
                    oDepartamento = JsonConvert.DeserializeObject<clsDepartamento>(textoJSONRespuesta);

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
    

