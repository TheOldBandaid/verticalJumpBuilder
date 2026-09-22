using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float Velocity;
    private bool isStopped;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void OnTrigger(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag = "block")
        {

        }
    }
}
