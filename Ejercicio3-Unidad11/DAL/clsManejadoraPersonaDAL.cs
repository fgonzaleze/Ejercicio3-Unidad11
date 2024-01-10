using DAL;
using Ejercicio3_Unidad11.Entities;
using Newtonsoft.Json;
using System.Net;

namespace Ejercicio3_Unidad11.DAL;

public class clsManejadoraPersonaDAL 
{
    private static HttpClient cliente = new HttpClient();
    private static string urlConexion = clsConnection.connection();
    /// <summary>
    /// crea una nueva clsPersona en la base de datos. Utiliza el metodo HTTP POST para enviar los datos de clsPersona a la API
    /// </summary>
    /// <param name="persona"></param>
    /// <returns>Codigo de estado de la operacion HTTP</returns>
    public static async Task<HttpStatusCode> CreatePersonaDAL(clsPersona persona)
    {
        Uri uri = new Uri($"{urlConexion}Personas");
        HttpResponseMessage respuestaHttp = await PostAsync(uri, persona);

        return respuestaHttp.StatusCode;
    }
    /// <summary>
    /// actualiza una clsPersona existente en la base de datos. Utiliza el mtodo HTTP PUT para enviar los datos actualizados de clsPersona a la API
    /// </summary>
    /// <param name="persona">los datos de la persona</param>
    /// <returns></returns>
    public static async Task<HttpStatusCode> UpdatePersonaDAL(clsPersona persona)
    {
        Uri uri = new Uri($"{urlConexion}Personas/{persona.Id}"); // Id de la persona, o pasarlo por param?
        HttpResponseMessage respuestaHttp = await PutAsync(uri, persona);


        return respuestaHttp.StatusCode;
    }
    /// <summary>
    /// elimina una clsPersona existente de la base de datos utilizando su id
    /// </summary>
    /// <param name="id">id de la persona a borrar</param>
    /// <returns>Codigo de estado de la operacion HTTP</returns>
    public async static Task<HttpStatusCode> DeletePersonaDAL(int id)
    {
        Uri uri = new Uri($"{urlConexion}Personas/{id}");
        HttpResponseMessage respuestaHttp = await cliente.DeleteAsync(uri);

        return respuestaHttp.StatusCode;
    }
    /// <summary>
    /// funcionprivada que realiza una solicitud HTTP POST a la API y convierte el objeto clsPersona en una cadena JSON para la API
    /// </summary>
    /// <param name="uri"></param>
    /// <param name="persona"></param>
    /// <returns></returns>
    private static async Task<HttpResponseMessage> PostAsync(Uri uri, clsPersona persona)
    {
        string datosJson = JsonConvert.SerializeObject(persona);
        HttpContent contenidoHttp = new StringContent(datosJson, System.Text.Encoding.UTF8, "aplication/json");
        return await cliente.PostAsync(uri, contenidoHttp);
    }

    /// <summary>
    /// funcionprivada que realiza una solicitud HTTP PUT a la API y convierte el objeto clsPersona en una cadena JSON para la API
    /// </summary>
    /// <param name="uri"></param>
    /// <param name="persona"></param>
    /// <returns></returns>
    private static async Task<HttpResponseMessage> PutAsync(Uri uri, clsPersona persona)
    {
        string datosJson = JsonConvert.SerializeObject(persona);
        HttpContent contenidoHttp = new StringContent(datosJson, System.Text.Encoding.UTF8, "aplication/json");
        return await cliente.PutAsync(uri, contenidoHttp);
    }
}
