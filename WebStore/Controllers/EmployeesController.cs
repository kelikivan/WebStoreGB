using Microsoft.AspNetCore.Mvc;
using WebStore.Models;
using WebStore.Services.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
	//[Route("empl/[action]/{id?}")]
	//[Route("Staff/{action=Index}/{id?}")]
	public class EmployeesController : Controller
	{
		private readonly IEmployeesService _employeesService;
		private readonly ILogger<EmployeesController> _logger;

		public EmployeesController(IEmployeesService employeesService, ILogger<EmployeesController> logger)
		{
			_employeesService = employeesService;
			_logger = logger;
		}

		public IActionResult Index()
		{
			var result = _employeesService.GetAll();
			return View(result);
		}

		//[Route("~/employees/info-{id}")]
		public IActionResult Details(int id)
		{
			var employee = _employeesService.GetById(id);
			
			if (employee is null)
			{
				return NotFound();
			}

			return View(employee);
		}

		public IActionResult Create() => View("Edit", new EmployeeEditViewModel());

		public IActionResult Edit(int? id)
		{
			if (id is null)
			{
				return View(new EmployeeEditViewModel());
			}

			var employee = _employeesService.GetById((int)id);
			if (employee is null)
			{
				_logger.LogWarning("Попытка редактирования отсутствующего сотрудника с Id:{0}.", id);
				return NotFound();
			}

			var model = new EmployeeEditViewModel
			{
				Id = employee.Id,
				LastName = employee.LastName,
				FirstName = employee.FirstName,
				Patronymic = employee.Patronymic,
				BirthDay = employee.BirthDay,
			};

			return View(model);
		}
		
		[HttpPost]
		public IActionResult Edit(EmployeeEditViewModel model)
		{
			if (model.LastName.Contains("Kelik"))
			{
				ModelState.AddModelError("", "Себя добавлять нельзя");
			}

			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var employee = new Employee
			{
				Id = model.Id,
				LastName = model.LastName,
				FirstName = model.FirstName,
				Patronymic = model.Patronymic,
				BirthDay = model.BirthDay,
			};

			if (model.Id == 0)
			{
				_employeesService.Add(employee);
				_logger.LogInformation("Создан новый сотрудник {0}.", employee);
			}
			else if (!_employeesService.Edit(employee))
			{
				return NotFound();
			}
			else
			{
				_logger.LogInformation("Информация о сотруднике {0} изменена.", employee);
			}

			return RedirectToAction("Index");
		}

		public IActionResult Delete(int id)
		{
			if (id < 0)
			{
				return BadRequest();
			}

			var employee = _employeesService.GetById(id);
			if (employee is null)
			{
				return NotFound();
			}

			var model = new EmployeeEditViewModel
			{
				Id = employee.Id,
				LastName = employee.LastName,
				FirstName = employee.FirstName,
				Patronymic = employee.Patronymic,
				BirthDay = employee.BirthDay,
			};

			return View(model);
		}

		[HttpPost]
		public IActionResult DeleteConfirmed(int id)
		{
			if (!_employeesService.Delete(id))
			{
				return NotFound();
			}

			_logger.LogInformation("Сотрудник с Id:{0} удалён.", id);
			return RedirectToAction("Index");
		}
	}
}
