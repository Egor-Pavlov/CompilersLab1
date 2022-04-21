using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilersLab1
{
    class Lexem
    {
        public Codes Code;
        public string Text;
        public int StartPosition { get; }

        public Lexem(Codes code, string text, int startPos)
        {
            Code = code;
            Text = text.Replace("\n", "");
            StartPosition = startPos;
        }
        public string GetInfo()
        {
            return Convert.ToInt32(Code).ToString() + " - " + Code.ToString() + " - \"" + Text +
                "\" - начальная позиция: " + StartPosition.ToString() + "; конечная позиция: " + (StartPosition + Text.Length - 1).ToString();
        }
    }
}
