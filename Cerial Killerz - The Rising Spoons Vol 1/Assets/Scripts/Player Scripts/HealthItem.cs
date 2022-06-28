using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Rigidbody ridgidBody;
    public Vector3 hitBoxSize;
    public Vector3 hitBoxPosition;
    public LayerMask layers;

    // Start is called before the first frame update
    void Start()
    {
        ridgidBody = GetComponent < Rigidbody > ();
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position + (Vector3)hitBoxPosition, new Vector3(hitBoxSize.x, hitBoxSize.y, hitBoxSize.z));
    }

    public void CheckHitbox()
    {
        Collider[] col = Physics.OverlapBox(transform.position + (Vector3)hitBoxPosition, new Vector3(hitBoxSize.x, hitBoxSize.y, 0), Quaternion.identity, layers);

        foreach (Collider colItem in col)
        {
            if (colItem.tag == "Player")
            {
                CheckHealth(colItem);
            }
        } 
    }

    public void CheckHealth(Collider col)
    {
        PlayerHealth PlayerHealth = col.GetComponent<PlayerHealth>();
        if (PlayerHealth != null)
        {
            PlayerHealth.AddHealth(20);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckHitbox();
    }
}
