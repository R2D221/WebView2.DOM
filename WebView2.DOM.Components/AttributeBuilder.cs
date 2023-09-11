using System;
using System.Collections;
using static DelegateBindings.DelegateBinder;

namespace WebView2.DOM.Components;

public sealed class AttributeBuilder<T> : IEnumerable
{
	private readonly (bool, T)? constantValue;
	private readonly Action<T>? setter;

	private AttributeBuilder(T value)
	{
		this.constantValue = (true, value);
	}

	public AttributeBuilder(Action<T> setter)
	{
		this.setter = setter;
	}

	public static implicit operator AttributeBuilder<T>(T value) => new(value);

	public T GetConstantValue() =>
		constantValue switch
		{
			(true, var x) => x,
			_ => throw new InvalidOperationException(),
		};

	public void Add(Func<T> getter)
	{
		if (setter is null) { throw new InvalidOperationException(); }
		_ = Bind(() => setter(getter()));
	}

	IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
}
