using UnityEngine;

public class CameraMovement2 : MonoBehaviour
{
    public float heigth;
    public float distance;
    private Transform player;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        transform.position = player.position + new Vector3(0, heigth, -distance);
        transform.LookAt(player.position);
    }

    void Update()
    {
        Vector3 direction = new Vector3(transform.position.x - player.position.x, 0, transform.position.z - player.position.z).normalized * distance;
        direction.y = heigth;
        transform.position = player.position + direction;
        transform.LookAt(player.position);
    }
}
