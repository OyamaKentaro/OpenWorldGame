using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    int m_frame = 0;
    float m_gameTime = 0.0f;
    float m_gameTimeOld = 0.0f;
    float m_gameDelta = 0.0f;
    float m_gameSpeed = 1.0f;
    float m_gravity = 9.8f;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
        UpdateGameTime();
    }

    void UpdateGameTime()
    {
        ++m_frame;
        m_gameTimeOld = m_gameTime;
        m_gameTime += Time.deltaTime * m_gameSpeed;
        m_gameDelta = m_gameTime - m_gameTimeOld;
    }

    public int GetFrame()
    {
        return m_frame;
    }

    public float GetTime()
    {
        return m_gameTime;
    }

    public float GetDeltaTime()
    {
        return m_gameDelta;
    }

    public void SetGameSpeed(float speed)
    {
        m_gameSpeed = speed;
    }

    public float GetGameSpeed()
    {
        return m_gameSpeed;
    }

    public float GetGravity()
    {
        return m_gravity;
    }
}
