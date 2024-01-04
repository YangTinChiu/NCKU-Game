using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymanege : MonoBehaviour
{
    public GameObject enemy_obj;
    public enemycontrol[] enemy_list;
    public int max_enemy_num = 10;
    public int enemy_num = 0;
    public float spawn_time = 5f, spawn_delay = 5f;
    // Start is called before the first frame update
    void Start()
    {
        enemy_list = new enemycontrol[max_enemy_num];
    }

    // Update is called once per frame
    void Update()
    {
        spawn_delay += Time.deltaTime;

        if(spawn_delay > spawn_time && enemy_num < max_enemy_num) {
            spawn_delay = 0;
            
            // generate random position with trnasform
            Vector3 randomPosition = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            randomPosition += transform.position;
            GameObject obj = Instantiate(enemy_obj, randomPosition, Quaternion.identity);
            obj.SetActive(true);
            enemy_list[enemy_num] = obj.GetComponent<enemycontrol>();
            enemy_num++;
        }

        for(int i = 0; i < enemy_num; i++) {
            if(enemy_list[i].Life == 0) {
                DestroyEnemy(i);
            }
        }
    }

    void DestroyEnemy(int index) {
        Destroy(enemy_list[index].gameObject,3f);
        for(int i = index; i < enemy_num - 1; i++) {
            enemy_list[i] = enemy_list[i + 1];
        }
        enemy_num--;
    }
}
