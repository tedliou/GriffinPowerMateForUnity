using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;

#if UNITY_EDITOR
[InitializeOnLoad]
#endif
[InputControlLayout(stateType = typeof(PowerMateReport))]
public class PowerMateDevice : InputDevice, IInputStateCallbackReceiver
{
    public IntegerControl button { get; protected set; }
    public IntegerControl knobDisplacement { get; protected set; }

    static PowerMateDevice()
    {
        Initialize();
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        InputSystem.RegisterLayout<PowerMateDevice>(
            matches: new InputDeviceMatcher()
                .WithInterface("HID")
                .WithProduct("Griffin PowerMate"));
    }

    protected override void FinishSetup()
    {
        button = TryGetChildControl<IntegerControl>("Button");
        knobDisplacement = TryGetChildControl<IntegerControl>("KnobDisplacement");
    }

    public void OnNextUpdate()
    {
        InputState.Change(knobDisplacement, 0);
    }

    public void OnStateEvent(InputEventPtr eventPtr)
    {
        InputState.Change(this, eventPtr);
    }

    public bool GetStateOffsetForEvent(InputControl control, InputEventPtr eventPtr, ref uint offset)
    {
        return false;
    }
}