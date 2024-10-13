﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Froggy
{
	public class Lake : IEnumerable<int>
	{
		private readonly int[] _stones;

		public Lake(int[] stones)
		{
			this._stones = stones ?? throw new ArgumentNullException(nameof(stones));
		}

		public IEnumerator<int> GetEnumerator()
		{
			for (int i = 0; i < this._stones.Length; i+=2)
			{
				yield return this._stones[i];
			}

			int reverseStart = this._stones.Length - (this._stones.Length % 2) - 1;	

			for (int i = reverseStart; i > 0; i -= 2)
			{
				yield return this._stones[i];
			}
		}

		IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

	}
}
