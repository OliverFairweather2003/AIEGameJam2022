using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoonThrow : MonoBehaviour
{
    bool go;
    public GameObject spoon;
    public GameObject Player;

    Transform itemToRotate;
    public Transform throwPoint;
    public float spoonForce = 10f;


    // Start is called before the first frame update
    void Start()
    {
        go = false;
        itemToRotate = gameObject.transform.GetChild(0);
        StartCoroutine(Boom());
    }

    public void Throw()
    {
        spoon.SetActive(false);
        StartCoroutine(Boom());
    }

    IEnumerator Boom()
    {
        go = true;
        yield return new WaitForSeconds(1.5f);
        go = false;
    }

    // Update is called once per frame
    void Update()
    {
        itemToRotate.transform.Rotate(0, Time.deltaTime * 500, 0);

        if(go)
        {
            transform.position = Vector3.MoveTowards(transform.position, throwPoint.position + throwPoint.forward * spoonForce, Time.deltaTime * 40);
        }

        if(!go)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(Player.transform.position.x, Player.transform.position.y + 1, Player.transform.position.z), Time.deltaTime * 40);
        }

        if(!go && Vector3.Distance(Player.transform.position, transform.position) < 1.5 )
        {
            spoon.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
