using UnityEngine;
using UnityEngine.UI;

public class CustomCam : MonoBehaviour
{

    public InputField inputField;

    void Update()
    {

        if (inputField.isFocused == true)
            return;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = transform.position + (transform.forward * Time.deltaTime * 3.5f);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = transform.position + (-transform.right * Time.deltaTime * 3.5f);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = transform.position + (-transform.forward * Time.deltaTime * 3.5f);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = transform.position + (transform.right * Time.deltaTime * 3.5f);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 80);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(-Vector3.up * Time.deltaTime * 80);
        }
        if (Input.GetKey(KeyCode.X))
        {
            transform.position = transform.position + (transform.up * Time.deltaTime * 1.4f);
        }
        if (Input.GetKey(KeyCode.Z))
        {
            transform.position = transform.position + (-transform.up * Time.deltaTime * 1.4f);
        }
    }


}