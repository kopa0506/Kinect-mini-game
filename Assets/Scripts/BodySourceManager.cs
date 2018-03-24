using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;
using System.Linq;

public class BodySourceManager : MonoBehaviour {

    private KinectSensor Sensor;
    private BodyFrameReader Reader;
    private Body[] BodyData = null;

    public Body[] GetBodies()
    {
        return BodyData;
    }

    void Start () {
        Sensor = KinectSensor.GetDefault();
        if (Sensor != null)
        {
            Reader = Sensor.BodyFrameSource.OpenReader();

            if (!Sensor.IsOpen)
            {
                Sensor.Open();
            }
            BodyData = new Body[Sensor.BodyFrameSource.BodyCount];
        }
    }

    void Update()
    {
        if (Reader != null)
        {
            var frame = Reader.AcquireLatestFrame();
            if (frame != null)
            {
                frame.GetAndRefreshBodyData(BodyData);
                foreach (var body in BodyData.Where(b => b.IsTracked))
                {
                    /*
                    IsAvailable = true;

                    if (body.HandRightConfidence == TrackingConfidence.High && body.HandRightState == HandState.Lasso)
                    {
                        IsFire = true;
                    }
                    else
                    {
                        PaddlePosition = RescalingToRangesB(-1, 1, -8, 8, body.Lean.X);
                        handXText.text = PaddlePosition.ToString();
                    }*/
                }
                frame.Dispose();
                frame = null;
            }
        }
    }

    void OnApplicationQuit()
    {
        if (Reader != null)
        {
            Reader.Dispose();
            Reader = null;
        }

        if (Sensor != null)
        {
            if (Sensor.IsOpen)
            {
                Sensor.Close();
            }

            Sensor = null;
        }
    }
}
