using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    public class UIControllerBase : MonoBehaviour
    {
        protected VisualElement _root;

        protected virtual void Awake()
        {
            UIDocument uiDocument = transform.root.GetComponent<UIDocument>();
            _root = uiDocument.rootVisualElement;
        }


        protected T GetElement<T>(string name) where T : VisualElement
        {
            return _root.Q<T>(name);
        }

        protected T GetElementFrom<T>(string name, VisualElement parent) where T : VisualElement
        {
            return parent.Q<T>(name);
        }

        protected T RegisterClick<T>(string name, EventCallback<ClickEvent> callback) where T : VisualElement
        {
            T visualElement = GetElement<T>(name);

            visualElement.RegisterCallback(callback);

            return visualElement;
        }

        protected T RegisterClickFrom<T>(string name, VisualElement parent, EventCallback<ClickEvent> callback) where T : VisualElement
        {
            T visualElement = GetElementFrom<T>(name, parent);

            visualElement.RegisterCallback(callback);

            return visualElement;
        }

        protected void ProcessPlaceholder(TextField textField)
        {
            Label placeholder = textField.Q<Label>("Placeholder");

            textField.RegisterValueChangedCallback(e =>
            {
                placeholder.visible = string.IsNullOrEmpty(e.newValue);
            });
        }


        protected VisualElement TopMostElement(Vector2 pointPosition)
        {
            IPanel panel = _root.panel;

            Vector2 position = ConvertPosition(panel, pointPosition);

            VisualElement topmost = panel.Pick(position);
            return topmost;
        }

        protected List<VisualElement> AllElementsInPosition(Vector2 pointPosition)
        {
            List<VisualElement> listElements = new();

            IPanel panel = _root.panel;

            Vector2 position = ConvertPosition(panel, pointPosition);

            panel.PickAll(position, listElements);
            return listElements;
        }

        protected Vector2 WorldToElementScreenPosition(Vector2 positionWorld, VisualElement element)
        {
            Vector2 screenPosition = new(positionWorld.x + (element.resolvedStyle.width / 2),
                (element.resolvedStyle.height / 2) - positionWorld.y);

            return screenPosition;
        }

        protected Vector2 WorldToScreenPosition(Vector2 positionWorld)
        {
            Vector2 screenPosition = new(positionWorld.x + (Screen.width / 2),
                (Screen.height / 2) - positionWorld.y);

            return screenPosition;
        }

        protected Vector2 ScreenToWorldPosition(Vector2 positionScreen)
        {
            Vector2 worldPosition = new(positionScreen.x - (Screen.width / 2),
                   (Screen.height / 2) - positionScreen.y);

            return worldPosition;
        }

        protected bool CheckPositionOverElement(VisualElement element, Vector2 screenPosition)
        {
            Vector2 localPosition = element.WorldToLocal(screenPosition);
            return element.ContainsPoint(localPosition);
        }

        protected Vector2 ConvertPosition(IPanel panel, Vector2 pointPosition)
        {
            Vector2 panelPosition = RuntimePanelUtils.ScreenToPanel(panel, pointPosition);
            Vector2 position = new(panelPosition.x, Screen.height - panelPosition.y);

            return position;
        }
    }
}