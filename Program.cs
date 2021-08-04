using System;
using System.Collections.Generic;

namespace PolymorphismExample
{

    public class CarIDInfo // has a 
    {
        public int IDNum { get; set; } = 0;
        public string Owner { get; set; } = "No Owner";

    }

    public class M3 : Bmw // is a 
    {

        public M3(int hp, string color, string model):base(hp,color,model)
        {

        }

        public override void Repair()
        {
            base.Repair();
        }

    }

    public class Bmw : Car
    {
        public string Model { get; set; }
        private string _brand = "BMW";
        public Bmw(int hp, string color, string model) :base(hp,color)
        {

            this.Model = model;
        }

        public new void ShowDetails()
        {
            Console.WriteLine("Brand: " + _brand + " Vehicle HP: " + Hp + " Vehicle Color: " + Color + " Vehicle Model: " + Model);

        }

        public override void Repair()
        {
            Console.WriteLine("The BMW {0} was repaired.",Model);

        }

    }

    public class Audi : Car
    {
        public string Model { get; set; }
        private string _brand = "Audi";

        public Audi(int hp, string color, string model) :base(hp,color)
        {
            this.Model = model;

        }

        public new void ShowDetails()
        {
            Console.WriteLine("Brand: " + _brand + " Vehicle HP: " + Hp + " Vehicle Color: " + Color + " Vehicle Model: " + Model);

        }

        public override void Repair()
        {
            Console.WriteLine("The Audi {0} was repaired.", Model);

        }
    }


    public class Car
    {
        public int Hp { get; set; }
        public string Color { get; set; }


        protected CarIDInfo carIDInfo = new CarIDInfo(); //has a

        public void SetCarIDInfo(int idnum, string owner) //has a
        {
            carIDInfo.IDNum = idnum;
            carIDInfo.Owner = owner;

        }

        public void GetCarIDInfo()
        {
            Console.WriteLine("CAR ID: {0}, Car Owner: {1}",carIDInfo.IDNum,carIDInfo.Owner);

        }

        public Car(int hp, string color)
        {
            this.Hp = hp;
            this.Color = color;
        }

        public void ShowDetails()
        {

            Console.WriteLine("Vehicle HP: " + Hp + " Vehicle Color: " + Color);
           
        }


        public virtual void Repair()
        {

            Console.WriteLine("Car was repaired!");

        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            var cars = new List<Car>() 
            {
             new Audi(200, "Blue", "A4"),

             new Bmw(300, "Orange", "M5")
            };


            foreach (var car in cars)
            {
                car.Repair();
                
            }


            Car bmwZ3 = new Bmw(200, "black", "Z3");
            Car audiA4 = new Audi(210, "green", "A4");
            bmwZ3.ShowDetails();
            audiA4.ShowDetails();

            bmwZ3.SetCarIDInfo(123, "John");
            audiA4.SetCarIDInfo(568, "Sam");

            bmwZ3.GetCarIDInfo();
            audiA4.GetCarIDInfo();

            Bmw M3 = new Bmw(280, "Red", "M3");
            M3.ShowDetails();


            Car carB = (Car)M3;
            carB.ShowDetails();

            M3 myM3 = new M3(360, "Silver", "M3");
            myM3.Repair();


            
        }
    }
}
