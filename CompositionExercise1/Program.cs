using System;
using System.Globalization;
using CompositionExercise1.Entities;
using CompositionExercise1.Entities.Enums;


namespace CompositionExercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string department = Console.ReadLine();

            Console.WriteLine("Enter worker data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Level (Junior/MidLevel/Senior): ");

            WorkerLevel level = (WorkerLevel) Enum.Parse(typeof(WorkerLevel), Console.ReadLine());

            Console.Write("Base salary: ");
            double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(department);

            Worker worker = new Worker(name, level, salary, dept);

            Console.Write("How many contracts to this worker? ");
            int numberOfContracts = int.Parse(Console.ReadLine());

            for (int i = 1; i<= numberOfContracts; i++)
            {
                Console.WriteLine("Enter #" + i + " contract data:");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);
            }
            Console.WriteLine();
            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string[] read = Console.ReadLine().Split('/');
            int month = int.Parse(read[0]);
            int year = int.Parse(read[1]);

            Console.WriteLine("Name: " + name);
            Console.WriteLine("Department: " + department);

            if (month < 10)
            {
                Console.WriteLine("Income for " + "0" + month + "/" + year + ": " + worker.Income(year, month));
            }
            else
            {
                Console.WriteLine("Income for " + month + "/" + year + ": " + worker.Income(year, month));
            }
        }
    }
}
