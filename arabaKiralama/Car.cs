using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anaSayfa
{
     public class Car{

        public Car(string model, string engineCapacity, string brand, int make, int km){
            Model = model;
            EngineCapacity = engineCapacity;
            Brand = brand;
            Make = make;
            Km = km;
            isRent = false;
        }

         public string Model{get; set;}
         public string EngineCapacity{get; set;}
         public string Brand{get; set;}
        public int Make{get; set;}
        public int Km{get; set;}
        public bool isRent{get; set;}

        public virtual int Fee(int Days, int Give){
            return 0;
        }
    }
}