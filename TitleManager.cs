using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class TitleManager : MonoBehaviour
{
    public XPManager       m_xpManager;
    public TextMeshProUGUI text;

    public List<string> list = new List<string>();
    public void Start()
    {
        // text = FindObjectOfType<TextMeshProUGUI>();
        text = GetComponent<TextMeshProUGUI>();
    }

    public void Update()
    {
        if (m_xpManager.level == 0)
        {
            text.text = list[0];
        }else if (m_xpManager.level == 1)
        {
            text.text = list[1];
        }else if (m_xpManager.level == 2)
        {
            text.text = list[2];
        }
        
    }
}
