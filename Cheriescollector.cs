using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheriescollector : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator cheries;
    private void Start()
    {
        cheries = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cheries.SetTrigger("Collected");
        }
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
