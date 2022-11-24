// Given a language, the Interpreter design pattern defines a representation for its grammar along
// with an interpreter that uses the representation to interpret sentences in the language
namespace Interpreter
{
    /// <summary>
    /// Context
    /// </summary>
    public class RomanContext
    {
        public int Input { get; set; }
        public string Output { get; set; }

        public RomanContext(int input)
        {
            Input = input;
            Output = string.Empty;
        }
    }

    /// <summary>
    /// AbstractExpression
    /// </summary>
    public interface IRomanExpression
    {
        public void Interpret(RomanContext context);
    }

    /// <summary>
    /// TerminalExpression
    /// </summary>
    public class RomanOneExpression : IRomanExpression
    {
        // numbers 1-9
        public void Interpret(RomanContext context)
        {
            while (context.Input - 9 >= 0)
            {
                context.Output += "IX";
                context.Input -= 9;
            }

            while (context.Input - 5 >= 0)
            {
                context.Output += "V";
                context.Input -= 5;
            }

            while (context.Input - 4 >= 0)
            {
                context.Output += "IV";
                context.Input -= 4;
            }

            while (context.Input - 1 >= 0)
            {
                context.Output += "I";
                context.Input -= 1;
            }
        }
    }

    /// <summary>
    /// TerminalExpression
    /// </summary>
    public class RomanTenExpression : IRomanExpression
    {
        // numbers 10-90
        public void Interpret(RomanContext context)
        {
            while (context.Input - 90 >= 0)
            {
                context.Output += "XC";
                context.Input -= 90;
            }

            while (context.Input - 50 >= 0)
            {
                context.Output += "L";
                context.Input -= 50;
            }

            while (context.Input - 40 >= 0)
            {
                context.Output += "XL";
                context.Input -= 40;
            }

            while (context.Input - 10 >= 0)
            {
                context.Output += "X";
                context.Input -= 10;
            }
        }
    }

    /// <summary>
    /// TerminalExpression
    /// </summary>
    public class RomanHundredExpression : IRomanExpression
    {
        // numbers 100-900
        public void Interpret(RomanContext context)
        {
            while (context.Input - 900 >= 0)
            {
                context.Output += "CM";
                context.Input -= 900;
            }

            while (context.Input - 500 >= 0)
            {
                context.Output += "D";
                context.Input -= 500;
            }

            while (context.Input - 400 >= 0)
            {
                context.Output += "CD";
                context.Input -= 400;
            }

            while (context.Input - 100 >= 0)
            {
                context.Output += "C";
                context.Input -= 100;
            }
        }
    }
}
