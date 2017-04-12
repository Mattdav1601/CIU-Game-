using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

public class SmallBox : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SmallBoxStand")
        {
            GameManager.instance.smallBoxPlaced = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "SmallBoxStand")
        {
            GameManager.instance.smallBoxPlaced = false;
        }
    }
}
