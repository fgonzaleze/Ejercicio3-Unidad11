using DAL;
using Ejercicio3_Unidad11.Entities;
using Newtonsoft.Json;

namespace Ejercicio3_Unidad11.DAL;

public class clsManejadoraPersonaDAL 
{
    public static async Task<int> CreatePersonaDAL(clsPersona persona)
    {
        HttpClient client = new HttpClient();
        string datos;
        HttpContent contenido;
        int personaCreada = 0;

        string stringURL = clsConnection.connection();
        Uri uri = new Uri($"{stringURL}Personas");

        HttpResponseMessage res = new HttpResponseMessage();

        try
        {
            datos = JsonConvert.SerializeObject(persona);

            contenido = new StringContent(datos, System.Text.Encoding.UTF8, "aplication/json");

            res = await client.PostAsync(uri, contenido);

            if (res.IsSuccessStatusCode)
            {
                personaCreada = 1;

            }
        }
        catch (Exception ex) { throw ex; }

        return personaCreada;

    }

    public static async Task<int> UpdatePersonaDAL(clsPersona persona)
    {

        HttpClient client = new HttpClient();
        string datos;
        HttpContent contenido;
        int personaActualizada = 0;

        string stringURL = clsConnection.connection();
        Uri uri = new Uri($"{stringURL}Personas");

        //Usaremos el estado de la respuesta para comprobar si se insertado bien el departamento.
        HttpResponseMessage res = new HttpResponseMessage();

        try
        {
            datos = JsonConvert.SerializeObject(persona);
            contenido = new StringContent(datos, System.Text.Encoding.UTF8, "aplication/json");

            res = await client.PutAsync(uri, contenido);


            if (res.IsSuccessStatusCode)
            {
                personaActualizada = 1;

            }
        }
        catch (Exception ex) { throw ex; }
        return personaActualizada;
    }

    public async static Task<int> DeletePersonaDAL(int id)
    {
        string stringURL = clsConnection.connection();
        Uri uri = new Uri($"{stringURL}Personas");

        int personaBorrada = 0;
        HttpClient client = new HttpClient();
        HttpResponseMessage message;
        string textoJSONRespuesta;

        try
        {
            message = await client.DeleteAsync(uri);

            if (message.IsSuccessStatusCode)
            {
                textoJSONRespuesta = await client.GetStringAsync(uri);
                personaBorrada = JsonConvert.DeserializeObject<int>(textoJSONRespuesta);

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return personaBorrada;
    }
}
