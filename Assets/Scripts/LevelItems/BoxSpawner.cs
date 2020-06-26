using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public List<GameObject> items;

    private Box box;

    private void Awake()
    {
        box = GetComponent<Box>();
    }

    private void Start()
    {
        box.usedItem = items[GiveRandomItem()];
    }

    private int GiveRandomItem()
    {
        var getRandom = Random.Range(0, items.Count);
        return getRandom;
    }
}
