using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {

	CharacterController controller;

	PlayerInputActions inputActions;

	Vector2 inputMoveValue;
	Vector3 moveValue;

	[SerializeField] float speed = 10.0f;

	void Start() {
		controller = GetComponent<CharacterController>();
		//inputActions = GetComponent<PlayerInput>().actions.;
	}

	void Update() {
		if (controller.isGrounded) {
			controller.Move(moveValue * speed * Time.deltaTime);
		} else {
			controller.Move(Physics.gravity * Time.deltaTime);
		}
	}

	public void OnMovement(InputValue value) {
		inputMoveValue = value.Get<Vector2>();
		moveValue = new Vector3(inputMoveValue.x, 0.0f, inputMoveValue.y);
	}
}