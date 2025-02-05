using System;
using UnityEngine;

public class destroyPuddle : MonoBehaviour
{   
    public float requiredDuration = 2.5f;
    public float timer = 0f;

    bool isOnPuddle = false;
    private Vector3 initialScale;

    private void Start()
    {
        initialScale = transform.localScale;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            isOnPuddle = true;
            print("On Puddle");
        }
    }
    private void OnTriggerExit(Collider other)
    {   
        if(other.CompareTag("Player")){
            isOnPuddle = false;
            print("Out of Puddle");
            timer = 0f;
        }
    }

    void Update()
    {  
        if(isOnPuddle){
            timer += Time.deltaTime;
            if(timer >= requiredDuration){
                float currentScaleX = transform.localScale.x;
                if(currentScaleX > 2){
                    ShrinkPuddle();
                } else {
                    Destroy(gameObject);
                }
                timer = 0f;
            }
        }
    }
    public void ShrinkPuddle()
    {
        transform.localScale = new Vector3(transform.localScale.x - 1.5f * Time.deltaTime, transform.localScale.y, transform.localScale.z - 1.5f * Time.deltaTime);
        // transform.localScale = new Vector3(-(transform.localScale.x - amount), transform.localScale.y, -(transform.localScale.z - amount));
    }
}
