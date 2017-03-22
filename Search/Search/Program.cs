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
            Console.WriteLine(Search("12 3abc123a123", "a123"));
        }

        static bool Search(string text, string word)
        {
            if (String.Equals(text, word))
                return true;

            char firstLetter = word[0];

            for (int i = 0; i < text.Length; i++)
            {
                if ((text.Length - i) < word.Length)
                    return false;

                if (text[i] == firstLetter)
                {
                    int textIndex = i;

                    for (int j = 1; j < word.Length; j++)
                    {
                        textIndex++;
                        if (text[textIndex] == word[j])
                            if (j == word.Length - 1)
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
