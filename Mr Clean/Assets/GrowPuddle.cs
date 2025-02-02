using UnityEngine;

public class SimpleGrow : MonoBehaviour
{
    public float growthRate = 1f; // Growth rate in units per second
    public Vector3 growthDirection = new Vector3(1, 0, 1); // Direction of growth (x and z axes)
    public float maxWidth = 10f; // Maximum width the object can grow
    public float maxDepth = 10f; // Maximum depth the object can grow

    private BoxCollider boxCollider;

    void Start()
    {
        // Get the BoxCollider component
        boxCollider = GetComponent<BoxCollider>();
        if (boxCollider == null)
        {
            Debug.LogError("No BoxCollider attached to this object!");
        }
    }

    void Update()
    {
        // Grow the collider's size
        Vector3 newSize = boxCollider.size;

        // Increase size in x and z directions (no growth in y-axis)
        newSize.x += growthRate * Time.deltaTime * growthDirection.x;
        newSize.z += growthRate * Time.deltaTime * growthDirection.z;

        // Clamp size to maximum limits
        newSize.x = Mathf.Min(newSize.x, maxWidth);
        newSize.z = Mathf.Min(newSize.z, maxDepth);

        // Apply the new size to the collider
        boxCollider.size = newSize;

        // Offset the position so growth happens in the desired direction
        Vector3 newCenter = boxCollider.center;
        newCenter.x += (growthRate * Time.deltaTime * growthDirection.x) / 2;
        newCenter.z += (growthRate * Time.deltaTime * growthDirection.z) / 2;
        boxCollider.center = newCenter;
    }
}
