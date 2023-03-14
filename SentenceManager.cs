using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class SentenceManager : MonoBehaviour
{
    public XPManager       m_xpManager;
    public GameManager     m_gameManager;
    public TextMeshProUGUI text;
    int                    index;
    
    public List<string> box1     = new List<string>();
    public List<string> box2     = new List<string>();
    public List<string> box3     = new List<string>();
    public List<string> box1Temp = new List<string>();
    public List<string> box2Temp = new List<string>();
    public List<string> box3Temp = new List<string>();
    
    public void Awake()
    {
        text  = GetComponent<TextMeshProUGUI>();
    }

    public void OnEnable()
    {
        if (m_gameManager.score <= 7)
        {
            if (box1Temp.Count == 0)
            {
                box1Temp.AddRange(box1);
                index = Random.Range(0, box1Temp.Count);
            }
            else
            {
                index = Random.Range(0, box1Temp.Count);
            }

            text.text = box1Temp[index];
            box1Temp.RemoveAt(index);
        }
        else if (m_gameManager.score > 7 && m_gameManager.score >= 20)
        {
            if (box2Temp.Count == 0)
            {
                box2Temp.AddRange(box2);
                index = Random.Range(0, box2Temp.Count);
            }
            else
            {
                index = Random.Range(0, box2Temp.Count);
            }

            text.text = box2Temp[index];
            box2Temp.RemoveAt(index);
        }
        else
        {
            {
                if (box3Temp.Count == 0)
                {
                    box3Temp.AddRange(box3);
                    index = Random.Range(0, box3Temp.Count);
                }
                else
                {
                    index = Random.Range(0, box3Temp.Count);
                }

                text.text = box3Temp[index];
                box3Temp.RemoveAt(index);
            }
        }
    }
}


//Chaiyo, you can do better.
//It's a beautiful day, let's try again.
    
//Hello Tu, long time no see.
//Chaiyo, you can do better.
//Are you free for a coffee sometime in the next few weeks?

//Happy new year em.
//Just wanted to send you a smile today.
//I believe in you! And unicorns. But mostly you!