using System.Runtime.InteropServices;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

[StructLayout(LayoutKind.Explicit)]
public struct PowerMateReport : IInputStateTypeInfo
{
    public FourCC format => new ('H', 'I', 'D');

    [FieldOffset(1)]
    [InputControl(name = "Button", layout = "Integer", format = "BYTE", bit = 0)]
    public byte Button;

    [FieldOffset(2)]
    [InputControl(name = "KnobDisplacement", layout = "Integer", format = "BYTE")]
    public byte KnobDisplacement;
}
