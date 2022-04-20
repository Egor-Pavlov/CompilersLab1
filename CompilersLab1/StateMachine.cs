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


        public StateMachine(List<Lexem> lexems)
        {

            for (int i = 0; i < lexems.Count; i++)
            {
                if (lexems[i].Code != Codes.Space && lexems[i].Code != Codes.NewStr)
                    this.lexems.Add(lexems[i]);
            }

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
            Result += "Ошибка на позиции " + lexems[i].StartPosition + ". Ожидалось: ";
            if (State == 0)
            {
                Result += "Identificator";
                State = 1;
                if(lexems[i].Code != Codes.Error)
                    I--;
            }
            else if (State == 1)
            {
                if (lexems.Count == 3 && i == 1 || lexems[i].Code == Codes.NewStr)
                {
                    Result += "\"End\"";
                    State = 4;
                }

                else if (lexems[i].Code != Codes.NewStr)
                {
                    Result += "\"Equal\"";
                    State = 2;

                    if (lexems[i].Code != Codes.Error)
                        I--;
                }
                

            }
            else if (State == 2)
            {
                if(lexems[i].Code == Codes.End)
                {
                    Result += "\"Number\" or \"String\" or \"Char\"";
                    State = 4;
                }
                else
                {
                    Result += "\"Number\" or \"String\" or \"Char\"";
                    State = 3;
                }
            }
            else if (State == 3)
            {
                Result += "\"End\"";
                State = 4;
            }
            else if(State == 4)
            {
                Result += "#";
            }

            Result += ". Встретилось: " + lexems[i].Code + " \"" + lexems[i].Text + "\"\n";
            return I;
        }
        public void Start()
        {
            bool flag = false;
            for (int i = 0; i < lexems.Count; i++)
            {
                if (State == 4 && lexems[i].Code == Codes.NewStr)
                    return;

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

        }

        // лаба

        //public StateMachine(string Text)
        //{
        //    this.Text = Text.Replace("\n", " ").Replace("\t", " ").Replace("\r", "").Replace("  ", " ").Split(' ');
        //    Result += State.ToString() + " ";
        //    //создаем таблицу состояний и переходов
        //    map.Add(((0, "a"), 1));
        //    map.Add(((0, "e"), 5));
        //    map.Add(((1, "b"), 0));
        //    map.Add(((1, "c"), 2));
        //    map.Add(((2, "c"), 2));
        //    map.Add(((2, "g"), 1));
        //    map.Add(((2, "d"), 3));
        //    map.Add(((3, "n"), 2));
        //    map.Add(((3, "o"), 4));
        //    map.Add(((4, "h"), 0));
        //    map.Add(((5, "c"), 6));
        //    map.Add(((5, "f"), 0));
        //    map.Add(((6, "c"), 6));
        //    map.Add(((6, "d"), 7));
        //    map.Add(((6, "g"), 5));
        //    map.Add(((7, "n"), 6));
        //    map.Add(((7, "m"), 9));
        //    map.Add(((7, "i"), 8));
        //    map.Add(((8, "j"), 9));
        //    map.Add(((8, "k"), 9));
        //    map.Add(((9, "l"), 10));
        //    map.Add(((10, "h"), 0));
        //}
        //public void Start()
        //{
        //    bool flag = false;
        //    for (int i = 0; i < Text.Length; i++)
        //    {
        //        flag = false;
        //        for (int j = 0; j < map.Count; j++)
        //        {
        //            if (map[j].Item1.Item1 == State && Text[i] == map[j].Item1.Item2)
        //            {
        //                flag = true;
        //                State = map[j].Item2;
        //                break;
        //            }

        //        }
        //        if (flag)
        //        {
        //            Result += State.ToString() + " ";
        //            continue;
        //        }
        //        else
        //        {
        //            Result += " Ошибка";
        //            return;
        //        }
        //    }

        //}
    }
}
