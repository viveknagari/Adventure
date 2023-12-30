using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class applecollector : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator apple;
    private void Start()
    {
        apple = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            apple.SetTrigger("Collected");
        }
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}