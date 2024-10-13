using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateCustomDataStructures
{
	public class CustomStack
	{
		private const int DefaultCapacity = 4;

		private int[] _buffer;

		public CustomStack()
			: this(DefaultCapacity)
		{

		}

		public CustomStack(int capacity)
		{
			this._buffer = new int[capacity];
		}

		public int Count { get; private set; }

		public void Push(int element)
		{
			if (this.Count == this._buffer.Length)
			{
				this.Grow();
			}

			this._buffer[this.Count++] = element;
		}

		public int Pop()
		{
			this.ValidateNotEmpty();

			int removedElement = this._buffer[this.Count - 1];
			this._buffer[--this.Count] = default;

			return removedElement;
		}

		public int Peek()
		{
			this.ValidateNotEmpty();
			return this._buffer[this.Count - 1];
		}

		private void Grow()
		{
			int[] newBuffer = new int[this._buffer.Length * 2];
			Array.Copy(this._buffer, newBuffer, this.Count);

			this._buffer = newBuffer;
		}

		private void ValidateNotEmpty()
		{
			if (this.Count == 0) throw new InvalidOperationException("Empty");
		}
	}
}
