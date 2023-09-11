using Nito.Mvvm.CalculatedProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WebView2.DOM.Components.Test
{
	abstract class ViewModelBase : INotifyPropertyChanged
	{
		protected readonly PropertyHelper properties;

		protected ViewModelBase()
		{
			properties = new(RaisePropertyChanged);
		}

		public event PropertyChangedEventHandler? PropertyChanged;

		protected virtual void RaisePropertyChanged(PropertyChangedEventArgs args) =>
			PropertyChanged?.Invoke(this, args);

		/// <inheritdoc cref="PropertyHelper.Calculated{T}(Func{T}, string)"/>
		protected T Calculated<T>(Func<T> calculateValue, [CallerMemberName] string? propertyName = null) =>
			properties.Calculated(calculateValue, propertyName ?? throw new ArgumentNullException(nameof(propertyName)));

		/// <inheritdoc cref="PropertyHelper.Get{T}(Func{T}, IEqualityComparer{T}?, string)"/>
		protected T Get<T>(Func<T> calculateInitialValue, IEqualityComparer<T>? comparer = null, [CallerMemberName] string? propertyName = null) =>
			properties.Get(calculateInitialValue, comparer, propertyName ?? throw new ArgumentNullException(nameof(propertyName)));

		/// <inheritdoc cref="PropertyHelper.Get{T}(T, IEqualityComparer{T}?, string)"/>
		protected T Get<T>(T initialValue, IEqualityComparer<T>? comparer = null, [CallerMemberName] string? propertyName = null) =>
			properties.Get(initialValue, comparer, propertyName ?? throw new ArgumentNullException(nameof(propertyName)));

		/// <inheritdoc cref="PropertyHelper.Set{T}(T, IEqualityComparer{T}?, string)"/>
		protected void Set<T>(T value, IEqualityComparer<T>? comparer = null, [CallerMemberName] string? propertyName = null) =>
			properties.Set(value, comparer, propertyName ?? throw new ArgumentNullException(nameof(propertyName)));
	}
}