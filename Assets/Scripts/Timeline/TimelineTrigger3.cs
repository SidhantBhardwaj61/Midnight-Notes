using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineTrigger3 : MonoBehaviour
{
    [SerializeField] PlayableDirector playableDirector;
    [SerializeField] GameObject enemyMain;
    [SerializeField] GameObject finalEnemy;
    [SerializeField] CoinSpawner coinSpawner;
    [SerializeField] GameObject otherCutsceneTrigger;

    void Update() 
    {
        if(enemyMain != null && InventoryManager.hasNotes == true)
        {
            enemyMain.SetActive(false);
            Destroy(enemyMain);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(InventoryManager.hasNotes == true)
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
        finalEnemy.SetActive(true);
        Destroy(gameObject);
        Destroy(otherCutsceneTrigger);
    }
}
