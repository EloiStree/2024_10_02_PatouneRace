using UnityEngine;
using UnityEngine.Events;

public class HiddenPatouneItemMono : MonoBehaviour {

    [Header("Display Patoune")]
    public UnityEvent m_whatToHideToHavePatoune;
    public UnityEvent m_whatToDisplayToHavePatoune;
    [Header("Hide Patoune")]
    public UnityEvent m_whatToHideToHaveOrigin;
    public UnityEvent m_whatToDisplayToHaveOrigin;

    [ContextMenu("Hide patoune")]
    public void HidePatoune() { 
        m_whatToHideToHaveOrigin.Invoke();
        m_whatToDisplayToHaveOrigin.Invoke();
    }

    [ContextMenu("Display Patoune")]
    public void DisplayPatoune() { 
        m_whatToHideToHavePatoune.Invoke();
        m_whatToDisplayToHavePatoune.Invoke();
    }
}
