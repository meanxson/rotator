using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class LogoTextEffect : MonoBehaviour
{
    private Vector3 _currentPosition;

    private void Awake()
    {
        _currentPosition = transform.localPosition;
        transform.position = new Vector3(-30, -30, -30);
    }
}
