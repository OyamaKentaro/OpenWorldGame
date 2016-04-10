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
        public int frame; 
    }

    List<CommandData> m_stack;

    public virtual void Start () {
        m_stack = new List<CommandData>();
    }

    public virtual void Update () {
        foreach (CommandData data in m_stack)
        {
            ExecuteCommand(data.id);
        }

        m_stack.Clear();
    }

    public void AddCommand(cmd.CommandID command)
    {
        CommandData data = new CommandData();
        data.id = command;
        data.frame = 0;
        m_stack.Add(data);
    }

    protected virtual void ExecuteCommand(cmd.CommandID command) {}
}
