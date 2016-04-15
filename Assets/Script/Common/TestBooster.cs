using UnityEngine;
using System.Collections;

public class TestBooster : MonoBehaviour {
    Rigidbody m_rigidBody = null;
    public Vector3 power = new Vector3();

    // Use this for initialization
    void Start () {
        m_rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {
        if (m_rigidBody == null)
        {
            return;
        }

        m_rigidBody.AddForce(power);
    }
}
