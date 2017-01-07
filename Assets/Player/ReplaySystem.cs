using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {

    private const int bufferFrames = 100;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];
    private Rigidbody rigidBody;
    private GameManager GameManager;
    private bool LastFrameMade = false; 


	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        GameManager = FindObjectOfType<GameManager>();

    }
	
	// Update is called once per frame
	void Update () {
        if (GameManager.recording)
        {
            Record();
        }
        else if (LastFrameMade)
        {
            PlayBack(); 
        }
     
          //  PlayBack();

	}

    void PlayBack()
    {
        rigidBody.isKinematic = true;
        int frame = Time.frameCount % bufferFrames;
        print("Reading frame " + frame);
        transform.position = keyFrames[frame].position;
        transform.rotation = keyFrames[frame].rotation;
    }

    void Record()
    {
        rigidBody.isKinematic = false;
        int frame = Time.frameCount % bufferFrames;
        print("Writing frame " + frame);
        if (Time.frameCount % bufferFrames == bufferFrames - 1)
        {
            LastFrameMade = true; 
        }
        float time = Time.time;
       // print("Writing fram " + frame);

        keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
    }
}

public class MyKeyFrame
{
    public float FrameTime;
    public Vector3 position;
    public Quaternion rotation;
    public MyKeyFrame(float aTime, Vector3 aPosition, Quaternion aRotation)
    {
        FrameTime = aTime;
        position = aPosition;
        rotation = aRotation;
    }
}
