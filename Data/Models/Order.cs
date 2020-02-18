using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Learn_Shop.Data.Models
{
    public class Order
    {
        [BindNever] //Чтобы это поле не отображалось на страничке
        public int id { get; set; }

        [Display(Name = "Введите имя")] //Как будет называеться поле в окне на сайте
        [StringLength(10)] // Проверка, если поле слишком длинное, то ошибка
        [Required(ErrorMessage ="Длинна более 10 символов")] // Текст ошибки
        public string name { get; set; }

        [Display(Name = "Фамилия")] 
        [StringLength(15)] 
        [Required(ErrorMessage = "Длинна более 15 символов")] 
        public string surname { get; set; }

        [Display(Name = "Адресс")]
        [StringLength(35)]
        [Required(ErrorMessage = "Длинна более 35 символов")]
        public string adress { get; set; }

        [Display(Name = "Телефон")]
        [StringLength(15)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Длинна более 15 символов")]
        public string phone { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(30)]
        [Required(ErrorMessage = "Длинна более 30 символов")]
        public string email { get; set; }

        [BindNever] // Не показвать на страничке
        [ScaffoldColumn(false)] //Чтобы это поле не отображалось даже в исходном коде!
        public DateTime orderTime { get; set; }

        public List<OrderDetail> orderDetails { get; set; }

    }
}
