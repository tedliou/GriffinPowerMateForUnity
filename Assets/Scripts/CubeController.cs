using UnityEngine;
using UnityEngine.InputSystem;

public class CubeController : MonoBehaviour
{
    public void OnClick(InputAction.CallbackContext ctx)
    {
        var button = ctx.ReadValue<int>();
        if (button == 1)
        {
            transform.localScale = Vector3.one * 2;
        }
        else
        {
            transform.localScale = Vector3.one;
        }
    }

    public void OnRotate(InputAction.CallbackContext ctx)
    {
        var rotate = ctx.ReadValue<int>();
        if (rotate > 128)
        {
            rotate -= 256;
        }

        transform.Rotate(0, 0, -rotate * .01f * 360);
    }
}
