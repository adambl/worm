using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormHeadController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 10;
    Vector2 moveVelocity;
    //private LinkedList<GameObject> wormParts = new LinkedList<GameObject>()
    // Start is called before the first frame update
    void Start()
    {
        //GameObject head = Instantiate()
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            Debug.Log("X: " + Input.GetAxis("Horizontal") + ",y: " + Input.GetAxis("Vertical"));
            Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            moveVelocity = moveInput.normalized * speed;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
