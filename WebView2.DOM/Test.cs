using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebView2.DOM
{
	internal abstract class MyMixin<T> : IReadOnlyCollection<T>, ICollection
	{
		protected abstract int MyMixin_Count();

		public int Count => MyMixin_Count();

		int IReadOnlyCollection<T>.Count => MyMixin_Count();

		int ICollection.Count => MyMixin_Count();

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => null!;

		void ICollection.CopyTo(Array array, int index)
		{
			throw new NotImplementedException();
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			throw new System.NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new System.NotImplementedException();
		}
	}

	class IdMixin
	{
		public Guid Id { get; set; } = Guid.NewGuid();
	}

	//[Mixin.Mixin(typeof(IdMixin))]
	//public partial class mytestobject
	//{

	//}




	//[Mixin.Mixin(typeof(MyMixin<string>))]
	//public partial class TestObject
	//{
	//	protected partial int MyMixin_Count() => 5;
	//}
}
