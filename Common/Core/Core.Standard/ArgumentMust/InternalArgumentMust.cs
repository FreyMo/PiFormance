namespace Core.Standard.ArgumentMust
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using Extensions;
	using Predicates;

	internal static class InternalArgumentMust
	{
		[DebuggerHidden]
		public static void NotBeNull<T>(Func<T> argumentFunc) where T : class
		{
			if (argumentFunc().IsNull())
			{
				var nullArgument = argumentFunc.GetParameter(GenericTypePredicates.IsNull);
				throw new ArgumentNullException(nullArgument.Name);
			}
		}

		[DebuggerHidden]
		public static void NotBeEmpty<T>(Func<IEnumerable<T>> argumentFunc)
		{
			if (EnumerablePredicates.IsEmpty(argumentFunc()))
			{
				var argument = argumentFunc.GetParameter(EnumerablePredicates.IsEmpty);
				throw new ArgumentException($"The sequence '{argument.Name}' must not be empty.", argument.Name);
			}
		}

		[DebuggerHidden]
		public static void NotContainNull<T>(Func<IEnumerable<T>> argumentFunc)
		{
			if (EnumerablePredicates.ContainsNull(argumentFunc()))
			{
				var argument = argumentFunc.GetParameter(EnumerablePredicates.ContainsNull);
				throw new ArgumentException($"No item in the sequence '{argument.Name}' may be null.", argument.Name);
			}
		}

		[DebuggerHidden]
		public static void BeGreater<T>(Func<T> argumentFunc, T lowerLimit) where T : IComparable
		{
			if (ComparablePredicates.IsLessOrEqual(argumentFunc(), lowerLimit))
			{
				var argument = argumentFunc.GetParameter(p => ComparablePredicates.IsLessOrEqual(p, lowerLimit));
				throw new ArgumentException($"The argument '{argument.Name}' must not be less than or equal to {lowerLimit}.", argument.Name);
			}
		}

		[DebuggerHidden]
		public static void BeGreaterOrEqual<T>(Func<T> argumentFunc, T lowerLimit) where T : IComparable
		{
			if (ComparablePredicates.IsLessThan(argumentFunc(), lowerLimit))
			{
				var argument = argumentFunc.GetParameter(p => ComparablePredicates.IsLessThan(p, lowerLimit));
				throw new ArgumentException($"The argument '{argument.Name}' must not be less than {lowerLimit}.", argument.Name);
			}
		}
		
		[DebuggerHidden]
		public static void BeLess<T>(Func<T> argumentFunc, T upperLimit) where T : IComparable
		{
			if (ComparablePredicates.IsGreaterOrEqual(argumentFunc(), upperLimit))
			{
				var argument = argumentFunc.GetParameter(p => ComparablePredicates.IsGreaterOrEqual(p, upperLimit));
				throw new ArgumentException($"The argument '{argument.Name}' must not be greater than or equal to {upperLimit}.", argument.Name);
			}
		}

		[DebuggerHidden]
		public static void BeLessOrEqual<T>(Func<T> argumentFunc, T upperLimit) where T : IComparable
		{
			if (ComparablePredicates.IsGreaterThan(argumentFunc(), upperLimit))
			{
				var argument = argumentFunc.GetParameter(p => ComparablePredicates.IsGreaterThan(p, upperLimit));
				throw new ArgumentException($"The argument '{argument.Name}' must not be greater than {upperLimit}.", argument.Name);
			}
		}

		[DebuggerHidden]
		public static void BeEnum(Func<Type> argumentFunc)
		{
			if (!argumentFunc().IsEnum)
			{
				var argument = argumentFunc.GetParameter(p => !p.IsEnum);
				throw new ArgumentException($"The argument '{argument.Name}' was not of the requested Type enum.", argument.Name);
			}
		}

		[DebuggerHidden]
		public static void BeOfType<T>(Func<object> argumentFunc)
		{
			if (!argumentFunc().Is<T>())
			{
				var argument = argumentFunc.GetParameter(p => !p.Is<T>());
				throw new ArgumentException($"The argument '{argument.Name}' was not of the requested Type '{typeof(T)}'.", argument.Name);
			}
		}

		[DebuggerHidden]
		public static void InheritFrom<T>(Func<Type> argumentFunc)
		{
			if (!typeof(T).IsAssignableFrom(argumentFunc()))
			{
				var argument = argumentFunc.GetParameter(p => !typeof(T).IsAssignableFrom(p));
				throw new ArgumentException($"The argument '{argument.Name}' does not inherit from the requested Type '{typeof(T)}'.", argument.Name);
			}
		}

		[DebuggerHidden]
		public static void NotBeNullOrWhitespace(Func<string> argumentFunc)
		{
			if (string.IsNullOrWhiteSpace(argumentFunc()))
			{
				var argument = argumentFunc.GetParameter(string.IsNullOrWhiteSpace);
				throw new ArgumentException($"The argument '{argument.Name}' must not be null or whitespace.", argument.Name);
			}
		}
	}
}