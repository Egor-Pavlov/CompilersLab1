﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilersLab1
{
    class StateMachine
    {
        string[] Text;
        public string Result = "";
        int State = 0;
        List<((int, string), int)> map = new List<((int, string), int)>();


        public StateMachine(string Text)
        {
            this.Text = Text.Replace("\n", " ").Replace("\t", " ").Replace("\r", "").Replace("  ", " ").Split(' ');
            Result += State.ToString() + " ";
            //создаем таблицу состояний и переходов
            map.Add(((0, "a"), 1));
            map.Add(((0, "e"), 5));
            map.Add(((1, "b"), 0));
            map.Add(((1, "c"), 2));
            map.Add(((2, "c"), 2));
            map.Add(((2, "g"), 1));
            map.Add(((2, "d"), 3));
            map.Add(((3, "n"), 2));
            map.Add(((3, "o"), 4));
            map.Add(((4, "h"), 0));
            map.Add(((5, "c"), 6));
            map.Add(((5, "f"), 0));
            map.Add(((6, "c"), 6));
            map.Add(((6, "d"), 7));
            map.Add(((6, "g"), 5));
            map.Add(((7, "n"), 6));
            map.Add(((7, "m"), 9));
            map.Add(((7, "i"), 8));
            map.Add(((8, "j"), 9));
            map.Add(((8, "k"), 9));
            map.Add(((9, "l"), 10));
            map.Add(((10, "h"), 0));
        }
        public void Start()
        {
            bool flag = false;
            for (int i = 0; i < Text.Length; i++)
            {
                flag = false;
                for (int j = 0; j < map.Count; j++)
                {
                    if (map[j].Item1.Item1 == State && Text[i] == map[j].Item1.Item2)
                    {
                        flag = true;
                        State = map[j].Item2;
                        break;
                    }

                }
                if (flag)
                {
                    Result += State.ToString() + " ";
                    continue;
                }
                else
                {
                    Result += " Ошибка";
                    return;
                }
            }

        }
    }
}