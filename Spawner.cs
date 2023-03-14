using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public           GameObject ObjectPrefab;
    public           XPManager  m_xpManager;
    [SerializeField] float      BeginSpwam = 1f;
    [SerializeField] float      spwamRate  = 1f;
    [SerializeField] float      minHeight  = -1.5f;
    [SerializeField] float      maxHeight  = 1.5f;
    [SerializeField] bool       isStoppingAtLevel;
    [SerializeField] int        LevelCondition = 1;
    void OnEnable()
    {
        StartCoroutine(SpawnLoop());
    }

    public void OnDisable()
    {
        StopAllCoroutines();
    }

    public void Spawn()
    {
        GameObject Item = Instantiate(ObjectPrefab, transform.position, Quaternion.identity);
        Item.transform.parent   =  this.transform;
        Item.transform.position += Vector3.up * UnityEngine.Random.Range(minHeight, maxHeight);
        GameManager.OnAddObject(Item);
    }

    private IEnumerator SpawnLoop()
    {
        yield return new WaitForSeconds(BeginSpwam);
        while (true)
        {
            if (isStoppingAtLevel)
            {
                if (m_xpManager.level <= LevelCondition)
                {
                    Spawn();
                }
                Debug.Log(m_xpManager.level);
            }
            else
            {
                Spawn();
            }
            
            yield return new WaitForSeconds(spwamRate);
        }
    }
}   
