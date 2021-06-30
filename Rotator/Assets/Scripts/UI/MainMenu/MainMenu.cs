using System;
using System.Collections;
using System.Collections.Generic;
using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private Button _button;

    private void Awake() => _button = GetComponentInChildren<Button>();

    private void Start() => _button.onClick.AddListener(OnStartButtonClick);

    private void OnStartButtonClick() => SampleScene.Load();
}
