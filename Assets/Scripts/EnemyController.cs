using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private int score = 0;
    private List<GameObject> enemy = new List<GameObject>();
    [SerializeField]
    private Player player;
    [SerializeField]
    private int maxScore = 16;
    [SerializeField]
    private Text winText;
    [SerializeField]
    private AudioSource winSound;
    [SerializeField]
    private AudioSource dieSound;
    [SerializeField]
    private Text scoreText;
 
    private void Start()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy").ToList();
        //PlayerPrefs.SetInt("highscore", 0);
        maxScore = enemy.Count;
        StartCoroutine(ChangeToGameOverSence());
    }
    public void IncreaseScore()
    {
        dieSound.Play();
        score++;
        scoreText.text = score.ToString();
        if (score > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", score);
        }
       
        if(score >= maxScore)
        {
            winSound.Play();
            StartCoroutine(ChangeToWinSence());
        }
    }

    IEnumerator ChangeToWinSence()
    {
        StopCoroutine(ChangeToGameOverSence());
        winText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("MenuScene");
    }

    IEnumerator ChangeToGameOverSence()
    {
        yield return new WaitUntil(() => player.GetDie());

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("GameOverScene");
    }
}
