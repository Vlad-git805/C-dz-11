using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public delegate void Change_of_Course_delegate(bool c);

    public class Buyer
    {
        private string name { get; set; }
        private int money { get; set; }

        public Buyer()
        {
            name = "lol";
            money = 10000;
        }

        public Buyer(string name)
        {
            this.name = name;
            money = 10000;
        }

        public int Get_money()
        {
            return money;
        }

        public void Set_money(int money)
        {
            this.money = money;
        }

        public void Buy(bool b)
        {
            if (b == true)
            {
                Console.WriteLine(name + " buying currency");
                money -= 200;
                Console.WriteLine(money);
            }
            else if (b == false)
            {
                Console.WriteLine(name + " selling currency");
                money += 200;
                Console.WriteLine(money);
            }
        }
    }

    public class Seller
    {
        private string name { get; set; }
        private int money { get; set; }

        public Seller()
        {
            name = "lol";
            money = 10000;
        }

        public Seller(string name)
        {
            this.name = name;
            money = 10000;
        }

        public int Get_money()
        {
            return money;
        }

        public void Set_money(int money)
        {
            this.money = money;
        }

        public void Sell(bool b)
        {
            if (b == true)
            {
                Console.WriteLine(name + " selling currency");
                money += 200;
                Console.WriteLine(money);
            }
            else if (b == false)
            {
                Console.WriteLine(name + " buying currency");
                money -= 200;
                Console.WriteLine(money);
            }
        }
    }

    public class Exchange
    {
        public bool Course { get; set; }
        public event Change_of_Course_delegate change_of_course;

        public void CourseChange()
        {
            Random rnd = new Random();
            int random = rnd.Next(2);
            if (random == 0)
            {
                Course = true;
            }
            else
            {
                Course = false;
            }
            change_of_course?.Invoke(Course);

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Buyer buyer1 = new Buyer("Vlad");
            Buyer buyer2 = new Buyer("Vas9");

            Exchange exchange = new Exchange();
            exchange.change_of_course += buyer1.Buy;
            exchange.change_of_course += buyer2.Buy;
            exchange.CourseChange();
        }
    }
}
