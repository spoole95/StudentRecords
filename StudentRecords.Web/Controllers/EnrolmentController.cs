using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StudentRecords.Web.Models;
using StudentRecords.WebApi.Models;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StudentRecords.Web.Controllers
{
    public class EnrolmentController : Controller
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string url;

        public EnrolmentController(IConfiguration configuration)
        {
            url = configuration.GetValue<string>("WebApiURL");
        }

        public async Task<ActionResult> Index(int studentId)
        {
            StudentModel student = JsonConvert.DeserializeObject<StudentModel>(await client.GetStringAsync($"{url}/Student/{studentId}"));

            CourseEnrolmentListModel model = new CourseEnrolmentListModel
            {
                Courses = student.CourseEnrolment.ToList(),
                StudentId = student.StudentId
            };
            return View(model);
        }

        // GET: EnrollmentController/Create
        public ActionResult Create(int studentId)
        {
            var model = new CourseEnrolmentModel
            {
                StudentId = studentId.ToString()
        };
            return View(model);
        }

        // POST: EnrollmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CourseEnrolmentModel model)
        {
            try
            {
                await client.PutAsync($"{url}/Student/{model.StudentId}", new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
                return RedirectToAction("Index", "Student");
            }
            catch
            {
                return View();
            }
        }

        // GET: EnrollmentController/Edit/5
        public async Task<ActionResult> Edit(int studentId, string enrolmentId)
        {
            StudentModel student = JsonConvert.DeserializeObject<StudentModel>(await client.GetStringAsync($"{url}/Student/{studentId}"));

            var model = student.CourseEnrolment.Single(x => x.EnrolmentId == enrolmentId);
            model.StudentId = student.StudentId;

            return View(model);
        }

        // POST: EnrollmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int studentId, CourseEnrolmentModel model)
        {
            try
            {
                await client.PutAsync($"{url}/Student/{studentId}", new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));

                return RedirectToAction("Index", "Student");
            }
            catch
            {
                return View();
            }
        }
    }
}
