using UnityEngine;
using System.Collections;

public enum ScrollType
{
    TYPE_XY,
    TYPE_XZ,
};

public class CameraController : MonoBehaviour {
    public ScrollType m_type = ScrollType.TYPE_XY;
    private static float m_sizeMax = 100.0f;
    private static float m_sizeMin = 0.5f;
    private static float m_scrollSpeedRatio = 0.00325f;

    private Vector3 m_startDragWarldPosition;    // ドラッグ開始した時点でのワールド位置.
    private Vector3 m_startDrag2DPosition;       // ドラッグ開始した時点でのスクリーン位置.
    private Vector3 m_startDragCameraPotision;   // ドラッグ開始した時点でのカメラ位置.
    private float m_size;                        // 映すサイズ.
    private float m_sizeOld;                     // 1frame前のサイズ.
    private Camera m_camera;

    // Use this for initialization
    void Start () {
        m_size = m_sizeOld = 5.0f;
        m_camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update () {
        // マウス位置アップデート
        UpdateMousePosition();

        // ズームインアウト.
        ZoomInOut();

        // カメラアップデート
        UpdateCamera();
    }

    // マウス位置アップデート
    private void UpdateMousePosition() {
        // 押された瞬間.
        if (Input.GetMouseButtonDown(0)) {
            m_startDrag2DPosition = Input.mousePosition;
            m_startDragWarldPosition = m_camera.ScreenToWorldPoint(m_startDrag2DPosition);
            m_startDragCameraPotision = transform.localPosition;
        }
    }

    private void ZoomInOut() {
        m_sizeOld = m_size;
        m_size -= Input.GetAxis("Mouse ScrollWheel") * 5.0f;

        if (m_size < m_sizeMin) {
            m_size = m_sizeMin;
        } else if (m_size > m_sizeMax) {
            m_size = m_sizeMax;
        }
    }

    // カメラアップデート.
    private void UpdateCamera() {
        // 移動.
        if (Input.GetMouseButton(0)) {
            switch (m_type)
            {
                case ScrollType.TYPE_XY:
                    {
                        Vector3 difference = (m_startDrag2DPosition - Input.mousePosition) * m_size * m_scrollSpeedRatio;
                        transform.localPosition = m_startDragCameraPotision + difference;

                        m_camera.orthographicSize = m_size;
                    }
                    break;

                case ScrollType.TYPE_XZ:
                    {
                        Vector3 difference = (m_startDrag2DPosition - Input.mousePosition) * m_size * m_scrollSpeedRatio;
                        Vector3 pos = m_startDragCameraPotision + new Vector3(difference.x, 0.0f, difference.y);
                        pos.y = m_size;
                        transform.localPosition = pos;
                    }
                    break;
            }
        }

        // ズーム.
        switch (m_type)
        {
            case ScrollType.TYPE_XY:
                {
                    m_camera.orthographicSize = m_size;
                }
                break;

            case ScrollType.TYPE_XZ:
                {
                    Vector3 pos = transform.localPosition;
                    pos.y = m_size;
                    transform.localPosition = pos;
                }
                break;
        }

#if false
        // ズームによる移動.
        if (m_size < m_sizeOld) {
            float zoomRatioOld = m_sizeOld / m_sizeMax;
            float zoomRatioNew = m_size / m_sizeMax;
            float moovRatio = zoomRatioOld - zoomRatioNew;
            Debug.Log(zoomRatioOld);
            Debug.Log(zoomRatioNew);
            Debug.Log(moovRatio);

            Vector3 centerPos = new Vector3(UnityEngine.Screen.width * 0.5f, UnityEngine.Screen.height * 0.5f, 0.0f);
            Vector3 targetVector = (Input.mousePosition - centerPos).normalized;
            float length = Vector3.Distance(Input.mousePosition, centerPos) / zoomRatioOld;


            transform.localPosition += targetVector * length * moovRatio * 0.01f;
        }
#endif
    }
}
