using System.IO;
using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{
    Transform playerTransform;

    [SerializeField] Vector3 offset; 

    [SerializeField] float cameraSpeed; 


    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    private void Update()
    {
        transform.position = Vector3.Slerp(transform.position, playerTransform.position + offset, cameraSpeed * Time.deltaTime);
    }



}
