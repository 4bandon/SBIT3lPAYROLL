using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SBIT3lPAYROLL.Models;

namespace SBIT3lPAYROLL.Controllers
{
    public class EmployeeController : Controller
    {

        private ILogger<EmployeeController> logger;

        private static bool hasDeleted = false;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            this.logger = logger;
        }

        // GET: EmployeeController

        private static readonly List<EmployeeModel> employeeModel = new List<EmployeeModel>();
        //or private readonly List<EmployeeModel> employeeModel = new List<EmployeeModel>(){
        //  new employeeModel{Id=1, firstName="ronnel", middleName="bronio", lastName="mateo"}
        //  };
        //
        public ActionResult Index()
        {
            if (!employeeModel.Any() && !hasDeleted)
            {
                employeeModel.AddRange(
                                [
                                    new() {
                                    Id = 1,
                                    firstName = "Ronnel",
                                    middleName = "Bronio",
                                    lastName = "Mateo"
                                }
                                ]
                            );
            }


            //or like this
            //public ActionResult Index(){
            //var employeeModel = new List<EmployeeModel>();
            //employeeModel.Add(new EmployeeModel
            //@
            //{
            //    Id = 1,
            //    firstName = "Ronnel",
            //    middleName = "Bronio",
            //    lastName = "Mateo"
            //}
            //    );

            return View(employeeModel);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] EmployeeModel model)
        {
            try
            {
                logger.LogInformation(model.firstName);
                employeeModel.Add(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //public ActionResult Create(EmployeeModel newEmployee)
        //{
        //  var newPerson = newEmployee;
        //
        //}

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = employeeModel.Find(x => x.Id == id);
            
            return View(model);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [FromForm] EmployeeModel model)
        {
            
            employeeModel[id - 1] = model;
            return RedirectToAction(nameof(Index));
           
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {

            return View();
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, [FromForm] EmployeeModel model)
        {
            logger.LogInformation(id.ToString());
            model = employeeModel.Find(x => x.Id == id);
            employeeModel.Remove(model);
            hasDeleted = true;
            return RedirectToAction(nameof(Index));

        }
    }
}
