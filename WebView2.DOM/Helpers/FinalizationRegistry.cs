using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;

namespace WebView2.DOM
{
	/// <summary>
	/// A FinalizationRegistry object lets you request a callback when an object is garbage-collected.
	/// </summary>
	/// <remarks>
	/// Class based on JS FinalizationRegistry:
	/// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/FinalizationRegistry
	/// </remarks>
	internal class FinalizationRegistry<TObject, THeldValue>
		where TObject : class
	{
		private readonly ConditionalWeakTable<TObject, FinalizerCallback<THeldValue>>
			callbacks = new();

		private readonly Action<THeldValue> action;

		public FinalizationRegistry(Action<THeldValue> action)
		{
			this.action = action;
		}

		public void Register(TObject obj, THeldValue value)
		{
			callbacks.Add(obj, new(action, value));
		}

		public void Unregister(TObject obj)
		{
			if (callbacks.TryGetValue(obj, out var callback))
			{
				_ = callbacks.Remove(obj);
				callback.Inactivate();
			}
		}
	}

	/// <summary>
	/// A FinalizationRegistry object lets you request a callback when an object is garbage-collected.
	/// </summary>
	/// <remarks>
	/// Class based on JS FinalizationRegistry:
	/// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/FinalizationRegistry
	/// </remarks>
	internal class FinalizationRegistry<TObject, THeldValue, TUnregisterToken>
		where TObject : class
		where TUnregisterToken : class
	{
		private readonly ConditionalWeakTable<TObject, FinalizerCallback<THeldValue>>
			callbacks = new();
		private readonly ConcurrentDictionary<TUnregisterToken, ImmutableHashSet<WeakReference<TObject>>>
			tokenDict = new();

		private readonly Action<THeldValue> action;

		public FinalizationRegistry(Action<THeldValue> action)
		{
			this.action = action;
		}

		private void Collect()
		{
			var toBeRemoved = (
				from entry in tokenDict
				from weakRef in entry.Value
				where weakRef.TryGetTarget(out _) == false
				group weakRef by entry.Key)
				.ToImmutableArray();

			foreach (var weakRefs in toBeRemoved)
			{
				var token = weakRefs.Key;

				// based on https://stackoverflow.com/a/72063401/1858296

				while (true)
				{
					if (!tokenDict.TryGetValue(token, out var existing))
					{
						break;
					}

					var updated = existing.Except(weakRefs);
					if (updated == existing)
					{
						break;
					}

					if (updated.IsEmpty)
					{
						var wasRemoved =
							((ICollection<KeyValuePair<TUnregisterToken, ImmutableHashSet<WeakReference<TObject>>>>)tokenDict)
							.Remove(new KeyValuePair<TUnregisterToken, ImmutableHashSet<WeakReference<TObject>>>(token, existing));

						if (wasRemoved)
						{
							break;
						}
					}
					else
					{
						if (tokenDict.TryUpdate(token, updated, existing))
						{
							break;
						}
					}
					// We lost the race to either TryRemove or TryUpdate. Try again.
				}
			}
		}

		public void Register(TObject obj, THeldValue value, TUnregisterToken token)
		{
			Collect();

			callbacks.Add(obj, new(action, value));

			_ = tokenDict.AddOrUpdate(token,
				_ => ImmutableHashSet<WeakReference<TObject>>.Empty.Add(new(obj)),
				(_, existing) => existing.Add(new(obj)));
		}

		public void Unregister(TUnregisterToken token)
		{
			Collect();

			ImmutableHashSet<WeakReference<TObject>>? existing;

			// based on https://stackoverflow.com/a/72063401/1858296

			while (true)
			{
				if (!tokenDict.TryGetValue(token, out existing))
				{
					return;
				}

				var wasRemoved =
					((ICollection<KeyValuePair<TUnregisterToken, ImmutableHashSet<WeakReference<TObject>>>>)tokenDict)
					.Remove(new KeyValuePair<TUnregisterToken, ImmutableHashSet<WeakReference<TObject>>>(token, existing));

				if (wasRemoved)
				{
					break;
				}

				// We lost the race to either TryRemove or TryUpdate. Try again.
			}

			if (existing is null) { return; }

			foreach (var weakRef in existing)
			{
				if (weakRef.TryGetTarget(out var target))
				{
					if (callbacks.TryGetValue(target, out var callback))
					{
						_ = callbacks.Remove(target);
						callback.Inactivate();
					}
				}
			}
		}
	}

	internal class FinalizerCallback<THeldValue>
	{
		private bool active;
		private readonly Action<THeldValue> action;
		private readonly THeldValue value;

		public FinalizerCallback(Action<THeldValue> action, THeldValue value)
		{
			this.active = true;
			this.action = action;
			this.value = value;
		}

		public void Inactivate() => active = false;

		~FinalizerCallback()
		{
			try
			{
				if (!active) { return; }

				action(value);
			}
			catch
			{
				// Intentionally swallow exception
			}
		}
	}
}
