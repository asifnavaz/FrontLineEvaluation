using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontlineCodeChallenge
{

    /// <summary>
    /// This class is used to parse the string provided to a tree structure by appending hyphens to inner node
    /// </summary>
    public class HyphenTree
    {
        public string strTitle { get; set; }
        public List<HyphenTree> lstChild { get; set; }

        /// <summary>
        /// This method prints the result by accepting the tree level as param
        /// </summary>
        /// <param name="intLevel"></param>
        public void PrintTree(int intLevel)
        {
            if (string.IsNullOrEmpty(strTitle))
                return;

            //Appends the hyphen based on the tree level passed as argument
            for (int i = 0; i < intLevel-1; i++)
            {
                Console.Write("-");
            }

            Console.WriteLine(strTitle);

            //calling the print function recursive to build the tree
            if (lstChild != null)
            {
                foreach (HyphenTree objHtree in lstChild)
                    objHtree.PrintTree(intLevel + 1);
            }
                

        }

        /// <summary>
        /// This method sorts the results in the list by Title field
        /// </summary>
        public void Sort()
        {
            lstChild = lstChild.OrderBy(objHtree => objHtree.strTitle).ToList();
            foreach (HyphenTree objHtree in lstChild)
            {
                objHtree.Sort();
            }
                
        }
    }
}
