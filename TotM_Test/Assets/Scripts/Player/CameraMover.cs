using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _speed;
    [SerializeField] private int _distanceCamera;
    void Start()
    {
        transform.position = new Vector3()
        {
            x = _player.transform.position.x,
            y = _player.transform.position.y,
            z = _player.transform.position.z - _distanceCamera



        }; 
    }

    void Update()
    {
        transform.position = Vector3.Lerp(
            transform.position,
            new Vector3 (
                _player.transform.position.x, 
                _player.transform.position.y,
                _player.transform.position.z - _distanceCamera),
            _speed * Time.deltaTime);
        
    }
}
