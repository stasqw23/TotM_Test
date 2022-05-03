using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventControler : MonoBehaviour
{


    [SerializeField] private RuntimeAnimatorController _animatorDoorBlow;
    [SerializeField] private RuntimeAnimatorController _animatorBanana;
    [SerializeField] private RuntimeAnimatorController _animatorRoadExplosion;
    [SerializeField] private RuntimeAnimatorController _animatorPassAnimation;

    [Header("Time in millisecond")]

    [SerializeField] private float _timeAnimationEventDoorDelete;
    [SerializeField] private float _timeAnimationEventVibrationOn;
    [SerializeField] private float _timeAnimationEventBlow;
    [SerializeField] private float _timeAnimationEventRoadExplosion;
    [SerializeField] private float _timeAnimationEventPass;

    private AnimationEvent _animationEventDoorDelete = new AnimationEvent();
    private AnimationEvent _animationEventVibrationOn = new AnimationEvent();
    private AnimationEvent _animationEventBlow = new AnimationEvent();
    private AnimationEvent _animationEventRoadExplosion = new AnimationEvent();
    private AnimationEvent _animationEventPass = new AnimationEvent();


    void Start()
    {
        _animationEventDoorDelete.time = _timeAnimationEventDoorDelete / 60f;
        _animationEventDoorDelete.functionName = "Delete";
        _animatorDoorBlow.animationClips[0].AddEvent(_animationEventDoorDelete);

        _animationEventVibrationOn.time = _timeAnimationEventVibrationOn / 60f;
        _animationEventVibrationOn.functionName = "VibrationOn";
        _animatorBanana.animationClips[1].AddEvent(_animationEventVibrationOn);

        _animationEventBlow.time = _timeAnimationEventBlow / 60f;
        _animationEventBlow.functionName = "Blow";
        _animatorBanana.animationClips[1].AddEvent(_animationEventBlow);

        _animationEventRoadExplosion.time = _timeAnimationEventRoadExplosion / 60f;
        _animationEventRoadExplosion.functionName = "Destroy";
        _animatorRoadExplosion.animationClips[0].AddEvent(_animationEventRoadExplosion);

        _animationEventPass.time = _timeAnimationEventPass / 60f;
        _animationEventPass.functionName = "DestroiAnimation";
        _animatorPassAnimation.animationClips[0].AddEvent(_animationEventPass);
        
    }

    void Update()
    {
        
    }
}
