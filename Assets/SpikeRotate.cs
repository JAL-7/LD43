using UnityEngine;

public class SpikeRotate : MonoBehaviour
{

    public Vector3 rotationDirection;
    public float speed;

    public void Update()
    {
        transform.Rotate(rotationDirection * Time.deltaTime * speed);
    }

}