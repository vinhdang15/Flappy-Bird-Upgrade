using Unity.VisualScripting;
using UnityEngine;

public class TranformObject : MonoBehaviour
{
    public float speed = 4f;
    public float leftEdge;

    void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }
    private void Update()
    {
        // transform.position += Vector3.left * speed * Time.smoothDeltaTime;
        transform.Translate(Vector3.left * speed * Time.smoothDeltaTime);
        
        if (transform.position.x < leftEdge)
        {
            // gameObject.SetActive(false);
            Destroy(gameObject);
        }
        
    }
}

