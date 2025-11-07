using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] GameObject crossHair;
    [SerializeField] GameObject crossHairBoundary;
    [SerializeField] GameObject droppedCoin;
    [SerializeField] Transform player;
    [SerializeField] AudioSource CoinDropSFX;
    [SerializeField] GameObject timer;
    public Vector3 crossHairLocation;

    GameObject tempCoin;

    GameObject coinCross;
    GameObject coinCrossBoundary;

    bool crossActive = false;
    public bool coinThrown = false;

    public void SpawnCross()
    {
        if (!crossActive && timer.GetComponent<CoinTimer>().timerActive == false)
        {
            //spawn the coin crosshair and take control from the user
            coinCross = Instantiate(crossHair, player.position, Quaternion.identity);
            coinCrossBoundary = Instantiate(crossHairBoundary, player.position, Quaternion.identity);

            //restrict player movement
            player.gameObject.GetComponent<PlayerMovement>().enabled = false;
            player.gameObject.GetComponentInChildren<PlayerInteraction>().enabled = false;
            crossActive = true;

        }
    }

    public void DespawnCross()
    {
        if (crossActive)
        {
            //the destination of the guard is the cross hair location
            crossHairLocation = coinCross.transform.position;
            tempCoin = Instantiate(droppedCoin, crossHairLocation, Quaternion.identity);
            CoinDropSFX.Play();

            //you threw the coin
            coinThrown = true;

            //timer begins
            timer.SetActive(true);

            //disable crosshair
            Destroy(coinCross);
            Destroy(coinCrossBoundary);

            //give control back to player
            player.gameObject.GetComponent<PlayerMovement>().enabled = true;
            player.gameObject.GetComponentInChildren<PlayerInteraction>().enabled = true;
            crossActive = false;

            StartCoroutine(DespawnCoinRoutine());
        }
    }

    void Update()
    {
        //if the player presses enter
        if (Input.GetKeyDown(KeyCode.Return))
        {
            DespawnCross();
        }
    }
    
    IEnumerator DespawnCoinRoutine()
    {
        yield return new WaitForSeconds(10f);
        Destroy(tempCoin);
    }
}
