using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCheckpointMono : MonoBehaviour
{
    public GameObject m_whatToDisable;
    public bool m_useDebug;
    

    public void Display()
    {
        if(m_useDebug)
        Debug.Log("Display", this.gameObject);
        m_whatToDisable.SetActive(true);
    }
    public void Hide()
    {
        if (m_useDebug)
            Debug.Log("Hide", this.gameObject);
        m_whatToDisable.SetActive(false);
    }
}
