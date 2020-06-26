using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    [SerializeField] protected string itemName;
    public int damage;
    public Sprite image;

}
