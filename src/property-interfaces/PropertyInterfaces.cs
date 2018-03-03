using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace BeatThat
{
	public interface IHasTexture : IHasValue<Texture> {}

	public interface IEditsTexture : IHasTexture, IHasValueChangedEvent {}

	public interface IHasMaterial : IHasValue<Material> {}

	public interface IHasText : IHasValue<string> {}

	public interface IHasColor : IHasValue<Color> {}

	public interface IHasColorBlock : IHasValue<ColorBlock> {}
		
	public interface IHasTextInput : IHasText
	{
		void ActivateInput();
	}

	public interface IHasValue<T>
	{
		T value { get; set; }
	}

	public interface IHasFloat : IHasValue<float> {}

	public interface IHasInt : IHasValue<int> {}

	public interface IHasLong : IHasValue<long> {}

	public interface IHasBool : IHasValue<bool> {}

	public interface IHasDateTime : IHasValue<DateTime> {}

	public interface IHasClick 
	{
		bool interactable { get; set; }

		UnityEvent onClicked { get; }
		[Obsolete("use UnityEvent onValueChanged")]event Action Clicked; // TODO: replace with UnityEvent
	}

	public interface IHasValueObjChanged
	{
		UnityEvent onValueObjChanged { get; }
	}

	public interface IHasValueChangedEvent<T>
	{
		UnityEvent<T> onValueChanged { get; }
	}

	public interface IHasValueChangedEvent 
	{
		UnityEvent onValueChanged { get; }
	}

	public interface IHasBounds
	{
		Bounds bounds { get; }
	}

	public interface IHasRect 
	{
		Rect rect { get; }
	}

	public interface IHasUVRect 
	{
		Rect uvRect { get; set; }
	}

	public interface IEditsBool : IHasBool, IHasValueChangedEvent
	{
	}


	public interface IDrive 
	{
		object GetDrivenObject();

		/// <summary>
		/// Used when loop is detected
		/// </summary>
		/// <returns><c>true</c>, if driven was cleared, <c>false</c> otherwise.</returns>
		bool ClearDriven();
	}

	/// <summary>
	/// A way for a driver to make discoverable that it drives another component, 
	/// e.g. CurvesFloat implements IDrive<IHasFloat>
	/// </summary>
	public interface IDrive<T> : IDrive where T : class
	{
		T driven { get; }
	}

}