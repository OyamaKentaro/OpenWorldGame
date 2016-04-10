using UnityEngine;
using System.Collections;

// キーボードの入力からコマンドを発行する.
public class CmdPublisherKeyboard : MonoBehaviour {
    private Command m_command;

    // Use this for initialization
    void Start () {
        m_command = GetComponent<MovementBase>();
    }

    // Update is called once per frame
    void Update () {
        bool isInput = false;

        if (Input.GetKey(KeyCode.A))
        {
            m_command.AddCommand(cmd.CommandID.ID_MOVE_LEFT);
            isInput = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            m_command.AddCommand(cmd.CommandID.ID_MOVE_DOWN);
            isInput = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            m_command.AddCommand(cmd.CommandID.ID_MOVE_RIGHT);
            isInput = true;
        }

        if (Input.GetKey(KeyCode.W))
        {
            m_command.AddCommand(cmd.CommandID.ID_MOVE_UP);
            isInput = true;
        }

        if (Input.GetKeyDown("space"))
        {
            m_command.AddCommand(cmd.CommandID.ID_JUMP);
            isInput = true;
        }

        if (!isInput)
        {
            m_command.AddCommand(cmd.CommandID.ID_NO_INPUT);
        }
    }
}
