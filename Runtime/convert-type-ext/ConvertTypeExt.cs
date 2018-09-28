using System;
using UnityEngine;

namespace BeatThat.ConvertTypeExt
{
    public static class Ext
	{
		/// <summary>
		/// Ext method for <c>object</c> that (safely) tries to convert to any provided type.
		/// </summary>
		/// <returns><c>true</c>, if conversion succeeded, <c>false</c> otherwise.</returns>
		/// <param name="o">The 'this' object for the extension method</param>
		/// <param name="result">The converted result as an out param</param>
		/// <typeparam name="T">Target type for the conversion</typeparam>
		public static bool TryConvertTo<T>(this object o, out T result)
		{
            if (o == null) {
                result = default(T);
                return true;
            }

			if(o is T) {
				result = (T)o;
				return true;
			}

			if(o is IConvertible) {
				try {
					result = (T)Convert.ChangeType(o, typeof(T));
					return true;
				}
				#pragma warning disable 0168
				catch(Exception e) {
					#if UNITY_EDITOR || DEBUG_UNSTRIP
					Debug.LogError("[" + Time.frameCount + "] invalid convert to type " + typeof(T) 
						+ " for object with type " 
						+ ((o != null)? o.GetType().ToString(): "null"));
					#endif
				}
				#pragma warning restore 0168
			}

			try {
				result = (T)o;
				return true;
			}
			#pragma warning disable 0168
			catch(Exception e) {
				#if UNITY_EDITOR || DEBUG_UNSTRIP
				Debug.LogError("[" + Time.frameCount + "] invalid cast to listener type " + typeof(T) 
					+ " for object with type " 
					+ ((o != null)? o.GetType().ToString(): "null"));
				#endif
			}
			#pragma warning restore 0168

			result = default(T);
			return false;
		}

	}
}
