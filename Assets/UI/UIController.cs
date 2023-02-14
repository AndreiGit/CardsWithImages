using CardsService;
using UI;
using UnityEngine;
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

        _dropdownField.value = _dropdownField.choices[0];
    }

    private void InitUI()
    {
        _container = GetElement<VisualElement>("Root");
        _dropdownField = GetElementFrom<DropdownField>("DropdownField", _container);
        _load = RegisterClickFrom<Button>("Load", _container, (x) => LoadImages());  
        _cancel = RegisterClickFrom<Button>("Cancel", _container, (x) => CancelLoad());
        
        _dropdownField.RegisterValueChangedCallback(evt => ChangedDropdawnValue(evt.newValue));    
    }

    private void InitDeck()
    {
        var deckElement = GetElementFrom<VisualElement>("Deck", _container);

        _deck = new Deck(deckElement);
    }

    private void ChangedDropdawnValue(string value) => _deck.SetStrategy(value);

    private void LoadImages()
    {
        _deck.LoadImages();
        Debug.Log("Загрузка колоды");
    }

    private void CancelLoad()
    {
        Debug.Log("Отмена загрузка колоды");
    }
}
