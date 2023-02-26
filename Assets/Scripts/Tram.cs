using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tram : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // получает данные из инспектора
        rb.constraints = RigidbodyConstraints.FreezeRotation; //фриз ротейшн
    }

    void FixedUpdate()
    {
        //rb.AddForce(0, 0, speed, ForceMode.Impulse);
        transform.Translate(Vector3.forward * Time.deltaTime * speed); //движение игрока вперед
    }
}
