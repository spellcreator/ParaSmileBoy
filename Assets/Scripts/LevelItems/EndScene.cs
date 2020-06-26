using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    public RectTransform titles;
    public LevelLoader loadMain;

    public float speed;
    public int time;

    private void Start()
    {
        StartCoroutine(LoadMain());
    }

    private void Update()
    {
        TitleMove();
    }
    private void TitleMove()
    {
        titles.transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
    }

    private IEnumerator LoadMain()
    {

        yield return new WaitForSeconds(time);
        loadMain.LoadLevel(0);
    }


}
