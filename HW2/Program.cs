using System;

namespace HW2
{
    public class Person
    {
        private string name;
        private string address;
        private double salary;

        public Person() { }

        public Person(string name, string address, double salary)
        {
            this.name = name;
            this.address = address;
            this.salary = salary;
        }

        public string GetName() => name;
        public void SetName(string name) => this.name = name;

        public string GetAddress() => address;
        public void SetAddress(string address) => this.address = address;

        public double GetSalary() => salary;
        public void SetSalary(double salary) => this.salary = salary;


    }

    class Program
    {
        public static Person InputPersonInfo(string name, string address, string sSalary)
        {
            if (string.IsNullOrWhiteSpace(sSalary))
            {
                throw new Exception("You must input Salary.");
            }
            if (!double.TryParse(sSalary, out double salary))
            {
                throw new Exception("You must input digit.");
            }

            if (salary <= 0)
            {
                throw new Exception("Salary is greater than zero");
            }

            return new Person(name, address, salary);
        }

        public static void DisplayPersonInfo(Person person)
        {
            Console.WriteLine("Information of Person you have entered:");
            Console.WriteLine($"Name: {person.GetName()}");
            Console.WriteLine($"Address: {person.GetAddress()}");
            Console.WriteLine($"Salary: {person.GetSalary()}");
        }

        public static Person[] SortBySalary(Person[] personArray)
        {
            try
            {
                int n = personArray.Length;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (personArray[j].GetSalary() > personArray[j + 1].GetSalary())
                        {                           // Đổi chỗ
                            Person temp = personArray[j];
                            personArray[j] = personArray[j + 1];
                            personArray[j + 1] = temp;
                        }
                    }
                }
                return personArray;
            }
            catch (Exception)
            {
                throw new Exception("Can't Sort Person");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("=====Management Person programer=====");
            Person[] persons = new Person[3];

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Input Information of Person");

                Console.Write("Please input name: ");
                string name = Console.ReadLine();

                Console.Write("Please input address: ");
                string address = Console.ReadLine();

                double salary = 0;
                while (true)
                {
                    Console.Write("Please input salary:");
                    string sSalary = Console.ReadLine();

                    try
                    {
                        Person p = InputPersonInfo(name, address, sSalary);
                        salary = p.GetSalary();
                        persons[i] = p;
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            try
            {
                persons = SortBySalary(persons);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            foreach (var p in persons)
            {
                DisplayPersonInfo(p);
            }
        }
    }
}