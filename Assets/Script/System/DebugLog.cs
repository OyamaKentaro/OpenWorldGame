using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DebugLog : MonoBehaviour {
    static int INDEX_MAX = 12;
    List<string> m_logText = new List<string>();
    int m_index = 0;
    bool m_isDirty = true;
    Rect m_rect = new Rect(10, 10, 150, 200);
    string m_text;
    bool m_hyde = true;

    public void EnableViewLog()
    {
        m_hyde = false;
    }

    public void DesableViewLog()
    {
        m_hyde = true;
    }

    // Use this for initialization
    void Start () {
        m_text = "";
    }

    // Update is called once per frame
    void Update () {
        if (m_isDirty)
        {
            m_isDirty = false;

            m_text = "";
            foreach (string str in m_logText)
            {
                m_text += str;
                m_text += "\n";
            }
        }
    }

    void OnGUI ()
    {
        if (m_hyde)
        {
            return;
        }
        GUI.TextField(m_rect, m_text);
    }

    public void AddLog(string str)
    {
        m_isDirty = true;

        if (m_index < INDEX_MAX)
        {
            // 末尾に追加.
            m_logText.Add(str);
            ++m_index;
        } else
        {
            // 末尾に追加.
            m_logText.Add(str);

            // 表示できないので先頭を削除.
            m_logText.RemoveRange(0, 1);
        }
    }
}
