using ApiIntro.Client.Dtos;
using ApiIntro.Client.Dtos.Categories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ApiIntro.Client.Controllers
{
    public class CategoryController : Controller
    {

        private readonly string Endpoint = "http://localhost:7161";
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            HttpClient httpClient = new HttpClient();
            GetItems<CategoryGetDto> getItems = new GetItems<CategoryGetDto>();
            getItems.Items = new List<CategoryGetDto>();

            var json = await httpClient.GetStringAsync(Endpoint + "/api/Categories/getall");


            getItems = JsonConvert.DeserializeObject<GetItems<CategoryGetDto>>(json);

            return View(getItems.Items);
        }
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CategoryUpdateDto dto)
        {
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var json = await httpClient.PostAsync(Endpoint + "/api/Categories/create", content);
            if (json.IsSuccessStatusCode)
            {


            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            HttpClient httpClient = new HttpClient();
            var obj = new CategoryUpdateDto();

            var json = await httpClient.GetStringAsync(Endpoint + $"/api/admin/Categories/getbyid/{id}");


            obj = JsonConvert.DeserializeObject<CategoryUpdateDto>(json);

            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateDto dto)
        {
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var json = await httpClient.PutAsync(Endpoint + $"/api/Categories/update/{dto.Id}", content);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            HttpClient httpClient = new HttpClient();
            var json = await httpClient.DeleteAsync(Endpoint + $"/api/Categories/delete/{id}");
            return RedirectToAction(nameof(Index));
        }

    }
}
