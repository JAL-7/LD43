using UnityEngine;
using System.Collections;

public class Slamdown : MonoBehaviour
{

    public Vector3 wantedMovement;
    public float timeToMove, timeAtBottom, frequency;

    public bool colliderTriggered;

    float timeOfLast;

    public void ActivateTest()
    {
        if (timeOfLast.TimeHasPassed(frequency) && colliderTriggered)
        {
            colliderTriggered = false;
            StartCoroutine(Activate());
        }
    }

    IEnumerator Activate()
    {
        timeOfLast = Time.time;
        while (!timeOfLast.TimeHasPassed(timeToMove) || transform.position.y > 2.1f)
        {
            transform.position = transform.position + (wantedMovement * Time.deltaTime / timeToMove);
            yield return null;
        }
        yield return new WaitForSeconds(timeAtBottom);
        while (!timeOfLast.TimeHasPassed(timeToMove + timeToMove + timeAtBottom) || transform.position.y < 3.4f)
        {
            transform.position = transform.position - (wantedMovement * Time.deltaTime / timeToMove);
            yield return null;
        }
        yield break;
    }

}