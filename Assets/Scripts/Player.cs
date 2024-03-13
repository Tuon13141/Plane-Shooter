using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private bool die = false;
    [SerializeField]
    private GameObject explotion;


    private void Start()
    {
        StartCoroutine(Die());
        StartCoroutine(CanShoot());
    }
 
    IEnumerator Die()
    {
        yield return new WaitUntil(() => die);
        yield return new WaitForSeconds(0.2f);
        Instantiate(explotion);
        explotion.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
        StopCoroutine(Shoot());
        
        Destroy(this.gameObject);
    }

    IEnumerator CanShoot()
    {
        yield return new WaitForSeconds(1f);

        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        Instantiate(bullet);
        bullet.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 1f);

        yield return new WaitForSeconds(0.1f);

        StartCoroutine(Shoot());
    }
    public void SetDie(bool die)
    {
        this.die = die;
    }

    public bool GetDie()
    {
        return this.die;
    }
}
