
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhettoTeleport : MonoBehaviour
{

    private float sensitivity = 5.0f;

    // Use this for initialization
    void Start()
    {
        loadPrefs();
    }

    void OnApplicationQuit()
    {
            
    }

    void savePrefs()
    {
        //transform
        PlayerPrefs.SetFloat("ObjectPositionX", transform.position.x);
        PlayerPrefs.SetFloat("ObjectPositionY", transform.position.y);
        PlayerPrefs.SetFloat("ObjectPositionZ", transform.position.z);


        // scales
        PlayerPrefs.SetFloat("ObjectScaleX", transform.localScale.x);
        PlayerPrefs.SetFloat("ObjectScaleY", transform.localScale.y);
        PlayerPrefs.SetFloat("ObjectScaleZ", transform.localScale.z);


        // rotation
        PlayerPrefs.SetFloat("ObjectRotationX", transform.eulerAngles.x);
        PlayerPrefs.SetFloat("ObjectRotationY", transform.eulerAngles.y);
        PlayerPrefs.SetFloat("ObjectRotationZ", transform.eulerAngles.z);

        PlayerPrefs.SetFloat("ObjectSensitivity", sensitivity);
    }

    void loadPrefs()
    {

        //transform
        transform.position = new Vector3(
        PlayerPrefs.GetFloat("ObjectPositionX"),
        PlayerPrefs.GetFloat("ObjectPositionY"),
        PlayerPrefs.GetFloat("ObjectPositionZ")
        );

        //scale
        transform.localScale = new Vector3(
        PlayerPrefs.GetFloat("ObjectScaleX"),
        PlayerPrefs.GetFloat("ObjectScaleY"),
        PlayerPrefs.GetFloat("ObjectScaleZ"));

        // rotation
        transform.eulerAngles = new Vector3(
        PlayerPrefs.GetFloat("ObjectRotationX"),
        PlayerPrefs.GetFloat("ObjectRotationY"),
        PlayerPrefs.GetFloat("ObjectRotationZ")
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
            transform.Rotate(Vector3.up * Time.deltaTime * sensitivity, Space.World);
            Debug.Log("q key was pressed.");
        }

        if (Input.GetKey("e"))
        {
            transform.Rotate(-Vector3.up * Time.deltaTime * sensitivity, Space.World);
            Debug.Log("e key was pressed.");
        }

        if (Input.GetKey("k"))
        {
            Debug.Log("Ghetto Teleport saved to PlayerPrefs.");
            savePrefs();
        }

        if (Input.GetKey("l"))
        {
            Debug.Log("Ghetto Teleport load from PlayerPrefs.");
            loadPrefs();
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
    }
}
