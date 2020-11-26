using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GOL.Reactive
{
	[Serializable]
	public class ReactiveProperty<T>
	{
		private T _value;
		private Action<T> _action;

		public T Value
		{
			get => _value;
			set
			{
				_value = value;
				_action.Invoke(value);
			}
		}

		public ReactiveProperty(T value = default)
		{
			_value = value;
		}

		public void Subscribe(Action<T> action)
		{
			_action += action;
		}
	}
}
