using UnityEngine;
using BeatThat.Anim;

namespace BeatThat
{
	/// <summary>
	/// Delegate callback used to script some incremental behavior on every frame/update of a transition.
	/// @see PrepareTransition(PanelTransition t, OnTransitionFrameDelegate onFrameDel)
	/// </summary>
	public delegate void OnTransitionFrameDelegate(float transitionTime, float frameTime);

	/// <summary>
	/// A <c>Panel</c> (generally of ui elements) that can be transitioned in and out as a unit.
	/// </summary>
	public interface Panel
	{
		Transform transform { get; }

		Transition PrepareTransition(PanelTransition t, OnTransitionFrameDelegate onFrameDel = null);

		/// <summary>
		/// Starts one of the panel's transitions. 
		/// The most common transitions are PanelTransition.IN and PanelTransition.OUT,
		/// and generally those should exist for any panel,
		/// but a panel may optionally support any set of custom PanelTransition s
		/// </summary>
		void StartTransition(PanelTransition t);

		/// <summary>
		/// Bring in the panel immediately, e.g. put the panel into it's active spot without any animated transition
		/// Bring in is generally runs PanelTransition.IN and fast forwards to the end of the transition.
		/// </summary>
		void BringInImmediate();

		/// <summary>
		/// Dismiss the panel immediately, e.g. put the panel into it's out state immediately.
		/// Dismiss generally runs PanelTransition.IN and fast forwards to the end of the transition.
		/// </summary>
		void DismissImmediate();
	}
}
