using System;
using System.Collections;
using System.Linq.Expressions;
using static DelegateBindings.DelegateBinder;

namespace WebView2.DOM.Components;

public sealed class TwoWayAttributeBuilder<T> : IEnumerable
{
	private static (Func<T>, Action<T>) CompileGetterAndSetter(Expression<Func<T>> expr)
	{
		var getter = expr.Compile();

		var parameter = Expression.Parameter(typeof(T));

		var setter =
			Expression.Lambda<Action<T>>
			(
				Expression.Assign(expr.Body, parameter),
				parameter
			)
			.Compile();

		return (getter, setter);
	}

	private readonly (bool, T)? constantValue;
	private readonly Action<T>? setter;
	private readonly Func<T>? getterBack;
	private Action<T>? setterBack;

	private TwoWayAttributeBuilder(T value)
	{
		this.constantValue = (true, value);
	}

	public TwoWayAttributeBuilder(Expression<Func<T>> expr, Action<EventHandler<Event>> attachEventHandler)
	{
		(getterBack, setter) = CompileGetterAndSetter(expr);

		attachEventHandler(handler);
	}

	public static implicit operator TwoWayAttributeBuilder<T>(T value) => new(value);

	public T GetConstantValue() =>
		constantValue switch
		{
			(true, var x) => x,
			_ => throw new InvalidOperationException(),
		};

	public void Add(Expression<Func<T>> expr)
	{
		if (setter is null) { throw new InvalidOperationException(); }

		(var getter, setterBack) = CompileGetterAndSetter(expr);

		_ = Bind(() => setter(getter()));
	}

	public void handler(object? sender, Event args)
	{
		if (setterBack is null) { throw new InvalidOperationException(); }
		if (getterBack is null) { throw new InvalidOperationException(); }

		setterBack(getterBack());
	}

	IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
}
