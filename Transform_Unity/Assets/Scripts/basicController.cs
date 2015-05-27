using UnityEngine;
using System.Collections;

public class basicController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        CharacterController controller = GetComponent<CharacterController>();
        Vector3 moveDirection = Vector3.zero;
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= 5f;

            transform.Rotate(0, Input.GetAxis("Horizontal"), 0);

        }

        moveDirection.y -= 20f * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
	}
}
