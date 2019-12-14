using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;
    private Rigidbody rb;

	[SerializeField]
	private Transform background;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
		//move player
		if(Input.GetAxis("Horizontal") != 0)
		{
			Vector3 movement_vector = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
			rb.MovePosition(rb.position + (movement_vector * speed) * Time.deltaTime);
		}

		//move background depending on player position
		background.position = new Vector3(transform.position.x / 5, background.position.y, background.position.z);
	}
}
