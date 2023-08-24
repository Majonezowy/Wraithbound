using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject flashlight;

    public AudioSource turnOn;
    public AudioSource turnOff;

    [Header("Keybinds")]
    public KeyCode flashlightKey = KeyCode.F;

    private bool isOn;

    void Start()
    {
        isOn = true;
        flashlight.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(flashlightKey))
        {
            if (isOn)
            {
                flashlight.SetActive(false);
                Debug.Log("Flashlight off");
                turnOff.Play();
            }
            else
            {
                flashlight.SetActive(true);
                Debug.Log("Flashlight on");
                turnOn.Play();
            }
            isOn = !isOn;
        }
    }
}
