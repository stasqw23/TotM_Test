using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator _animatorDoorBlow;
    

  
    void Start()
    {
        _animatorDoorBlow = gameObject.GetComponent<Animator>();
    }
    public void OpenDoorAnimation()
    {
        _animatorDoorBlow.SetBool("Blow", true);
        
    }
    private void Delete()
    {
        Destroy(gameObject);
    }
}
