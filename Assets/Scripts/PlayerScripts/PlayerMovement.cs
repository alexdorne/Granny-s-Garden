using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    InputManager inputManager;
    Rigidbody rb;

    [SerializeField] GameObject cameraHolder; 

    [SerializeField] float speed;
    [SerializeField] float rotationSpeed; 
    
    [SerializeField] Animator animator; 

    private void Awake()
    {
        inputManager = InputManager.Instance; 
        rb = GetComponent<Rigidbody>(); 
        
    }

    private void FixedUpdate()
    {
        MovePlayer(); 
        RotatePlayer();
    }

    private void MovePlayer()
    { 
        // Transform

        //transform.position += new Vector3(inputManager.InputVector.x, 0, inputManager.InputVector.y) * speed * Time.deltaTime;

        Vector3 forward = cameraHolder.transform.forward;
        
        Vector3 right = cameraHolder.transform.right;

        Vector3 moveDirection = ( inputManager.MovementInputVector.x * right + inputManager.MovementInputVector.y * forward ).normalized; 

        //Debug.Log(moveDirection.magnitude); 

        animator.SetFloat("Speed", moveDirection.magnitude);


        // Rigidbody

        if (rb.linearVelocity.magnitude < 2)
        {
            rb.AddForce(moveDirection * speed);
        }


    }

    private void RotatePlayer()
    {
        Vector3 movementDirection = rb.linearVelocity; 

        //Debug.Log(movementDirection.magnitude); 

        Quaternion lookRotation; 
         
        if (inputManager.MovementInputVector.magnitude  != 0 && movementDirection.magnitude > 0.1f)
        {
            lookRotation = Quaternion.LookRotation(movementDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.fixedDeltaTime);

            

        }


    }

}