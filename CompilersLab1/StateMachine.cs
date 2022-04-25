using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilersLab1
{
    class StateMachine
    {
        List<Lexem> lexems = new List<Lexem>();
        public string Result = "";
        int State = 0;
        List<((int, Codes), int)> map = new List<((int, Codes), int)>();
        string StringNum;

        public StateMachine(List<Lexem> lexems, int n)
        {
            StringNum = n.ToString();
            for (int i = 0; i < lexems.Count; i++)
            {
                if (lexems[i].Code != Codes.Space && lexems[i].Code != Codes.NewStr)
                    this.lexems.Add(lexems[i]);
            }
            if (this.lexems.Count == 0)
                return;
            this.lexems.Add(new Lexem(Codes.NewStr, "#", this.lexems.Last().StartPosition + this.lexems.Last().Text.Length));
            //создаем таблицу состояний и переходов
            map.Add(((0, Codes.Identificator), 1));
            map.Add(((1, Codes.Equal), 2));
            map.Add(((1, Codes.End), 4));
            map.Add(((2, Codes.Number), 3));
            map.Add(((2, Codes.String), 3));
            map.Add(((2, Codes.Char), 3));
            map.Add(((3, Codes.End), 4));

            Start();
        }
        int Error(int i)
        {
            int I = i;
            Result += "Строка " + StringNum + ": Ошибка на позиции " + lexems[i].StartPosition + ". Ожидалось: ";
            if (State == 0)
            {
                Result += "Идентификатор";
                State = 1;
                Result += ". Встретилось: " + "\"" + lexems[i].Text + "\"\n";
                if (lexems[i].Code != Codes.Error)
                {
                    Lexem l = new Lexem(lexems[i].Code, lexems[i].Text, lexems[i].StartPosition);
                    lexems.Insert(i, l);
                    lexems[i].Code = Codes.Identificator;
                    lexems[i].Text = "$<identificator>";


                }
                else
                {
                    lexems[i].Code = Codes.Identificator;
                    lexems[i].Text = "$<identificator>";
                }
            }
            else if (State == 1)
            {
                if (lexems.Count == 3 && i == 1 || lexems[i].Code == Codes.NewStr)
                {
                    Result += "\";\"";
                    Result += ". Встретилось: " + "\"" + lexems[i].Text + "\"\n";
                    lexems[i].Code = Codes.End;
                    lexems[i].Text = ";";
                    State = 4;
                }

                else if (lexems[i].Code != Codes.NewStr)
                {
                    Result += "\"=\"";
                    State = 2;
                    Result += ". Встретилось: " + "\"" + lexems[i].Text + "\"\n";
                    if (lexems[i].Code != Codes.Error)
                    {
                        lexems[i].Code = Codes.Equal;
                        lexems[i].Text = "=";
                        I--;
                    }
                    else
                    {
                        Lexem l = new Lexem(lexems[i].Code, lexems[i].Text, lexems[i].StartPosition);
                        lexems.Insert(i, l);
                        lexems[i].Code = Codes.Equal;
                        lexems[i].Text = "=";
                    }

                }


            }
            else if (State == 2)
            {
                if (lexems[i].Code == Codes.End)
                {
                    Result += "Число, или строка, или символ";
                    State = 3;
                    Result += ". Встретилось: " + "\"" + lexems[i].Text + "\"\n";
                    Lexem l = new Lexem(lexems[i].Code, lexems[i].Text, lexems[i].StartPosition);
                    lexems.Insert(i, l);
                    lexems[i].Code = Codes.Number;
                    lexems[i].Text = "0";
                }
                else
                {
                    Result += "число, или строка, или символ";
                    State = 3;
                    Result += ". Встретилось: " + "\"" + lexems[i].Text + "\"\n";
                    lexems[i].Code = Codes.Number;
                    lexems[i].Text = "0";
                }
            }
            else if (State == 3)
            {
                Result += "\";\"";
                State = 4;
                Result += ". Встретилось: " + "\"" + lexems[i].Text + "\"\n";
                if (lexems.Count > i)
                {
                    if (lexems.Count > i + 1)
                    {
                        if (lexems[i + 1].Code == Codes.NewStr)
                        {
                            State = 3;

                            lexems[i].Code = Codes.End;
                            lexems[i].Text = ";";
                            I--;
                        }
                    }
                    if(lexems[i].Code == Codes.NewStr)
                    {
                        Lexem l = new Lexem(lexems[i].Code, lexems[i].Text, lexems[i].StartPosition);
                        lexems.Insert(i, l);
                        lexems[i].Code = Codes.End;
                        lexems[i].Text = ";";
                    }
                }
                else
                {

                    lexems[i].Code = Codes.End;
                    lexems[i].Text = ";";
                }
            }
            else if (State == 4)
            {
                Result += "#";
                Result += ". Встретилось: " + "\"" + lexems[i].Text + "\"\n";
                lexems[i].Code = Codes.NewStr;
                lexems[i].Text = "#";
            }


            return I;
        }
        public void Start()
        {
            bool flag = false;
            for (int i = 0; i < lexems.Count; i++)
            {
                if (State == 4 && lexems[i].Code == Codes.NewStr)
                    break;

                flag = false;
                for (int j = 0; j < map.Count; j++)
                {
                    if (map[j].Item1.Item1 == State && lexems[i].Code == map[j].Item1.Item2)
                    {
                        flag = true;
                        State = map[j].Item2;
                        break;
                    }

                }
                if (flag)
                {
                    continue;
                }
                else
                {
                    i = Error(i);

                }
            }
            if (State != 4)
            {
                Error(lexems.Count - 1);
            }
            if (Result != "")
            {

                string fixedstr = "Исправленная строка: ";

                foreach (Lexem l in lexems)
                {
                    if (l.Text != "#")
                        fixedstr += l.Text;
                }
                Result += fixedstr + "\n";
            }
        }

    }
}
