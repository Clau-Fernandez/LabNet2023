using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using LabNetPractica6_MVC.Models;
using System.Net.Http.Formatting;

namespace LabNetPractica6_MVC.Controllers
{
    public class TheDogAPIController : Controller
    {
        
        public async Task<ActionResult> Index()
        {
            try
            {
                var dogView = await GetRandomDog();
                return View(dogView);
            }
            catch (Exception ex)
            {
                // Envía la información de la excepción a la vista de error personalizada
                return View("Error", new ErrorView { ErrorMessage = ex.Message });
            }
        }

        public async Task<DogView> GetRandomDog()
        {
            string apiUrl = "https://api.thedogapi.com/v1/images/search";
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("x-api-key", "live_bVHXxfy2xOtM1TYI4glBivIzO2Ho3zsWG9I3Au4Fdgx5rjOOxmI93xHdopgiIxH7");
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        if (data != null)
                        {
                            var result = JsonConvert.DeserializeObject<List<DogView>>(data);
                            return result.FirstOrDefault();
                        }
                    }
                    // Si no se pudo obtener la imagen, lanza una excepción personalizada
                    throw new Exception("No se pudo obtener una imagen de perro aleatoria.");
                }
                catch (Exception ex)
                {
                    // Lanza una excepción personalizada con el mensaje de la excepción original
                    throw new Exception("Error al obtener la imagen.", ex);
                }
            }
           
        }

    }




}

