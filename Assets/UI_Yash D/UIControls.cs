using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class UIControls : MonoBehaviour
{
    public void Quit()
    {
        #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
        #else
                Application.Quit(); // original code to quit Unity player
        #endif
    }
}
