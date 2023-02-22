using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anaSayfa
{
    public class RentCar
    {
       /* private List<Car> car = new List<Car>();
        public List<Car> Myproperty {get;} */
        
        public Car Car {get; set;}
        public Customer Customer{get; set;}
        public int Days{get; set;}

     

        public RentCar(Car car, Customer customer, int days){
            Car = car;
            Customer = customer;
            Days = days;
        }
       
    }
}