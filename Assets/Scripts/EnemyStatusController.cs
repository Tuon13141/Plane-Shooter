using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatusController : MonoBehaviour
{
    [SerializeField]
    private int hp = 5;
    [SerializeField]
    private EnemyPositionController positionController;
    
    private EnemyController enemyController;

    [SerializeField]
    private AudioSource getHitAudio;
    [SerializeField]
    private bool changeColorByHit = true;
    void Start()
    {
        enemyController = GameObject.Find("EnemyController").GetComponent<EnemyController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet" && positionController.CanTakingDamage)
        {
          
            hp--;
            getHitAudio.Play();
            if(changeColorByHit)
            {
                changeColorByHit = false;
                StartCoroutine(ChangeColor());
            }
            if(hp <= 0)
            {
                enemyController.IncreaseScore();
               
                Destroy(this.gameObject);
            }
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().SetDie(true);
        }
    }

    IEnumerator ChangeColor()
    {
        this.GetComponent<SpriteRenderer>().color = Color.red;

        yield return new WaitForSeconds(0.5f);

        this.GetComponent<SpriteRenderer>().color = Color.white;
        changeColorByHit = true;
    }
}
