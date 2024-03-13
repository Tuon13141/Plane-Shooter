using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlaySceneCavas : MonoBehaviour
{
    [SerializeField]
    private Image dangerPanel;
    [SerializeField]
    private Text turto;

    private bool fadeOut = false;
    public float fadeOutSpeed;

    private void Start()
    {
        
        StartCoroutine(TurnOffDangerPanel());
    }
    void Update()
    {
        if (!fadeOut)
        {
            Color temp = dangerPanel.color;
            temp.a += fadeOutSpeed * Time.deltaTime;
            dangerPanel.color = temp;

        }
        else
        {
            Color temp = dangerPanel.color;
            temp.a -= fadeOutSpeed * Time.deltaTime;
            dangerPanel.color = temp;
        }

        if (dangerPanel.color.a > 0.5)
        {
            fadeOut = true;
        }
        else if(dangerPanel.color.a < 0.3)
        {
            fadeOut = false;
        }


    }

    IEnumerator TurnOffDangerPanel()
    {
        yield return new WaitForSeconds(5.8f);

        dangerPanel.gameObject.SetActive(false);
        turto.gameObject.SetActive(false);
    }
}
