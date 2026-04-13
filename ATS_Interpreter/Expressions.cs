using System;
using System.Collections.Generic;
using System.Text;

namespace ATS_Interpreter
{
    /// <summary>
    /// Интерфейс интерпретатора
    /// </summary>
    public interface IRuleElement
    {
        bool Interpret(CallContext c);
    }
    public class OrExpression : IRuleElement
    {
        IRuleElement left, right;
        public OrExpression(IRuleElement l, IRuleElement r)
        {
            left = l;
            right = r;
        }
        public bool Interpret(CallContext c)
        {
            return left.Interpret(c) || right.Interpret(c);
        }
        public override string ToString()
        {
            return left.ToString() + " ИЛИ " + right.ToString();
        }
    }
    public class AndExpression : IRuleElement
    {
        IRuleElement left, right;
        public AndExpression(IRuleElement l, IRuleElement r)
        {
            left = l;
            right = r;
        }
        public bool Interpret(CallContext c)
        {
            return left.Interpret(c) && right.Interpret(c);
        }
        public override string ToString()
        {
            return left.ToString() + " И " + right.ToString();
        }
    }
}
