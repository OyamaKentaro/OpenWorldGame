using UnityEngine;
using System.Collections;

public class PlayerMovement : MovementBase {
    public float m_maxSpeed = 1.0f;
    public float m_moveSpeed = 0.5f;
    private Vector3 m_work = new Vector3(); // new を減らすためのワーク.
    Rigidbody m_rigidbody;

    public override void Start()
    {
        base.Start();
        m_rigidbody = GetComponent<Rigidbody>();
    }

    public override void Update()
    {
        base.Update();
    }

    protected override void ExecuteCommand(cmd.CommandID command)
    {
        switch (command)
        {
            case cmd.CommandID.ID_MOVE_LEFT:
            {
                m_work = Vector3.zero;
                m_work.x = -1.0f * Time.deltaTime;
                AddVelocity(m_work);
                break;
            }

            case cmd.CommandID.ID_MOVE_RIGHT:
            {
                m_work = Vector3.zero;
                m_work.x = 1.0f * Time.deltaTime;
                AddVelocity(m_work);
                break;
            }

            case cmd.CommandID.ID_MOVE_DOWN:
            {
                m_work = Vector3.zero;
                m_work.z = -1.0f * Time.deltaTime;
                AddVelocity(m_work);
                break;
            }

            case cmd.CommandID.ID_MOVE_UP:
            {
                m_work = Vector3.zero;
                m_work.z = 1.0f * Time.deltaTime;
                AddVelocity(m_work);
                break;
            }

            case cmd.CommandID.ID_NO_INPUT:
            {
                BrakeVelocity();
                break;
            }

            default:
            {
                break;
            }
        }
    }

    private void AddVelocity(Vector3 velocity)
    {
        if (Vector3.Distance(velocity, Vector3.zero) <= 0.0f)
        {
            return;
        }

        float speed = Vector3.Distance(Vector3.zero, m_rigidbody.velocity);
        m_rigidbody.velocity += velocity.normalized * m_moveSpeed;

        m_work.x = m_rigidbody.velocity.x;
        m_work.y = 0.0f;
        m_work.z = m_rigidbody.velocity.z;

        float flatSpeed = Vector3.Distance(Vector3.zero, m_work);
        if (flatSpeed > m_maxSpeed)
        {
            m_work = m_work.normalized * m_maxSpeed;
            m_work.y = m_rigidbody.velocity.y;
            m_rigidbody.velocity = m_work;
        }
    }

    private void BrakeVelocity()
    {
        Vector3 velocity = m_rigidbody.velocity;
        velocity.x = 0.0f;
        velocity.z = 0.0f;
        m_rigidbody.velocity = velocity;
    }
}
