using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rinomovement : MonoBehaviour
{
    [SerializeField] private GameObject WayStart;
    [SerializeField] private GameObject WayEnd;
    int Direction = 1;
    public float Movespeed;
    private SpriteRenderer sp;
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Direction == 1)
        {
            sp.flipX = true;
        }
        else
        {
            sp.flipX = false;   
        }
        if(transform.position.x <  WayStart.transform.position.x || transform.position.x > WayEnd.transform.position.x)
        {
            Direction *= -1;
        }
        transform.Translate(Movespeed * Direction * Time.deltaTime, 0, 0);
        
    }
}
