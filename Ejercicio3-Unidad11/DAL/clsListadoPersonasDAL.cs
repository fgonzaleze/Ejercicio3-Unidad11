using DAL;
using Ejercicio3_Unidad11.Entities;
using Newtonsoft.Json;

namespace Ejercicio3_Unidad11.DAL;

    public static class clsListadoPersonasDAL
    {
        private static HttpClient cliente = new HttpClient();
        private static string urlConexion = clsConnection.connection();
    /// <summary>
    /// funcion que obtiene un listado completo de clsPersona de la base de datos. Utiliza el método HTTP GET para solicitar los datos de la API. 
    /// </summary>
    /// <returns>devuelve el JSON en un listado de personas</returns>
    public async static Task<List<clsPersona>> ListadoCompletoPersonasDAL()
        {
            Uri uri = new Uri($"{urlConexion}Personas");
            List<clsPersona> listadoPersonas = new List<clsPersona>();
            HttpResponseMessage mensaje = await cliente.GetAsync(uri);

        if (mensaje.IsSuccessStatusCode)
        {
            string mensajeJSON = await cliente.GetStringAsync(uri);
            listadoPersonas = JsonConvert.DeserializeObject<List<clsPersona>>(mensajeJSON);
        }

            return listadoPersonas;
        }
    /// <summary>
    /// funcion queobtiene los detalles de una clsPersona especifica de la base de datos utilizando su id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>devuelve el JSON en un objeto persona </returns>
    public async static Task<clsPersona> DetailsPersonaDAL(int id)
        {

            Uri uri = new Uri($"{urlConexion}Personas/{id}");
            clsPersona persona = new clsPersona();
            HttpResponseMessage mensaje;

        try
        {
            mensaje = await cliente.GetAsync(uri);

            if (mensaje.IsSuccessStatusCode)
            {
                string mensajeJSON = await cliente.GetStringAsync(uri);
                persona = JsonConvert.DeserializeObject<clsPersona>(mensajeJSON);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return persona;

        }

    }
