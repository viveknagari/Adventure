using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movespeed = 7;
    [SerializeField] private float jump = 12;
    private Rigidbody2D rb;
    private float xdir = 0f;
    private Animator player;
    private SpriteRenderer sp;
    public Left leftbutton;
    public Right rightbutton;
    [SerializeField] private bool Keyboard;
    private float bxdir = 0f;
    int doublejump = 0;
    [SerializeField] private AudioSource jumpAudio;
    [SerializeField] private AudioSource DieAudio;
  

    private enum movement { idle, run, jump, fall, doublejump};
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        movement state;
        
        if (transform.position.x < -5)
        {
            transform.position = new Vector2(-5,transform.position.y);
        }
        if (Keyboard)
        {
           
            xdir = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(xdir * movespeed, rb.velocity.y);
            if (xdir < 0f)
            {
                sp.flipX = true;
                state = movement.run;
               

            }
            else if (xdir > 0f)
            {
                sp.flipX = false;
                state = movement.run;
            }
            
            else
            {

                state = movement.idle;
            }
            
           
            if (rb.velocity.y > 0.1f)
            {
                state = movement.jump;
            }
            else if (rb.velocity.y < -0.1f)
            {
                state = movement.fall;
            }
            if (Input.GetButtonDown("Jump") && doublejump < 2)
            {
                doublejump += 1;
                jumpAudio.Play();
                rb.velocity = new Vector2(rb.velocity.x, jump);
            }
            if (doublejump == 2)
            {
                state = movement.doublejump;
            }
            player.SetInteger("State", (int)state);
        }
        else
        {
            rb.velocity = new Vector2(bxdir * movespeed, rb.velocity.y);
            if (leftbutton.LeftClick())
            {
                leftclick();
                sp.flipX = true;
                state = movement.run;

            }
            else if (rightbutton.rightClick())
            {
                sp.flipX= false;
                righttclick();
                state = movement.run;
            }
            else
            {
                state = movement.idle;
            }
            
            if (rb.velocity.y > 0.1f)
            {
                state = movement.jump;
            }
            else if (rb.velocity.y < -0.1f)
            {
                state = movement.fall;
            }
            if (doublejump == 2)
            {
                state = movement.doublejump;
            }
            player.SetInteger("State", (int)state);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
          doublejump = 0;
           
        }
    }
    

    public void leftclick()
    {
       
        if (leftbutton.LeftClick())
        {
            bxdir -= Time.deltaTime;
            if(bxdir < -1)
            {
                bxdir = -1;
            }
        }
        else
        {
            bxdir = 0;
        }

    }
    public void righttclick()
    {
       
        if (rightbutton.rightClick())
        {
            bxdir += Time.deltaTime;
            if (bxdir > 1)
            {
                bxdir = 1;
            }
        }
        else
        {
            bxdir = 0;
        }

    }
    public void up()
    {
        jumpAudio.Play();
        doublejump += 1;
        if (doublejump == 1)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }
        if (doublejump == 2)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bird")
        {
            player.SetTrigger("Death");
            DieAudio.Play();
            rb.bodyType = RigidbodyType2D.Static;
        }
        if (collision.gameObject.CompareTag("Win"))
        {
            SceneManager.LoadScene(1);
        }
    }
   
   
}
