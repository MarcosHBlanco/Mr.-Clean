using UnityEngine;

public class destroyPuddle : MonoBehaviour
{   
    public float requiredDuration = 3f;
    public float timer = 0f;
    bool isOnPuddle = false;

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
                Destroy(gameObject);
            }
        }
    }
}
