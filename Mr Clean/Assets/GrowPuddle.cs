using UnityEngine;

public class SimpleScale : MonoBehaviour
{
    public float growthRate = 0.5f; // How fast the object grows
    public float maxScaleX = 5f;
    public float maxScaleZ = 5f;
    private Vector3 initialScale;
     public float requiredDuration = 2.5f;
    public float timer = 0f;
    bool isOnPuddle = false;
    void Start()
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
                ShrinkPuddle();
            } else {
                GrowPuddle();
            }
        } else {
            GrowPuddle();
        }
    }
    private void GrowPuddle(){
        float newScaleX = Mathf.Min(transform.localScale.x + growthRate * Time.deltaTime, maxScaleX);
        float newScaleZ = Mathf.Min(transform.localScale.z + growthRate * Time.deltaTime, maxScaleZ);

        transform.localScale = new Vector3(newScaleX, initialScale.y, newScaleZ);   
    }
    public void ShrinkPuddle()
    {
        transform.localScale = new Vector3(transform.localScale.x - 1.5f * Time.deltaTime, transform.localScale.y, transform.localScale.z - 1.5f * Time.deltaTime);
        // transform.localScale = new Vector3(-(transform.localScale.x - amount), transform.localScale.y, -(transform.localScale.z - amount));
        if(transform.localScale.x < 1f){
            Destroy(gameObject);
        }
    }
}
