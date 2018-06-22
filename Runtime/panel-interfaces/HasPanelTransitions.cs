using BeatThat.Transitions;

namespace BeatThat.Panels
{
    public interface HasPanelTransitions 
	{
		PanelTransitionState panelState { get; }

		/// <summary>
		///	Ensures at the time of transition execution that the panel is either already in or it will transition in.
		/// </summary>
		/// <returns>The transition in.</returns>
		Transition EnsureTransitionIn();

		/// <summary>
		/// Prepares the transition in but does not run.
		/// </summary>
		/// <returns> 
		/// The transition in.
		/// </returns>
		Transition PrepareTransitionIn();

		/// <summary>
		/// Prepares the transition out but does not run.
		/// </summary>
		Transition PrepareTransitionOut();

		/// <summary>
		/// Like PrepareTransitionOut with an addition 'Unbind' call, really for presenters.
		/// </summary>
		Transition PrepareTransitionOut(bool unbind);
		
		/// <summary>
		/// Transitions out the panel
		/// </summary>
		/// <param name='unbind'>
		/// If true, unbinds/cleansup
		/// </param>
		void TransitionOut(bool unbind);
		
		/// <summary>
		/// Transitions in the panel
		/// </summary>
		void TransitionIn();
		
		/// <summary>
		/// If panel is running any transition,
		/// forces that transition to complete immediately
		/// </summary>
		void ForceCompleteActiveTransitions();
	}

	public static class HasPanelTransitionsExt
	{
		public static bool IsInOrTransitioningIn(this HasPanelTransitions hpt)
		{
			return hpt.panelState == PanelTransitionState.IN 
			|| hpt.panelState == PanelTransitionState.TRANSITIONING_IN;
		}

		public static bool IsOutOrTransitioningOut(this HasPanelTransitions hpt)
		{
			return (hpt.panelState == PanelTransitionState.OUT 
				|| hpt.panelState == PanelTransitionState.TRANSITIONING_OUT);
		}
	}
}

