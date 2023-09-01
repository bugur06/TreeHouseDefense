using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    [SerializeField]
    private int damage = 35;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        
        if (collision.CompareTag("Wolf"))
        {
            collision.GetComponent<WolfHealth>().TakeDamage(damage);
            Destroy(gameObject);

        }
        
    }

}
