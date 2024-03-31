using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class HW5Prob5b : MonoBehaviour
{

    public GameObject headtracker;
    public GameObject lhandtracker;
    public GameObject rhandtracker;
    public GameObject head;
    public GameObject lhand;
    public GameObject rhand;
    public GameObject ball;
    Rigidbody m_Rigidbody;
    public float m_push = 200f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = headtracker.transform.position;
        Quaternion q = headtracker.transform.rotation;
        // pos.z = 1.5f + pos.z;
        // q.x = -q.x;
        // q.y = -q.y;
        head.transform.position = pos;
        head.transform.rotation = q;

        // Vector3 Lpos = lhandtracker.transform.position;
        // Quaternion Lq = lhandtracker.transform.rotation;
        // Lpos.z = 1.5f - Lpos.z;
        // Lq.x = -Lq.x;
        // Lq.y = -Lq.y;
        // lhand.transform.position = Lpos;
        // lhand.transform.rotation = Lq;

        // Vector3 Rpos = rhandtracker.transform.position;
        // Quaternion Rq = rhandtracker.transform.rotation;
        // Rpos.z = 1.5f - Rpos.z;
        // Rq.x = -Rq.x;
        // Rq.y = -Rq.y;
        // rhand.transform.position = Rpos;
        // rhand.transform.rotation = Rq;


        rhand.transform.localScale = new Vector3(0.1f, 0.05f, 0.2f + OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger));
        lhand.transform.localScale = new Vector3(0.1f, 0.05f, 0.2f + OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger));

        if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
        {
            m_Rigidbody.AddForce(0,0,m_push, ForceMode.Impulse);
            Debug.Log("Trigger Pressed");
        }

        if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger))
        {
            ball.transform.position = rhand.transform.position;
            Vector3 vel = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RHand);
            vel.z = -vel.z;
            ball.GetComponent<Rigidbody>().velocity = vel;
        }

        
    }

}
