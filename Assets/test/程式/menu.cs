using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Windows.Kinect;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {
    public Vector3 PosStart = new Vector3(0, -10, 0);
    public Vector3 PosExit = new Vector3(0, -90, 0);
    private KinectSensor _sensor;
    private BodyFrameReader _bodyFrameReader;
    private Body[] _bodies = null;
    public static menu instance = null;
    private float oldhandy = 0;
    private float time;
    private float deltaT = 0.08f;
    private float threshold = 0.2f;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
            Destroy(gameObject);
        Application.targetFrameRate = 60;
    }
    void Start () {
        _sensor = KinectSensor.GetDefault();

        if (_sensor != null)
        {
            _bodyFrameReader = _sensor.BodyFrameSource.OpenReader();

            if (!_sensor.IsOpen)
            {
                _sensor.Open();
            }

            _bodies = new Body[_sensor.BodyFrameSource.BodyCount];
        }
    }

    // Update is called once per frame
    void Update () {
        if (_bodyFrameReader != null)
        {
            var frame = _bodyFrameReader.AcquireLatestFrame();

            if (frame != null)
            {
                time += Time.deltaTime;
                frame.GetAndRefreshBodyData(_bodies);

                foreach (var body in _bodies.Where(b => b.IsTracked))
                {
                    
                    if (time > deltaT)
                    {

                        //print(oldhandy - body.Joints[JointType.HandRight].Position.Y);

                        if (oldhandy == 0)
                        {
                            oldhandy = body.Joints[JointType.HandRight].Position.Y;
                        }
                        else
                        {
                            if(oldhandy - body.Joints[JointType.HandRight].Position.Y > threshold)
                            {
                                HandDown();
                                oldhandy = body.Joints[JointType.HandRight].Position.Y;
                            }
                            else if(oldhandy - body.Joints[JointType.HandRight].Position.Y < -threshold)
                            {
                                HandUp();
                                oldhandy = body.Joints[JointType.HandRight].Position.Y;
                            }
                        }
                        time = 0;
                    }
                    if (body.HandLeftConfidence == TrackingConfidence.High && body.HandLeftState == HandState.Lasso)
                    {
                        if (this.transform.localPosition == PosStart)
                        {
                            SceneManager.LoadScene("easy", LoadSceneMode.Single);
                        }
                           
                        else
                            Application.Quit();
                    }
                }
                frame.Dispose();
                frame = null;
            }
        }
    }
    void HandDown()
    {
        if(this.transform.localPosition == PosStart)
        {
            this.transform.localPosition = PosExit;
        }
    }
    void HandUp()
    {
        if (this.transform.localPosition == PosExit)
        {
            this.transform.localPosition = PosStart;
        }
    }
}
