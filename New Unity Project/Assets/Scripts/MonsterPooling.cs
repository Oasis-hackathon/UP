using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
public class MonsterPooling : MonoBehaviour
{
    private LifeEntity[] n_monster;
    private DropItem[] drops;
    public GameObject boss;
    public List<LifeEntity> pooling_ObjectQueue = new List<LifeEntity>();
    public void Start()
    {
        n_monster = this.GetComponentsInChildren<LifeEntity>();
        drops = this.GetComponentsInChildren<DropItem>();

        for(int i = 0; i < n_monster.Length; i++)
        {
            pooling_ObjectQueue.Add(n_monster[i]);
        }

        StageManager.sminstance.poolingSystem = this;
        if (SceneManager.GetActiveScene().name == "Stage1")
        {
            int[] posi = DBmanager.instance.stageposition[0];
            StartCoroutine(Spawn(posi[0],posi[1],posi[2],posi[3]));
            boss_spawner(0);
        }
        if (SceneManager.GetActiveScene().name == "Stage2")
        {
            int[] posi = DBmanager.instance.stageposition[1];
            StartCoroutine(Spawn(posi[0], posi[1], posi[2], posi[3]));
            boss_spawner(1);

        }
        if (SceneManager.GetActiveScene().name == "Stage3")
        {
            int[] posi = DBmanager.instance.stageposition[2];
            StartCoroutine(Spawn(posi[0], posi[1], posi[2], posi[3]));
            boss_spawner(2);

        }
        if (SceneManager.GetActiveScene().name == "Stage4")
        {
            int[] posi = DBmanager.instance.stageposition[3];
            StartCoroutine(Spawn(posi[0], posi[1], posi[2], posi[3]));
            boss_spawner(3);

        }
        if (SceneManager.GetActiveScene().name == "Stage5")
        {
            int[] posi = DBmanager.instance.stageposition[4];
            StartCoroutine(Spawn(posi[0], posi[1], posi[2], posi[3]));
            boss_spawner(4);

        }

    }
    public void StopCo()
    {
        StopAllCoroutines();
    }
    public void boss_spawner(int stage)
    {
        GameObject thisboss = Instantiate(boss);
        int[] posi = DBmanager.instance.stageBosspositionList[stage];
        thisboss.transform.position = new Vector2(posi[0],posi[1]);
        thisboss.GetComponent<LifeEntity>().Respawn();
    }
    IEnumerator Spawn(int x_min,int x_max,int y_min,int y_max)
    {
        while (true)
        {
            for (int i = 0; i < pooling_ObjectQueue.Count; i++)
            {
                LifeEntity monster = pooling_ObjectQueue.First();
                pooling_ObjectQueue.RemoveAt(0);
                monster.transform.position = new Vector2(Random.Range(x_min, x_max), Random.Range(y_min, y_max));
                monster.Respawn();
            }

            yield return new WaitForSeconds(1);
        }
        
    }
}
