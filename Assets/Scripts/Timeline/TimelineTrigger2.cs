using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineTrigger2 : MonoBehaviour
{
    [SerializeField] PlayableDirector playableDirector;
    [SerializeField] GameObject enemyMain;
    [SerializeField] GameObject tempEnemy;
    [SerializeField] CoinSpawner coinSpawner;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(InventoryManager.hasKey == true)
        {
            if(collision.CompareTag("Player"))
            {
                playableDirector.stopped += OnTimelineFinished;
                playableDirector.Play();
            }
        }
    }

    void OnTimelineFinished(PlayableDirector playableDirector)
    {
        coinSpawner.crossHairLocation = Vector2.zero;
        coinSpawner.coinThrown = false;
        enemyMain.SetActive(true);
        Destroy(tempEnemy);
        Destroy(gameObject);
    }
}
