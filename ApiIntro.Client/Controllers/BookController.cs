using ApiIntro.Client.Dtos;
using ApiIntro.Client.Dtos.Books;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ApiIntro.Client.Controllers
{
    public class BookController : Controller
    {
        private readonly string Endpoint = "http://localhost:7161";

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            HttpClient httpClient = new HttpClient();
            Dtos.Categories.GetItems<BookGetDto> getItems = new Dtos.Categories.GetItems<BookGetDto>();
            getItems.Items = new List<BookGetDto>();

            var json = await httpClient.GetStringAsync(Endpoint + "/api/Books");


            getItems = JsonConvert.DeserializeObject<Dtos.Categories.GetItems<BookGetDto>>(json);

            return View(getItems.Items);
        }
        public async Task<IActionResult> Create()
        {
            HttpClient httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(Endpoint + "/api/Categories");
            ViewBag.Categories = JsonConvert.DeserializeObject<Dtos.Categories.GetItems<BookGetDto>>(json).Items;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BookUpdateDto dto)
        {
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var json = await httpClient.PostAsync(Endpoint + "/api/Books/create", content);
            if (!json.IsSuccessStatusCode)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            HttpClient httpClient = new HttpClient();
            var obj = new BookUpdateDto();

            var json = await httpClient.GetStringAsync(Endpoint + $"/api/Books/getbyid/{id}");

            obj = JsonConvert.DeserializeObject<BookUpdateDto>(json);

            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Update(BookUpdateDto dto)
        {
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var json = await httpClient.PutAsync(Endpoint + $"/api/Books/update/{dto.Id}", content);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            HttpClient httpClient = new HttpClient();
            var json = await httpClient.DeleteAsync(Endpoint + $"/api/Books/delete/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
