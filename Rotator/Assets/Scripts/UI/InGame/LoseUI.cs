using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.UI;

public class LoseUI : MonoBehaviour
{
    private Button _button;
    
    private void Awake() => _button = GetComponentInChildren<Button>();

    private void Start() => _button.onClick.AddListener(Restart);

    private void Restart() => SampleScene.Load();
}
