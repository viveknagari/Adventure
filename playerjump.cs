using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerjump : MonoBehaviour
{
    private Animator animator;
    [SerializeField] GameObject player;
    private Rigidbody2D playerRg;
    public int jump;
    [SerializeField] private AudioSource PolJumpAudio;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerRg = player.GetComponent<Rigidbody2D>();
        animator.enabled = false;
    }
    private void Update()
    {
        if(playerRg.velocity.y < -0.1)
        {
            animator.enabled = false;
           
        }
       
    }
    // Update is called once per frame
    public void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            animator.enabled = true;
            PolJumpAudio.Play();
            playerRg.velocity = new Vector2 (playerRg.velocity.x, jump);
        }
       
    }
    public void jumpol()
    {
        animator.enabled = false;
    }
   
    

}
