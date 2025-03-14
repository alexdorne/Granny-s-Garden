using NUnit.Framework.Constraints;
using System.IO;
using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{
    Transform playerTransform;

    InputManager inputManager; 


    [SerializeField] Vector3 offset; 

    [SerializeField] float cameraSpeed;
    [SerializeField] float cameraRotateSpeed; 


    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; 
        inputManager = InputManager.Instance;
    }

    private void Update()
    {
        transform.position = Vector3.Slerp(transform.position, playerTransform.position + offset, cameraSpeed * Time.deltaTime);


        transform.Rotate(new Vector3(0, inputManager.CameraInputVector.x * cameraRotateSpeed * Time.deltaTime, 0) * cameraRotateSpeed * Time.deltaTime); 
    }



}
