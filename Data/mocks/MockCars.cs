using Learn_Shop.Data.Interfaces;
using Learn_Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learn_Shop.Data.mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _categoryCars = new MockCategory();

        public IEnumerable<Car> Cars
        {
            get
            {
                return new List<Car>
                {
                    new Car {
                        name = "Tesla Model S",
                        shortDescription = "Быстрый автомобиль",
                        longDescription = "Красивый, быстрый и очень тихий автомобиль компании Tesla",
                        img = "/img/Tesla.jpg",
                        price = 45000,
                        isFavourite = true,
                        available = true,
                        Category = _categoryCars.AllCategories.First()
                    },
                    new Car {
                        name = "Ford Fiesta",
                        shortDescription = "Тихий и спокойный",
                        longDescription = "Удобный автомобиль для городской жизни",
                        img = "/img/Ford.jpg",
                        price = 11000,
                        isFavourite = false,
                        available = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car {
                        name = "BMW W3",
                        shortDescription = "Дерзкий и стильный",
                        longDescription = "Удобный автомобиль для городской жизни",
                        img = "/img/BMW.jpg",
                        price = 65000,
                        isFavourite = true,
                        available = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car {
                        name = "Mercedes C class",
                        shortDescription = "Уютный и большой",
                        longDescription = "Удобный автомобиль для городской жизни",
                        img = "/img/Mercedes.jpg",
                        price = 40000,
                        isFavourite = false,
                        available = false,
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car {
                        name = "Nissan Leaf",
                        shortDescription = "Бесшумный и экономный",
                        longDescription = "Удобный автомобиль для городской жизни",
                        img = "/img/Nissan.jpg",
                        price = 14000,
                        isFavourite = true,
                        available = true,
                        Category = _categoryCars.AllCategories.First()
                    }
                };
                
            }
            
        }
        public IEnumerable<Car> getFavCars { get; set; }

        public Car getObjectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}


