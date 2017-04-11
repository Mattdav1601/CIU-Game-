using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

public class Detection : MonoBehaviour
{
    [SerializeField]
    private float reachDistance = 2.0f;

    [SerializeField]
    private GameObject crossHairPrefab;
    private GameObject crossHairPrefabInstance;

    [SerializeField]
    private GameObject maleExit;
    [SerializeField]
    private GameObject femaleExit;

    [SerializeField]
    private GameObject selectText;

	// Use this for initialization
	void Start ()
    {
        crossHairPrefabInstance = Instantiate(crossHairPrefab);
        crossHairPrefabInstance.transform.SetParent(transform, true);
	}
	
	// Update is called once per frame
	void Update ()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, reachDistance))
        {
            if (hit.collider.tag == "FemaleObject" || hit.collider.tag == "MaleObject")
            {
                selectText.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E) && hit.collider.tag == "MaleObject" && GameManager.instance.objectCount > 0)
                {
                    GameManager.instance.objectCount -= 1;
                    GameManager.instance.mObjects += 1;
                    Destroy(hit.collider.gameObject);
                }

                if (Input.GetKeyDown(KeyCode.E) && hit.collider.tag == "FemaleObject" && GameManager.instance.objectCount > 0)
                {
                    GameManager.instance.objectCount -= 1;
                    GameManager.instance.fObjects += 1;
                    Destroy(hit.collider.gameObject);
                }
            }

            else
            {
                selectText.SetActive(false);
            }

            if (hit.collider.tag == "fWorkBox" && GameManager.instance.jobCount > 0 || hit.collider.tag == "mWorkBox" && GameManager.instance.jobCount > 0)
            {
                selectText.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E) && hit.collider.tag == "fWorkBox")
                {
                    GameManager.instance.fGender += 1;
                    GameManager.instance.jobCount -= 1;
                }

                if (Input.GetKeyDown(KeyCode.E) && hit.collider.tag == "mWorkBox")
                {
                    GameManager.instance.mGender += 1;
                    GameManager.instance.jobCount -= 1;
                }
            }

            if (hit.collider.tag == "fHobbyBox" && GameManager.instance.hobbyCount > 0 || hit.collider.tag == "mHobbyBox" && GameManager.instance.hobbyCount > 0)
            {
                selectText.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E) && hit.collider.tag == "fHobbyBox")
                {
                    GameManager.instance.fGender += 1;
                    GameManager.instance.hobbyCount -= 1;
                }

                if (Input.GetKeyDown(KeyCode.E) && hit.collider.tag == "mHobbyBox")
                {
                    GameManager.instance.mGender += 1;
                    GameManager.instance.hobbyCount -= 1;
                }
            }
        }
        Debug.DrawRay(ray.origin, ray.direction * reachDistance, Color.blue);
	}

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "MaleExit")
        {
            GameManager.instance.mGender += 1;
            Destroy(other.gameObject);
            Destroy(femaleExit);
        }

        if (other.gameObject.tag == "FemaleExit")
        {
            GameManager.instance.fGender += 1;
            Destroy(other.gameObject);
            Destroy(maleExit);
        }

        if (other.gameObject.tag == "Stage2Exit")
        {
            if (GameManager.instance.fObjects > GameManager.instance.mObjects && GameManager.instance.objectCount <= 0)
            {
                GameManager.instance.fGender += 1;
            }
            else if (GameManager.instance.mObjects > GameManager.instance.fObjects && GameManager.instance.objectCount <= 0)
            {
                GameManager.instance.mGender += 1;
            }

            Destroy(other.gameObject);
        }
    }
}
