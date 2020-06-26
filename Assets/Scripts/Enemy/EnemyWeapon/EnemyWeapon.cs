using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public GameObject usableItem;
    public Transform itemPos;

    private void Start()
    {
        var weapon = Instantiate(usableItem, itemPos);
    }
}
