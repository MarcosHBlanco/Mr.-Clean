using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FillTank : MonoBehaviour
{   
    // public GameObject TankPrefab;

    public float tankCapacity = 100f;
    public float tankFill = 0;
    public float tankFillSpeed = 2f;
    private bool isOnPuddle = false;
    private GameObject currentPuddle;
    public Image fillBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnPuddle)
        {
            tankFill += tankFillSpeed * Time.deltaTime;
            tankFill = Mathf.Clamp(tankFill, 0, tankCapacity);
            Debug.Log("Tank is " + tankFill + "% filled");
        } 
        if(isOnPuddle && currentPuddle == null){
            isOnPuddle = false;
        }
        if(fillBar != null){
            fillBar.fillAmount = tankFill / tankCapacity;
        }
    }
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Puddle")){
            currentPuddle = other.gameObject;
            Debug.Log(currentPuddle);
            isOnPuddle = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Puddle")){
            isOnPuddle = false;
            currentPuddle = null;
        }
    }
}
