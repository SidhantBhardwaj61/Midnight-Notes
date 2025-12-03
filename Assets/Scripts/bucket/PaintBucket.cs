using UnityEngine;

public class PaintBucket : MonoBehaviour
{
    [SerializeField] GameObject fellBucket;
    [SerializeField] AudioSource bucketFallSFX;

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);
            bucketFallSFX.Play();
            fellBucket.SetActive(true);
            Invoke("DestroyBucket" , 3f);
        }
    }

    void DestroyBucket()
    {
        Destroy(gameObject);
    }
}
