using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCatcher : MonoBehaviour
{
    /// <summary>
    /// references to parent dustbin (Dustbin(Parent) -> GarbageCatcher(Child))
    /// </summary>
    [SerializeField] Dustbin dustbin;
    float testForce = 30f;
     

    /// <summary>
    /// called when a collision is detected
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    { 

        if (collision.gameObject.tag.Equals("Garbage"))
        {
            bool isGarbageAccepted = dustbin.GotGarbage(collision.gameObject.GetComponent<GarbageItem>());
            if (isGarbageAccepted)
            {
                collision.gameObject.SetActive(false);
            }
            else
            {
                collision.gameObject.GetComponent<Rigidbody>().AddForce(dustbin.transform.forward * testForce);
            }
        }
    }
     

}
