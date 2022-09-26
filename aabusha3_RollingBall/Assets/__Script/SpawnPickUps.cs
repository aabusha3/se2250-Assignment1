using System.Collections;
using UnityEngine;

public class SpawnPickUps : MonoBehaviour
{
    public GameObject cubePickUpPrefab;
    public GameObject cylinderPickUpPrefab;
    public GameObject capsulePickUpPrefab;
    public float timeTillNextSpawn = 1f;

    public Transform parent;

    private float spawnX = 0f, spawnZ = 0f;

    void Start()
    {
        FindObjectOfType<PlayerMovement>().enabled = true;
        parent = GameObject.FindGameObjectWithTag("PickUps").GetComponent<Transform>();
        SpawnMore();
        StartCoroutine(CheckPickUpCount());
    }
    void SpawnMore()
    {
        FindObjectOfType<PlayerMovement>().enabled = true;
        while (GameObject.FindGameObjectsWithTag("CubePickUp").Length + GameObject.FindGameObjectsWithTag("CylinderPickUp").Length + GameObject.FindGameObjectsWithTag("CapsulePickUp").Length < 12)
            SpawnPickUp();
            //Invoke("SpawnPickUp", timeTillNextSpawn);
    }

    void SpawnPickUp()
    {
        int whichToSpawn = Random.Range(0, 7);
        GameObject temp;

        if (whichToSpawn == 0 || whichToSpawn == 1 || whichToSpawn == 2)
            temp = Instantiate(cubePickUpPrefab) as GameObject;
        else if (whichToSpawn == 3 || whichToSpawn == 4)
            temp = Instantiate(cylinderPickUpPrefab) as GameObject;
        else
            temp = Instantiate(capsulePickUpPrefab) as GameObject;


        temp.transform.SetParent(parent);
        do
        {
            spawnX = Random.Range((transform.localScale.x / -2f) + 0.5f, (transform.localScale.x / 2f) - 0.5f) + transform.position.x;
            spawnZ = Random.Range((transform.localScale.z / -2f) + 0.5f, (transform.localScale.z / 2f) - 0.5f) + transform.position.z;
        } while (spawnX == transform.position.x && spawnZ == transform.position.z);


        temp.transform.position = new Vector3(spawnX, 1.1f, spawnZ);
    }

    IEnumerator CheckPickUpCount()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            if (GameObject.FindGameObjectsWithTag("CubePickUp").Length + GameObject.FindGameObjectsWithTag("CylinderPickUp").Length + GameObject.FindGameObjectsWithTag("CapsulePickUp").Length == 0)
            {
                FindObjectOfType<PlayerMovement>().enabled = false;
                Invoke("SpawnMore", 2f);
            }
        }
    }
}
