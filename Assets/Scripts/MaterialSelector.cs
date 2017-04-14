using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSelector : MonoBehaviour
{
    public Material[] materials;
    public Renderer renderer;

	// Use this for initialization
	void Start ()
    {
        renderer = GetComponent<Renderer>();

        renderer.material = materials[Random.Range(0, materials.Length)];
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ChangeMaterial()
    {
        renderer.material = materials[Random.Range(0, materials.Length)];
    }
}
