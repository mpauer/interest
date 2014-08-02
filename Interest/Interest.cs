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
            
//          reading the file
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

//          calculating the interest for each account
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