using UnityEngine;

public class Score : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "MovingStick")
        {
            //if the stick has stopped
            if(MovingStick.isMoving == false)
            {
                ScoreArea.hasScored = true;
            }
        }
    }
}
