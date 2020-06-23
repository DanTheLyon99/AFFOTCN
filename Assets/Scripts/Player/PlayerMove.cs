using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
   [SerializeField] public float speed;
   // [SerializeField] float health;
    private Rigidbody2D rb;

    private Vector2 moveAmount;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip collisionSound;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //TODO find a better way to stop angular velocity
        rb.angularVelocity = 0f;

        MoveInput();

        // Move with mouse
        //TODO find a better way to do this.
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle -180 , Vector3.forward);
        transform.rotation = rotation;
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }
    
    private void MoveInput()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveAmount = moveInput.normalized * speed;
    }
    
   

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Collidable"))
        {
            audioSource.PlayOneShot(collisionSound);

        }
    }
}
