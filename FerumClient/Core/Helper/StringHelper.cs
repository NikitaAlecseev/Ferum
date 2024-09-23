using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerumClient.Core.Helper
{
    public class StringHelper
    {
        public static string AddHyphensToText(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            // Добавляем дефис после каждого второго символа
            string result = "";
            for (int i = 0; i < text.Length; i++)
            {
                result += text[i];
                if ((i + 1) % 2 == 0 && i + 1 < text.Length)
                {
                    result += "-";
                }
            }
            return result;
        }
    }
}
