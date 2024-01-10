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
        private static HttpClient cliente = new HttpClient();
        private static string urlConexion = clsConnection.connection();
        public async static Task<List<clsDepartamento>> ListadoCompletoDepartamentosDAL()
        {
            Uri uri = new Uri($"{urlConexion}Departamentos");
            List<clsDepartamento> listadoDepartamentos = new List<clsDepartamento>();
            HttpResponseMessage mensaje = await cliente.GetAsync(uri);

            if (mensaje.IsSuccessStatusCode)
            {
                string mensajeJSON = await cliente.GetStringAsync(uri);
                listadoDepartamentos = JsonConvert.DeserializeObject<List<clsDepartamento>>(mensajeJSON);
            }

            return listadoDepartamentos;
        }
    

        public async static Task<clsDepartamento> DetailsDepartamento(int idDepartamento)
        {
            Uri uri = new Uri($"{urlConexion}Departamentos/{idDepartamento}");
            clsDepartamento departamento = new clsDepartamento();
            HttpResponseMessage mensaje;

        try
        {
            mensaje = await cliente.GetAsync(uri);

            if (mensaje.IsSuccessStatusCode)
            {
                string mensajeJSON = await cliente.GetStringAsync(uri);
                departamento = JsonConvert.DeserializeObject<clsDepartamento>(mensajeJSON);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return departamento;
        }
    }
}
    

