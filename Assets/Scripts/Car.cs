using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {
    public float speed;
    Vector2 direction = new Vector2();
    public float moveDirection = 1;
    public AudioSource honk;

    // Use this for initialization
    void Start()
    {
        direction.x = moveDirection;
        direction.y = 0;
        direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            honk = GetComponent<AudioSource>();
            honk.Play();
        }
    }
}
