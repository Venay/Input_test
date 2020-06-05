using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

namespace Testing.InputDebugger
{
	public class InputDebugger : MonoBehaviour
	{
		PointerInput pointerInput;
		public Text inputText;
		public Text deviceText;
		public Text buttonText;

		private void Awake()
		{
			pointerInput = new PointerInput();
			pointerInput.General.Pointer.performed += ctx => OnPointer(ctx.ReadValue<myCompositData>());
			pointerInput.General.Pointer.canceled += ctx => OnPointer(ctx.ReadValue<myCompositData>());

			string text = "";

			foreach (var S in InputSystem.devices)
			{
				text += S.device + " : " + S.enabled + "  \n";
			}
			deviceText.text = text;
		}

		private void OnEnable() => pointerInput.Enable();
		private void OnDisable() => pointerInput.Disable();



		public void OnPointer(myCompositData data)
		{

			string n = "\n";
			string Press = "Press: " + data.Press.ToString() + n;
			string PressCount = "Press Count: " + data.PressCount + n;
			string Position = "Position: " + data.Position + n;
			string Delta = "Delta: " + data.Delta + n;
			string Radius = "Radius: " + data.Radius + n;

			string Tap = "Tap: " + data.Tap + n;
			string StartPosition = "Start Position: " + data.StartPosition + n;
			string StartTime = "Start Time: " + data.StartTime + n;

			string Scroll = "Scroll: " + data.Scroll + n;

			inputText.text = Time.time + n + Press + PressCount + Position + Delta + Radius + n + Tap + StartPosition + StartTime + n + Scroll;

		}

		public void OnButtonPress() => buttonText.text = "Pressed at:\n" + Time.time;
	}


}
