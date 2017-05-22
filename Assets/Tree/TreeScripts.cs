using UnityEngine;
using System.Collections;


public class TreeScripts : MonoBehaviour {

    public GameObject explosion;
    
    public float speed = 10.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -15.0f)
            Destroy(gameObject);
        transform.Translate(-1 * Time.deltaTime * speed,0.0f , 0.0f);
    }

    void OnTriggerEnter(Collider other)
    {
        
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        
    }
}
