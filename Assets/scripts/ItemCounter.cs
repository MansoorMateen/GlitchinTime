using UnityEngine;
using TMPro;

[System.Serializable]
public class ItemCounter
{
    public GameObject itemPrefab;   // The prefab of the item to be counted
    public TMP_Text countText;      // The TMP_Text field to display the count
    [HideInInspector]
    public int count;               // The count of collected items
}
