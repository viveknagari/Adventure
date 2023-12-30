
using UnityEngine;

public class Collecter : MonoBehaviour
{
    private Animator player_Death;
    private Rigidbody2D rb;
    [SerializeField] private AudioSource CollectAudio;
    [SerializeField] private AudioSource DieAudio;
    private void Start()
    {
        player_Death = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Banana") || collision.gameObject.CompareTag("apple") || collision.gameObject.CompareTag("Cheries"))
        {
            Destroy(collision.gameObject, 0.2f);
            CollectAudio.Play();
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            player_Death.SetTrigger("Death");
            DieAudio.Play();
            rb.bodyType = RigidbodyType2D.Static;
        }
    }

}
