namespace WebView2.DOM.Collections
{
	public interface IList<T> :
		System.Collections.Generic.IList<T>,
		ICollection<T>,
		IReadOnlyList<T>
	{
		new T this[int index] { get; set; }
		
		T System.Collections.Generic.IList<T>.this[int index]
		{
			get => this[index];
			set => this[index] = value;
		}

		T System.Collections.Generic.IReadOnlyList<T>.this[int index] => this[index];
	}
}
