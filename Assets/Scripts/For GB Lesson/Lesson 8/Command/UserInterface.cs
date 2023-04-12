using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Command
{
    internal sealed class UserInterface : MonoBehaviour
    {
        [SerializeField] private PanelOne _panelOne;
        [SerializeField] private PanelTwo _panelTwo;
        [SerializeField] private PanelThree _panelThree;
        [SerializeField] private PanelFour _panelFour;
        private readonly Stack<StateUI> _stateUi = new Stack<StateUI>();
        private BaseUi _currentWindow;
        private void Start()
        {
            _panelOne.Cancel();
            _panelTwo.Cancel();
            _panelThree.Cancel();
            _panelFour.Cancel();
        }
        private void Execute(StateUI stateUI, bool isSave = true)
        {
            if (_currentWindow != null)
            {
                _currentWindow.Cancel();
            }
            switch (stateUI)
            {
                case StateUI.PanelOne:
                    _currentWindow = _panelOne;
                    break;
                case StateUI.PanelTwo:
                    _currentWindow = _panelTwo;
                    break;
                case StateUI.PanelThree:
                    _currentWindow = _panelThree;
                    break;
                case StateUI.PanelFour:
                    _currentWindow = _panelFour;
                    break;
                default:
                    break;
            }
            _currentWindow.Execute();
            if (isSave)
            {
                _stateUi.Push(stateUI);
            }
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Execute(StateUI.PanelOne);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Execute(StateUI.PanelTwo);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Execute(StateUI.PanelThree);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                Execute(StateUI.PanelFour);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_stateUi.Count > 0)
                {
                    Execute(_stateUi.Pop(), false);
                }
            }
        }
    }
}
