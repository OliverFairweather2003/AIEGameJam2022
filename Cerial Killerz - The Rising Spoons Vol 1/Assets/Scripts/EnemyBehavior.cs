using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehavior : MonoBehaviour
{
    Rigidbody ridgidBody;

    Vector2 direction = new Vector3(1, 0,0); //Direction we are heading in

    public float speed = 5f; //Speed

    public Vector3 hitBoxSize;//The hitBox Size

    public Vector3 hitBoxPosition;//The hitBox Position

    public LayerMask layers;

    void OnDrawGizmos()
    {
        // Draw a red cube at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + (Vector3)hitBoxPosition, new Vector3(hitBoxSize.x, hitBoxSize.y, 0));
    }

    void CheckHitbox()
    {
        Collider[] col = Physics.OverlapBox(transform.position + (Vector3)hitBoxPosition, new Vector3(hitBoxSize.x, hitBoxSize.y, 0),Quaternion.identity, layers);
        
        foreach (Collider colItem in col)
        {
            //Debug.Log("ColliderItem " +col.Length);
            if (colItem.gameObject != gameObject)
            {
                Debug.Log("Hit Item");
                direction.x = -direction.x;
            }
            if (colItem.tag == "Player")
            {
                CheckDamage(colItem);
            }
            if (colItem.tag == "Spoon")
            {
                CheckDamage(colItem);
            }
        }
    }

    void CheckDamage(Collider col)
    {
        Rigidbody spoonRB = col.GetComponent<Rigidbody>();
        if (spoonRB != null)
        {
            if (spoonRB.velocity.y < -0.2f, spoonRB.velocity.x < -0.2f, spoonRB.velocity.y < 0.2f, spoonRB.velocity.x < 0.2f)
            {
                Destroy(gameObject);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ridgidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckHitbox();
        ridgidBody.velocity = direction * speed;
    }
}
