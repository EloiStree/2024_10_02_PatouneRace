using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnCheckPointCollisionMono : MonoBehaviour
{
    public UnityEvent m_onTriggerEnter;
    public UnityEvent m_onTriggerExit;
    public UnityEvent m_onColliderEnter;
    public UnityEvent m_onColliderExit;

    public bool m_useTrigger;
    public bool m_useCollider;

    public LayerMask m_layerMask;
  

    bool IsGameObjectInLayerMask(GameObject gameObject, LayerMask layerMask)
    {
        // The layer of the GameObject is represented as a bit mask.
        int objectLayerMask = 1 << gameObject.layer;

        // Perform a bitwise AND between the layer mask and the object's layer mask.
        return (layerMask.value & objectLayerMask) != 0;
    }
    public void OnTriggerEnter(Collider other)
    {
        if(!m_useTrigger)
            return;
        if(!IsGameObjectInLayerMask(other.gameObject, m_layerMask))
            return;
        m_onTriggerEnter.Invoke();
    }
    public void OnTriggerExit(Collider other)
    {
        if (!m_useTrigger)
            return;
        if (!IsGameObjectInLayerMask(other.gameObject, m_layerMask))
            return;
        m_onTriggerExit.Invoke();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (!m_useCollider)
            return;
        if (!IsGameObjectInLayerMask(collision.gameObject, m_layerMask))
            return;
        m_onColliderEnter.Invoke();
    }

    public void OnCollisionExit(Collision collision)
    {
        if (!m_useCollider)
            return;
        if (!IsGameObjectInLayerMask(collision.gameObject, m_layerMask))
            return;
        m_onColliderExit.Invoke();
    }
}
