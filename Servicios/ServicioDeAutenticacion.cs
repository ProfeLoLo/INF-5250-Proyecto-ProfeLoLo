using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SisPlan0401.Servicios
{
    public class ServicioDeAutenticacion
    {
        // Se recomienda mantener una única instancia de HttpClient para evitar agotamiento de sockets
        private static readonly HttpClient _http = new HttpClient();

        // Reemplaza con tu dominio exacto de Auth0
        private const string Domain = "ingenieria-software-2.us.auth0.com";
        private const string TokenUrl = "https://" + Domain + "/oauth/token";

        /// <summary>
        /// Obtiene un Access Token desde Auth0 replicando la prueba de Postman.
        /// </summary>
        public async Task<string> ObtenerTokenAsync(string clientId, string clientSecret)
        {
            try
            {
                var parametros = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", "client_credentials"),
                    new KeyValuePair<string, string>("client_id", clientId),
                    new KeyValuePair<string, string>("client_secret", clientSecret),
                    new KeyValuePair<string, string>("audience", $"https://{Domain}/api/v2/")
                };

                var contenido = new FormUrlEncodedContent(parametros);

                // Enviar la petición POST
                HttpResponseMessage respuesta = await _http.PostAsync(TokenUrl, contenido);

                // Lanzar excepción si la respuesta no es 2xx (por ejemplo 401, 400, 500)
                respuesta.EnsureSuccessStatusCode();

                // Leer el cuerpo de la respuesta en texto JSON
                string jsonRespuesta = await respuesta.Content.ReadAsStringAsync();

                // Deserializar el JSON para extraer únicamente la propiedad "access_token"
                using (JsonDocument doc = JsonDocument.Parse(jsonRespuesta))
                {
                    JsonElement root = doc.RootElement;
                    if (root.TryGetProperty("access_token", out JsonElement tokenElement))
                    {
                        return tokenElement.GetString();
                    }
                }

                return jsonRespuesta; // Retorna todo el JSON si no se puede mapear el token
            }
            catch (HttpRequestException httpEx)
            {
                throw new Exception($"Error de red al conectar con Auth0: {httpEx.Message}", httpEx);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en el servicio de autenticación: {ex.Message}", ex);
            }
        }
    }
}