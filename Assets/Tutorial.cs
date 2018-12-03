using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{

    public GameObject controller;

    Text thisText;

    public string[] tutorialText;
    public bool[] loadNextAutomatically;

    public GameObject arrow;

    public Vector2[] arrowLoc;
    public Vector3[] arrowRotation;

    public int tutLoc;

    public bool acceptingInput;

    public GameObject shop, ads, stats;

    public void Start()
    {
        thisText = GetComponent<Text>();
        thisText.text = tutorialText[0];
        controller.GetComponent<Stats>().maxTutorial = tutorialText.Length;
        shop.GetComponent<Button>().interactable = false;
        ads.GetComponent<Button>().interactable = false;
        stats.GetComponent<Button>().interactable = false;
    }

    void Update()
    {
        if (acceptingInput && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Next();
        }
        if (tutLoc == 14)
        {
            controller.GetComponent<Stats>().money += 500;
            ads.GetComponent<AdManager>().tutCompleted = true;
            shop.GetComponent<Button>().interactable = true;
            ads.GetComponent<Button>().interactable = true;
            stats.GetComponent<Button>().interactable = true;
            transform.parent.gameObject.SetActive(false);
        }
    }

    public void Next()
    {

        tutLoc++;

        controller.GetComponent<Stats>().tutorialStage = tutLoc;
        thisText.text = tutorialText[tutLoc];

        if (!loadNextAutomatically[tutLoc])
            acceptingInput = false;

        arrow.transform.localPosition = arrowLoc[tutLoc];
        arrow.transform.eulerAngles = arrowRotation[tutLoc];

        if (tutLoc == 2)
        {
            ads.GetComponent<Button>().interactable = true;
        }

        if (tutLoc == 3)
        {
            ads.GetComponent<Button>().interactable = false;
            acceptingInput = true;
        }

        if (tutLoc == 4)
        {
            arrow.SetActive(true);
            shop.GetComponent<Button>().interactable = true;
        }

        if (tutLoc == 5)
        {
            shop.GetComponent<Button>().interactable = false;
        }

        if (tutLoc == 6)
        {
            shop.GetComponent<Button>().interactable = true;
        }

        if (tutLoc == 7)
        {
            shop.GetComponent<Button>().interactable = false;
        }

        if (tutLoc == 15)
        {
            transform.parent.gameObject.SetActive(true);
            ads.GetComponent<AdManager>().CloseAd();
        }

        if (tutLoc == 16)
        {
            transform.parent.gameObject.SetActive(false);
        }

         if (tutLoc == 17)
        {
            transform.parent.gameObject.SetActive(true);
            shop.GetComponent<Button>().interactable = false;
            ads.GetComponent<AdManager>().CloseAd();
        }

        if (tutLoc == 18)
        {
            transform.parent.gameObject.SetActive(false);
        }

    }

}