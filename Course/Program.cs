using Course.Entities;
using System;
using System.Globalization;
using System.Collections.Generic;

namespace Course {
    class Program {
        static void Main(string[] args) {

            List<Pessoa> list = new List<Pessoa>();

            Console.Write("Enter the number of tax payers: ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 1; i <= n; i++) {
                Console.WriteLine($"Tax Payer #{i} data: ");
                Console.Write("Individual or company (i/c)? ");
                char type = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Anual income: ");
                double income = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if(type == 'i') {
                    Console.Write("Health expenditures: ");
                    double healthExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new PessoaFisica(name, income, healthExpenditures));
                } else {
                    Console.Write("Number of employees: ");
                    int employees = int.Parse(Console.ReadLine());
                    list.Add(new PessoaJuridica(name, income, employees));
                }

            }

            Console.WriteLine();

            double sum = 0;
            Console.WriteLine("TAXES PAID: ");
            foreach(Pessoa obj in list) {
                double p = obj.Imposto();
                Console.WriteLine(obj.Nome + ": $ " + p.ToString("F2", CultureInfo.InvariantCulture));
                sum += p;
            }
            Console.WriteLine();
            Console.WriteLine("TOTAL TAXES: " + sum.ToString("F2", CultureInfo.InvariantCulture));
            

        }
    }
}

