using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateCustomDataStructures
{
	public class CustomList
	{
		private const int DefaultCpacity = 4;

		private int[] _buffer;

		public CustomList()
			: this(DefaultCpacity)
		{

		}

		public CustomList(int capacity)
		{
			if (capacity <= 0) throw new ArgumentOutOfRangeException("Must be positive int.", nameof(capacity));

			this._buffer = new int[capacity];
		}

		public int Count { get; private set; }
		public int this[int index]
		{
			get
			{
				this.ValidateIndex(index);
				return this._buffer[index];
			}

			set
			{
				this.ValidateIndex(index);
				this._buffer[index] = value;
			}
		}

		public void Add(int element)
		{
			if (this.Count == this._buffer.Length)
			{
				this.Grow();
			}

			this._buffer[this.Count] = element;
			this.Count++;
		}

		public void Insert(int index, int element)
		{
			if (index == this.Count)
			{
				this.Add(element);
			}
			else
			{
				this.ValidateIndex(index);
				if (this.Count == this._buffer.Length)
				{
					this.Grow();
				}

				for (int i = this.Count - 1; i >= index; i--)
				{
					this._buffer[i + 1] = this._buffer[i];
				}
			}
		}

		public int RemoveAt(int index)
		{
			this.ValidateIndex(index);

			int removedElement = this._buffer[index];

			for (int i = index + 1; i < this.Count; i++)
			{
				this._buffer[i - 1] = this._buffer[i];
			}

			this._buffer[this.Count - 1] = default;

			this.Count--;

			return removedElement;
		}
		public bool Contains(int element)
		{
			for (int i = 0; i < this.Count; i++)
			{
				if (this._buffer[i] == element)
				{
					return true;
				}
			}

			return false;
		}

		public void Swap(int firstIndex, int secondIndex)
		{
			this.ValidateIndex(firstIndex);
			this.ValidateIndex(secondIndex);

			if (firstIndex != secondIndex)
			{
				int swap = this._buffer[firstIndex];
				this._buffer[firstIndex] = this._buffer[secondIndex];
				this._buffer[secondIndex] = swap;
			}
		}

		private void Grow()
		{
			int[] newBuffer = new int[this._buffer.Length * 2];
			Array.Copy(this._buffer, newBuffer, this.Count);

			this._buffer = newBuffer;
		}

		private void ValidateIndex(int index)
		{
			if (index < 0 || index >= this.Count)
			{
				throw new IndexOutOfRangeException($"Index out of range[0, {this.Count}]");
			}
		}
	}
}
