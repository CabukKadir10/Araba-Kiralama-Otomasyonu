using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anaSayfa
{
    public class Customer{
        public Customer(string UserName,string Phone, string Email){
            userName = UserName;
            phone = Phone;
            email = Email;
        }
        public string userName{get; set;}
        public string phone{get; set;}
        public string email{get; set;}

    }
}