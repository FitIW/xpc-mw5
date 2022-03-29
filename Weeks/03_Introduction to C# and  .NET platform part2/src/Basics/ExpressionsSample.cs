using System;
using System.Linq.Expressions;

namespace Basics
{
    public class ExpressionsSample : ISample
    {
        public void Run()
        {
            Sample1();
            Sample2();
        }

        private static void Sample1()
        {
            Expression<Func<int, bool>> expr = num => num < 5;

            // Compiling the expression tree into a delegate.  
            Func<int, bool> result = expr.Compile();

            // Invoking the delegate and writing the result to the console.  
            Console.WriteLine(result(4));

            // Prints True.  

            // You can also use simplified syntax  
            // to compile and run an expression tree.  
            // The following line can replace two previous statements.  
            Console.WriteLine(expr.Compile()(4));
        }

        private static void Sample2()
        {
            var blockExpr = Expression.Block(
                Expression.Call(
                    null,
                    typeof(Console).GetMethod("Write", new[] { typeof(string) }),
                    Expression.Constant("Hello ")
                ),
                Expression.Call(
                    null,
                    typeof(Console).GetMethod("WriteLine", new[] { typeof(string) }),
                    Expression.Constant("World!")
                ),
                Expression.Constant(42)
            );

            Console.WriteLine("The result of executing the expression tree:");
            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.
            var expression = Expression.Lambda<Func<int>>(blockExpr);
            var compiledExpression = expression.Compile();
            var result = compiledExpression();
            // Hello World!

            // Print out the expressions from the block expression.
            Console.WriteLine("The expressions from the block expression:");
            foreach (var expr in blockExpr.Expressions)
            {
                Console.WriteLine(expr.ToString());
                // Write("Hello ")
                // WriteLine("World!")
                // 42
            }

            // Print out the result of the tree execution.
            Console.WriteLine("The return value of the block expression:");
            Console.WriteLine(result);
            // 42
        }
    }
}