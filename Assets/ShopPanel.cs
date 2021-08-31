using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShopPanel : MonoBehaviour
{
    [Range(0f, 1f)]
    public float duration = .5f;
    public bool isOpened = false;

    private readonly float HIDE_SIZE = -100f;


    public void Open()
    {
        float size = 10 * (Screen.height / 100);
        isOpened = true;
        transform.DOMoveY(size, duration);
    }

    public void Close()
    {
        isOpened = false;
        transform.DOMoveY(HIDE_SIZE, duration);
    }
}
