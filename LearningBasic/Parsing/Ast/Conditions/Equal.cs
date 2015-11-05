﻿namespace LearningBasic.Parsing.Ast.Conditions
{
    using System.Linq.Expressions;

    public class Equal : BinaryOperator
    {
        public Equal(IExpression left, IExpression right)
            : base(Associativity.Left, Priority.Comparison, "=", left, right)
        { }

        protected override Expression BuildExpression(Expression left, Expression right)
        {
            return PerformBuiltInOperator(ExpressionType.Equal, left, right);
        }
    }
}
