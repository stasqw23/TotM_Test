using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaBomb : MonoBehaviour
{

    [SerializeField] private float _time;
    [SerializeField] private float _maxDistanseBlow;
    [SerializeField] private GameObject _explosionRoad;

    private Animator _animator;
    private bool _vibration;



    private Vector2[] _directionBlow;


    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();

        StartCoroutine(Blowup());

        _directionBlow = new Vector2[]
        {
            transform.right,

            -transform.right,

            transform.up,

            -transform.up

        };
        

    }

    void Update()
    {
        Vibration();
    }
    IEnumerator Blowup()
    {
        yield return new WaitForSeconds(_time);

        _animator.SetBool("blowup",true);
        
        yield return null;

    }
    private void VibrationOn()
    {
        _vibration = true;

    }
    private void Vibration()
    {
        if (_vibration)
        {
            Handheld.Vibrate();
        }
    }
    private void Blow()
    {      

        for (int a = 0; a < _directionBlow.Length; a++)
        { 
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, _directionBlow[a], _maxDistanseBlow);
            for (int i = 0; i < hits.Length; i++)
            {

                if ((hits[i].collider.isTrigger))
                {
                    Instantiate(_explosionRoad, hits[i].collider.transform);
                   
                }
                else if (hits[i].collider.tag == "Player")
                {
                    
                    hits[i].collider.GetComponent<Death>().DeathBomb();
                }
                else
                {
                    if (i == 0)

                    {
                        return;
                    }
                    else if (hits[i].collider.tag == "door")
                    {
                        hits[i].collider.GetComponent<Door>().OpenDoorAnimation();
                        break;
                    }                    
                    else
                    {

                        break;
                    }

                }
            }


        }
        GameEvents.CallUseBombEvent(true);
        Destroy(gameObject);
    }


}
