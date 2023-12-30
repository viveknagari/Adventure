
using UnityEngine;

public class BlueBird : MonoBehaviour
{
    private SpriteRenderer sp;
    int direction = 1;
    [SerializeField] private GameObject WayStart;
    [SerializeField] private GameObject WayEnd;
    public float movespeed; 
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.x < WayStart.transform.position.x)
        {
            direction = 1;
        }
        else if(transform.position.x > WayEnd.transform.position.x)
        {
            direction = -1;
        }
        transform.Translate( movespeed*direction * Time.deltaTime, 0, 0);
        if(direction == 1)
        {
            sp.flipX = true;
        }
        else
        {
            sp.flipX = false;
        }
    }
    
}
