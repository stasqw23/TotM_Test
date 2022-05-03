using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Сrossbow : MonoBehaviour
{
    [SerializeField] private float _rotetionSpeed;
    [SerializeField] private float _biasZ;
    [SerializeField] private GameObject _arrowSpawner;
    [SerializeField] private GameObject _arrow;
    [SerializeField] private float _timeSpawnArrow;
    [SerializeField] private GameObject _arrowContainer;
    private bool _flagArrow = true;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (_flagArrow)
            {
                StartCoroutine(ArrowSpawn());
            }
            var playerVector = collision.transform.position - gameObject.transform.position;
            var rotatedPlayerVector = Quaternion.Euler(0, 0, _biasZ) * playerVector;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(Vector3.forward, rotatedPlayerVector), _rotetionSpeed);



        }
    }

    private IEnumerator ArrowSpawn()
    {

        _flagArrow = false;
        Instantiate(_arrow, _arrowSpawner.transform).transform.SetParent(_arrowContainer.transform);


        yield return new WaitForSeconds(_timeSpawnArrow);
        _flagArrow = true;
        yield return null;
    }





}

