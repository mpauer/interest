using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Interest
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] myParts;
            List<int>    myFoNo = new List<int>();
            List<string> myFond = new List<string>();
            List<char> myType = new List<char>();
            List<DateTime> myDate = new List<DateTime>();
            List<float>    myAmmo = new List<float>();
            int i = 0;
            int myIndex;
            int myIndexB;
            int myIndexD;
            int myDiff;
            
            string[] myLines = File.ReadAllLines("input.txt");
            foreach (string myLineX in myLines)
            {
                if (myLineX == "") continue;
                
                myParts = myLineX.Split('\t');
                if (myParts.Length != 4) continue;

                myIndex = myFond.IndexOf(myParts[0]);
                if (myIndex < 0)
                {
                    myFoNo.Add(i);
                    i++;
                }
                else
                {
                    myFoNo.Add(myFoNo[myIndex]);
                }

                myFond.Add(myParts[0]);
                myType.Add(char.Parse(myParts[1]));
                myDate.Add(DateTime.Parse(myParts[2]));
                myAmmo.Add(float.Parse(myParts[3]));
            }

            float mySum;
            float myCumulate;
            float myResult;

            int k;
            for (int j = 0; j < i; j++)
            {
                mySum = 0.0f;
                myCumulate = 0.0f;
                myResult = 0.0f;
                myIndexB = -1;
                myIndexD = -1;
                for (k = 0; k < myType.Count; k++)
                {
                    if (myFoNo[k] == j && myType[k] == 'B')
                    {
                        myIndexB = k;
                    }
                    if (myFoNo[k] == j && myType[k] == 'D')
                    {
                        myIndexD = k;
                    }
                }
                if (myIndexB < 0 || myIndexD < 0)
                {
                    myIndex = myFoNo.IndexOf(j);
                    Console.WriteLine("There is no deposit or balance for " + myFond[myIndex]);
                }
                else
                {
                    for (k = 0; k < myType.Count; k++)
                    {
                        if (myFoNo[k] == j && myType[k] == 'D')
                        {
                            myDiff = (myDate[myIndexB] - myDate[k]).Days;
                            mySum = mySum + myAmmo[k];
                            myCumulate = myCumulate + myDiff * myAmmo[k];
                        }
                    }
                    myResult = (myAmmo[myIndexB] - mySum) * 365.0f / myCumulate * 100.0f;
                    myIndex = myFoNo.IndexOf(j);
                    Console.WriteLine(myResult.ToString("n2") + " " + myFond[myIndex]);
                }
            }
        Console.ReadLine();
        }
    }
}


//+﻿using System;
// +using System.Collections.Generic;
// +using System.IO;
// +using System.Linq;
// +using System.Text;
// +using System.Threading.Tasks;
// +
// +namespace Interest
// +{
// +    class Movement
// +    {
// +        public string type;
// +        public float value;
// +        public DateTime when;
// +
// +        public int pointer(Movement[] myData, int lines)
// +        {
// +            int i = 0;
// +            int j = 0;
// +            for (i = 0; i < lines; i++)
// +            {
// +                if (myData[i].type == "B" && myData[i].when > myData[j].when)
// +                {
// +                    j = i;
// +                }
// +            }
// +            return j;
// +        }
// +
// +        public float result(Movement[] myData, int lines)
// +        {
// +            float result = 0.0F;
// +            float sum = 0.0F;
// +            float cumulate = 0.0F;
// +            int diff;
// +            int i = 0;
// +            int j = 0;
// +            for (i = 0; i < lines; i++)
// +            {
// +                if (myData[i].type == "B" && myData[i].when > myData[j].when)
// +                {
// +                    j = i;
// +                }
// +            }
// +            for (i = 0; i < lines; i++)
// +            {
// +                if (myData[i].type == "D")
// +                {
// +                    diff = (myData[j].when - myData[i].when).Days;
// +                    sum = sum + myData[i].value;
// +                    cumulate = cumulate + diff * myData[i].value;
// +                }
// +            }
// +            result = (myData[j].value - sum) * 365.0F / cumulate;
// +            return result;
// +        }
// +    }
// +
// +    class Program
// +    {
// +        static void Main(string[] args)
// +        {
// +            string[] parts;
// +            float result = 0.0F;
// +            int j;
// +
// +            string[] lines = File.ReadAllLines("input.txt");
// +            Movement[] myMovement = new Movement[lines.Length];
// +
// +//          nacteni souboru
// +            int i = 0;
// +            foreach (string linex in lines)
// +            {
// +                parts = linex.Split('\t');
// +
// +                myMovement[i] = new Movement();
// +                myMovement[i].type = parts[0];
// +                myMovement[i].value = float.Parse(parts[2]);
// +                myMovement[i].when = DateTime.Parse(parts[1]);
// +
// +                i++;
// +            }
// +
// +//          analyza souboru
// +            Movement myResult = new Movement(); //???
// +            result = myResult.result(myMovement, lines.Length);
// +            j = myResult.pointer(myMovement, lines.Length);
// +
// +//          vypis vysledku
// +            Console.WriteLine("Account history as of " + myMovement[j].when.ToShortDateString() + ":");
// +            for (i = 0; i < lines.Length; i++)
// +            {
// +                if (myMovement[i].type == "D")
// +                {
// +                    Console.Write(myMovement[i].type + " " + myMovement[i].value + " on " + myMovement[i].when.ToShortDateString());
// +                    Console.WriteLine();
// +                }
// +            }
// +            Console.WriteLine(result * 100.0F + "% interest this year");
// +            Console.WriteLine();
// +            Console.ReadLine();
// +        }
// +    }
// +}