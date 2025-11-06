using UnityEngine;

public class ScoreArea : MonoBehaviour
{
    [SerializeField] GameObject scoreBox;
    [SerializeField] Transform leftPos;
    [SerializeField] Transform rightPos;
    public static bool hasScored = false;

    void OnEnable()
    {
        float randomX = Random.Range(leftPos.position.x, rightPos.position.x);

        Vector2 randomSpawn = new Vector2(randomX, transform.position.y);
        //spawn the area at a random point between two positions
        Instantiate(scoreBox, randomSpawn, Quaternion.identity);
    }

    
}
