using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeCheckpointGroupMono : MonoBehaviour
{

    public RandomizeCheckpointItemMono[] m_whatToRandomized;
    public bool m_randomizeOnStart = false;
    public bool m_randomizeOnEnable = false;

    private void Start()
    {
        if (m_randomizeOnStart)
        {
            RandomizePositionAllItems();
        }
    }

    private void OnEnable()
    {
        if (m_randomizeOnEnable)
        {
            RandomizePositionAllItems();
        }
    }

    [ContextMenu("Randomized All Items")]
    public void RandomizePositionAllItems()
    {
        foreach (var item in m_whatToRandomized)
        {
            if (item != null)
                item.RandomizePosition();
        }
    }
}
