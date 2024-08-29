using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class DisplayItemCounts : MonoBehaviour
{
    public List<ItemCounter> itemCounters = new List<ItemCounter>();

    void Start()
    {
        LoadAndDisplayItemCounts();
    }

    void LoadAndDisplayItemCounts()
    {
        foreach (var itemCounter in itemCounters)
        {
            int count = PlayerPrefs.GetInt(itemCounter.itemPrefab.name + "_Count", 0);
            if (itemCounter.countText != null)
            {
                itemCounter.countText.text = itemCounter.itemPrefab.name + ": " + count;
            }
        }
    }
}
