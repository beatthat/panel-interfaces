using UnityEngine;

namespace BeatThat
{
	public interface Syncable 
	{
		void Sync();
	}

	public static class SyncableExt
	{
		public static void SyncChildren(this Component c, bool includeInactive = false)
		{
			c.gameObject.SyncChildren(includeInactive);
		}

		public static void SyncChildren(this GameObject go, bool includeInactive = false)
		{
			using(var syncables = ListPool<Syncable>.Get()) {
				foreach(var s in syncables) {
					if(!includeInactive && (s as Component).gameObject.activeInHierarchy == false) {
						continue;
					}
					s.Sync();
				}
			}
		}
	}
}
