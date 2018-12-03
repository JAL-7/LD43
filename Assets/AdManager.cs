using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AdManager : MonoBehaviour
{

    public GameObject sloganFeedbackParent;
    public Text sloganFeedback;
    public Color[] sloganResultColors;

    public List<string> slogans;

    public GameObject adPanel;

    public GameObject arrow;

    public Tutorial theTutorial;

    public GameObject stats, shop;

    public bool tutCompleted;

    public GameObject slogansPanel;

    public Text slogan1, slogan2, slogan3;

    public int price, peoplePerSecond;

    public GameObject controller;

    bool firstSlogan;

    public bool canBuyAds;

    void Start()
    {
        firstSlogan = canBuyAds = true;
    }

    public void OpenAd()
    {
        //if (!theTutorial.acceptingInput)
        //{
        stats.SetActive(false);
        shop.GetComponent<Shop>().ShopOff();
        arrow.SetActive(false);
        adPanel.SetActive(!adPanel.activeSelf);

        //}
    }

    public void CloseAd()
    {
        //if (!theTutorial.acceptingInput)
        //{
        stats.SetActive(false);
        shop.GetComponent<Shop>().ShopOff();
        arrow.SetActive(false);
        adPanel.SetActive(false);

        //}
    }

    public void OpenSlogans()
    {
        slogansPanel.SetActive(true);
        List<string> originalSlogans = slogans.ToList();
        int a = Random.Range(0, slogans.Count);
        string sloganOne = "";
        string sloganTwo = "";
        try
        {
            sloganOne = slogans[a];
        }
        catch
        {
            Debug.Log(a);
        }
        slogans.Remove(sloganOne);
        int b = Random.Range(0, slogans.Count);
        try
        {
            sloganTwo = slogans[b];
        }
        catch
        {
            Debug.Log(b);
        }
        slogans.Remove(sloganTwo);
        string sloganThree = slogans[Random.Range(0, slogans.Count)];
        slogans = originalSlogans;
        slogan1.text = sloganOne;
        slogan2.text = sloganTwo;
        slogan3.text = sloganThree;
    }

    public void SloganPurchase()
    {

        controller.GetComponent<Stats>().money -= price;

        slogansPanel.transform.GetChild(0).gameObject.SetActive(true);
        slogansPanel.transform.GetChild(1).gameObject.SetActive(false);
        slogansPanel.transform.GetChild(2).gameObject.SetActive(false);
        slogansPanel.SetActive(false);

        bool? judgement = JudgeSlogan();

        if (judgement == true)
        {
            controller.GetComponent<People>().peoplePerSecond += (int)(peoplePerSecond * 0.9f);
            sloganFeedback.text = "Good Slogan";
            sloganFeedback.color = sloganResultColors[0];
        }
        if (judgement == null)
        {
            controller.GetComponent<People>().peoplePerSecond += (int)(peoplePerSecond * 0.6f);
            sloganFeedback.text = "Mediocre Slogan";
            sloganFeedback.color = sloganResultColors[1];
        }
        if (judgement == false)
        {
            controller.GetComponent<People>().peoplePerSecond += (int)(peoplePerSecond * 0.3f);
            sloganFeedback.text = "Bad Slogan";
            sloganFeedback.color = sloganResultColors[2];
        }

        StartCoroutine(SloganAppearence());

    }

    IEnumerator SloganAppearence()
    {
        sloganFeedbackParent.SetActive(true);
        canBuyAds = false;
        yield return new WaitForSeconds(1.5f);
        canBuyAds = true;
        sloganFeedbackParent.SetActive(false);
    }

    bool? JudgeSlogan()
    {

        if (firstSlogan)
        {
            firstSlogan = false;
            return true;
        }
        else
        {
            int randomResult = Random.Range(0, 3);
            switch (randomResult)
            {
                case 0:
                    return true;
                case 1:
                    return null;
                default:
                    return false;
            }
        }

    }

}