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

        ID_NO_INPUT,
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

    public virtual void Start () {
        m_stack = new List<CommandData>();
    }

    public virtual void Update () {
        int count = 0;
        foreach (CommandData data in m_stack)
        {
            Debug.Log(count);
            ++count;
            ExecuteCommand(data);
        }

        m_stack.Clear();
    }

    public void AddCommand(CommandData command)
    {
        m_stack.Add(command);
    }

    protected virtual void ExecuteCommand(CommandData command) {}
}
