using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRow : MonoBehaviour
{
    public string description;

    public Vector3 finPos;
    private float speedMove = 10.0f;

    private void Awake()
    {
        finPos = this.transform.position;
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position != finPos)
        {
            transform.position = Vector3.Lerp(transform.position, finPos, speedMove*Time.deltaTime);
        }
    }
}
