using ConsumingCategoriaWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsumingCategoriaWebAPI.Controllers
{
    public class CategoriaController : Controller
    {
        Uri baseAdress = new Uri("https://localhost:7018/api");
        private readonly HttpClient? _client;

        public CategoriaController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAdress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<CategoriaViewModel> categoriaList = new List<CategoriaViewModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/categoria/Get").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                categoriaList = JsonConvert.DeserializeObject<List<CategoriaViewModel>>(data);
            }
            return View(categoriaList);
        }
    }
}
