using UnityEngine;

public class PurchaseAds : MonoBehaviour
{

    public AdManager adManager;

    public GameObject controller;
    public int price;
    public int peoplePerSecond;

    public Tutorial tutorial;

    bool tutorialFired;

    public void Purchase()
    {
        if (!adManager.canBuyAds)
            return;
        if (!adManager.tutCompleted)
        {
            if (controller.GetComponent<Stats>().money > price)
            {
                controller.GetComponent<Stats>().money -= price;
                controller.GetComponent<People>().peoplePerSecond += peoplePerSecond;
            }
            if (price == 40 && !tutorialFired)
            {
                tutorialFired = true;
                transform.parent.parent.gameObject.SetActive(false);
                tutorial.Next();
            }
        }
        else
        {
            if (controller.GetComponent<Stats>().money > price)
            {
                adManager.price = price;
                adManager.peoplePerSecond = peoplePerSecond;
                adManager.OpenSlogans();
            }
        }
    }

}