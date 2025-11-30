using UnityEngine;

public class DoorTeleport : MonoBehaviour
{
    [SerializeField] Transform destination;
    [SerializeField] GameObject player;
    [SerializeField] float exteriorOffset = 3f;
    [SerializeField] float interiorOffset = 1f;
    [SerializeField] float exteriorSideOffset = 1f;
    [SerializeField] float interiorSideOffset = 1f;
    [SerializeField] float classroomOffset = 2f;
    Vector2 teleportPos;

    void OnEnable()
    {
        if (this.gameObject.tag == "Interior")
        {
            teleportPos = new Vector2(destination.position.x, destination.position.y - exteriorOffset);
        }
        else if(this.gameObject.tag == "Exterior")
        {
            teleportPos = new Vector2(destination.position.x, destination.position.y + interiorOffset);
        }
        else if(this.gameObject.tag == "ExteriorSide")
        {
            teleportPos = new Vector2(destination.position.x + interiorSideOffset, destination.position.y);
        }
        else if(this.gameObject.tag == "InteriorSide")
        {
            teleportPos = new Vector2(destination.position.x - exteriorSideOffset, destination.position.y);
        }
        else if(this.gameObject.tag == "ClassroomGate")
        {
            teleportPos = new Vector2(destination.position.x, destination.position.y - classroomOffset);
        }
        else if(this.gameObject.tag == "ClassroomGateInterior")
        {
            teleportPos = new Vector2(destination.position.x + classroomOffset, destination.position.y);
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
