using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveDirection : MonoBehaviour  , IBeginDragHandler , IDragHandler ,IPointerClickHandler ,IEndDragHandler
{
    private Vector2 _moveDirection;
    private bool _canUseBomb = true;
    private bool _morOneBomb = true;
    [SerializeField] private GameObject _bomb;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _parentBomb;


    public Vector2 moveDirection { get { return _moveDirection; } }


    private void Awake()
    {
        GameEvents.UseBombEvent += CanUseBomb;
    }

    void Start()
    {
        _moveDirection = new Vector2 (0,0);
    }

    void Update()
    {
        
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        _canUseBomb = false;
        
        if ((Mathf.Abs(eventData.delta.x)) > (Mathf.Abs(eventData.delta.y)))
        {
            if (eventData.delta.x > 0)
            {
                _moveDirection = transform.right;
                

            }
            else
            {
                _moveDirection = -transform.right;
            }
        }
        else 
        {
            if (eventData.delta.y > 0)
            {
                _moveDirection = transform.up;
            }
            else
            {
                _moveDirection = -transform.up;
            }
        }
        

    }

    public void OnDrag(PointerEventData eventData)
    {
        

    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (_canUseBomb&&_morOneBomb)
        {
            _morOneBomb = false;           
            Instantiate(_bomb, _player.transform).GetComponent<Transform>().SetParent(_parentBomb.transform);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canUseBomb = true;
    }
   private  void CanUseBomb(bool UseBomb)
    {
        _morOneBomb = UseBomb;
    }
    private void OnDestroy()
    {

        GameEvents.UseBombEvent -= CanUseBomb;
    }
}

