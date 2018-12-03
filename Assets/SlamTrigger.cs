using UnityEngine;

public class SlamTrigger : MonoBehaviour
{

    void OnTriggerEnter()
    {
        transform.parent.GetComponent<Slamdown>().colliderTriggered = true;
        transform.parent.GetComponent<Slamdown>().ActivateTest();
    }


}