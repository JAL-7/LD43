using UnityEngine;

public class World : MonoBehaviour
{

    public GameObject controller;

    public Tutorial theTut;

    public int activeIndustry;

    public GameObject nature;

    public GameObject industrialPlane;

    public GameObject[] otherObjects;

    public GameObject temp;

    public void AddWorld(int type)
    {

        Destroy(nature.transform.GetChild(0).gameObject);

        temp = Instantiate(industrialPlane, new Vector3(1.5f + 3 * activeIndustry, 0, 5), Quaternion.identity);
        temp.SetActive(true);
        temp = Instantiate(otherObjects[type], new Vector3(1.5f + 3 * activeIndustry, 0, 0), Quaternion.identity);
        temp.SetActive(true);
        GetComponent<People>().conveyorBelts.Add(temp.transform.GetChild(0));

        switch (type)
        {
            case 0:
                controller.GetComponent<Stats>().fallSpikes++;
                break;
            case 1:
                controller.GetComponent<Stats>().rotatingSpikes++;
                break;
            case 2:
                controller.GetComponent<Stats>().crushers++;
                break;
        }

        activeIndustry++;

        if (activeIndustry >= 41)
        {
            theTut.Next();
        }

    }


}