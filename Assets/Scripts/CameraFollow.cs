using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float timeOffset;
    [SerializeField] private Vector3 posOffset;

    private Vector3 velocity;

    void Update()
    {   
        Vector3 targetPosition = new Vector3(player.transform.position.x + posOffset.x, transform.position.y, transform.position.z);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, timeOffset);
    }
}
