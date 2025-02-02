using UnityEngine;

public class destroyPuddle : MonoBehaviour
{   
    public float requiredDuration = 3f;
    public float timer = 0f;
    bool isOnPuddle = false;

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            isOnPuddle = true;
            print("On Puddle");
        }
    }
    /// <summary>
    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    private void OnTriggerExit(Collider other)
    {   
        if(other.CompareTag("Player")){
            isOnPuddle = false;
            print("Out of Puddle");
            timer = 0f;
        }
    }

    // Update is called once per frame
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
