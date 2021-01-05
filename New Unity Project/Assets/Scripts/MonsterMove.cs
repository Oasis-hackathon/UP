using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterMove : MonoBehaviour
{
    public GameObject player;
    private float targetmove;
    private float Speed;
    private LifeEntity mystate;

    public GameObject M_HP;
    public Slider bar;

    private void Start()
    {
        Speed = 1f;
        mystate = this.GetComponent<LifeEntity>();
        StartCoroutine(Move());
    }
    private void Update()
    {
        M_HP.transform.position = this.transform.position + new Vector3(0, 1, 0);
        bar.maxValue = mystate.HP;
        bar.value = mystate.CurrentHP;
    }
    IEnumerator Move()
    {
        while (true)
        {
            if (mystate.Is_Dead)
            {
                yield break;
            }
            targetmove = (player.GetComponent<Transform>().position.x-this.GetComponent<Transform>().position.x);
            int random = Random.Range(-1, 2);
            if(random == -1)
            {
                targetmove *= random;
                yield return new WaitForSeconds(1.5f);
            }
            yield return new WaitForSeconds(1);
        }
    }
    private void FixedUpdate()
    {
        if (mystate.Is_Dead)
        {
            return;
        }
        if (targetmove > 0)
        {
            transform.position += Vector3.right * Speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * Speed * Time.deltaTime;
        }

    }
}
