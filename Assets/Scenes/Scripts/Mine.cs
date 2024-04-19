using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public GameObject blast;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Blast()
    {
        GameObject explosive = Instantiate(blast, transform.position, transform.rotation);
        Destroy(explosive, 0.5f);
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
            Blast();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
