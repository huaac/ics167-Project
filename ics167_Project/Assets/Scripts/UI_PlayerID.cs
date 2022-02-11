using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_PlayerID : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private float offset;

    private RectTransform selfTransform;
    private bool playerDied;

    private void Awake()
    {
        selfTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        playerDied = false;
    }

    private void Update()
    {
        if (playerDied)
        {
            return;
        }

        selfTransform.position = new Vector2(player.position.x, player.position.y + offset);
    }

    public void EraseUI()
    {
        playerDied = true;
        text.color = Color.clear;
    }
}
