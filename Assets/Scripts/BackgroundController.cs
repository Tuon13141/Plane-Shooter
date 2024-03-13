using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] GameObject background_1;
    [SerializeField] GameObject background_2;
    [SerializeField] GameObject background_3;
    [SerializeField] GameObject background_4;

    [SerializeField] float Speed;

    private void Start()
    {
        StartCoroutine(ReloadBackground(background_4, background_1));
        StartCoroutine(ReloadBackground(background_3, background_4));
        StartCoroutine(ReloadBackground(background_2, background_3));
        StartCoroutine(ReloadBackground(background_1, background_2));
    }

    void Update()
    {
        MoveBackground(background_1);
        MoveBackground(background_2);
        MoveBackground(background_3);
        MoveBackground(background_4);
    }

    IEnumerator ReloadBackground(GameObject background_1, GameObject background_2)
    {
        yield return new WaitUntil(() => background_1.transform.position.y <= -38.4f);
        
        background_1.transform.position = new Vector2(0, background_2.transform.position.y + 19.2f);
        
        StartCoroutine(ReloadBackground(background_1, background_2));
    }

    void MoveBackground(GameObject background)
    {
        background.transform.Translate(Vector2.down * Speed * Time.deltaTime);
    }
}
