using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour {

    private float horizontalInput;
    private float verticalInput;
    public float speed = 1f; //скорость player X
    public float rotSpeed = 1f; //скорость player X
    private Rigidbody rb;
    public float rotY = 20f;

    public float maxHealth = 10f;
    public float currentHealth;
    //public HealthBar healthbar;
    public GameObject HP1;
    public GameObject HP2;
    public GameObject HP3;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // получает данные из инспектора
        rb.constraints = RigidbodyConstraints.FreezeRotation; //фриз ротейшн
        rb.mass = 100;

        currentHealth = maxHealth;
        //healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal"); //управление клавишами
        transform.Rotate(Vector3.up, Time.deltaTime * rotSpeed * horizontalInput);
        //float translation = Input.GetAxis("Vertical") * speed;
        //transform.Translate(0, 0, translation);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -50, 50), Mathf.Clamp(transform.position.z, 6f, 16f)); //ограничитель
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Clamp(transform.eulerAngles.y, 75, 105), transform.eulerAngles.z); //ограничитель градусов

        transform.Translate(Vector3.forward * Time.deltaTime * speed); //движение игрока вперед

        if (transform.eulerAngles.y > 91)
        {
            transform.Rotate(0, -rotY * Time.deltaTime, 0);
        }
        else if (transform.eulerAngles.y < 89)
        {
            transform.Rotate(0, rotY * Time.deltaTime, 0);

        }

        if (currentHealth <= 19)
        {
            HP1.SetActive(false);

        }
        if (currentHealth <= 9)
        {
            HP2.SetActive(false);

        }

        if (currentHealth <= 1)
        {
            HP3.SetActive(false);

        }


        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
            //Debug.Log("low health");

        }


        IncreaseSpeed(0.3f);


    }

    void OnCollisionEnter(Collision coll)
    {
       
        if (coll.gameObject.tag == "obstacles")
        {
            TakeDamage(9f);
        }

    }

    void TakeDamage(float damage)
    {
        currentHealth -= damage;
        //healthbar.SerHealth(currentHealth);
    }

    void IncreaseSpeed(float spd)
    {
        speed += spd * Time.deltaTime;
    }

}
