﻿namespace LearningBasic.Parsing.Code.Conditions
{
    using LearningBasic.Parsing.Code.Expressions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class NotTests : BaseTests
    {
        [TestMethod]
        public void Not_WithFalse_ReturnsTrue()
        {
            var operand = new Constant(false);

            var operation = new Not(operand);
            var actual = (bool)operation.GetExpression(null).Calculate();

            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void Not_WithTrue_ReturnsFalse()
        {
            var operand = new Constant(true);

            var operation = new Not(operand);
            var actual = (bool)operation.GetExpression(null).Calculate();

            Assert.AreEqual(false, actual);
        }
    }
}