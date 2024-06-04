using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /*//Room camera
    [SerializeField] private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    //Follow player camera
    [SerializeField]private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;


    private void Update()
    {
        //Room Camera
        //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z),ref velocity, speed * Time.deltaTime);

        //follow player
        transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);

        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;
    }*/
    // Start is called before the first frame update
    public Transform player;
    public float cameraDistance = 2.0f;
    [SerializeField] public float camFromGround;

    private void Awake()
    {
        //GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cameraDistance);
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x, player.position.y + camFromGround, transform.position.z);
    }
}
