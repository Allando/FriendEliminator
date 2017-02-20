using System;
using UnityEngine;

public class speedUpScript : MonoBehaviour
{
    public DateTime DateTime;
    public Rigidbody2D rb;

    // Use this for initialization
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {

    }
}