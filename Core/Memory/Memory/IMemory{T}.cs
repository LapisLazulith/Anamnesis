﻿// Concept Matrix 3.
// Licensed under the MIT license.

namespace ConceptMatrix.Memory
{
	using System;
	using System.ComponentModel;
	using ConceptMatrix.Memory.Offsets;

	public interface IMemory<T> : IMemory
	{
		event ValueChangedEventHandler<T> ValueChanged;
		event DisposingEventHandler Disposing;

		/// <summary>
		/// Gets a value used to identify this memory when logging.
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Gets or sets the value in memory.
		/// </summary>
		T Value { get; set; }

		/// <summary>
		/// Sets the value in memory.
		/// </summary>
		/// <param name="value">the value to write.</param>
		/// <param name="immediate">should this value be pushed into process memory immediately.</param>
		void SetValue(T value, bool immediate = false);
	}

	public interface IMemory : INotifyPropertyChanged, IDisposable
	{
		bool Active { get; }
		void UpdateBaseOffset(IBaseMemoryOffset newBaseOffset);
	}

	#pragma warning disable SA1201
	public delegate void ValueChangedEventHandler<T>(object sender, T value);
	public delegate void DisposingEventHandler();
}
