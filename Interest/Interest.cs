using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using movement;

namespace Interest
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] parts
            float result = 0.0F
            int j;

//          nacteni souboru 
            string[] lines = File.ReadAllLines("Input.txt");
            Movement[] myMovement = new Movement[lines.Length];

            int i = 0;
            foreach (string linex in lines)
            {
                parts = linex.Split('\t');

                myMovement[i] = new Movement();
                myMovement[i].type = parts[0];
                myMovement[i].value = float.Parse(parts[2]);
                myMovement[i].when = DateTime.Parse(parts[1]);

                i++;
            }

//          analyza souboru
            Movement myResult = new Movement();
            result = myResult.result(myMovement, lines.Length); //samotny vypocet
            j = myResult.pointer(myMovement, lines.Length);     //jeste poloha balance v souboru

//          vypis vysledku
            Console.WriteLine("Account history as of " + myMovement[j].when.ToShortDateString() + ":");
            for (i = 0; i < lines.Length; i++)
            {
                if (myMovement[i].type == "D" || myMovement[i].type == "B")
                {
                    Console.WriteLine(myMovement[i].type + " " + myMovement[i].value + " on " + myMovement[i].when.ToShortDateString());
                }
            }
            Console.WriteLine("So far it's " + result * 100.0F + "% interest this year");
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
