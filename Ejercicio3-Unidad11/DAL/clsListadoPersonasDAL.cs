using DAL;
using Ejercicio3_Unidad11.Entities;
using Newtonsoft.Json;

namespace Ejercicio3_Unidad11.DAL;

    public static class clsListadoPersonasDAL
    {
        public async static Task<List<clsPersona>> ListadoCompletoPersonasDAL()
        {
            //Pedimos la uri
            string stringURL = clsConnection.connection();

            //Esto es para que el enrutamiento salga bien
            Uri uri = new Uri($"{stringURL}Personas");

            List<clsPersona> listadoPersonas = new List<clsPersona>();
            HttpClient client = new HttpClient();
            HttpResponseMessage message;
            string textoJSONRespuesta;


            //Hacemos el request del listado
            message = await client.GetAsync(uri);

            //En caso de que salga bien
            if (message.IsSuccessStatusCode)
            {
                //Guardamos el resultado en un JSON
                textoJSONRespuesta = await client.GetStringAsync(uri);

                //Instalamos el NuGet de NewtonSoft para poder de-serializar el JSON.
                listadoPersonas = JsonConvert.DeserializeObject<List<clsPersona>>(textoJSONRespuesta);

            }

            return listadoPersonas;
        }

        public async static Task<clsPersona> DetailsPersonaDAL(int id)
        {

            //Pedimos la uri
            string miCadenaURL = "";

            //Esto es para que el enrutamiento salga bien
            Uri miUri = new Uri($"{miCadenaURL}Personas/{id}");

            clsPersona oPersona = new clsPersona();
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
                    oPersona = JsonConvert.DeserializeObject<clsPersona>(textoJSONRespuesta);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return oPersona;


        }

    }
