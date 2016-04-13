using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public GameObject m_debugLogObject = null;
    DebugLog m_debugLog = null;

    // Use this for initialization
    void Start () {
        if (m_debugLogObject)
        {
            m_debugLog = m_debugLogObject.GetComponent<DebugLog>();
        }
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void AddLog(string str)
    {
        if (m_debugLog)
        {
            m_debugLog.AddLog(str);
        }
    }
}
