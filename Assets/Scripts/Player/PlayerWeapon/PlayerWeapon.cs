using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWeapon : MonoBehaviour
{
    public GameObject usableItem;
    public Transform itemPos;
    private Box box;
    private bool isPickUp;

    [SerializeField] private Button takeGun;

    private void Start()
    {
        takeGun.onClick.AddListener(PickUp);
    }

    public void PickUp()
    {
        if (isPickUp && usableItem == null)
        {
            var weapon = Instantiate(box.usedItem, itemPos);
            usableItem = weapon;
            Destroy(box.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        box = collision.GetComponent<Box>();
        if (collision.transform.tag == "Box")
        {
            isPickUp = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPickUp = false;
    }
}
