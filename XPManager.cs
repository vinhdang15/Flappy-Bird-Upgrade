using System;
using System.Collections.Generic;
using UnityEngine;

public class XPManager : MonoBehaviour
{
    public        GameObject       starBar;
    public static Action           updateXP = delegate {  };
    public        List<GameObject> listXP;
    public        int              currentXP;
    public        int              targetXP = 3;
    public        int              level;
    public void OnEnable()
    {
        updateXP  += AddXP;
        currentXP =  0;
        level     =  0;
        for (int i = 0; i < listXP.Count; i++)
        {
            listXP[i].SetActive(false);
        }
    }

    public void AddXP()
    {
        starBar.SetActive(true);
        currentXP++;
        if (level < 2)
        {
            if (currentXP >= targetXP)
            {
                currentXP = 0;
                level++;
            }
        
            for (int i = listXP.Count-1; i >= 0; i--)
            {
                listXP[i].SetActive( i < currentXP);
            }
        }
        if (level >= 2)
        {
            for (int i = listXP.Count-1; i >= 0; i--)
            {
                listXP[i].SetActive( true);
            }
        }

    }

    public void OnDisable()
    {
        updateXP += AddXP;
    }
}
