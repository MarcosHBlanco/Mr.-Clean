using System;
using UnityEngine;

public class destroyPuddle : MonoBehaviour
{   
    public float requiredDuration = 3f;
    public float timer = 0f;
    public float minScale = 3f;
    bool isOnPuddle = false;
    private Vector3 initialScale;

    private void Start(){
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
                if(currentScaleX > 3){
                    ShrinkPuddle(3f);
                } else {
                    Destroy(gameObject);
                }
                timer = 0f;
            }
        }
    }
    public void ShrinkPuddle(float amount){
        // float newScaleX = Mathf.Max(transform.localScale.x - amount, minScale);
        // float newScaleZ = Mathf.Max(transform.localScale.z - amount, minScale);

        transform.localScale = new Vector3(transform.localScale.x - amount, transform.localScale.y, transform.localScale.z - amount);
    }
}
