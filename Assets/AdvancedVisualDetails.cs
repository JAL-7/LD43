using UnityEngine;
using UnityEngine.PostProcessing;
using System.Collections;

public class AdvancedVisualDetails : MonoBehaviour
{

    public GameObject water, blood, cameraMain;
    public PostProcessingProfile[] ppProfiles;
    public Tutorial theTut;

    bool tutFired;

    int a;

    public void Update()
    {

        a = (GetComponent<World>().activeIndustry + 1) / 3;
        a = Mathf.Clamp(a, 0, 4);
        cameraMain.GetComponent<PostProcessingBehaviour>().profile = ppProfiles[a];

        if (GetComponent<World>().activeIndustry > 0)
        {
            water.transform.position = new Vector3(3000 + GetComponent<World>().activeIndustry * 3, water.transform.position.y, water.transform.position.z);
            blood.transform.position = new Vector3(-3000 + GetComponent<World>().activeIndustry * 3, water.transform.position.y, water.transform.position.z);
        }

        if (a == 4 && !tutFired)
        {
            tutFired = true;
            theTut.Next();
            StartCoroutine(InputAllowedSoon());
        }

    }

    IEnumerator InputAllowedSoon()
    {
        yield return new WaitForSeconds(1.8f);
        theTut.acceptingInput = true;
    }


}