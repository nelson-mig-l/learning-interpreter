﻿namespace LearningBasic.Parsing
{
    using LearningBasic.Parsing.Ast;
    using LearningBasic.Parsing.Ast.Statements;

    /// <summary>
    /// Implements methods to parse BASIC statements and to build Abstract Syntax Tree's nodes.
    /// </summary>
    public static class BasicScannerStatementExtensions
    {
        public static IStatement ReadStatementExcludingNext(this IScanner<Token> scanner)
        {
            IStatement result;

            if (scanner.TryReadLet(out result))
                return result;

            if (scanner.TryReadPrint(out result))
                return result;

            if (scanner.TryReadInput(out result))
                return result;

            if (scanner.TryReadList(out result))
                return result;

            if (scanner.TryReadToken(Token.Quit))
                return new Quit();

            throw new ParserException(ErrorMessages.MissingStatement);
        }

        public static bool TryReadLet(this IScanner<Token> scanner, out IStatement result)
        {
            ILValue lValue;
            IExpression expression;

            if (scanner.TryReadToken(Token.Let))
            {
                lValue = scanner.ReadLValue();
            }
            else if (!scanner.TryReadLValue(out lValue))
            {
                result = null;
                return false;
            }

            scanner.ReadToken(Token.Eq);
            expression = scanner.ReadExpression();
            result = new Let(lValue, expression);
            return true;
        }

        public static bool TryReadPrint(this IScanner<Token> scanner, out IStatement result)
        {
            if (scanner.TryReadToken(Token.Print))
            {
                var expressions = scanner.ReadExpressions();

                if (scanner.TryReadToken(Token.Semicolon))
                    result = new Print(expressions);
                else
                    result = new PrintLine(expressions);

                return true;
            }

            result = null;
            return false;
        }

        public static bool TryReadInput(this IScanner<Token> scanner, out IStatement result)
        {
            if (scanner.TryReadToken(Token.Input))
            {
                string prompt;
                if (scanner.TryReadToken(Token.String, out prompt))
                {
                    scanner.ReadToken(Token.Comma);
                    result = new Input(prompt, scanner.ReadLValue());
                    return true;
                }

                result = new Input(scanner.ReadLValue());
                return true;
            }

            result = null;
            return false;
        }

        public static bool TryReadList(this IScanner<Token> scanner, out IStatement result)
        {
            if (scanner.TryReadToken(Token.List))
            {
                result = new List();
                return true;
            }

            result = null;
            return false;
        }
    }
}