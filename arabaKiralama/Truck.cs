using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anaSayfa
{
    public class Truck{
        public int TotalFee{get; set;}
      /*  public Truck(string model, string engineCapacity, string brand, int make, int km) : base(model, engineCapacity, brand, make, km){

        } */
        public int Fee(int Days, int Give){
            if(Days >= Give){
                    TotalFee = Give*50;
                }else if(Days < Give){
                    TotalFee = Days*50 + (Give-Days)*100;
                }
            return TotalFee;
        }
    }
}