using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class CheckpointRaceMono : MonoBehaviour
{

    public GameObject[] m_checkpoints;
    
    public bool m_atLeastOneActive = false;
    public bool m_allCheckpointsDeactivated;
    private bool m_previousValue;
    public UnityEvent m_endRace;
    public UnityEvent m_startRace;

    public bool m_loadInSceneAtAwake = true;

    private void Awake()
    {
        if (m_loadInSceneAtAwake)
        {
            FetchCheckpointCurrentGame();
        }
        bool isOneActive = IsOneCheckPointActive();
        m_atLeastOneActive = isOneActive;
        m_previousValue = !isOneActive;
        m_allCheckpointsDeactivated = !isOneActive;
        if (m_allCheckpointsDeactivated)
        {
            m_endRace.Invoke();
        }
        else
        {
            m_startRace.Invoke();
        }
    }

    void Update()
    {

        bool isOneActive = IsOneCheckPointActive();
        m_atLeastOneActive = isOneActive;
        m_previousValue = m_allCheckpointsDeactivated;
        m_allCheckpointsDeactivated = !isOneActive;

        if (m_previousValue != m_allCheckpointsDeactivated)
        {
            if (m_allCheckpointsDeactivated) { 
                m_endRace.Invoke();
            }
            else
            {
                m_startRace.Invoke();
            }
        }


    }

    public bool IsOneCheckPointActive()
    {
        int i = 0;
        int stop_arrayLenght = m_checkpoints.Length;

        bool isOneActive = false;

        while (i < stop_arrayLenght)
        {
            if (m_checkpoints[i].activeSelf)
            {
                isOneActive = true;
                break;
            }
            i = i + 1;
        }
        return isOneActive;
    }

    [ContextMenu("Display All")]
    public void DisplayAll()
    {
        for (int i = 0; i < m_checkpoints.Length; i++)
        {
            m_checkpoints[i].SetActive(true);
        }
    }
    [ContextMenu("Hide All")]
    public void HideAll()
    {
        for (int i = 0; i < m_checkpoints.Length; i++)
        {
            m_checkpoints[i].SetActive(false);
        }
    }
    [ContextMenu("Random All")]
    public void RandomAll()
    {
        for (int i = 0; i < m_checkpoints.Length; i++)
        {
            bool random = Random.Range(0, 2) == 0;
            m_checkpoints[i].SetActive(random);
        }
    }


    [ContextMenu("Fetch Childers checkpoint")]
    public void FetchCheckpointInChilds()
    {
        Transform[] t = this.GetComponentsInChildren<Transform>(true);
        List<PointCheckpointMono> points = new List<PointCheckpointMono>();
        foreach (Transform tr in t)
        {
            PointCheckpointMono point = tr.GetComponent<PointCheckpointMono>();
            if (point != null)
            {
                points.Add(point);
            }
        }
        points = points.Distinct().ToList();
        m_checkpoints = new GameObject[points.Count];
        for (int i = 0; i < points.Count; i++)
        {
            m_checkpoints[i] = points[i].gameObject;
        }
    }

    [ContextMenu("Fetch in scene checkpoint.")]
    public void FetchCheckpointCurrentGame()
    {
        PointCheckpointMono[] points = FindObjectsByType<PointCheckpointMono>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
        m_checkpoints = points.Select(x => x.gameObject).Distinct().ToArray();
    }

    
}
