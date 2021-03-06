﻿namespace LearningInterpreter.Basic.Code.Statements
{
    using System;
    using System.Collections.Generic;
    using LearningInterpreter.RunTime;

    public class Print : IStatement
    {
        public IReadOnlyList<IExpression> Expressions { get; private set; }

        public Print(IEnumerable<IExpression> expressions)
        {
            if (expressions == null)
                throw new ArgumentNullException("expressions");

            Expressions = new List<IExpression>(expressions);
        }

        public virtual EvaluateResult Execute(IRunTimeEnvironment rte)
        {
            foreach (var expression in Expressions)
            {
                var compiled = expression.GetExpression(rte.Variables);
                var value = compiled.Calculate();
                var valueAsString = value == null ? string.Empty : value.ToString();
                rte.InputOutput.Write(valueAsString);
            }

            return EvaluateResult.None;
        }

        public override string ToString()
        {
            return "PRINT " + string.Join(", ", Expressions) + ';';
        }
    }
}
