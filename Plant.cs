using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Plant : MonoBehaviour
{
    private Transform player;
    private SpriteRenderer psp;
    private Animator plant;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private GameObject player1;
    int flip;
    private BoxCollider2D box;
    Animator player_death;
    GameObject bulletclone;
    public float spawnRate = 1f; // Bullets per second
    private float nextSpawnTime = 0f; // Bullets per second
    private Rigidbody2D playerRb;
    
    // Start is called before the first frame update
    void Start()
    {
        psp = GetComponent<SpriteRenderer>();
        plant = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        player_death = player1.GetComponent<Animator>();
        player = player1.GetComponent<Transform>();
        playerRb = player1.GetComponent<Rigidbody2D>(); 
        
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if (flip == -1)
        {
            flip = -2;
        }
        float val = transform.position.x - player.position.x;
        if(val < 0)
        {
            psp.flipX = true;
            flip = 1;
            box.offset = new Vector2(-0.2f, -0.1f);

        }
         if(val > 0) 
        {
            psp.flipX = false;
            flip = -1;
            box.offset = new Vector2(0.2f, -0.1f);
        }
        if(math.abs(val) < 15)
        {
           
            Bullet.active = true;
                
                if (Time.time >= nextSpawnTime)
                {
                    spambullet();
                    nextSpawnTime = Time.time + 2f / spawnRate; // Calculate next spawn time
                }
          
             
        }
       if(math.abs(val) > 15)
        {
            Bullet.active = false;

        }
       

    }

    [System.Obsolete]
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;

        if (collider.name == "Player")
        {
            ContactPoint2D contact = collision.contacts[0];
            Vector3 pos = contact.point;
            if (pos.y >= -0.7f)
            {
                plant.SetTrigger("Die");
                bulletclone.active = false;
                
            }
            else if(pos.x > transform.position.x || pos.x < transform.position.x) 
            {
                player_death.SetTrigger("Death");
                playerRb.bodyType = RigidbodyType2D.Static;

            }
        }
    }

    [System.Obsolete]
    private void spambullet()
    {
             bulletclone = Instantiate(Bullet, Bullet.transform.position, Quaternion.identity);
            if (flip == -1)
            {
                bulletclone.GetComponent<Rigidbody2D>().velocity = new Vector2(-2, 0f);
            }
            else
            {
                bulletclone.GetComponent<Rigidbody2D>().velocity = new Vector2(2, 0f);
            }
    }


    public void PlantDestroy()
    {
        Destroy(gameObject); 
                    
    }
    public void plantidle()
    {
        plant.SetBool("Attack", false);
    }
    public void plantAttack()
    {
        plant.SetBool("Attack", true);
    }
   
}
