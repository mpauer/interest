using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using movement;

namespace Interest
{
    //class Movement
    //{
    //    public string type;
    //    public float value;
    //    public DateTime when;

    //    public int pointer(Movement[] myData, int lines)
    //    {
    //        int i = 0;
    //        int j = 0;
    //        for (i = 0; i < lines; i++)
    //        {
    //            if (myData[i].type == "B" && myData[i].when > myData[j].when)
    //            {
    //                j = i;
    //            }
    //        }
    //        return j;
    //    }

    //    public float result(Movement[] myData, int lines)
    //    {
    //        float result = 0.0F;
    //        float sum = 0.0F;
    //        float cumulate = 0.0F;
    //        int diff;
    //        int i = 0;
    //        int j = 0;

    //        for (i = 0; i < lines; i++)
    //        {
    //            if (myData[i].type == "B" && myData[i].when > myData[j].when)
    //            {
    //                j = i;
    //            }
    //        }
    //        for (i = 0; i < lines; i++)
    //        {
    //            if (myData[i].type == "D")
    //            {
    //                diff = (myData[j].when - myData[i].when).Days;
    //                sum = sum + myData[i].value;
    //                cumulate = cumulate + diff * myData[i].value;
    //            }
    //        }
    //        result = (myData[j].value - sum) * 365.0F / cumulate;
    //        return result;
    //    }
    //}

    class Program
    {
        static void Main(string[] args)
        {
            string[] parts;
            float result = 0.0F;
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
                if (myMovement[i].type == "D")
                {
                    Console.Write(myMovement[i].type + " " + myMovement[i].value + " on " + myMovement[i].when.ToShortDateString());
                    Console.WriteLine();
                }
            }
            Console.WriteLine("So far it's " + result * 100.0F + "% interest this year");
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
