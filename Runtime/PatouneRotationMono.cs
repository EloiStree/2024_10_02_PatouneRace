using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatouneRotationMono : MonoBehaviour
{
    public Transform m_whatToRotate;
    public float m_rotationSpeed = 120;
    public Vector3 m_axis = Vector3.up;

    private void Reset()
    {
            m_whatToRotate = transform;
    }

    void Update()
    {
        m_whatToRotate.Rotate(m_axis, m_rotationSpeed * Time.deltaTime);
        
    }
}
