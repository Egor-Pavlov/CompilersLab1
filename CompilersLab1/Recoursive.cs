using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilersLab1
{


    //      G[<условный оператор>]:
    //  1. <условный оператор> ::= IF <условие> THEN <оператор>
    //  2. <условие> ::= <выражение><операция отношения><выражение>
    //  3. <выражение> ::= <терм>{ +< терм >}
    //  4. <терм> ::= <множитель>{*<множитель>}
    //  5. < множитель > ::= < идентификатор >| (< выражение >)
    //  6. < идентификатор > ::= < буква >{< буква >|< цифра >}
    //  7. < оператор > ::= < идентификатор >:=< выражение > | < условный оператор > 
    //  8. < операция отношения > ::= ”==” || ”<” | ”<=” | ”>” | ”>=” | ”!=”
    //      < буква > ::= A | B | ...| Y | Z
    //      < цифра > ::= 0 | 1 | ...| 8 | 9
    class Recoursive
    {
        string Text = "";
        public bool Result = true;
        int I = 0;
        public string ResultText = "";

        public Recoursive(string text)
        {
            Text = text.Replace(" ", "").Replace("\n", "").Replace("\t", "").Replace("\r", "");
        }

        void Identificator()
        {
            ResultText += " Identificator ";
            I++;
            while (I < Text.Length)
            {
                if (Char.IsLetterOrDigit(Text[I]))
                    Result = true;
                else
                {
                    I--;
                    return;
                }
                I++;
            }
        }

        void Multiplier()
        {
            ResultText += " Multiplier ";
            I++;
            if (Char.IsLetter(Text[I]))
            {

                Identificator();
            }

            else
            {
                if (Text[I] == '(')
                {
                    Expression();
                    I++;
                    if (Text[I] == ')')
                    {
                        Result = false;
                        return;
                    }
                }

            }
        }
        void Term()
        {
            ResultText += " Term ";
            
            I++;
            while (I < Text.Length)
            {
                if (Text[I] == '*')
                    Multiplier();
                else return;
                I++;
            }
        }

        void Expression()
        {
            ResultText += " Expression ";
            Term();
            if(I + 1 < Text.Length)
                while (Text[I + 1] == '+' && I + 1 < Text.Length)
                {
                    I++;
                    Term();

                }
        }
        //< операция отношения > ::= ”==” | ”<” | ”<=” | ”>” | ”>=” | ”!=”
        void Operation()
        {
            ResultText += " Operation ";
            if (I + 1 < Text.Length)
            {
                I++;
                if(Text[I] == '>' || Text[I] == '<')
                {
                    I++;
                    if (Text[I] == '=')
                    {
                        Result = true;
                        return;
                    }
                    else
                    {
                        Result = false;
                        return;
                    }
                }
                else
                {
                    if(Text[I] == '=' || Text[I] == '!')
                    {
                        I++;
                        if (Text[I] == '=')
                        {
                            Result = true;
                            return;
                        }
                        else
                        {
                            Result = false;
                            return;
                        }
                    }
                    else
                    {
                        Result = false;
                        return;
                    }
                }
            }
            else
            {
                Result = false;
                return;
            }
        }

        public void Condition()
        {
            ResultText += " Condition ";
            Expression();
            Operation();
            Expression();
        }

        //< оператор > ::= < идентификатор >:=< выражение > | < условный оператор > 
        void Operator()
        {
            ResultText += " Operator ";
            I++;
            if (Char.IsLetter(Text[I]))
            {
                Identificator();
            }

            else
            {
                Result = false;
                return;
            }

            if (I + 2 < Text.Length) 
            {
                I++;
                if (Text[I] == ':')
                {
                    I++;
                    if(Text[I] == '=')
                    {
                        Expression();
                    }
                    else
                    {
                        Result = false;
                        return;
                    }
                }
                else
                {
                    ConditionalOperator();
                }
            }

        }
        void ConditionalOperator()
        {
            ResultText += " ConditionalOperator ";
            if (Text[I] == 'I' && Text[I + 1] == 'F' && Text.Length > 3 + I)
            {
                I += 1;
                Condition();
            }
            else
            {
                Result = false;
                return;
            }
           

            if (I + 4 < Text.Length)
                if (Text[I + 1] == 'T' && Text[I + 2] == 'H' && Text[I + 3] == 'E' && Text[I + 4] == 'N')
                {
                    I += 4;
                    Operator();
                }
                else Result = false;
            else Result = false;
        }
        public bool Scan()
        {

            ConditionalOperator();

            return Result;
        }
    }
}
