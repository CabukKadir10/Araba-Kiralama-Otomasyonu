using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anaSayfa
{
    public class VipCar{
        public int TotalFee{get; set;}
      /*  public VipCar(string model, string engineCapacity, string brand, int make, int km) : base(model, engineCapacity, brand, make, km){

        } */
        public int Fee(int Days, int Give){
            if(Days >= Give){
                    TotalFee = Days*500;
                }else if(Days < Give){
                    TotalFee = Days*500 + (Give-Days)*1000;
                }
            return TotalFee;
        }
    }
}