using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Startingtext: MonoBehaviour
{
    public GameObject StartRoom;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void textDisplay()
    {
        StartRoom.SetActive(true);

    }

        public void textStop()
    {
        StartRoom.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            textDisplay();
        }
    }


        private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            textStop();
        }
    }
}
