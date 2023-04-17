using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameManager : MonoBehaviour
{
    [SerializeField] private TrailRenderer line;
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private WaypointSO waypoints;
    [SerializeField] private int waypointIndex;
    [SerializeField] private float minDis;
    [SerializeField] private Transform startPos;
    [SerializeField] private Vector3 lastPos;
    [SerializeField] private Transform goalPos;
    [SerializeField] private bool isMoving;

    public float speed;

    private void Start()
    {
        //Moves the object to the starting position;
        
        line = gameObject.GetComponentInChildren<TrailRenderer>();
        particleSystem = gameObject.GetComponentInChildren<ParticleSystem>();
        
        lastPos = gameObject.transform.position;
        waypointIndex = 0;
        
        line.gameObject.SetActive(true);
        particleSystem.gameObject.SetActive(true);
        
        gameObject.transform.position = startPos.transform.position;
        
        goalPos = waypoints.transforms[waypointIndex + 1].GetComponent<Transform>();
    }

    public void TurnOff()
    {
        line.gameObject.SetActive(false);
        particleSystem.gameObject.SetActive(false);
    }

    public void TurnOn()
    {
        line.gameObject.SetActive(true);
        particleSystem.gameObject.SetActive(true);
    }

    private void MoveToPoint()
    {
        if (waypointIndex >= waypoints.transforms.Length)
        {
            waypointIndex = 0;
            TurnOff();
            transform.position = waypoints.transforms[waypointIndex].transform.position;
            
        }
        
        //Move to point [index] transform
        if(Vector3.Distance(waypoints.transforms[waypointIndex].transform.position, transform.position) > minDis)
        {
            isMoving = true;
            //Turns on the particle
            TurnOn();
            transform.position = Vector3.MoveTowards(transform.position, waypoints.transforms[waypointIndex].transform.position,
                Time.deltaTime * speed);
        }

        if (!(Vector3.Distance(waypoints.transforms[waypointIndex].transform.position, transform.position) < minDis)) return;
        waypointIndex++;
        //Turns off the particle
        isMoving = false;
        StartCoroutine(WaitForSeconds(3));
        TurnOff();



    }

    private IEnumerator WaitForSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
    

    private void Replay()
    {
        transform.position = lastPos;
        MoveToPoint();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        waypointIndex++;
        MoveToPoint();
    }

    private void Update()
    {
        MoveToPoint();
        
    }
}
