using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float forceBullet = 20f;
    public Vector3 vectorBullet = Vector3.up;
    private Rigidbody _rigidbody;
    public GameObject Explosive;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddRelativeForce(vectorBullet * forceBullet, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag != "Player")
        {
            GameObject explosive = Instantiate(Explosive, transform.position, transform.rotation);
            Destroy(explosive, 0.5f);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
