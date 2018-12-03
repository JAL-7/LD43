using UnityEngine;

public class Shop : MonoBehaviour
{

    public GameObject controller;

    public GameObject[] appearObjects;

    public int type;

    public Tutorial theTutorial;
    public GameObject arrow;

    public GameObject statsPanel, adPanel;

    public int price;

    bool tutFired, tutFired2;

    public void ShopPressed()
    {
//if (!theTutorial.acceptingInput)
            foreach (GameObject go in appearObjects)
            {
                go.SetActive(!go.activeSelf);
            }
            arrow.SetActive(false);
            statsPanel.SetActive(false);
            adPanel.SetActive(false);
    }

    public void ShopOff()
    {
            foreach (GameObject go in appearObjects)
            {
                go.SetActive(false);
            }
    }

    public void ImagePressed()
    {
        // foreach (GameObject go in appearObjects)
        // {
        //     go.SetActive(false);
        // }

        if (controller.GetComponent<Stats>().money < price)
            return;

        controller.GetComponent<World>().AddWorld(type);
        controller.GetComponent<Stats>().money -= price;

        if (!tutFired && price == 50)
        {
            tutFired = true;
            ShopPressed();
            theTutorial.acceptingInput = true;
            theTutorial.Next();
        }
        else if (!tutFired2 && price == 50)
        {
            tutFired2 = true;
            ShopPressed();
            theTutorial.acceptingInput = true;
            theTutorial.Next();
        }


    }

}