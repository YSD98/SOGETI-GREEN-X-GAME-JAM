using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dustbin : MonoBehaviour
{
    /// <summary>
    /// dustbin color would decide the type of waste it can accept
    /// </summary>
    [SerializeField] string dustbinColor;
    

    /// <summary>
    /// it gets triggered whenever a dustbin receives an "Garbage" item
    /// </summary>
    /// <param name="garbageReceived"></param>
    /// <returns></returns>
    public bool GotGarbage(GarbageItem garbageReceived)
    {
        bool isValid = false; 

        if (garbageReceived.destinationDustbinColor.Equals(dustbinColor))
        {
            isValid = true;
            GameManager.mInstance.ChangeScore(50, "Add");
        }
        else
        {
            isValid = false;
            GameManager.mInstance.ChangeScore(50, "Minus");
        }

        return isValid;
    }
}
