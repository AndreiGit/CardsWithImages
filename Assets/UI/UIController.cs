using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIController : UIControllerBase
{
    private VisualElement _container;
    private DropdownField _dropdownField;

    void Start()
    {
        _container = GetElement<VisualElement>("Root");
        _dropdownField = GetElementFrom<DropdownField>("DropdownField", _container);

        _dropdownField.RegisterValueChangedCallback(evt => ChangedDropdawnValue(evt.newValue));
        _dropdownField.value = _dropdownField.choices[0];
    }

    private void ChangedDropdawnValue(string value)
    {
        Debug.Log(value);
    }

    private void AllAtOnce()
    {
        Debug.Log("AllAtOnce");
    }

    private void OneByOne()
    {
        Debug.Log("OneByOne");
    }

    private void WhenImageReady()
    {
        Debug.Log("WhenImageReady");
    }
}
