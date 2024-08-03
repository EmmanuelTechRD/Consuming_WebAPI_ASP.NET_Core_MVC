using ConsumingCategoriaWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsumingCategoriaWebAPI.Controllers
{
    public class ClienteController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7127/api");
        private readonly HttpClient? _client;

        public ClienteController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<ClienteViewModel> clienteList = new List<ClienteViewModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/cliente/Get").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                clienteList = JsonConvert.DeserializeObject<List<ClienteViewModel>>(data);
            }
            return View(clienteList);
        }
    }
}
