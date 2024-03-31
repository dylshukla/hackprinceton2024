using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class JoystickLocomotion : MonoBehaviour
{

public Rigidbody player;
public float speed;

public List<GameObject> waypoints;
int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var joystickAxis = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick,OVRInput.Controller.LTouch);
        float fixedY = player.position.y;

        player.position += (transform.right * joystickAxis.x + transform.forward * joystickAxis.y) * Time.deltaTime * speed;
        player.position = new Vector3(player.position.x,fixedY, player.position.z);

        if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger))
        {
            player.transform.position = new Vector3(2,1,-2);

            Vector3 destination = waypoints[index].transform.position;
            Vector3 newPos = Vector3.MoveTowards(transform.position, waypoints[index].transform.position, speed * Time.deltaTime);
            transform.position = newPos;

            float distance = Vector3.Distance(transform.position, destination);
            if (distance <= .05)
            {
                index += 1;
            }
        }

        if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
        {
            player.transform.position = new Vector3(-2,1,3);

            Vector3 destination = waypoints[index].transform.position;
            Vector3 newPos = Vector3.MoveTowards(transform.position, waypoints[index].transform.position, speed * Time.deltaTime);
            transform.position = newPos;

            float distance = Vector3.Distance(transform.position, destination);
            if (distance <= .05)
            {
                index += 1;
            }

        }
    }
}
