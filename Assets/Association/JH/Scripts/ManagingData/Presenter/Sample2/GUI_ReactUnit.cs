using UnityEngine;

public class GUI_ReactUnit : MonoBehaviour
{

    [ContextMenu("sad")]
    public void func1_void()
    {
        Debug.Log("func1_nonParam");
    }

    [ContextMenu("sad2")]
    public void func2_int(int input)
    {
        Debug.Log("func2_intParam : " + input);
    }
}
