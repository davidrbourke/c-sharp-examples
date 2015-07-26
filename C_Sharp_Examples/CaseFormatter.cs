using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public class CaseFormatter
    {
        public string FormatString(string val)
        {

            string[] wordList = val.Split(' ');
            string[] updatedWordList = new string[wordList.Length];
            // declare lowercaselist

            string[] lowercaseWords = {
                                          "and",
                                          "at",
                                          "the"
                                      };

            if (wordList.Count() > 0)
            {
                // Capitalise word[0]
                if (wordList.Length > 0)
                {
                    updatedWordList[0] = Capitalise(wordList[0]);
                }
                // capitalise word [last]
                if (wordList.Length > 1)
                {
                    updatedWordList[wordList.Length - 1] = Capitalise(wordList[wordList.Length - 1]);
                }

                // for word[1] to word[last-1]
                for (int i = 1; i < wordList.Length - 1; i++)
                {
                    // if word in lowercase list
                    if (lowercaseWords.Contains(wordList[i].ToLower())) // lowercase word
                    {
                        updatedWordList[i] = Lowercase(wordList[i]);
                    }
                    else
                    {
                        updatedWordList[i] = Capitalise(wordList[i]); // capitalise
                    }
                }
            }

            return string.Join(" ", updatedWordList);
            
        }


        // lowercase
        public string Lowercase(string val)
        {
            return val.ToLower();
        }

        // capitalise
        public string Capitalise(string val)
        {
            // lowercase
            string lowered = Lowercase(val);

            // capitalise first letter
            return lowered.Substring(0, 1).ToUpper() + lowered.Substring(1, lowered.Length - 1);
        }
        
    }
}
