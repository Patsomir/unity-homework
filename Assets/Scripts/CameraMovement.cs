using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Vector3 relativePosition;
    public Transform player;

    /*private bool leftPressed = false;
    private bool rightPressed = false;*/
    void Update()
    {
        transform.position = player.position + relativePosition;
    }
}
