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
        rb = GetComponent<Rigidbody>(); // �������� ������ �� ����������
        rb.constraints = RigidbodyConstraints.FreezeRotation; //���� �������

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed); //�������� ������ ������
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -50, 50), Mathf.Clamp(transform.position.z, 6f, 16f)); //������������
    }

    void OnCollisionEnter(Collision coll)
    {

        if (coll.gameObject.tag == "obstacles")
        {
            Destroy(gameObject); 
        }

    }
}
