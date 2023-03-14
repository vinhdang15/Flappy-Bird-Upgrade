using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public  float        backGroundSpeed = 1f;
    
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    
    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(backGroundSpeed * Time.deltaTime, 0);
    }
}