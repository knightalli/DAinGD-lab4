using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private int numberType;
    private Material material;
    [SerializeField] private int numberTrigger;
    [SerializeField] private Material[] materials;

    void Start()
    {
        material = gameObject.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (SceneManager.GetActiveScene().buildIndex == 0) ORScene();
        if (SceneManager.GetActiveScene().buildIndex == 1) ANDScene();
        if (SceneManager.GetActiveScene().buildIndex == 2) NANDScene();
        if (SceneManager.GetActiveScene().buildIndex == 3) XORScene();
        Destroy(other.gameObject);
    }

    private void ORScene()
    {
        if (numberType == 0)
        {
            if (numberTrigger == 0) material.color = materials[0].color;
            else if (numberTrigger == 1) material.color = materials[1].color;
        }

        if (numberType == 1)
        {
            if (numberTrigger == 0) material.color = materials[1].color;
            else if (numberTrigger == 1) material.color = materials[1].color;
        }
    }

    private void ANDScene()
    {
        if (numberType == 0)
        {
            if (numberTrigger == 0) material.color = materials[0].color;
            else if (numberTrigger == 1) material.color = materials[0].color;
        }

        if (numberType == 1)
        {
            if (numberTrigger == 0) material.color = materials[0].color;
            else if (numberTrigger == 1) material.color = materials[1].color;
        }
    }

    private void NANDScene()
    {
        if (numberType == 0)
        {
            if (numberTrigger == 0) material.color = materials[1].color;
            else if (numberTrigger == 1) material.color = materials[1].color;
        }

        if (numberType == 1)
        {
            if (numberTrigger == 0) material.color = materials[1].color;
            else if (numberTrigger == 1) material.color = materials[0].color;
        }
    }

    private void XORScene()
    {
        if (numberType == 0)
        {
            if (numberTrigger == 0) material.color = materials[0].color;
            else if (numberTrigger == 1) material.color = materials[1].color;
        }

        if (numberType == 1)
        {
            if (numberTrigger == 0) material.color = materials[1].color;
            else if (numberTrigger == 1) material.color = materials[0].color;
        }
    }
}
