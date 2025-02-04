using UnityEngine;

public class SimpleScale : MonoBehaviour
{
    public float growthRate = 0.5f; // How fast the object grows
    public float maxScaleX = 5f;
    public float maxScaleZ = 5f;
    private Vector3 initialScale;
    void Start()
    {
       initialScale = transform.localScale;
    }

    void Update()
    {
        float newScaleX = Mathf.Min(transform.localScale.x + growthRate * Time.deltaTime, maxScaleX);
        float newScaleZ = Mathf.Min(transform.localScale.z + growthRate * Time.deltaTime, maxScaleZ);

        transform.localScale = new Vector3(newScaleX, initialScale.y, newScaleZ);    
    }
}
