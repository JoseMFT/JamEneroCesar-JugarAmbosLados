using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehavior : MonoBehaviour
{
    float lifetime = 2f;
    const float kVelocidadLaser = 20f;
    Rigidbody rbLaser;

    // Start is called before the first frame update

    private void Awake () {
        rbLaser = gameObject.GetComponent<Rigidbody>();
    }
    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate () {

        Vector3 destinoLaser = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + kVelocidadLaser * Time.deltaTime, gameObject.transform.position.z);
        if (lifetime > 0f) {
            lifetime -= Time.deltaTime;
            rbLaser.MovePosition(destinoLaser);
        } else {
            lifetime = 2f;
            gameObject.SetActive(false);

        }
    }

    private void OnCollisionEnter (Collision collision) {
        if (collision.gameObject.name.Contains("Meteorito")) {
            lifetime = 2f;
            gameObject.SetActive(false);
        }
    }
}
