using UnityEngine;
using UnityEngine.Playables;

public class TimelineTrigger : MonoBehaviour
{
    [SerializeField] PlayableDirector playableDirector;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playableDirector.stopped += OnTimelineFinished;
            playableDirector.Play();
        }
    }

    void OnTimelineFinished(PlayableDirector playableDirector)
    {
        Destroy(gameObject);
    }
}
