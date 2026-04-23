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
        /// <summary>
        /// Вычислить если данный контекст звонка выполняет это правило
        /// </summary>
        /// <param name="c">Контекст звонка</param>
        /// <returns>Соответствует ли <paramref name="c"/> правилу</returns>
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
        /// <summary>
        /// Вычислить если данный контекст звонка выполняет хотя бы одно из двух правил
        /// </summary>
        /// <param name="c">Контекст звонка</param>
        /// <returns>Соответствует ли <paramref name="c"/> правилу</returns>
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
        /// <summary>
        /// Вычислить если данный контекст звонка выполняет оба правила
        /// </summary>
        /// <param name="c">Контекст звонка</param>
        /// <returns>Соответствует ли <paramref name="c"/> правилам</returns>
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
