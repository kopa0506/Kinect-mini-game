using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;

public class BodyView : MonoBehaviour {
    public GameObject BobySourceManager;
    public GameObject LeftHand; //7
    public GameObject RightHand; //11
    private Vector3 L_position;
    private Vector3 R_position;
    private Body[] BodyData;
    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        BodyData = BobySourceManager.GetComponent<BodySourceManager>().GetBodies();
        foreach (var body in BodyData)
        {
            if (body == null)
            {
                continue;
            }

            if (body.IsTracked)
            {
                L_position = new Vector3(body.Joints[JointType.HandLeft].Position.X * 10,
                    body.Joints[JointType.HandLeft].Position.Y * 10,
                    body.Joints[JointType.HandLeft].Position.Z * 10);
                R_position = new Vector3(body.Joints[JointType.HandRight].Position.X * 10,
                    body.Joints[JointType.HandRight].Position.Y * 10,
                    body.Joints[JointType.HandRight].Position.Z * 10);

                LeftHand.transform.position = L_position;
                RightHand.transform.position = R_position;
            }
        }

    }
}