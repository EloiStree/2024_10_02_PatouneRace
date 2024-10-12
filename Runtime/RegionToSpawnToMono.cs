using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionToSpawnToMono : MonoBehaviour
{
    public Transform m_regionCenter;
    public Transform m_regionTopFrontRight;

    public void GiveRandomPosition(out Vector3 worldPosition)
    {

        Vector3 direction = m_regionTopFrontRight.position - m_regionCenter.position;
        Vector3 random = new Vector3(Random.Range(-direction.x, direction.x), Random.Range(-direction.y, direction.y), Random.Range(-direction.z, direction.z));

        Vector3 relocated = m_regionCenter.rotation* random;

        worldPosition = m_regionCenter.position + relocated;




    }
}
