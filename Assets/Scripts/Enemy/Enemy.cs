using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [Header("Destinations")]
    [SerializeField] List<Transform> destinations;
    Animator animator;
    Transform currentDest;
    [SerializeField] GameObject player;
    [SerializeField] LayerMask playerMask;

    [Header("NavMesh")]
    bool isWalking;
    bool isChasing;
    NavMeshAgent ai;
    [SerializeField] float enemySpeed = 5f;
    [SerializeField] float chaseSpeed = 10f;
    [SerializeField] float sightDistance = 10f;
    [SerializeField] float catchDistance = 5f;

    [Header("WaitingTime")]
    [SerializeField] float idleTime;
    [SerializeField] float minIdleTime = 3f;
    [SerializeField] float maxIdleTime = 8f;
    [SerializeField] float chaseTime;
    [SerializeField] float minChaseTime = 3f;
    [SerializeField] float maxChaseTime = 8f;
    [SerializeField] float jumpscareTime = 2f;

    [Header("Distraction")]
    [SerializeField] CoinSpawner spawnedCoin;

    [Header("RandomVariables")]
    int random1;

    void Start()
    {
        animator = GetComponent<Animator>();
        ai = GetComponent<NavMeshAgent>();
        ai.updateRotation = false;
        ai.updateUpAxis = false;
        isWalking = true;
        random1 = Random.Range(0, destinations.Count - 1);
        ai.destination = destinations[random1].position;
        ai.speed = enemySpeed;
    }

    void Update()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        Vector2 velocity = ai.velocity;
        animator.SetFloat("Horizontal", velocity.x);
        animator.SetFloat("Vertical", velocity.y);
        animator.SetFloat("Speed", velocity.magnitude);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, sightDistance, playerMask);
        Debug.DrawRay(transform.position, direction, Color.green);
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            isWalking = false;
            StopCoroutine(IdleRoutine());
            StopCoroutine(ChaseRoutine());
            StartCoroutine(ChaseRoutine());
            isChasing = true;
        }

        //if the coin is thrown while walking
        if (!isChasing && spawnedCoin.coinThrown)
        {
            animator.speed = 1.5f;
            ai.ResetPath();
            ai.destination = spawnedCoin.crossHairLocation;
            ai.speed = chaseSpeed;
            float guardToCoinDist = Vector2.Distance(transform.position, spawnedCoin.crossHairLocation);
            if (guardToCoinDist <= ai.stoppingDistance)
            {
                ai.speed = 0;
                StopCoroutine(IdleRoutine());
                StartCoroutine(IdleRoutine());
                isWalking = false;
                spawnedCoin.coinThrown = false;
            }
        }

        if (isChasing)
        {
            ai.destination = player.transform.position;
            ai.speed = chaseSpeed;
            animator.speed = 1.5f;
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if (distanceToPlayer <= catchDistance)
            {
                player.SetActive(false);
                StartCoroutine(DeathRoutine());
                isChasing = false;
            }
        }

        if (isWalking && !spawnedCoin.coinThrown)
        {
            animator.speed = 1f;
            ai.destination = destinations[random1].position;
            ai.speed = enemySpeed;
            if (ai.remainingDistance <= ai.stoppingDistance)
            {
                ai.speed = 0;
                StopCoroutine(IdleRoutine());
                StartCoroutine(IdleRoutine());
                isWalking = false;
            }
        }

    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.SetActive(false);
            StartCoroutine(DeathRoutine());
            isChasing = false;
        }
    }

    IEnumerator IdleRoutine()
    {
        idleTime = Random.Range(minIdleTime, maxIdleTime);
        yield return new WaitForSeconds(idleTime);
        random1 = Random.Range(0, destinations.Count - 1);
        ai.destination = destinations[random1].position;
        isWalking = true;
    }

    IEnumerator ChaseRoutine()
    {
        chaseTime = Random.Range(minChaseTime, maxChaseTime);
        yield return new WaitForSeconds(chaseTime);
        isWalking = true;
        isChasing = false;
        random1 = Random.Range(0, destinations.Count - 1);
        ai.destination = destinations[random1].position;
    }

    IEnumerator DeathRoutine()
    {
        yield return new WaitForSeconds(jumpscareTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
