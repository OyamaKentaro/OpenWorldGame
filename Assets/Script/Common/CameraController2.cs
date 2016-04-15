using UnityEngine;
using System.Collections;

public class CameraController2 : MonoBehaviour {
    static float m_criteriaHeight = 15.0f; // カメラの高さ基準.
    public float m_Height = m_criteriaHeight;  // カメラの高さ.
    public float m_playDistanceRatio = 0.5f; // 遊びの画面割合.
    public float m_offsetXRatio = 0.0f; // オフセット位置の画面割合.
    public float m_offsetYRatio = 0.0f; // オフセット位置の画面割合.
    public GameObject m_traceTarget = null; // トレス対象.
    public float m_speed = 1.0f;
    Camera m_controllCamera = null; // カメラ.
    float m_screenSizeMin = 100;

    Vector3 m_work = new Vector3();

    // Use this for initialization
    void Start () {
        m_controllCamera = GetComponent<Camera>();
        m_screenSizeMin = Mathf.Min(Screen.width, Screen.height);
    }

    // Update is called once per frame
    void Update () {
        if (m_traceTarget == null || m_controllCamera == null)
        {
            return;
        }

        Vector3 pos = transform.position;
        Vector3 targetPos = m_traceTarget.transform.position;
        Vector3 targetScreenPos = m_controllCamera.WorldToScreenPoint(targetPos);
        targetScreenPos.z = 0.0f;
        m_work.x = Screen.width * 0.5f;
        m_work.y = Screen.height * 0.5f;
        m_work.z = 0.0f;

        float playDistance = m_screenSizeMin * m_playDistanceRatio;
        if (Vector3.Distance(targetScreenPos, m_work) > playDistance)
        {
            Vector3 cameraWorldPos = m_controllCamera.ScreenToWorldPoint(targetScreenPos);
            cameraWorldPos.y = targetPos.y;
            float distance = Vector3.Distance(cameraWorldPos, targetPos);
            pos += (targetPos - cameraWorldPos).normalized * m_speed * (m_Height / m_criteriaHeight) * Time.deltaTime;
        }

        pos.y = m_Height;
        transform.position = pos;
    }
}
