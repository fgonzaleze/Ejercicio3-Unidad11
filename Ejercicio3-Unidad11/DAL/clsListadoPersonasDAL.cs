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
            string mensajeJSON;

            message = await client.GetAsync(uri);

            if (message.IsSuccessStatusCode)
            {
                mensajeJSON = await client.GetStringAsync(uri);
                listadoPersonas = JsonConvert.DeserializeObject<List<clsPersona>>(mensajeJSON);

            }

            return listadoPersonas;
        }

        public async static Task<clsPersona> DetailsPersonaDAL(int id)
        {

            string stringURL = "";
            Uri uri = new Uri($"{stringURL}Personas/{id}");

            clsPersona oPersona = new clsPersona();
            HttpClient client = new HttpClient();
            HttpResponseMessage message;
            string mensajeJSON;

            try
            {
                //Hacemos el request del listado
                message = await client.GetAsync(uri);

                //En caso de que salga bien
                if (message.IsSuccessStatusCode)
                {
                    mensajeJSON = await client.GetStringAsync(uri);
                    oPersona = JsonConvert.DeserializeObject<clsPersona>(mensajeJSON);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return oPersona;


        }

    }
