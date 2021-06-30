using System.Collections.Generic;
using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private CameraMover _mover;
    private Button[] _buttons;

    private void Awake() => _buttons = GetComponentsInChildren<Button>();

    private void Start() => InitButtons(new []{ (UnityAction) OnClickButtonUp, 
        OnClickButtonDown, Exit, Restart});

    private void InitButtons(IReadOnlyList<UnityAction> buttons)
    {
        for (var i = 0; i < _buttons.Length; i++) 
            _buttons[i].onClick.AddListener(buttons[i]);
    }

    private void OnClickButtonUp() => _mover.ButtonUp();

    private void OnClickButtonDown() => _mover.ButtonDown();

    private void Exit() => MainMenuScene.Load();
    
    private void Restart() => SampleScene.Load();
}
