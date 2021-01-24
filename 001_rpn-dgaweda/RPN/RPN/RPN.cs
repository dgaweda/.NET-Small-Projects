using System;
using System.Collections.Generic;

namespace RPNCalulator {
	public class RPN {

			private Stack<int> _operators;
		Dictionary<string, Func<int, int, int>> _operationFunction;

		public int EvalRPN(string input)
		{
			_operationFunction = new Dictionary<string, Func<int, int, int>>
			{
				["+"] = (fst, snd) => (fst + snd),
				["-"] = (fst, snd) => (fst - snd),
				["*"] = (fst, snd) => (fst * snd),
				["/"] = (fst, snd) => (fst / snd),
				["|"] = (fst, _) => Absolute(fst)
			};
			_operators = new Stack<int>();

			var splitInput = input.Split(' ');
			foreach (var op in splitInput)
			{
				if (IsNumber(op))
					_operators.Push(Int32.Parse(op));
				else if (IsSingleOperator(op))
				{
					var value = _operators.Pop();
					_operators.Push(_operationFunction[op](value, 0));
				}
				else if (IsOperator(op))
				{
					var num1 = _operators.Pop();
					var num2 = _operators.Pop();
					_operators.Push(_operationFunction[op](num1, num2));
				}
			}
			var result = _operators.Pop();
			if (_operators.IsEmpty)
			{
				return result;
			}
			throw new InvalidOperationException();

		}

		private bool IsNumber(String input) => Int32.TryParse(input, out _);

		private bool IsOperator(String input) =>
		input.Equals("+") || input.Equals("-") ||
		input.Equals("*") || input.Equals("/");

		private Func<int, int, int> Operation(String input) =>
		(x, y) =>
		(
			(input.Equals("+") ? x + y :
				(input.Equals("*") ? x * y : 
					(input.Equals("-") ? x - y :
						(input.Equals("/") ? x / y : int.MinValue)))
			)
		);

		private static int Absolute(int value)
		{
			if (value <= 0)
			{
				return value * (-1);
			}
			else
				return value;
		}

		private static bool IsSingleOperator(string input)
		{
			return input.Equals("|");
		}
	}
}