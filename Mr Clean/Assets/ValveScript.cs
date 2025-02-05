using System;
using System.Globalization;
using Unity.Mathematics;
using UnityEngine;

public class ValveScript : MonoBehaviour
{
    public GameObject puddlePrefab;
    private GameObject currentPuddle;

    private bool isOpen = false;
    private int numberOfPuddles = 0;

    private float timeToOpen;
    private float timer = 0;

    void Start()
    {
        System.Random rnd = new System.Random();
        timeToOpen = rnd.Next(1, 20);
    }

    // Update is called once per frame
    void Update()
    {
        timer += 0.05f*Time.time;
        if(timer >= timeToOpen && numberOfPuddles < 1){
            isOpen = true;
            numberOfPuddles++;
        }
        if(isOpen){
            SpawnPuddle();
        }
    }
    void SpawnPuddle(){
        if(currentPuddle == null){
            Vector3 spawnPosition = new Vector3 (transform.position.x, 0, transform.position.z);
            currentPuddle = Instantiate(puddlePrefab, spawnPosition, Quaternion.identity);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            isOpen = false;
        }
    }
}
