@script RequireComponent(CharacterController)
private var controller :CharacterController;
controller = gameObject.GetComponent(CharacterController);
 
private var moveDirection = Vector3.zero;
private var forward = Vector3.zero;
private var right = Vector3.zero;

function Update()
{
	forward = transform.forward;
	right = Vector3(forward.z, 0, -forward.x);
 
	var horizontalInput = Input.GetAxisRaw("Horizontal");
	var verticalInput = Input.GetAxisRaw("Vertical");
		var targetDirection = horizontalInput * right + verticalInput * forward;	
 
	moveDirection = Vector3.MoveTowards(moveDirection, targetDirection, 1000);
 
	var movement = moveDirection  * Time.deltaTime * 2;
	controller.Move(movement);

      }