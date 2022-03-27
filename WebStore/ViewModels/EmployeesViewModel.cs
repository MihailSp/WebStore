﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebStore.ViewModels
{
    public class EmployeesViewModel
    {
        [HiddenInput(DisplayValue=false)]
        public int Id { get; set; }

        [Display(Name ="Фамилия")]
        [Required(ErrorMessage ="Фамилия является обязательной")]
        [StringLength(255, MinimumLength =2, ErrorMessage ="Длина фамилии должна быть от 2 до 255 символов")]
        [RegularExpression(@"([А-ЯЁ][а-яё]+)|([A-Z][a-z]+)", ErrorMessage = "Ошибка формата строки")]
        public string LastName { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Имя является обязательным")]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "Длина имени должна быть от 2 до 255 символов")]
        [RegularExpression(@"([А-ЯЁ][а-яё]+)|([A-Z][a-z]+)", ErrorMessage ="Ошибка формата строки")]
        public string FirstName { get; set; }

        [Display(Name = "Отчество")]
        [StringLength(255, ErrorMessage = "Длина отчества может быть до 255 символов")]
        [RegularExpression(@"([А-ЯЁ][а-яё]+)|([A-Z][a-z]+)?", ErrorMessage = "Ошибка формата строки")]
        public string Patronymic { get; set; }

        [Display(Name = "ФИО")]
        [StringLength(255, ErrorMessage = "Длина ФИО может быть до 255 символов")]
        public string ShortName { get; set; }

        [Display(Name = "Возраст")]
        [Range(18, 80, ErrorMessage ="Возраст должен быть в пределах от 18 до 80 лет")]
        public int Age { get; set; }
    }
}
