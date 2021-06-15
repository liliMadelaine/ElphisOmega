using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    private Rigidbody2D rb;
    public float knockback;

    Vector3 lastVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    void Update()
    {
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D (Collision2D other){
        if(other.gameObject.tag == "Tornado"){
            if(rb.position.x < other.contacts[0].point.x){
                var direction = Vector2.Reflect(rb.position, other.contacts[0].normal);
                rb.velocity = direction * knockback;
            } else {
                var direction = Vector2.Reflect(rb.position, other.contacts[0].normal);
                rb.velocity = -direction * knockback;
            }
        }
        
    }
}
