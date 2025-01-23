using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (!Input.GetKey(KeyCode.Space))
            {
                transform.position += transform.right * 5f;
            }
            else
            {
                Vector3 a = transform.eulerAngles;
                a.y += 90f;
                transform.eulerAngles = a;
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!Input.GetKey(KeyCode.Space))
            {
                transform.position += -transform.right * 5f;
            }
            else
            {
                Vector3 a = transform.eulerAngles;
                a.y -= 90f;
                transform.eulerAngles = a;
            }
        }
        rb.velocity = transform.forward * speed;
    }
}
