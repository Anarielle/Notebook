using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook
{
    public class Validation
    {
        public bool Required { get; set; }
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public char[] ValidSymbols { get; set; }

        public Validation(bool req, int min, int max, char[] val)
        {
            Required = req;
            MinLength = min;
            MaxLength = max;
            ValidSymbols = val;
        }

        public bool TryValidate(string input, out string output)
        {
            output = null;

            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
            {
                if (Required)
                {
                    output = "Это поле является обязательным!";
                    return false;
                }
                else
                {
                    output = null;
                    return true;
                }
            }

            if (input.Length < MinLength)
            {
                output = $"Минимальная длина: {MinLength}!";
                return false;
            }

            if (input.Length > MaxLength)
            {
                output = $"Максимальная длина: {MaxLength}!";
                return false;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (!ValidSymbols.Contains(input[i]))
                {
                    output = $"Используйте только: {new String(ValidSymbols)}!";
                    return false;
                }
            }
            return true;
        }
    }
}
