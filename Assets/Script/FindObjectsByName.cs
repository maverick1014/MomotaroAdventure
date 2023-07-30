using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindObjectsByName : MonoBehaviour
{
    [SerializeField] private string targetObjectName;

    void OnMouseDown()
    {
        GameObject[] objectsWithSameName = GameObject.FindGameObjectsWithTag(targetObjectName);

        if(objectsWithSameName.Length == 1){
            Debug.Log("Win");
        }
    }
}