using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LosePanel : MonoBehaviour
{
    private void Awake() => gameObject.SetActive(false);

    public void LosePanelActive(bool flag) => gameObject.SetActive(flag);
}