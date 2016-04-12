using UnityEngine;
using System.Collections;

namespace PublisherInput{
    public enum MouseState
    {
        STATE_NONE,
        STATE_DOWN,
        STATE_DRAG,
        STATE_UP,
    }
}

// 入力からコマンドを発行する.
public class CmdPublisherInput : MonoBehaviour {
    Command m_command;
    Command.CommandData m_commandWork = new Command.CommandData();
    PublisherInput.MouseState m_mouseState;
    Vector3 m_dragStartPos = new Vector3();
    Vector3 m_posWork = new Vector3();

    // Use this for initialization
    void Start () {
        m_command = GetComponent<MovementBase>();
        m_mouseState = PublisherInput.MouseState.STATE_NONE;
    }

    // Update is called once per frame
    void Update () {
        //UpdateKeybord();
        UpdateMouseState();
        UpdateMouse();
    }

    void UpdateMouseState() {
        bool down = false;
        bool keep = false;
        bool up = false;
        m_posWork = Vector3.zero;

        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer )
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                down = true;
                m_posWork = touch.position;
            } else if (touch.phase == TouchPhase.Stationary)
            {
                keep = true;
            } else if (touch.phase == TouchPhase.Ended)
            {
                up = true;
            }
        } else
        {
            if (Input.GetMouseButtonDown(0))
            {
                down = true;
            }

            if (Input.GetMouseButton(0))
            {
                keep = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                up = true;
            }

            m_posWork = Input.mousePosition;
        }

        switch (m_mouseState)
        {
            // 何も入力していない.
            case PublisherInput.MouseState.STATE_NONE:
                {
                    // 左クリックダウン.
                    if (down)
                    {
                        m_mouseState = PublisherInput.MouseState.STATE_DOWN;
                        Vector3 pos = m_posWork;
                        pos.z = 0.0f;
                        m_dragStartPos = pos;
                    }
                    break;
                }

            // キー押し込み.
            case PublisherInput.MouseState.STATE_DOWN:
                {
                    if (keep)
                    {
                        Vector3 pos = m_posWork;
                        pos.z = 0.0f;
                        if (pos != m_dragStartPos)
                        {
                            m_mouseState = PublisherInput.MouseState.STATE_DRAG;
                        }
                    } else
                    {
                        m_mouseState = PublisherInput.MouseState.STATE_UP;
                    }
                    break;
                }

            // ドラッグ.
            case PublisherInput.MouseState.STATE_DRAG:
                {
                    if (up)
                    {
                        m_mouseState = PublisherInput.MouseState.STATE_UP;
                    }
                    break;
                }

            // キーリリース.
            case PublisherInput.MouseState.STATE_UP:
                {
                    m_mouseState = PublisherInput.MouseState.STATE_NONE;
                    break;
                }
        }
    }

    void UpdateMouse()
    {
        switch (m_mouseState)
        {
            case PublisherInput.MouseState.STATE_DRAG:
                {
                    // このマウスの判定はいらんだろうけど一応ね.
                    if (Input.GetMouseButton(0))
                    {
                        Vector3 pos = m_posWork;
                        pos.z = 0.0f;

                        m_commandWork.id = cmd.CommandID.ID_MOVE_FREE;
                        m_commandWork.vectorWork = pos - m_dragStartPos;
                        m_command.AddCommand(m_commandWork);
                    }
                    break;
                }
        }
    }

    void UpdateKeybord() {
        if (Input.GetKey(KeyCode.A))
        {
            m_commandWork.id = cmd.CommandID.ID_MOVE_LEFT;
            m_command.AddCommand(m_commandWork);
        }

        if (Input.GetKey(KeyCode.S))
        {
            m_commandWork.id = cmd.CommandID.ID_MOVE_DOWN;
            m_command.AddCommand(m_commandWork);
        }

        if (Input.GetKey(KeyCode.D))
        {
            m_commandWork.id = cmd.CommandID.ID_MOVE_RIGHT;
            m_command.AddCommand(m_commandWork);
        }

        if (Input.GetKey(KeyCode.W))
        {
            m_commandWork.id = cmd.CommandID.ID_MOVE_UP;
            m_command.AddCommand(m_commandWork);
        }

        if (Input.GetKeyDown("space"))
        {
            m_commandWork.id = cmd.CommandID.ID_JUMP;
            m_command.AddCommand(m_commandWork);
        }
    }
}
