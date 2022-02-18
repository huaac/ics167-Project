using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// by Aissa Akiyama
/// A script to enable the Helper in a scene.
/// Note that instantiating a prefab does NOT work, as the Helper and HelperSearchRange
/// require references to the Player1 and Player2 prefab instances.
/// </summary>

public class HelperEnabler : MonoBehaviour
{
    [SerializeField] private int helperThreshold;
    [SerializeField] private IntVariable restartCount;

    [SerializeField] private GameObject Helper;
    [SerializeField] private GameObject HelperSearchRange;

    private bool enabledHelper;

    private void Start()
    {
        HelperSearchRange.SetActive(false);
        Helper.SetActive(false);
    }

    private void Update()
    {
        if (restartCount.value > helperThreshold && !enabledHelper)
        {
            HelperSearchRange.SetActive(true);
            Helper.SetActive(true);
            enabledHelper = true;
        }
    }
}
