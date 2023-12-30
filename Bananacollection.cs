
using UnityEngine;

public class Bananacollection : MonoBehaviour
{
    private Animator banana;
    private void Start()
    {
        banana = GetComponent<Animator>();
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            banana.SetTrigger("Collected");
           

        }
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}

