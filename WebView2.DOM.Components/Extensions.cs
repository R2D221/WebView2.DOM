using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using WebView2.DOM.Components;
using static System.Collections.Specialized.NotifyCollectionChangedAction;

//public static class Extensions
//{
//	public static ObservedCollection<TSource> Observe<TSource>(this INotifyCollectionChanged source)
//		where TSource : notnull
//	{
//		return new ObservedCollection<TSource>(Unsafe.As<INotifyingCollection<TSource>>(source));
//	}
//}

namespace System.Collections.Specialized
{
	public interface INotifyingCollection<T> : IReadOnlyCollection<T>, INotifyCollectionChanged { }
	public interface INotifyingList<T> : INotifyingCollection<T>, IReadOnlyList<T> { }
}

//namespace WebView2.DOM.Components
//{
//	public sealed class ObservedCollection<TSource>
//		where TSource : notnull
//	{
//		private readonly INotifyingCollection<TSource> source;

//		public ObservedCollection(INotifyingCollection<TSource> source)
//		{
//			this.source = source;
//		}

//		public INotifyingCollection<TResult> Select<TResult>(Func<TSource, TResult> selector)
//		{
//			return source switch
//			{
//				IReadOnlyList<TSource> => new ProjectedNotifyingList<TSource, TResult>(Unsafe.As<INotifyingList<TSource>>(source), selector),
//				_ => new ProjectedNotifyingSet<TSource, TResult>(source, selector),
//			};
//		}
//	}

//	internal sealed class ProjectedNotifyingList<TSource, TResult> : INotifyingList<TResult>
//		where TSource : notnull
//	{
//		private readonly INotifyingList<TSource> source;
//		private readonly Func<TSource, TResult> selector;
//		private List<TResult> result;

//		public ProjectedNotifyingList(INotifyingList<TSource> source, Func<TSource, TResult> selector)
//		{
//			this.source = source;
//			this.selector = selector;
//			this.result = Enumerable.Select(source, selector).ToList();

//			this.source.CollectionChanged += Source_CollectionChanged;
//		}

//		public TResult this[int index] => result[index];

//		public int Count => result.Count;

//		public event NotifyCollectionChangedEventHandler? CollectionChanged;

//		public IEnumerator<TResult> GetEnumerator() => result.GetEnumerator();

//		IEnumerator IEnumerable.GetEnumerator() => result.GetEnumerator();

//		private void Source_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
//		{
//			switch ((e.Action, e.NewItems, e.OldItems))
//			{
//			case (Add, {/*notnull*/} e_NewItems, _):
//			{
//				var newItems =
//					e_NewItems.Cast<TSource>()
//					.Select(selector)
//					.ToImmutableArray()
//					;

//				result.InsertRange(e.NewStartingIndex, newItems);

//				CollectionChanged?.Invoke(this, new
//				(
//					action: Add,
//					changedItems: newItems,
//					startingIndex: e.NewStartingIndex
//				));

//				break;
//			}
//			case (Remove, _, {/*notnull*/} e_OldItems):
//			{
//				var oldItemsCount = e_OldItems.Count;

//				var oldItems =
//					result.ToImmutableArray().AsSpan()
//					[e.OldStartingIndex..(e.OldStartingIndex + oldItemsCount)]
//					.ToArray()
//					.ToImmutableArray();

//				result.RemoveRange(e.OldStartingIndex, oldItemsCount);

//				CollectionChanged?.Invoke(this, new
//				(
//					action: Remove,
//					changedItems: oldItems,
//					startingIndex: e.OldStartingIndex
//				));

//				break;
//			}
//			case (Replace, {/*notnull*/} e_NewItems, {/*notnull*/} e_OldItems):
//			{
//				var oldItemsCount = e_OldItems.Count;

//				var oldItems =
//					result.ToImmutableArray().AsSpan()
//					[e.OldStartingIndex..(e.OldStartingIndex + oldItemsCount)]
//					.ToArray()
//					.ToImmutableArray();

//				result.RemoveRange(e.OldStartingIndex, oldItemsCount);

//				var newItems =
//					e_NewItems.Cast<TSource>()
//					.Select(selector)
//					.ToImmutableArray()
//					;

//				result.InsertRange(e.NewStartingIndex, newItems);

//				CollectionChanged?.Invoke(this, new
//				(
//					action: Replace,
//					newItems: newItems,
//					oldItems: oldItems,
//					startingIndex: e.OldStartingIndex
//				));

