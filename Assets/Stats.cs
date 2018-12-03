using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{

    public Tutorial theTutorial;

    public GameObject stats;

    public GameObject shop, ads;

    public int money, revenue, peopleKilled, fallSpikes, rotatingSpikes, crushers, tutorialStage, maxTutorial;

    [Space(10)]

    public Text mainMoney;
    public Text tutText, moneyText, revenueText, peopleKilledText, fallSpikesText, rotatingSpikesText, crushersText, quote;

    public void Update()
    {
        mainMoney.text = "$" + money;
    }

    public void DisplayStats()
    {
        // if (!theTutorial.acceptingInput)
        //{
            shop.GetComponent<Shop>().ShopOff();
            ads.SetActive(false);
            stats.SetActive(!stats.activeSelf);
            tutText.text = "Story Completion: " + (tutorialStage - 1) + "/" + (maxTutorial - 2);
            moneyText.text = "Money: " + money;
            revenueText.text = "Revenue: " + revenue;
            peopleKilledText.text = "People Killed: " + peopleKilled;
            fallSpikesText.text = "Falling Spike Machines: " + fallSpikes;
            rotatingSpikesText.text = "Rotating Gear Machines: " + rotatingSpikes;
            crushersText.text = "Rotating Spike Machines: " + crushers;
            quote.text = GenerateQuote();
//        }
    }

    string GenerateQuote()
    {
        if (fallSpikes + rotatingSpikes + crushers < 6)
        {
            return "You gotta pump these numbers up. These are rookie numbers.";
        }
        if (fallSpikes + rotatingSpikes + crushers < 12)
        {
            return "More sacrifice, more money.";
        }
        else
        {
            return "Buisness is booming!";
        }
    }

}