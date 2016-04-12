using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace cmd
{
    public enum CommandID
    {
        ID_MOVE_LEFT,
        ID_MOVE_RIGHT,
        ID_MOVE_DOWN,
        ID_MOVE_UP,
        ID_MOVE_FREE,
        ID_JUMP,

        /*
        ID_SIT_DOWN,
        ID_ATTACK,
        ID_DAMAGE,
        */
    }
}

public class Command : MonoBehaviour {
    public struct CommandData
    {
        public cmd.CommandID id;
        public int intWork;
        public float floatWork;
        public Vector3 vectorWork;
    }

    List<CommandData> m_stack;
    bool m_commandExecute = false;

    public virtual void Start () {
        m_stack = new List<CommandData>();
    }

    public virtual void Update () {
        m_commandExecute = false;
        foreach (CommandData data in m_stack)
        {
            ExecuteCommand(data);
            m_commandExecute = true;
        }

        m_stack.Clear();
    }

    public void AddCommand(CommandData command)
    {
        m_stack.Add(command);
    }

    public bool IsCommandExecute()
    {
        return m_commandExecute;
    }

    protected virtual void ExecuteCommand(CommandData command) {}
}
