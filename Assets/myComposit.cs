using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.InputSystem.Layouts;
#if UNITY_EDITOR
using UnityEditor;
#endif


public struct myCompositData
{
	public bool Press;
	public int PressCount;
	public Vector2 Position;
	public Vector2 Delta;
	public Vector2 Radius;

	public bool Tap;
	//public UnityEngine.InputSystem.TouchPhase Phase;
	public Vector2 StartPosition;
	public double StartTime;

	public Vector2 Scroll;
}


#if UNITY_EDITOR
[InitializeOnLoad]
#endif
public class myComposit : InputBindingComposite<myCompositData>
{
	

#if UNITY_EDITOR
	static myComposit()
	{
		Initialize();
	}
#endif


	[RuntimeInitializeOnLoadMethod]
	private static void Initialize()
	{
		InputSystem.RegisterBindingComposite<myComposit>();
	}

	[InputControl(layout = "Button")]
	public int press;
	[InputControl(layout = "Integer")]
	public int pressCount;
	[InputControl(layout = "Vector2")]
	public int position;
	[InputControl(layout = "Vector2")]
	public int delta;
	[InputControl(layout = "Vector2")]
	public int radius;

	[InputControl(layout = "Button")]
	public int tap;
	//[InputControl(layout = "TouchPhase")]
	//public int phase;
	[InputControl(layout = "Vector2")]
	public int startPosition;
	[InputControl(layout = "Double")]
	public int startTime;

	[InputControl(layout = "Vector2")]
	public int scroll;

	

	public override myCompositData ReadValue(ref InputBindingCompositeContext context)
	{
		
		var press = context.ReadValueAsButton(this.press);
		var pressCount = context.ReadValue<int>(this.pressCount);
		var position = context.ReadValue<Vector2, Vector2MagnitudeComparer>(this.position);
		var delta = context.ReadValue<Vector2, Vector2MagnitudeComparer>(this.delta);
		var radius = context.ReadValue<Vector2, Vector2MagnitudeComparer>(this.radius);

		var tap = context.ReadValueAsButton(this.tap);
		//var phase = context.ReadValue<UnityEngine.InputSystem.TouchPhase>(this.phase);
		var startPosition = context.ReadValue<Vector2, Vector2MagnitudeComparer>(this.startPosition);
		var startTime = context.ReadValue<double>(this.startTime);

		var scroll = context.ReadValue<Vector2, Vector2MagnitudeComparer>(this.scroll);

		return new myCompositData()
		{
			Press = press,
			PressCount = pressCount,
			Position = position,
			Delta = delta,
			Radius = radius,

			Tap = tap,
			StartPosition = startPosition,
			StartTime = startTime,

			Scroll = scroll

		};
	}
}
