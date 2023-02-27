using EntryPoint;
using UI;
using UnityEngine.UIElements;

public class UIController : UIControllerBase
{
    private VisualElement _container;

    private DropdownField _dropdownField;

    private Button _load;

    private Button _cancel;

    private IDeckView _deckView;

    void Start()
    {
        _deckView = App.Instance.GetService<IDeckView>();

        InitUI();

        InitDropdown();
    }

    private void InitUI()
    {
        _container = GetElement<VisualElement>("Root");
        _load = RegisterClickFrom<Button>("Load", _container, (x) => _deckView.Deck.LoadImagesAsync(SetInteractable));  
        _cancel = RegisterClickFrom<Button>("Cancel", _container, (x) => _deckView.Deck.CancelLoading());
    }

    private void InitDropdown()
    {
        _dropdownField = GetElementFrom<DropdownField>("DropdownField", _container);
        _dropdownField.RegisterValueChangedCallback(evt => ChangedDropdawnValue(evt.newValue));
        _dropdownField.value = _dropdownField.choices[0];
    }

    private void ChangedDropdawnValue(string value) => _deckView.Deck.SetStrategy(value);

    private void SetInteractable(bool state)
    {
        _load.SetEnabled(state);
        _dropdownField.SetEnabled(state);
    }
}
