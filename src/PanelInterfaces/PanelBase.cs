using UnityEngine;
using BeatThat.UI;
using BeatThat.Anim;

namespace BeatThat
{
	public abstract class PanelBase : MonoBehaviour, Panel
	{
		public Transition PrepareTransition(PanelTransition t, OnTransitionFrameDelegate onFrameDel = null)
		{
			return this._panel.PrepareTransition(t, onFrameDel);
		}

		public void StartTransition(PanelTransition t)
		{
			this._panel.StartTransition(t);
		}

		public void BringInImmediate()
		{
			this._panel.BringInImmediate();
		}

		public void DismissImmediate()
		{
			this._panel.DismissImmediate();
		}
		
		abstract protected Panel _panel { get; }
		
	}
}
