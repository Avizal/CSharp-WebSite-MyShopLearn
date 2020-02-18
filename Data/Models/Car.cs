using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learn_Shop.Data.Models
{
    public class Car
    {
        public int id { set; get; } // id товара

        public string name { set; get; } // Имя товара

        public string shortDescription { set; get; } // короткое описание товара

        public string longDescription { set; get; } // Длинное описание товара

        public string img { set; get; } // адресс картинки

        public ushort price { set; get; } // цена товара

        public bool isFavourite { set; get; } // Если фаворит (отображаться на главной страничке)

        public bool available { set; get; } // Есть ли данный товар на складе и сколько осталось.

        public int categoryID { set; get; } // присваевает объект к категории

        public virtual Category Category { set; get; } // объект на основе определенной категории

    }
}
