using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAtRandomPositionRegionMono : MonoBehaviour
{

    public Transform m_whatToMove;
    public RegionToSpawnToMono [] m_regions;

    public bool m_moveEnabled = true;

    public void OnEnable()
    {
        if (m_moveEnabled)
        {
            MoveAtRandomPosition();
        }
    }

    [ContextMenu("Move To Random Position")]
    public void MoveAtRandomPosition()
    {
        if(m_regions.Length == 0)
        {
            return;
        }
        int randomIndex = Random.Range(0, m_regions.Length);
        m_regions[randomIndex].GiveRandomPosition(out Vector3 worldPosition);
        m_whatToMove.position = worldPosition;

    }
}
