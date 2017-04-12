using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PickUp : MonoBehaviour
    {
        Detection detection;

        public Transform Player;

        public GameObject BigBox;
        public GameObject SmallBox;

        public Rigidbody bigBoxRb;
        public Rigidbody smallBoxRb;

        public bool holdingSomething;
        public bool droppedSomething;

        // Use this for initialization
        void Start()
        {
            bigBoxRb = GameObject.FindGameObjectWithTag("BigBox").GetComponent<Rigidbody>();
            smallBoxRb = GameObject.FindGameObjectWithTag("SmallBox").GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            bigBoxRb.isKinematic = true;
            smallBoxRb.isKinematic = true;

            if (Detection.instance.bigBoxPickUp == true)
            {
                if (Input.GetMouseButtonDown(0) && holdingSomething == false)
                {
                    BigBox.transform.parent = Player;
                    holdingSomething = true;
                }

                if (Input.GetMouseButtonDown(1) && holdingSomething == true)
                {
                    BigBox.transform.parent = null;
                    holdingSomething = false;
                    Detection.instance.bigBoxPickUp = false;
                }
            }

            if (Detection.instance.smallBoxPickUp == true)
            {
                if (Input.GetMouseButtonDown(0) && holdingSomething == false)
                {
                    SmallBox.transform.parent = Player;
                    holdingSomething = true;
                }

                if (Input.GetMouseButtonDown(1) && holdingSomething == true)
                {
                    SmallBox.transform.parent = null;
                    holdingSomething = false;
                    Detection.instance.smallBoxPickUp = false;
                }
            }
        }
    }
}
