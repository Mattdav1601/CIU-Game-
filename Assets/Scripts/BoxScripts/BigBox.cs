using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

public class BigBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BigBoxStand")
        {
            GameManager.instance.bigBoxPlaced = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "BigBoxStand")
        {
            GameManager.instance.bigBoxPlaced = false; 
        }
    }
}
