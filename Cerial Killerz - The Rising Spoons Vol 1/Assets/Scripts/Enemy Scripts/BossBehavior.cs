using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    Rigidbody ridgidBody;

    public int BossHealth = 99;

    Vector2 direction = new Vector3(0, 0, 0);//Direction we are heading in
    public float gravityScale = 1.0f;
    public float speed = 5f;

    public Vector3 hitBoxSize;//The hitBox Size

    public Vector3 hitBoxPosition;//The hitBox Position

    public LayerMask layers;

    public GameObject spewBox;
    public ParticleSystem spewEffect;

    public Transform teleportLocation;

    // Start is called before the first frame update
    void OnDrawGizmos()
    {
        // Draw a red cube at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + (Vector3)hitBoxPosition, new Vector3(hitBoxSize.x, hitBoxSize.y, hitBoxSize.z));
    }



    public void CheckHitbox()
    {
        Collider[] col = Physics.OverlapBox(transform.position + (Vector3)hitBoxPosition, new Vector3(hitBoxSize.x, hitBoxSize.y, 0), Quaternion.identity, layers);

        foreach (Collider colItem in col)
        {
            if (colItem.tag == "Player")
            {
                Debug.Log("Hit");
                CheckDamage(colItem);
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Hit");
        if (collision.gameObject.tag == "Player")
        {

            PlayerMovement PlayerHealth = collision.gameObject.GetComponent<PlayerMovement>();
            if (PlayerHealth != null)
            {
                if (PlayerHealth.currentVelocity.y < -0.2f)
                {
                    TakeDamageBoss(33);

                    PlayerHealth.Teleport(teleportLocation);
                }
            }
        }
    }

    public void CheckDamage(Collider col)
    {
        Rigidbody PlayerHealth = col.GetComponent<Rigidbody>();
        if (PlayerHealth != null)
        {
            if (PlayerHealth.velocity.y < -0.2f)
            {
                TakeDamageBoss(33);
            }
        }
    }

    void TakeDamageBoss(int damage)
    {
        BossHealth -= damage;
    }

    void Die()
    {
        Destroy(gameObject);
    }


    void Spew(bool isSpewing)
    {
        spewBox.SetActive(isSpewing);
        if (isSpewing)
            spewEffect.Play();
        else
            spewEffect.Stop();
    }

    


    // Start is called before the first frame update
    void Start()
    {
        ridgidBody = GetComponent<Rigidbody>();
        Spew(false);
    }


    float timer;
    bool spewing = false;
    // Update is called once per frame
    void Update()
    {
        CheckHitbox();

        timer += Time.deltaTime;

        if (timer > 4f)
        {
            spewing = !spewing;
            Spew(spewing);
            timer = 0;
        }


        ridgidBody.velocity = direction * speed;

        if (BossHealth <= 0)
        {
            Die();
        }
    }
}
