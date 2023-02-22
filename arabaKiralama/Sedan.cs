using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anaSayfa
{
    public class Sedan{

        public int TotalFee{get; set;}

       /* public Sedan(string model, string engineCapacity, string brand, int make, int km) : base(model, engineCapacity, brand, make, km){

        } */
        public int Fee(int Days, int Give){
            if(Days >= Give){
                    TotalFee = Give*250;
                }else if(Days < Give){
                    TotalFee = Days*250 + (Give-Days)*500;
                }
            
            return TotalFee;
        }
    }
}