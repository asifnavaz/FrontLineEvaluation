using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontlineCodeChallenge
{
    /// <summary>
    /// This entry point which utilizes the Hyphen class to manipulate the- 
    /// string provided into a tree structure as requested by Frontline
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string strInput = "id,created,employee(id,firstname,employeeType(id),lastname),location";
            strInput += ",";

            Stack<HyphenTree> stackItems = new Stack<HyphenTree>();
            int intStart = 0;
            int intPosition = 0;

            HyphenTree objRoot = new HyphenTree { strTitle = "Result Tree", lstChild = new List<HyphenTree>() };
            foreach (char chrInput in strInput)
            {
                intPosition++;
                if (chrInput == '(')
                {
                    HyphenTree objChildRoot = new HyphenTree { strTitle = strInput.Substring(intStart, intPosition - intStart - 1), lstChild = new List<HyphenTree>() };
                    objRoot.lstChild.Add(objChildRoot);
                    stackItems.Push(objRoot);
                    objRoot = objChildRoot;
                    intStart = intPosition;
                }

                if (chrInput == ',')
                {
                    if (strInput[intPosition - 1] == ')')
                    {
                        intStart = intPosition;
                        continue;
                    }

                    objRoot.lstChild.Add(new HyphenTree { strTitle = strInput.Substring(intStart, intPosition - intStart - 1), lstChild = new List<HyphenTree>() });
                    intStart = intPosition;
                }

                if (chrInput == ')')
                {
                    objRoot.lstChild.Add(new HyphenTree { strTitle = strInput.Substring(intStart, intPosition - intStart - 1), lstChild = new List<HyphenTree>() });
                    objRoot = stackItems.Pop();
                    intStart = intPosition;
                }

            }

            Console.WriteLine("Result before Sorting");
            Console.WriteLine("---------------------");
            objRoot.PrintTree(0);

            //Bonus question was provided to sort the result in alphabetical order
            Console.WriteLine("Result After Sorting");
            Console.WriteLine("---------------------");
            objRoot.Sort();
            objRoot.PrintTree(0);
                        
        }
    }
}
