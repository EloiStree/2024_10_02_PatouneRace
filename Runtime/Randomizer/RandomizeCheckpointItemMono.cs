using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeCheckpointItemMono : MonoBehaviour
{

    public Transform m_startPoint;
    public Transform m_whatToMove;
    public float m_radiusFromStartPoint = 2f;
    public bool m_onlyOnXZ = true;
    public bool m_randomizeOnStart = false;
    public bool m_randomizeOnEnable = false;

    private void Start()
    {
        if (m_randomizeOnStart)
        {
            RandomizePosition();
        }
    }

    private void OnEnable()
    {
        if (m_randomizeOnEnable)
        {
            RandomizePosition();
        }
    }


    [ContextMenu("Randomize Position")]
    public void RandomizePosition()
    {

        if (m_startPoint == null)
            return;
        if(m_whatToMove == null)
            return;

        Vector3 randomPos = m_startPoint.position +
            UnityEngine.Random.insideUnitSphere * m_radiusFromStartPoint;

        if (m_onlyOnXZ)
        {
            randomPos.y = m_whatToMove.position.y;
        }
        m_whatToMove.position = randomPos;
    }

}
