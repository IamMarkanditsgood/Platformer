using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InputSystem
{

    private List<IInputable> _inputSystems = new List<IInputable>();

    public void Init()
    {
        DeclareInputSystems();
    }

    public void UpdateInputs()
    {
        foreach (var system in _inputSystems)
        {
            system.UpdateInput();
        }
    }

    private void DeclareInputSystems()
    {
        _inputSystems.Add(new KeyboardInputSystem());
    }
}