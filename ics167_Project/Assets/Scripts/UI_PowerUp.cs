using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_PowerUp : MonoBehaviour
{
    [SerializeField] private Image icon;

    private void Awake()
    {
        icon.color = Color.clear;
    }

    public void UpdateUI(Sprite sprite)
    {
        icon.color = Color.white;
        icon.sprite = sprite;
    }

    public void EraseUI()
    {
        icon.sprite = null;
        icon.color = Color.clear;
    }
}
