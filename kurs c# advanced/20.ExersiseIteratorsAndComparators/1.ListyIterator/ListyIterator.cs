using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>	
    {
        private readonly List<T> _list;
        private int _index;

        public ListyIterator(List<T> list)
        {
            this._list = list ?? throw new ArgumentNullException(nameof(list));
        }


        public bool Move()
		{
			if (this.HasNext())
			{
				this._index++;
				return true;
			}
			return false;
		}

		public bool HasNext()
		{
			return this._index + 1 < this._list.Count;
		}

		public void Print()
		{
			if (this._index >= this._list.Count)
			{
				throw new InvalidOperationException("Invalid Operation!");
			}

			Console.WriteLine(this._list[this._index]);
        }

		public IEnumerator<T> GetEnumerator()
		{
			foreach (T element in this._list)
			{
				yield return element;
			}
		}

		IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
			
	}
}
