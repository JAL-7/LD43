using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour
{

    public GameObject bloodPrefab;
    public Material[] bloods;
    GameObject temp;

    bool fired;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Killer" && !fired)
        {
            fired = true;

            A();

            StartCoroutine(Deactivate());

        }
    }

    [ContextMenu("A")]
    public void A()
    {
            temp = GameObject.Find("Controller");
            int moneyMade = Random.Range(1, 6);

            temp.GetComponent<Stats>().peopleKilled++;
            temp.GetComponent<Stats>().money += moneyMade;
            temp.GetComponent<Stats>().revenue += moneyMade;

            ParticleSystem ps = GetComponent<ParticleSystem>();
            var shape = ps.shape;
            shape.shapeType = ParticleSystemShapeType.MeshRenderer;
            shape.meshRenderer = GetComponent<MeshRenderer>();

            ParticleSystem moneyEffect = transform.GetChild(0).GetComponent<ParticleSystem>();
            var emission = moneyEffect.emission;

            emission.SetBursts(
                new ParticleSystem.Burst[]
                {
                    new ParticleSystem.Burst(0, moneyMade)
                }
            );

            ps.Play();
            moneyEffect.Play();
    }
    IEnumerator Deactivate()
    {

        yield return new WaitForSeconds(0.05f);

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;

        temp = Instantiate(bloodPrefab, new Vector3(transform.position.x + Random.Range(-2.2f, 2.2f), 0.015f, transform.position.z + Random.Range(-2.2f, 2.2f)), Random.rotation);

        if (temp.transform.position.x < 0)
            temp.transform.position = new Vector3(temp.transform.position.x + 1.5f, temp.transform.position.y, temp.transform.transform.position.z);

        temp.transform.eulerAngles = new Vector3(90, transform.rotation.y, transform.rotation.z);
        temp.GetComponent<Renderer>().material = bloods[Random.Range(0, 5)];

        yield return new WaitForSeconds(0.95f);

        Destroy(gameObject);

    }

}