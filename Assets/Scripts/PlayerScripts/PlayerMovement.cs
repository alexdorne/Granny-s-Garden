using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    InputManager inputManager;
    Rigidbody rb;

    [SerializeField] float speed;
    [SerializeField] float rotationSpeed; 
    

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

        

        // Rigidbody

        if (rb.linearVelocity.magnitude < 2)
        {
            rb.AddForce(new Vector3(inputManager.InputVector.x, 0, inputManager.InputVector.y) * speed);
        }


    }

    private void RotatePlayer()
    {
        Vector3 movementDirection = rb.linearVelocity.normalized; 

        Debug.Log(movementDirection.magnitude); 

        Quaternion lookRotation; 
         
        if (movementDirection.magnitude > 0.1f)
        {
            lookRotation = Quaternion.LookRotation(movementDirection);
            rb.rotation = Quaternion.Lerp(transform.rotation, lookRotation, rotationSpeed * Time.fixedDeltaTime);


        }


    }

}