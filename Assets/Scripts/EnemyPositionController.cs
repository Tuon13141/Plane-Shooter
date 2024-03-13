using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPositionController : MonoBehaviour
{
    [SerializeField]
    List <float> xPos = new List<float>();
    [SerializeField]
    List <float > yPos = new List<float>();
    [SerializeField]
    private float moveSpeed;

    private bool canMove = false;

    private int index = 0;


    public bool CanTakingDamage { get; private set; } = false;
    public SpriteRenderer shield;
    private bool fadeOut = false;
    public float fadeOutSpeed;
    void Start()
    {
        StartCoroutine(SpawnAtRandomPositionOutSideScreen());
    }

    void Update()
    {
        if (canMove)
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(xPos[index], yPos[index]), moveSpeed * Time.deltaTime);

        if (!CanTakingDamage)
        {
            if (!fadeOut)
            {
                Color temp = shield.color;
                temp.a += fadeOutSpeed * Time.deltaTime;
                shield.color = temp;

            }
            else
            {
                Color temp = shield.color;
                temp.a -= fadeOutSpeed * Time.deltaTime;
                shield.color = temp;
            }

            if (shield.color.a > 0.7)
            {
                fadeOut = true;
            }
            else if (shield.color.a < 0.1)
            {
                fadeOut = false;
            }

        }
    }

    IEnumerator ChangePosition()
    {
        if (index == xPos.Count - 1)
        {
            yield return new WaitForSeconds(1f);
            Color temp = shield.color;
            temp.a = 0;
            shield.color = temp;
            CanTakingDamage = true;
        }
        yield return new WaitForSeconds(5f);
        if (index == xPos.Count - 1)
        { 
            yield break;
        }
        else index++;
        StartCoroutine(ChangePosition());
    }

    private IEnumerator SpawnAtRandomPositionOutSideScreen()
    {
        int ranX = 0;
        int ranY = 0;
        int ranChoice = Random.Range(1, 4);
        if (ranChoice == 1)
        {
            ranX = Random.Range(-19, -12);
            ranY = Random.Range(6, 20);
        }
        else if(ranChoice == 2)
        {
            ranX = Random.Range(12, 19);
            ranY = Random.Range(6, 20);

        }
        else if(ranChoice == 3)
        {
            ranX = Random.Range(-8, 8);
            ranY = Random.Range(16, 20);
        }
        
        transform.position = new Vector2(ranX, ranY);

        yield return new WaitForSeconds(2f);

        canMove = true;

        yield return new WaitForSeconds(2f);
        StartCoroutine(ChangePosition());
    }
}
