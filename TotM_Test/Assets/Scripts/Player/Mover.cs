using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    private bool _canMove = true;
    [SerializeField] private MoveDirection _moverDirectionScript;
    [SerializeField] private float _maxDistanseMove = 10f;
    [SerializeField] private float _speedMove;
    [SerializeField] private LayerMask _layerMaskRaycast;
    [SerializeField] private long _timeVibration;

    List<Transform> _pathRoad = new List<Transform>();

    private float _speedMoveForBust;
    private bool _canMower = false;
    private int _steps;
    Vector3 targetPosition;





    void Start()
    {
        _speedMoveForBust = _speedMove;
    }

    void Update()
    {
        TimeBurst();
        MoverChar();
        TimeCount(targetPosition, _steps);
    }
    private void MoverChar()
    {

        if (_canMove)
        {
            _canMove = false;
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, _moverDirectionScript.moveDirection, _maxDistanseMove, _layerMaskRaycast);
            targetPosition = transform.position;
            _steps = 0;
            for (int i = 1; i < hits.Length; i++)
            {

                if ((hits[i].collider.isTrigger))
                {

                    _pathRoad.Add(hits[i].transform);
                    
                }
                else
                {
                    if (i == 1)

                    {
                        
                        _canMove = true;
                        return;
                    }
                    else
                    {
                        Vibrator.Vibrate(_timeVibration);
                        _steps = i;
                        targetPosition = hits[i - 1].transform.position;
                        break;
                    }

                }


            }
           
            _canMower = true;



        }
    }

    void TimeCount(Vector3 TargetPosition, int Steps)
    {
        if (_canMower)
        {
            //_elapsedTime += Time.deltaTime;
            //_speedMove = _elapsedTime / (_desiredTime*Steps);

            //if(_speedMove>=1)
            //{
            //    _elapsedTime =0;
            //}

            transform.position = Vector3.MoveTowards(transform.position, TargetPosition, _speedMove * Steps*Time.deltaTime);

            if (transform.position == TargetPosition)
            {
                
                _canMove = true;
                _canMower = false;

            }
        }
    }
    private void TimeBurst()
    {
        if((Time.timeScale<1) || (Time.timeScale > 0))
        {
            _speedMove = _speedMoveForBust / Time.timeScale;
        }
        else
        {
            _speedMove = _speedMoveForBust;
        }

    }
  
}










