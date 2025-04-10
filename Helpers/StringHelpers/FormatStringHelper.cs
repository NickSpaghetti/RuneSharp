using System;
using System.Collections.Generic;
using System.Text;

namespace RuneSharp.Helpers.StringHelpers
{
    public static class FormatStringHelper
    {
        public static string UppercaseFirst(string word)
        {
            if(string.IsNullOrEmpty(word))
            {
                return string.Empty;
            }

            return char.ToUpper(word[0]) + word.Substring(1);
        }

        public static string UppercaseLast(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return string.Empty;
            }

            return word.Substring(0, word.Length - 1) + char.ToUpper(word[word.Length - 1]);
        }


        public static string UppercaseLetter(string word, int position)
        {

            if (string.IsNullOrEmpty(word) || word.Length < position)
            {
                return string.Empty;
            }

            if(position == 0)
            {
                return UppercaseFirst(word);
            }

            if(position == word.Length)
            {
                return UppercaseLast(word);
            }

            return word.Substring(0, position) + char.ToUpper(word[position]) + word.Substring(position + 1, word.Length - position - 1);
        }

        public static bool IsCharValidLetter(char c)
        {
            var isLetter = false;
            if(char.IsLetter(c) && c < 128)
            {
                isLetter = true;
            }
            return isLetter;
        }
    }
}
