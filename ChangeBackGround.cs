using System;
using UnityEngine;

public class ChangeBackGround : MonoBehaviour
{
    public Material[]  listMaterials;
    Renderer           usingRenderer;
    public GameObject  BackGround;
    public GameObject  transfer;
    public GameObject  snow;
    public GameManager GameManager;
    public Vector3     transferPositionStart = new Vector3(19, 0, 7);
    public float       TranferSpeed          = 2.15f;
    float              leftEdge;
    public int         conditionScore;
    
    public void Awake()
    {
        usingRenderer                = BackGround.GetComponent<MeshRenderer>();
        usingRenderer.sharedMaterial = listMaterials[0];
        
        transfer.SetActive(false);
        snow.SetActive(false);
        transfer.transform.localPosition = transferPositionStart;
        leftEdge                         = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 10f;
    }

    public void Update()
    {
        if (GameManager.score >= conditionScore && transfer.transform.position.x > leftEdge)
        {
            transfer.SetActive(true);
            transfer.transform.position += Vector3.left * TranferSpeed * Time.deltaTime;
        }
        
        if (transfer.transform.position.x + 18f < 0)
        {
            snow.SetActive(true);
            
        }

        if (transfer.transform.position.x < 0f && transfer.transform.position.x > -1f )
        {
            usingRenderer.sharedMaterial = listMaterials[1];
        }
    }

    public void OnEnable()
    {
        transfer.SetActive(true);
        usingRenderer.sharedMaterial     = listMaterials[0];
        transfer.transform.localPosition = transferPositionStart;
        snow.SetActive(false);
    }

    public void OnDisable()
    {
        // transfer.SetActive(false);
    }
}