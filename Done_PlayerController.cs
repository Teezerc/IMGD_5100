using UnityEngine;
using System.Collections;
using extOSC;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class Done_PlayerController : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Done_Boundary boundary;

	public GameObject shot1;
    public GameObject shot2;
    public GameObject shot3;

    public Transform shotSpawn1;
    public Transform shotSpawn2;
    public Transform shotSpawn3;
	public float fireRate;
	 
	private float nextFire;

    OSCReceiver osc;

    private void Start()
    {
        osc = this.gameObject.GetComponent<OSCReceiver>();
        osc.Bind("/3/xy", onMessage1);
        osc.Bind("/3/toggle1", onMessage2);
        osc.Bind("/3/toggle2", onMessage3);
        osc.Bind("/4/xy", onMessage4);
        osc.Bind("/4/toggle1", onMessage5);
        osc.Bind("/4/toggle2", onMessage6);
    }

    /*void Update ()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource>().Play ();
		}
	}*/

    void onMessage1(OSCMessage msg1)
    {
        Debug.LogFormat("msg {0}", msg1);
        float horizontal;
        float vertical;
        horizontal = msg1.Values[0].FloatValue-0.5f;
        vertical = 0.5f-msg1.Values[1].FloatValue;
        float moveHorizontal = horizontal;
        float moveVertical = vertical;
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement * speed;
    }
    void onMessage2(OSCMessage msg2)
    {
        Debug.LogFormat("msg {0}", msg2);
        float stu;
        stu = msg2.Values[0].FloatValue;
        if(stu>=1&&Time.time>nextFire)
        {
            nextFire= Time.time + fireRate;
            Instantiate(shot1, shotSpawn1.position, shotSpawn1.rotation);
            Instantiate(shot2, shotSpawn2.position, shotSpawn2.rotation);
            GetComponent<AudioSource>().Play();
        }
    }
    void onMessage3(OSCMessage msg3)
    {
        Debug.LogFormat("msg {0}", msg3);
        float stu;
        stu = msg3.Values[0].FloatValue;
        if (stu >= 1 && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot3, shotSpawn3.position, shotSpawn3.rotation);
            GetComponent<AudioSource>().Play();
        }
    }
    void onMessage4(OSCMessage msg4)
    {
        Debug.LogFormat("msg {0}", msg4);
        float horizontal;
        float vertical;
        horizontal = msg4.Values[0].FloatValue - 0.5f;
        vertical = 0.5f - msg4.Values[1].FloatValue;
        float moveHorizontal = horizontal;
        float moveVertical = vertical;
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement * speed;
    }
    void onMessage5(OSCMessage msg5)
    {
        Debug.LogFormat("msg {0}", msg5);
        float stu;
        stu = msg5.Values[0].FloatValue;
        if (stu >= 1 && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot1, shotSpawn1.position, shotSpawn1.rotation);
            Instantiate(shot2, shotSpawn2.position, shotSpawn2.rotation);
            GetComponent<AudioSource>().Play();
        }
    }
    void onMessage6(OSCMessage msg6)
    {
        Debug.LogFormat("msg {0}", msg6);
        float stu;
        stu = msg6.Values[0].FloatValue;
        if (stu >= 1 && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot3, shotSpawn3.position, shotSpawn3.rotation);
            GetComponent<AudioSource>().Play();
        }
    }
    void FixedUpdate ()
	{
		//float moveHorizontal = Input.GetAxis ("Horizontal");
        //float moveVertical = Input.GetAxis ("Vertical");

		//Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		//GetComponent<Rigidbody>().velocity = movement * speed;
		
		GetComponent<Rigidbody>().position = new Vector3
		(
			Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
		);
		
		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}
}
