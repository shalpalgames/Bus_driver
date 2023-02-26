using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviorForward : MonoBehaviour
{

    private Rigidbody rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // получает данные из инспектора
        rb.constraints = RigidbodyConstraints.FreezeRotation; //фриз ротейшн

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed); //движение игрока вперед
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -50, 50), Mathf.Clamp(transform.position.z, 6f, 16f)); //ограничитель
    }

    void OnCollisionEnter(Collision coll)
    {

        if (coll.gameObject.tag == "obstacles")
        {
            Destroy(gameObject); 
        }

    }
}
