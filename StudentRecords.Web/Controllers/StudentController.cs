using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StudentRecords.WebApi.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StudentRecords.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string url;


        public StudentController(IConfiguration configuration)
        {
            url = configuration.GetValue<string>("WebApiURL");
        }

        // GET: StudentController
        public async Task<ActionResult> Index()
        {
            return View(JsonConvert.DeserializeObject<List<StudentModel>>(await client.GetStringAsync($"{url}/Student")));
        }

        // GET: StudentController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(JsonConvert.DeserializeObject<StudentModel>(await client.GetStringAsync($"{url}/Student/{id}")));
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(StudentModel student)
        {
            try
            {
                await client.PostAsync($"{url}/Student", new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json"));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(student);
            }
        }

        // GET: StudentController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(JsonConvert.DeserializeObject<StudentModel>(await client.GetStringAsync($"{url}/Student/{id}")));
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, StudentModel student)
        {
            try
            {
                await client.PutAsync($"{url}/Student", new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json"));

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(student);
            }
        }
    }
}
