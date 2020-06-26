using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PistolWeapon : MonoBehaviour
{

    [SerializeField] private Item pislot;
    private GameObject piy;

    public int damage;
    private SpriteRenderer itemSprite;
    public GameObject bulletPrefab;
    public Transform firePoint;

    private void Awake()
    {
        itemSprite = GetComponent<SpriteRenderer>();
        itemSprite.sprite = pislot.image;
        damage = pislot.damage;
    }

    private void Start()
    {
        piy = GameObject.Find("Fire");
        piy.GetComponent<Button>().onClick.AddListener(Shoot);
    }
    public void Shoot()
    {
        var shootDir = new Vector3(firePoint.localRotation.x, 0f, firePoint.position.z);

        var bullets = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullets.GetComponent<Bullet>().damage = damage;
        bullets.GetComponent<Bullet>().shootDir = shootDir;
        Destroy(gameObject);
    }
}
