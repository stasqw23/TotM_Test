using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float _speedArrow;
    [SerializeField] private GameObject _animation;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(transform.up * _speedArrow* Time.deltaTime,Space.World);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "wall") || (collision.tag == "door"))
        {
            Destroy(gameObject);
        }
    }

}


