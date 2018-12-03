using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class People : MonoBehaviour
{

    public int peoplePerSecond;
    public int backlog;

    public Text backlogText;

    public GameObject person;

    public List<Transform> conveyorBelts;
    List<Transform> shuffledList;

    ConveyorBelt conveyorBelt;

    GameObject newestPerson;

    IEnumerator Start()
    {
        while (true)
        {
            if (peoplePerSecond > 0.1)
            {
                backlog++;
                    
                yield return new WaitForSeconds(1 / peoplePerSecond);
            }
            yield return null;
        }
    }

    public void Update()
    {
        shuffledList = conveyorBelts.OrderBy(x => Random.value).ToList();
        foreach (Transform conveyor in shuffledList)
        {
            if (backlog > 0)
            {
                conveyorBelt = conveyor.GetComponent<ConveyorBelt>();
                if (conveyorBelt.lastPerson.TimeHasPassed(conveyorBelt.timeBetweenPeople))
                {
                    backlog--;
                    conveyorBelt.lastPerson = Time.time;
                    newestPerson = Instantiate(person, conveyor);
                    newestPerson.transform.localScale = new Vector3(120, 32, 19);
                    newestPerson.transform.localPosition = new Vector3(0, 12f, -5.5f);
                }
            }
        }

        backlogText.text = "Backlog: " + backlog;
    }

}