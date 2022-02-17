using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// by Aissa Akiyama
// This is a UI script. It updates the displayed power-up to match what was collected by the player,
// then erases it when the power-up has expired.
// Power-up collection/expiration are notified by attaching a Game Event Listener to the parent canvas object
// and listening for corresponding Game Events.

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
