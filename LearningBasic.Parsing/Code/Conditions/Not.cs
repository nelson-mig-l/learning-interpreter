﻿namespace LearningBasic.Parsing.Code.Conditions
{
    using System.Linq.Expressions;

    public class Not : UnaryOperator
    {
        public Not(IExpression operand)
            : base(Associativity.Right, Priority.LogicalNegation, "NOT", operand)
        {
            DoInsertSpacebar = true;
        }

        protected override Expression BuildExpression(Expression operand)
        {
            return DynamicExpressionBuilder.BuildOperator(ExpressionType.Not, operand);
        }
    }
}