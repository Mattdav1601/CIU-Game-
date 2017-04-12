using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManagement
{
    public class GameManager : MonoBehaviour
    {
        public float mGender;
        public float fGender;

        public float mObjects;
        public float fObjects;
        public int objectCount = 3;

        public int hobbyCount = 1;
        public int jobCount = 1;

        public bool male;
        public bool female;
        public bool neutral;

        public bool bigBoxPlaced;
        public bool smallBoxPlaced;
        public bool fStageComplete;

        public static GameManager instance = null;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

        // Use this for initialization
        void Start()
        {
            mGender = 0;
            fGender = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if (objectCount <= 0 && hobbyCount <= 0 && jobCount <= 0)
            {
                if (mGender > fGender)
                {
                    male = true;
                }

                if (mGender < fGender)
                {
                    female = true;
                }

                if (mGender == fGender)
                {
                    neutral = true;
                }
            }

            if (bigBoxPlaced == true && smallBoxPlaced == true)
            {
                fStageComplete = true;
            }
        }
    }
}
