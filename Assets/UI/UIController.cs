using CardsService;
using UI;
using UnityEngine.UIElements;

public class UIController : UIControllerBase
{
    private VisualElement _container;

    private DropdownField _dropdownField;

    private Button _load;

    private Button _cancel;

    private IDeck _deck;


    void Start()
    {
        InitUI();

        InitDeck();
    }

    private void InitUI()
    {
        _container = GetElement<VisualElement>("Root");
        _dropdownField = GetElementFrom<DropdownField>("DropdownField", _container);
        _load = RegisterClickFrom<Button>("Load", _container, (x) => _deck.LoadImagesAsync());  
        _cancel = RegisterClickFrom<Button>("Cancel", _container, (x) => _deck.CancelLoading());     
    }

    private void InitDeck()
    {
        var deckElement = GetElementFrom<VisualElement>("Deck", _container);

        _deck = new Deck(deckElement);

        _dropdownField.RegisterValueChangedCallback(evt => ChangedDropdawnValue(evt.newValue));
        _dropdownField.value = _dropdownField.choices[0];
    }

    private void ChangedDropdawnValue(string value) => _deck.SetStrategy(value);
}
