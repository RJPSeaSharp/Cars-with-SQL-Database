using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_10._3
{
    interface ICRUD
    {
        int GetMaxId();
        void AddRecord(Car cars);
        void DeleteRecord(Car cars);
        ICollection<Car> GetAll();
        Car FindCar(int VIN);
        void Updaterecord(int VIN, Car cars);
    }

    class CRUD : ICRUD
    {
        CarsEntities entities;
        public CRUD() 
        {
        entities = new CarsEntities();
        }
        public void AddRecord(Car cars)
        {
            entities.Cars.Add(cars);
            entities.SaveChanges();
        }

        public void DeleteRecord(Car cars)
        {
            entities.Cars.Remove(cars);
            entities.SaveChanges();
        }

        public Car FindCar(int VIN)
        {
            return entities.Cars.Find(VIN);
        }

        public ICollection<Car> GetAll()
        {
            return entities.Cars.ToList();
        }

        public int GetMaxId()
        {
            throw new NotImplementedException();
        }

        public void Updaterecord(int VIN, Car cars)
        {
            var cartoupdate = entities.Cars.Find(VIN);
            cartoupdate.VIN= cars.VIN;
            cartoupdate.Make=cars.Make;
            cartoupdate.Model=cars.Model;
            cartoupdate.Year=cars.Year;
            cartoupdate.Price=cars.Price;
            entities.SaveChanges();
        }
    }
}

