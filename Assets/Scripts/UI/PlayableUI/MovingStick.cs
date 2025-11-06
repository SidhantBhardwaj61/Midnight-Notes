using System.Collections;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class MovingStick : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform stickSpawnArea;
    [SerializeField] GameObject movingStick;
    [SerializeField] Transform leftWallPos;
    [SerializeField] Transform rightWallPos;
    [SerializeField] GameObject puzzleCanvas;
    public static bool isStickActive = false;


    public static bool isMoving;

    GameObject stick;

    void OnEnable()
    {
        //spawn the score area in the middle
        stick = Instantiate(movingStick, stickSpawnArea.position, Quaternion.identity);
        isStickActive = true;
        isMoving = true;
    }

    void Update()
    {
        //despawn the canvas if not scored
        if (ScoreArea.hasScored == false && isMoving == false)
        {
            StartCoroutine(WaitRoutine());
            puzzleCanvas.SetActive(false);
        }

        else if (ScoreArea.hasScored == true && isMoving == false)
        {
            StartCoroutine(WaitRoutine());
            puzzleCanvas.SetActive(false);
        }
    }
    
    IEnumerator WaitRoutine()
    {
        yield return new WaitForSeconds(2f);
    }
}
