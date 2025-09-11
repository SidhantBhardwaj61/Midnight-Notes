using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] List<Transform> destinations;
    float wayPointIndex = 0;
    bool isWalking;
    NavMeshAgent ai;
    int rand1;

    void Start()
    {
        ai = GetComponent<NavMeshAgent>();
        ai.updateRotation = false;
        ai.updateUpAxis = false;
        isWalking = true;
        rand1 = Random.Range(0, destinations.Count - 1);
        ai.destination = destinations[rand1].position;
    }
}
