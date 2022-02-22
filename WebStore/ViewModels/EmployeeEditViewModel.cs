﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.ViewModels
{
	public class EmployeeEditViewModel : IValidatableObject 
	{
		[HiddenInput(DisplayValue = false)]
		public int Id { get; set; }

		[Display(Name = "Фамилия")]
		[Required(ErrorMessage = "Фамилия обязательна")]
		[StringLength(255, MinimumLength = 2, ErrorMessage = "Длина должна быть от 2 до 255 символов")]
		[RegularExpression(pattern:@"([А-ЯЁ][а-яё]+)|([A-Z][a-z]+)", ErrorMessage = "Ошибка формата")]
		public string LastName { get; set; }

		[Display(Name = "Имя")]
		[Required(ErrorMessage = "Имя обязательно")]
		[StringLength(255, MinimumLength = 2, ErrorMessage = "Длина должна быть от 2 до 255 символов")]
		[RegularExpression(pattern: @"([А-ЯЁ][а-яё]+)|([A-Z][a-z]+)", ErrorMessage = "Ошибка формата")]
		public string FirstName { get; set; }

		[Display(Name = "Отчество")]
		[StringLength(255, ErrorMessage = "Длина должна быть до 255 символов")]
		[RegularExpression(pattern: @"(([А-ЯЁ][а-яё]+)|([A-Z][a-z]+))?", ErrorMessage = "Ошибка формата")]
		public string Patronymic { get; set; }

		[Display(Name = "Дата рождения")]
		public DateTime BirthDay { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext context)
		{
			if (LastName.Length > 100)
			{
				yield return new ValidationResult("Длина фамилии больше 100 символов");
			}

			yield return ValidationResult.Success!;
		}
	}
}
