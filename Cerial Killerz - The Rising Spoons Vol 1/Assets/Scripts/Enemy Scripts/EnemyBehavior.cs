using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehavior : MonoBehaviour
{
    Rigidbody ridgidBody;

    Vector2 direction = new Vector3(1, 0,0); //Direction we are heading in
    public float gravityScale = 1.0f;
    public float speed = 5f; //Speed

    public Vector3 hitBoxSize;//The hitBox Size

    public Vector3 hitBoxPosition;//The hitBox Position

    public LayerMask layers;

    void OnDrawGizmos()
    {
        // Draw a red cube at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + (Vector3)hitBoxPosition, new Vector3(hitBoxSize.x, hitBoxSize.y, hitBoxSize.z));
    }

    public void CheckHitbox()
    {
        Collider[] col = Physics.OverlapBox(transform.position + (Vector3)hitBoxPosition, new Vector3(hitBoxSize.x, hitBoxSize.y, 0),Quaternion.identity, layers);
        
        foreach (Collider colItem in col)
        {
            //Debug.Log("ColliderItem " +col.Length);
            if (colItem.tag == "Player" || colItem.tag == "Spoon")
            {
                CheckDamage(colItem);
            }
            else if (colItem.gameObject != gameObject)
            {
                Debug.Log(colItem.name);
                direction.x = -direction.x;
            }
          
        }
    }

    public void CheckDamage(Collider col)
    {
        PlayerHealth PlayerHealth = col.GetComponent < PlayerHealth > ();
        if (PlayerHealth != null)
        {
            PlayerHealth.TakeDamage(10);
        }
        else if(col.tag == "Spoon")
        {
            Destroy(gameObject);
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

        Vector3 gravity = Physics.gravity.y * gravityScale * Vector3.up;
        ridgidBody.AddForce(gravity, ForceMode.Acceleration);
    }
}
