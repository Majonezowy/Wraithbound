﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public Animator door;
    public GameObject openText;
    public GameObject closeText;
    public AudioSource doorSound;

    private bool inReach;
    private bool Open;
    private bool Closed;


    void Start()
    {
        inReach = false;
        Open = false;
        Closed = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach" && Closed)
        {
            inReach = true;
            openText.SetActive(true);
        }
        if (other.gameObject.tag == "Reach" && Open)
        {
            inReach = true;
            closeText.SetActive(true);            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
            closeText.SetActive(false);
        }
    }
    void Update()
    {
        if (inReach && Closed && Input.GetButtonDown("Interact"))
        {
            Debug.Log("It Opens");
            door.SetBool("Open", true);
            door.SetBool("Closed", false);
            doorSound.Play();
            Open = true;
            Closed = false;
            
        }
        else if (inReach && Open && Input.GetButtonDown("Interact"))
        {
            Debug.Log("It Closes");
            door.SetBool("Open", false);
            door.SetBool("Closed", true);
            doorSound.Play();
            Open = false;
            Closed = true;
        }

    }

}