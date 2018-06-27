
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhettoTeleport : MonoBehaviour
{
    private float sensitivity = 0.1f;
    private bool isDisplayingSensitivity = false;

    [Tooltip("Name of the pref (each object should be different")]
    [SerializeField]
    private string prefName;
	
	[SerializeField]
	private bool loadPreferencesOnLoad;

    // points to teleport to 
    public Transform[] positions;
    // Use this for initialization
    void Start()
    {
        // load saved prefs by default
        if(loadPreferencesOnLoad) loadPrefs();
        // Debug.Log(sensitivity);
        if (prefName == "") prefName = gameObject.name; //gameObject.name
    }

    void OnApplicationQuit()
    {

    }

    void savePrefs()
    {
        //transform
        PlayerPrefs.SetFloat(prefName+"ObjectPositionX", transform.position.x);
        PlayerPrefs.SetFloat(prefName+"ObjectPositionY", transform.position.y);
        PlayerPrefs.SetFloat(prefName+"ObjectPositionZ", transform.position.z);


        // scales
        PlayerPrefs.SetFloat(prefName+"ObjectScaleX", transform.localScale.x);
        PlayerPrefs.SetFloat(prefName+"ObjectScaleY", transform.localScale.y);
        PlayerPrefs.SetFloat(prefName+"ObjectScaleZ", transform.localScale.z);


        // rotation
        PlayerPrefs.SetFloat(prefName+"ObjectRotationX", transform.eulerAngles.x);
        PlayerPrefs.SetFloat(prefName+"ObjectRotationY", transform.eulerAngles.y);
        PlayerPrefs.SetFloat(prefName+"ObjectRotationZ", transform.eulerAngles.z);

        PlayerPrefs.SetFloat(prefName+"ObjectSensitivity", sensitivity);
    }

    void loadPrefs()
    {

        //transform
        transform.position = new Vector3(
        PlayerPrefs.GetFloat(prefName+"ObjectPositionX"),
        PlayerPrefs.GetFloat(prefName+"ObjectPositionY"),
        PlayerPrefs.GetFloat(prefName+"ObjectPositionZ")
        );

        //scale
        transform.localScale = new Vector3(
        PlayerPrefs.GetFloat(prefName+"ObjectScaleX"),
        PlayerPrefs.GetFloat(prefName+"ObjectScaleY"),
        PlayerPrefs.GetFloat(prefName+"ObjectScaleZ"));

        // rotation
        transform.eulerAngles = new Vector3(
        PlayerPrefs.GetFloat(prefName+"ObjectRotationX"),
        PlayerPrefs.GetFloat(prefName+"ObjectRotationY"),
        PlayerPrefs.GetFloat(prefName+"ObjectRotationZ")
        );

        sensitivity = PlayerPrefs.GetFloat("ObjectSensitivity");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * sensitivity);
            Debug.Log("w key was pressed.");
        }

        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * Time.deltaTime * sensitivity);
            Debug.Log("s key was released.");
        }

        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * Time.deltaTime * sensitivity);
            Debug.Log("a key was pressed.");
        }

        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * Time.deltaTime * sensitivity);
            Debug.Log("d key was released.");
        }

        if (Input.GetKey("r"))
        {
            transform.Translate(Vector3.up * Time.deltaTime * sensitivity);
            Debug.Log("r key was pressed.");
        }

        if (Input.GetKey("f"))
        {
            transform.Translate(Vector3.down * Time.deltaTime * sensitivity);
            Debug.Log("f key was released.");
        }

        if (Input.GetKey("q"))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * sensitivity * 3, Space.World);
            Debug.Log("q key was pressed.");
        }

        if (Input.GetKey("e"))
        {
            transform.Rotate(-Vector3.up * Time.deltaTime * sensitivity * 3, Space.World);
            Debug.Log("e key was pressed.");
        }

        if (Input.GetKey("k"))
        {
            Debug.Log("Ghetto Teleport saved to PlayerPrefs. Object: "+prefName);
            savePrefs();
        }

        if (Input.GetKey("l"))
        {
            Debug.Log("Ghetto Teleport load from PlayerPrefs.");
            loadPrefs();
        }

        if (Input.GetKey("0"))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (Input.GetKey("8"))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (Input.GetKey("9"))
        {
            transform.eulerAngles = new Vector3(0, 90, 0);
        }

        if (Input.GetKeyDown("p"))
        {
            isDisplayingSensitivity = !isDisplayingSensitivity;
        }

        if (Input.GetKey(KeyCode.KeypadPlus))
        {
            sensitivity += .1f;
            Debug.Log(sensitivity);
        }

        if (Input.GetKey(KeyCode.KeypadMinus))
        {
            if (sensitivity > 0.0f)
                sensitivity -= .1f;
            else
                sensitivity = 0.0f;

            Debug.Log(sensitivity);
        }

        // Teleport to positions
        for (int i=0; i < positions.Length; i++)
        {
            if (Input.GetKey((i+1).ToString()))
                transform.position = positions[i].position;
        }
       
    }

 

    void OnGUI()
    {
        if (isDisplayingSensitivity)
            GUI.Label(new Rect(10, 40, 200, 100), "sensitivity: " + sensitivity);
    }
}
