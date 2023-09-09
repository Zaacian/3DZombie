using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyspawned : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int enemyCount; 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }
    IEnumerator EnemyDrop()
    {
        while (enemyCount < 3)
        {
            xPos = Random.Range(0,-5);
            zPos = Random.Range(-11,-18);
            Instantiate(theEnemy, new Vector3(xPos, 0.009f, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;       
        }
    }
}
