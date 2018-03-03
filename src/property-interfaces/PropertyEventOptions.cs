using System;
using System.Collections.Generic;
using UnityEngine.Events;


namespace BeatThat
{
	/// <summary>
	/// Specifies desired event behaviour when setting a property that has an onChanged event.
	/// 
	/// <c>SendOnChange</c> - sent the change event only if the new value is different from prev value
	/// <c>Disable</c> - don't sent the changed event
	/// <c>Force</c> - force send the change event
	/// </summary>
	public enum PropertyEventOptions 
	{
		SendOnChange = 0, 
		Disable = 1,
		Force = 2
	}

	public static class PropertyEventOptionsExt
	{
		public static void Set<T>(this PropertyEventOptions opt, ref T prop, T val, Action changeEvent)
		{
			if(EqualityComparer<T>.Default.Equals(prop, val) && opt != PropertyEventOptions.Force) {
				return;
			}

			prop = val;

			if(opt != PropertyEventOptions.Disable) {
				changeEvent();
			}
		}

		public static void Set<T>(this PropertyEventOptions opt, ref T prop, T val, UnityEvent changeEvent)
		{
			if(EqualityComparer<T>.Default.Equals(prop, val) && opt != PropertyEventOptions.Force) {
				return;
			}

			prop = val;

			if(opt != PropertyEventOptions.Disable) {
				changeEvent.Invoke ();
			}
		}
	}
}
