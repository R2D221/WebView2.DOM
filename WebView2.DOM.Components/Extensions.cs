using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using static System.Collections.Specialized.NotifyCollectionChangedAction;

public static class Extensions
{
	public static INotifyCollectionChanged<TResult> Select<TSource, TResult>(this ObservableCollection<TSource> source, Func<TSource, TResult> selector)
	{
		return new CalculatedCollection<TSource, TResult>(source, selector);
	}
}

public interface INotifyCollectionChanged<T> : IReadOnlyList<T>, INotifyCollectionChanged { }

public sealed class CalculatedCollection<TSource, TResult> : INotifyCollectionChanged<TResult>
{
	private readonly ObservableCollection<TSource> source;
	private readonly Func<TSource, TResult> selector;
	private ImmutableArray<TResult> result;

	public CalculatedCollection(ObservableCollection<TSource> source, Func<TSource, TResult> selector)
	{
		this.source = source;
		this.selector = selector;
		this.result = Enumerable.Select(source, selector).ToImmutableArray();

		this.source.CollectionChanged += Source_CollectionChanged;
	}

	public int Count => result.Length;
	public TResult this[int index] => result[index];

	private void Source_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		switch ((e.Action, e.NewItems, e.OldItems))
		{
		case (Add, {/*notnull*/} e_newItems, _):
		{
			var newItems =
				e_newItems.Cast<TSource>()
				.Select(selector)
				.ToImmutableArray()
				;

			result = result.InsertRange(e.NewStartingIndex, newItems);

			CollectionChanged?.Invoke(this, new
			(
				action: Add,
				changedItems: newItems,
				startingIndex: e.NewStartingIndex
			));

			break;
		}
		case (Remove, _, {/*notnull*/} e_OldItems):
		{
			var oldItemsCount = e_OldItems.Count;

			var oldItems =
				result[e.OldStartingIndex..(e.OldStartingIndex + oldItemsCount)];

			result = result.RemoveRange(e.OldStartingIndex, oldItemsCount);

			CollectionChanged?.Invoke(this, new
			(
				action: Remove,
				changedItems: oldItems,
				startingIndex: e.OldStartingIndex
			));

			break;
		}
		case (Replace, {/*notnull*/} e_newItems, {/*notnull*/} e_OldItems):
		{
			var oldItemsCount = e_OldItems.Count;

			var oldItems =
				result[e.OldStartingIndex..(e.OldStartingIndex + oldItemsCount)];

			result = result.RemoveRange(e.OldStartingIndex, oldItemsCount);

			var newItems =
				e_newItems.Cast<TSource>()
				.Select(selector)
				.ToImmutableArray()
				;

			result = result.InsertRange(e.NewStartingIndex, newItems);

			CollectionChanged?.Invoke(this, new
			(
				action: Replace,
				newItems: newItems,
				oldItems: oldItems,
				startingIndex: e.OldStartingIndex
			));

			break;
		}
		case (Move, {/*notnull*/} e_newItems, {/*notnull*/} e_OldItems):
		{
			var movedItemsCount = e_OldItems.Count;

			var movedItems =
				result[e.OldStartingIndex..(e.OldStartingIndex + movedItemsCount)];

			result = result.RemoveRange(e.OldStartingIndex, movedItemsCount);
			result = result.InsertRange(e.NewStartingIndex, movedItems);

			CollectionChanged?.Invoke(this, new
			(
				action: Move,
				changedItems: movedItems,
				index: e.NewStartingIndex,
				oldIndex: e.OldStartingIndex
			));

			break;
		}
		case (Reset, _, _):
		{
			result =
				Enumerable.Select(source, selector)
				.ToImmutableArray();

			CollectionChanged?.Invoke(this, new(action: Reset));

			break;
		}
		}
	}

	public event NotifyCollectionChangedEventHandler? CollectionChanged;
	public IEnumerator<TResult> GetEnumerator() => ((IEnumerable<TResult>)result).GetEnumerator();
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
