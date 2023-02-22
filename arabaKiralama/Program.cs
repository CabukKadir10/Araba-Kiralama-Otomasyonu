using System;
using System.Collections;

namespace anaSayfa{

    class Program
    {

        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();// araba depolama listesi
            List<Customer> customers = new List<Customer>();// müşteri depolama listesi
            List<RentCar> rentCars = new List<RentCar>();// araba kiralama geçmişi listesi

            Sedan sedan = new Sedan();
            Truck truck = new Truck();
            VipCar vipCar = new VipCar();
            

            cars.Add(new Car("sedan", "5.5", "bmw", 2010, 15000));
            cars.Add(new Car("truck", "5.0", "volvo", 2015, 8000));
            

            Console.WriteLine("*****Arac Kiralama Otomasyonu*****\n");

            while(true){

                Console.WriteLine("Secmek istediginiz islem numarasini giriniz:");
                Console.WriteLine("islem1: arac ekleme -- islem2: arac kiralama -- islem3: arac Teslim etme");
                Console.WriteLine("islem4: kiralama gecmisi -- islem5: arac listeleme -- islem6: arac silme");
                Console.WriteLine("Cikmak icin -1'e basin");
                int choice = int.Parse(Console.ReadLine());
                if(choice == -1){
                    Console.WriteLine("Arac Kiralama Sisteminden Cikiliyor.....");
                    break;
                }

                switch(choice){ // *****Araç Ekleme*****
                    case 1:
                    Console.WriteLine("araba modelini giriniz.");
                    string Model = Console.ReadLine();
                    Console.WriteLine("araba motorunu giriniz.");
                    string EngineCapacity = Console.ReadLine();
                    Console.WriteLine("araba markasini giriniz.");
                    string Brand = Console.ReadLine();
                    Console.WriteLine("araba yilini giriniz.");
                    int Make = int.Parse(Console.ReadLine());
                    Console.WriteLine("araba kilometresini giriniz.");
                    int Km = int.Parse(Console.ReadLine());
                    
                    cars.Add(new Car(Model, EngineCapacity, Brand, Make, Km));

                    Console.WriteLine("Arac basari ile eklenmistir...\n\n");
                    break;

                    case 2: // ******Araç Kiralama*****
                            Console.WriteLine("Müsteri adini giriniz.");
                            string userName = Console.ReadLine();
                            Console.WriteLine("Müsteri numarasini giriniz.");
                            string phone = Console.ReadLine();
                            Console.WriteLine("Müsteri mail hesabini giriniz.");
                            string email = Console.ReadLine();
                            
                            
                            Customer customer = new Customer(userName, phone, email);
                            customers.Add(customer);

                            Console.WriteLine("Kiralanabilir Otomobillerin Listesi...");
                            for (int i = 0; i < cars.Count; i++)
                            {
                                if(!cars[i].isRent){
                                    Console.WriteLine($"model: {cars[i].Model} - makine hacmi: {cars[i].EngineCapacity} - marka: {cars[i].Brand} - Uretim yili: {cars[i].Make} - kilometre: {cars[i].Km} - kiralik durumu: {cars[i].isRent}");
                                }
                            }

                            Console.WriteLine("Lütfen araba secimini yapiniz.");
                            int choiceCar = int.Parse(Console.ReadLine()) - 1;

                            cars[choiceCar].isRent = true;
                            Console.WriteLine("Araci kac gün kiralamak istiyorsunuz.");
                            int carDay = int.Parse(Console.ReadLine());

                            RentCar rent1 = new RentCar(cars[choiceCar],customer, carDay);
                            rentCars.Add(rent1);

                            Console.WriteLine("Tebrikler arac kiralama basari ile tamamlandi...\n\n");

                    break;

                    case 3:// *****Araç Teslimi ve fiyat Hesaplama*****
                        if(rentCars.Count == 0){
                            Console.WriteLine("Kiralanmis arac bulunamadi.");
                        }else{
                            foreach(var RentCars in rentCars){
                                Console.WriteLine($"Model: {RentCars.Car.Model} - Makine hacmi: {RentCars.Car.EngineCapacity} - Marka: {RentCars.Car.Brand} - uretim yili: {RentCars.Car.Make} - kilometre: {RentCars.Car.Km} - kiralik durumu: {RentCars.Car.isRent}");
                            }
                            Console.WriteLine("teslim etmek istediğiniz arac numarasini giriniz.");
                            int RentedCar = int.Parse(Console.ReadLine()) - 1;

                            if(rentCars[RentedCar].Car.isRent){
                                rentCars[RentedCar].Car.isRent = false;

                                Console.WriteLine("Müsteri araci kacinci günde teslim etti..");
                                int rentDay = int.Parse(Console.ReadLine());

                                if(cars[RentedCar].Model.Equals("sedan")){
                                    if(cars[RentedCar].Brand.Equals("bmw")){
                                        sedan.TotalFee = sedan.Fee(rentCars[RentedCar].Days, rentDay)*2;
                                        Console.WriteLine($"Ödenecek Toplam miktar sedan bmw: {sedan.TotalFee} -- Arac Basari ile teslim edilmistir...\n\n");
                                       // rentCars.RemoveAt(RentedCar);
                                     }else{
                                        sedan.TotalFee = sedan.Fee(rentCars[RentedCar].Days, rentDay);
                                        Console.WriteLine($"Ödenecek Toplam miktar sedan diğer: {sedan.TotalFee} -- Arac Basari ile teslim edilmistir...\n\n");
                                      //  rentCars.RemoveAt(RentedCar);
                                    }
                    
                                }else if(cars[choice].Model.Equals("truck")){
                                    truck.TotalFee = truck.Fee(rentCars[RentedCar].Days, rentDay);
                                    Console.WriteLine($"Ödenecek Toplam miktar truck: {truck.TotalFee} -- Arac Basari ile teslim edilmistir...\n\n");
                                 //   rentCars.RemoveAt(RentedCar);
                                }else if(cars[choice].Model.Equals("vipCar")){
                                    vipCar.TotalFee = vipCar.Fee(rentCars[RentedCar].Days, rentDay);
                                    Console.WriteLine($"Ödenecek Toplam miktar vipcar: {vipCar.TotalFee} -- Aras Basari ile teslim edilmistir...\n\n");
                                 //   rentCars.RemoveAt(RentedCar);
                                }

                            }else{
                                Console.WriteLine("Girdiğiniz arac kiralik durumda değil.\n\n");
                            }
                        }

                    break;

                    case 4: // *****Araç Kiralama Geçmişi*****
                            if(rentCars.Count == 0){
                                Console.WriteLine("Daha önce arac kiralanmamis...");
                            }else{
                                foreach(var RentCar in rentCars){
                                    Console.WriteLine($"Arac kiralayanin ismi: {RentCar.Customer.userName} -- Arac kiralayanin numarasi: {RentCar.Customer.phone} -- Arac kiralayanin maili: {RentCar.Customer.email}");
                                    Console.WriteLine($"Arac Modeli: {RentCar.Car.Model} -- Arac Markasi: {RentCar.Car.Brand} -- Arac Uretim Yili: {RentCar.Car.Make}\n\n");
                                }
                            }
                    break;

                    case 5: // *****Araç Listesi*****
                        foreach(var Car in cars){
                            Console.WriteLine($"Model: {Car.Model} - Makine hacmi: {Car.EngineCapacity} - Marka: {Car.Brand} - uretim yili: {Car.Make} - kilometre: {Car.Km} - kiralik durumu: {Car.isRent}");
                        }
                    break;

                    case 6:

                        foreach(var Car in cars){
                            Console.WriteLine($"Model: {Car.Model} - Makine hacmi: {Car.EngineCapacity} - Marka: {Car.Brand} - uretim yili: {Car.Make} - kilometre: {Car.Km} - kiralik durumu: {Car.isRent}");
                        }

                        Console.WriteLine("Lutfen listeden silmek istedginiz arac numarasini giriniz...");
                        int deleteCar = int.Parse(Console.ReadLine()) - 1;
                        cars.RemoveAt(deleteCar);
                        Console.WriteLine("Arac kaydi basari ile silinmistir...\n\n");
                    break;
                }
            }
        }
    }
}