//				break;
//			}
//			case (Move, {/*notnull*/} e_NewItems, {/*notnull*/} e_OldItems):
//			{
//				var movedItemsCount = e_OldItems.Count;

//				var movedItems =
//					result.ToImmutableArray().AsSpan()
//					[e.OldStartingIndex..(e.OldStartingIndex + movedItemsCount)]
//					.ToArray()
//					.ToImmutableArray();

//				result.RemoveRange(e.OldStartingIndex, movedItemsCount);
//				result.InsertRange(e.NewStartingIndex, movedItems);

//				CollectionChanged?.Invoke(this, new
//				(
//					action: Move,
//					changedItems: movedItems,
//					index: e.NewStartingIndex,
//					oldIndex: e.OldStartingIndex
//				));

//				break;
//			}
//			case (Reset, _, _):
//			{
//				result =
//					Enumerable.Select(source, selector)
//					.ToList();

//				CollectionChanged?.Invoke(this, new(action: Reset));

//				break;
//			}
//			}
//		}
//	}

//	internal sealed class ProjectedNotifyingSet<TSource, TResult> : INotifyingCollection<TResult>
//		where TSource : notnull
//	{
//		private readonly INotifyingCollection<TSource> source;
//		private readonly Func<TSource, TResult> selector;
//		private readonly Dictionary<TSource, TResult> projections = new();

//		public ProjectedNotifyingSet(INotifyingCollection<TSource> source, Func<TSource, TResult> selector)
//		{
//			this.source = source;
//			this.selector = selector;

//			this.source.CollectionChanged += Source_CollectionChanged;
//		}

//		public int Count => source.Count;

//		public event NotifyCollectionChangedEventHandler? CollectionChanged;

//		private TResult ProjectAndAdd(TSource sourceItem)
//		{
//			if (projections.TryGetValue(sourceItem, out var resultItem) is false)
//			{
//				resultItem = selector(sourceItem);
//				projections[sourceItem] = resultItem;
//			}

//			return resultItem;
//		}

//		private TResult ProjectAndRemove(TSource sourceItem)
//		{
//			if (projections.TryGetValue(sourceItem, out var resultItem))
//			{
//				_ = projections.Remove(sourceItem);
//				return resultItem;
//			}
//			else
//			{
//				return selector(sourceItem);
//			}
//		}

//		public IEnumerator<TResult> GetEnumerator() => source.Select(ProjectAndAdd).GetEnumerator();

//		IEnumerator IEnumerable.GetEnumerator() => source.Select(ProjectAndAdd).GetEnumerator();

//		private void Source_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
//		{
//			switch ((e.Action, e.NewItems, e.OldItems))
//			{
//			case (Add, {/*notnull*/} e_NewItems, _):
//			{
//				CollectionChanged?.Invoke(this, new
//				(
//					action: Add,
//					changedItems: e_NewItems.Cast<TSource>().Select(ProjectAndAdd).ToImmutableArray(),
//					startingIndex: e.NewStartingIndex
//				));

//				break;
//			}
//			case (Remove, _, {/*notnull*/} e_OldItems):
//			{
//				CollectionChanged?.Invoke(this, new
//				(
//					action: Remove,
//					changedItems: e_OldItems.Cast<TSource>().Select(ProjectAndRemove).ToImmutableArray(),
//					startingIndex: e.OldStartingIndex
//				));

//				break;
//			}
//			case (Replace, {/*notnull*/} e_NewItems, {/*notnull*/} e_OldItems):
//			{
//				var oldItems = e_OldItems.Cast<TSource>().Select(ProjectAndRemove).ToImmutableArray();
//				var newItems = e_NewItems.Cast<TSource>().Select(ProjectAndAdd).ToImmutableArray();

//				CollectionChanged?.Invoke(this, new
//				(
//					action: Replace,
//					newItems: newItems,
//					oldItems: oldItems,
//					startingIndex: e.OldStartingIndex
//				));

//				break;
//			}
//			case (Move, {/*notnull*/} e_NewItems, {/*notnull*/} e_OldItems):
//			{
//				CollectionChanged?.Invoke(this, new
//				(
//					action: Move,
//					changedItems: e_NewItems.Cast<TSource>().Select(ProjectAndAdd).ToImmutableArray(),
//					index: e.NewStartingIndex,
//					oldIndex: e.OldStartingIndex
//				));

//				break;
//			}
//			case (Reset, _, _):
//			{
//				CollectionChanged?.Invoke(this, new(action: Reset));

//				break;
//			}
//			}
//		}
//	}
//}
