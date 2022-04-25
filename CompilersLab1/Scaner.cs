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
        Equal = 2,
        End = 3,
        Space = 4,
        NewStr = 5,
        Number = 6,
        String = 7,
        Char = 8,
        Error = -1
    }

    class Scaner
    {
        string Text;
        public List<Lexem> lexems = new List<Lexem>();
        public Scaner(string Text)
        {
            this.Text = Text.Replace("\r", "").Replace("\t", " ").Replace("  ", " ").Replace(";", ";\n");
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

                else if (Char.IsDigit(Text[i]))
                {
                    i = CheckDigit(i);
                }
                else if (Text[i] == '"')
                {
                    i = CheckString(i);
                }
                else if (Text[i] == '\'')
                {
                    i = CheckChar(i);
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
                    i++;
                    while (i < Text.Length)
                    {
                        if (Text[i] != ' ' && Text[i] != ';' && Text[i] != '\n')
                        {

                            str += Text[i];
                            i++;
                        }
                        else
                        {
                            i--;
                            break;
                        }
                    }
                    Lexem l0 = new Lexem(Codes.Error, str, start);
                    lexems.Add(l0);
                    return i;
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
                Lexem l0 = new Lexem(Codes.Error, str, start);
                lexems.Add(l0);
                return i;
            }
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
                l = new Lexem(Codes.NewStr, "#", i);
            }
            else l = new Lexem(Codes.Error, Text[i].ToString(), i);

            lexems.Add(l);
            return i;
        }

        int CheckDigit(int i)
        {
            string str = "";
            int start = i;
            Lexem l = null;


            //если следующий символ подходит, то записываем его в строку
            while (i < Text.Length)
            {
                char c = Text[i];
                if (Char.IsDigit(Text[i]) || Text[i] == '.')
                {
                    if (Text[i] == '.')
                    {
                        str += Text[i];
                        i++;

                        while (i < Text.Length)
                        {
                            if (Char.IsDigit(Text[i]))
                            {
                                str += Text[i];
                                i++;
                            }
                            else break;
                        }
                        break;
                    }
                    else
                    {
                        str += Text[i];
                        i++;

                        if (i >= Text.Length)
                            break;
                        else
                            continue;
                    }
                }
                if (Text[i] != ' ' && Text[i] != ';' && Text[i] != '\n')
                {
                    while (i < Text.Length)
                    {
                        if (Text[i] != ' ' && Text[i] != ';' && Text[i] != '\n')
                        {
                            str += Text[i];
                            i++;
                        }
                        else
                        {
                            i--;
                            break;
                        }
                    }
                    l = new Lexem(Codes.Error, str, start);
                    lexems.Add(l);
                    return i;
                }
                if(Text[i] == ' ' || Text[i] == ';' || Text[i] == '\n') 
                    break;

                //if (i < Text.Length)
                //    i++;
                //else break;
            }
            double a;
            if (str.Last() == '.')
            {

                l = new Lexem(Codes.Error, str, start);
                lexems.Add(l);
                return i - 1;
            }
            str = str.Replace('.', ',');

            if (double.TryParse(str, out a))
            {
                if (start != 0)
                {
                    l = new Lexem(Codes.Number, str, start);
                    //if (Text[start - 1] == '\n' || Text[start - 1] == ' ')
                    //{
                    //}
                }
                else l = new Lexem(Codes.Number, str, start);
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
                    if (Char.IsLetterOrDigit(Text[i + 1]) || Text[i + 1] == '!' || Text[i + 1] == '&' || Text[i + 1] == '?' || Text[i + 1] == ',' || Text[i + 1] == '/' || Text[i + 1] == ' ')
                    {
                        str += Text[i + 1];
                        i++;
                    }
                    else
                    {
                        i++;
                        while (i < Text.Length)
                        {
                            if (Text[i] != ' ' && Text[i] != ';' && Text[i] != '\n')
                            {

                                str += Text[i];
                                i++;
                            }
                            else
                            {
                                i--;
                                break;
                            }
                        }
                        l = new Lexem(Codes.Error, str, start);
                        break;
                    }
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
        int CheckChar(int i)
        {
            string str = "";
            str += Text[i];
            int start = i;
            Lexem l = null;

            i++;
            if (Text.Length > i)
            {
                if (Char.IsLetterOrDigit(Text[i]) || Text[i] == '!' || Text[i] == '&' || Text[i] == '?' || Text[i] == ',' || Text[i] == '/' || Text[i] == ' ')
                {
                    str += Text[i];
                    i++;
                    if (Text.Length > i)
                    {
                        if (Text[i] == '\'')
                        {
                            str += Text[i];
                        }
                        else
                        {
                            str += Text[i];
                            i++;
                            while (i < Text.Length)
                            {
                                if (Text[i] != ' ' && Text[i] != ';' && Text[i] != '\n')
                                {

                                    str += Text[i];
                                    i++;
                                }
                                else
                                {
                                    i--;
                                    break;
                                }
                            }
                            l = new Lexem(Codes.Error, str, start);
                        }

                    }
                    else
                    {
                        l = new Lexem(Codes.Error, str, start);
                    }
                }
                else
                {
                    str += Text[i];
                    i++;
                    while (i < Text.Length)
                    {
                        if (Text[i] != ' ' && Text[i] != ';' && Text[i] != '\n')
                        {

                            str += Text[i];
                            i++;
                        }
                        else
                        {
                            i--;
                            break;
                        }
                    }
                    l = new Lexem(Codes.Error, str, start);
                }

            }
            else
            {
                l = new Lexem(Codes.Error, str, start);
            }



            if (l == null)
            {
                l = new Lexem(Codes.Char, str, start);
            }
            lexems.Add(l);
            return i;
        }
        int Error(int i)
        {
            string str = "";
            int start = i;
            //если следующий символ подходит, то записываем его в строку
            while (i < Text.Length)
            {
                if (Text[i] != ' ' && Text[i] != ';' && Text[i] != '\n')
                {

                    str += Text[i];
                    i++;
                }
                else
                {
                    i--;
                    break;
                }
            }

            Lexem l = new Lexem(Codes.Error, str, start);
            lexems.Add(l);
            return i;
        }

    }
}
