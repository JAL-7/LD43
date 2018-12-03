using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{

    public float movementPerSecond, timeBetweenPeople, lastPerson;

    void Start()
    {
        lastPerson = -100;
    }

    public void Update()
    {
        foreach (Transform child in transform)
        {
            child.position = new Vector3(child.position.x, child.position.y, child.position.z + movementPerSecond * Time.deltaTime);
        }
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0 * Time.time, 0.1f * Time.time);
    }

}