using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilersLab1
{
    class Lexem
    {
        Codes Code;
        string Text;
        int StartPosition;

        public Lexem(Codes code, string text, int startPos)
        {
            Code = code;
            Text = text;
            StartPosition = startPos;
        }
        public string GetInfo()
        {
            return Convert.ToInt32(Code).ToString() + " - " + Code.ToString() + " - " + Text +
                " - начальная позиция: " + StartPosition.ToString() + "; конечная позиция: " + (StartPosition + Text.Length - 1).ToString();
        }
    }
}
