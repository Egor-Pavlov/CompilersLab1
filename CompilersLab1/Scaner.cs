using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilersLab1
{
    enum Codes
    {
        Identificator = 1,
        OutputOperator = 2,
        True = 3,
        False = 4,
        Null = 5,
        Equal = 6,
        End = 7,
        Space = 8,
        NewStr = 9,
        Comment1 = 10,
        Comment2 = 11,
        Integer = 12,
        String = 13,
        Error = -1
    }

    class Scaner
    {
        string Text;
        List<Lexem> lexems = new List<Lexem>();
        public Scaner(string Text)
        {
            this.Text = Text.Replace("\r", "");
        }
        public string GetResult()
        {
            string res = "";
            foreach (Lexem l in lexems)
            {
                res += l.GetInfo() + "\n";
            }

            return res;
        }
        public void Scan()
        {
            lexems.Clear();
            for (int i = 0; i < Text.Length; i++)
            {
                if (Text[i] == '$')
                {
                    i = CheckIdentificator(i);
                }
                else if (Char.IsLetter(Text[i]))
                {
                    i = CheckWord(i);
                }
                else if (Text[i] == '=')
                {
                    i = CheckEqual(i);
                }
                else if (Text[i] == ';')
                {
                    i = CheckEnd(i);
                }
                else if (Text[i] == ' ')
                {
                    i = CheckSpace(i);
                }
                else if (Text[i] == '\n')
                {
                    i = CheckNewStr(i);
                }
                else if (Text[i] == '/')
                {
                    i = CheckComment1(i);
                }
                else if (Text[i] == '<')
                {
                    i = CheckComment2(i);
                }
                else if (Char.IsDigit(Text[i]))
                {
                    i = CheckDigit(i);
                }
                else if (Text[i] == '"')
                {
                    i = CheckString(i);
                }
                else i = Error(i);
            }
        }
        int CheckIdentificator(int i)
        {
            string str = "";
            str += Text[i];
            int start = i;
            try
            {

                if (!Char.IsLetter(Text[i + 1]))
                {
                    str += Text[i + 1];
                    Lexem l0 = new Lexem(Codes.Error, str, start);
                    lexems.Add(l0);
                    return i + 1;
                }
                i++;
                str += Text[i];
                for (; i < Text.Length - 1; i++)
                {
                    //если следующий символ подходит, то записываем его в строку
                    if (Char.IsLetterOrDigit(Text[i + 1]))
                    {
                        str += Text[i + 1];
                    }
                    //если не подходит то создаем объект для того что уже есть 
                    else
                    {
                        Lexem l1 = new Lexem(Codes.Identificator, str, start);
                        lexems.Add(l1);
                        return i;
                    }
                }
                //если вдруг кончился текст то записываем то что есть
                Lexem l = new Lexem(Codes.Identificator, str, start);
                lexems.Add(l);
                return i;
            }
            catch
            {
                str += Text[i];
                Lexem l0 = new Lexem(Codes.Error, str, start);
                lexems.Add(l0);
                return i;
            }
        }

        int CheckWord(int i)
        {
            string str = "";
            str += Text[i];
            int start = i;

            //если следующий символ подходит, то записываем его в строку
            while (i + 1 < Text.Length)
            {
                if (Char.IsLetter(Text[i + 1]))
                {
                    str += Text[i + 1];
                    i++;
                }
                else break;
            }
            Lexem l = null;

            //если вдруг кончился текст то записываем то что есть
            if (str == "echo")
            {
                l = new Lexem(Codes.OutputOperator, str, start);
            }
            else if (str == "True")
                l = new Lexem(Codes.True, str, start);
            else if (str == "False")
                l = new Lexem(Codes.False, str, start);
            else if (str == "Null")
                l = new Lexem(Codes.Null, str, start);

            if (l == null)
            {
                l = new Lexem(Codes.Error, str, start);
            }

            lexems.Add(l);
            return i;
        }
        int CheckEqual(int i)
        {
            Lexem l = null;

            if (Text[i] == '=')
            {
                l = new Lexem(Codes.Equal, Text[i].ToString(), i);
            }
            else l = new Lexem(Codes.Error, Text[i].ToString(), i);

            lexems.Add(l);
            return i;
        }
        int CheckEnd(int i)
        {
            Lexem l = null;

            if (Text[i] == ';')
            {
                l = new Lexem(Codes.End, Text[i].ToString(), i);
            }
            else l = new Lexem(Codes.Error, Text[i].ToString(), i);

            lexems.Add(l);
            return i;
        }
        int CheckSpace(int i)
        {
            Lexem l = null;

            if (Text[i] == ' ')
            {
                l = new Lexem(Codes.Space, Text[i].ToString(), i);
            }
            else l = new Lexem(Codes.Error, Text[i].ToString(), i);

            lexems.Add(l);
            return i;
        }
        int CheckNewStr(int i)
        {
            Lexem l = null;

            if (Text[i] == '\n')
            {
                l = new Lexem(Codes.NewStr, "", i);
            }
            else l = new Lexem(Codes.Error, Text[i].ToString(), i);

            lexems.Add(l);
            return i;
        }
        int CheckComment1(int i)
        {
            string str = "";
            str += Text[i];
            int start = i;
            Lexem l = null;
            if(Text.Length - 1 != i)
            {
                if (Text[i + 1] == '*')
                {
                    str += Text[i + 1];
                    i++;
                }
                else
                {
                    l = new Lexem(Codes.Error, str, start);
                }
            }
            else
            {
                l = new Lexem(Codes.Error, str, start);
            }
            while (i + 1 < Text.Length)
            {
                if (Text[i + 1] != '*')
                {
                    str += Text[i + 1];
                    i++;
                }
                else break;
            }
            if (Text.Length - 1 != i)
            {
                if (Text[i + 1] == '*')
                {
                    str += Text[i + 1];
                    i++;
                }
                else
                {
                    l = new Lexem(Codes.Error, str, start);
                }
            }
            else
            {
                l = new Lexem(Codes.Error, str, start);
            }

            if (Text.Length - 1 != i)
            {
                if (Text[i + 1] == '/')
                {
                    str += Text[i + 1];
                    i++;
                }
                else
                {
                    l = new Lexem(Codes.Error, str, start);
                }
            }
            else
            {
                l = new Lexem(Codes.Error, str, start);
            }

            if(l == null)
            {
                l = new Lexem(Codes.Comment1, str, start);
            }
            lexems.Add(l);
            return i;
        }
        int CheckComment2(int i)
        {
            string str = "";
            str += Text[i];
            int start = i;
            Lexem l = null;
            if (Text.Length - 1 != i)
            {
                if (Text[i + 1] == '!')
                {
                    str += Text[i + 1];
                    i++;
                }
                else
                {
                    l = new Lexem(Codes.Error, str, start);
                }
            }
            else
            {
                l = new Lexem(Codes.Error, str, start);
            }
            if (Text.Length - 1 != i)
            {
                if (Text[i + 1] == '-')
                {
                    str += Text[i + 1];
                    i++;
                }
                else
                {
                    l = new Lexem(Codes.Error, str, start);
                }
            }
            else
            {
                l = new Lexem(Codes.Error, str, start);
            }
            if (Text.Length - 1 != i)
            {
                if (Text[i + 1] == '-')
                {
                    str += Text[i + 1];
                    i++;
                }
                else
                {
                    l = new Lexem(Codes.Error, str, start);
                }
            }
            else
            {
                l = new Lexem(Codes.Error, str, start);
            }

            while (i + 1 < Text.Length)
            {
                if (Text[i + 1] != '-')
                {
                    str += Text[i + 1];
                    i++;
                }
                else break;
            }
            if (Text.Length - 1 != i)
            {
                if (Text[i + 1] == '-')
                {
                    str += Text[i + 1];
                    i++;
                }
                else
                {
                    l = new Lexem(Codes.Error, str, start);
                }
            }
            else
            {
                l = new Lexem(Codes.Error, str, start);
            }

            if (Text.Length - 1 != i)
            {
                if (Text[i + 1] == '-')
                {
                    str += Text[i + 1];
                    i++;
                }
                else
                {
                    l = new Lexem(Codes.Error, str, start);
                }
            }
            else
            {
                l = new Lexem(Codes.Error, str, start);
            }
            if (Text.Length - 1 != i)
            {
                if (Text[i + 1] == '>')
                {
                    str += Text[i + 1];
                    i++;
                }
                else
                {
                    l = new Lexem(Codes.Error, str, start);
                }
            }
            else
            {
                l = new Lexem(Codes.Error, str, start);
            }

            if (l == null)
            {
                l = new Lexem(Codes.Comment2, str, start);
            }
            lexems.Add(l);
            return i;
        }
        int CheckDigit(int i)
        {
            string str = "";
            int start = i;
            Lexem l = null;
            
            
            //если следующий символ подходит, то записываем его в строку
            while (Char.IsDigit(Text[i]))
            {
                str += Text[i];
                i++;
            }
            int a;
            
            if (int.TryParse(str, out a))
            {
                if (start != 0)
                {
                    if (Text[start - 1] == '\n' || Text[start - 1] == ' ')
                    {
                        l = new Lexem(Codes.Integer, str, start);
                    }
                }
                else l = new Lexem(Codes.Integer, str, start);
            }
            else l = new Lexem(Codes.Error, str, start);

            lexems.Add(l);
            return i - 1;
        }
        int CheckString(int i)
        {
            string str = "";
            str += Text[i];
            int start = i;
            Lexem l = null;
            while (i + 1 < Text.Length)
            {
                if (Text[i + 1] != '"')
                {
                    str += Text[i + 1];
                    i++;
                }
                else break;
            }
            if (Text.Length - 1 != i)
            {
                if (Text[i + 1] == '"')
                {
                    str += Text[i + 1];
                    i++;
                }
                else
                {
                    l = new Lexem(Codes.Error, str, start);
                }
            }
            else
            {
                l = new Lexem(Codes.Error, str, start);
            }

            if (l == null)
            {
                l = new Lexem(Codes.String, str, start);
            }
            lexems.Add(l);
            return i;
        }
        int Error(int i)
        {
            Lexem l = new Lexem(Codes.Error, Text[i].ToString(), i);
            lexems.Add(l);
            return i;
        }

    }
}
