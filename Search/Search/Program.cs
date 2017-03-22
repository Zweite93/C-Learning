using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Search("12 3abc123a1", "a123"));
        }

        static bool Search(string stringToSearch, string word)
        {
            char[] chars = word.ToCharArray();
            char firstWordChar = chars[0];

            if (String.Equals(stringToSearch, word))
                return true;

            for (int stringIndex = 0; stringIndex < stringToSearch.Length; stringIndex++)
            {
                if ((stringToSearch.Length - stringIndex) < chars.Length)
                    return false;

                if (stringToSearch[stringIndex] == firstWordChar)
                {
                    int secondStringIndex = stringIndex;

                    for (int charsIndex = 1; charsIndex < chars.Length; charsIndex++)
                    {
                        secondStringIndex++;
                        if (stringToSearch[secondStringIndex] == chars[charsIndex])
                            if (charsIndex == chars.Length - 1)
                                return true;
                            else
                                continue;
                        else
                            break;
                    }
                }
            }
            return false;
        }
    }
}
