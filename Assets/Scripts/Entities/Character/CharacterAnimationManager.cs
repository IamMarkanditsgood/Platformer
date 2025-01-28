using System;
using UnityEngine;

[Serializable]
public class CharacterAnimationManager
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _runParameterName;

    private bool _isRun;
    public void Run(float state)
    {
        if(state == 0 && _isRun)
        {
            SetRun(false);
        }
        else if((state > 0 || state < 0) && !_isRun)
        {
            SetRun(true);
        }
    }

    private void SetRun(bool state)
    {
        _isRun = state;
        _animator.SetBool(_runParameterName, state);
    }
}