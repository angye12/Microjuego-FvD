using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{


    public float thrustForce = 5f;
    public float rotationSpeed = 120f;
    public GameObject gun, bulletPrefab;

    Vector2 thrustDirection;
    Rigidbody _rigidbody;

    public static int score = 0;

    public float xBorderLimit;
    public float yBorderLimit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float rotation = Input.GetAxis("Rotate") * Time.deltaTime * rotationSpeed;
        float thrust = Input.GetAxis("Thrust") * thrustForce;
        thrustDirection = transform.right;
        transform.Rotate(Vector3.forward, -rotation);
        _rigidbody.AddForce(thrust * thrustDirection);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, Quaternion.identity);
            
            bullet balaScript = bullet.GetComponent<bullet>();

            balaScript.targetVector = transform.right;
        }
    }

    private void Update()
    {
        Vector3 newPos = transform.position;
        if (newPos.x > xBorderLimit)
        {
            newPos.x = -xBorderLimit + 1;
        }
        else if (newPos.x < -xBorderLimit)
        {
            newPos.x = xBorderLimit - 1;
        }
        else if (newPos.y > yBorderLimit)
        {
            newPos.y = -yBorderLimit + 1;
        }
        else if (newPos.y < -yBorderLimit)
        {
            newPos.y = yBorderLimit - 1;
        }
        transform.position = newPos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            score = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            Debug.Log(message:"He colisionado con otra cosa");
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
