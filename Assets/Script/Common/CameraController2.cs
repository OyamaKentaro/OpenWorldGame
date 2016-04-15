using UnityEngine;
using System.Collections;

public class CameraController2 : MonoBehaviour {
    public float m_Height = 15.0f;  // カメラの高さ.
    public float m_playDistanceRatioWidht = 0.5f; // x遊びの画面割合.
    public float m_playDistanceRatioHeight = 0.5f;  // x遊びの画面割合.
    public float m_offsetXRatio = 0.0f; // オフセット位置の画面割合.
    public float m_offsetYRatio = 0.0f; // オフセット位置の画面割合.
    public GameObject m_traceTarget = null; // トレス対象.
    Camera m_controllCamera = null; // カメラ.

    // Use this for initialization
    void Start () {
        m_controllCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update () {
        if (m_traceTarget == null || m_controllCamera == null)
        {
            return;
        }

        Vector3 pos = transform.position;
        Vector3 posScreenPos = m_controllCamera.WorldToScreenPoint(pos);
        Vector3 targetPos = m_traceTarget.transform.position;
        Vector3 targetScreenPos = m_controllCamera.WorldToScreenPoint(targetPos);
        float playWidht = Screen.width * m_playDistanceRatioWidht;
        float playHeight = Screen.height * m_playDistanceRatioHeight;
        float screenWidhtHalf = Screen.width * 0.5f;
        float screenHeightHalf = Screen.height * 0.5f;
        
        //if () {
          //  pos.x = targetPos.x;
        //}
        pos.y = m_Height;
        //pos.z = targetPos.z;
        transform.position = pos;
    }
}
