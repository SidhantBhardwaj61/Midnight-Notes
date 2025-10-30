using UnityEngine;

public class DoorTeleport : MonoBehaviour
{
    [SerializeField] Transform destination;
    [SerializeField] GameObject player;
    Vector2 teleportPos;

    void OnEnable()
    {
        if (this.gameObject.tag == "Interior")
        {
            teleportPos = new Vector2(destination.position.x, destination.position.y - 1f);
        }
        else if(this.gameObject.tag == "Exterior")
        {
            teleportPos = new Vector2(destination.position.x, destination.position.y + 1f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            player.transform.position = teleportPos;
        }
    }

}
