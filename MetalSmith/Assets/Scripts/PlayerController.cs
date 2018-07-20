using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(PlayerController))]
public class PlayerController : MonoBehaviour {

	 [SerializeField] private float speed = 5f;
	 [SerializeField] private float lookSensitivity = 3f;

	private PlayerMovement motor;

	void Start () {
		motor = GetComponent<PlayerMovement> ();
	}

	void Update () {
		//calculate movement velocity as a 3d vector
		float _xMov = Input.GetAxisRaw ("Horizontal");
		float _zMov = Input.GetAxisRaw ("Vertical");

		Vector3 _moveHorizontal = transform.right * _xMov;
		Vector3 _moveVertical = transform.forward * _zMov;

		//final movement vector
		Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed;
		
		//apply movement
		motor.Move(_velocity);
		//rotation as a 3d vector
		float _yRot = Input.GetAxisRaw("Mouse X");

		Vector3 _rotation = new Vector3 (0f, _yRot, 0f) * lookSensitivity;
		//apply rotation
		motor.Rotate(_rotation);

		//camera rotation as a 3d vector
		float _xRot = Input.GetAxisRaw("Mouse Y");

		Vector3 _cameraRotation = new Vector3 (_xRot, 0f, 0f) * lookSensitivity;
		//apply rotation
		motor.RotateCamera(_cameraRotation);
	}

}
