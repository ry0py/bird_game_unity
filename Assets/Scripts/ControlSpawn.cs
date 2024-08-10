using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSpawn : MonoBehaviour
{
    [SerializeField] GameObject heart_prefab;
    [SerializeField] GameObject coin_prefab;
    [SerializeField] GameObject enemy_prefab;
    GameObject[] prefab;
    Vector3[] position;
    Vector3 position_random;
    float count = 0.0f;
    float appear_time = 0.0f;
    void Start()
    {
        var heart_position = new Vector3(
            heart_prefab.transform.position.x,
            heart_prefab.transform.position.y +5.0f,//なぜか5.0fを足さないと上下の距離が合わない
            heart_prefab.transform.position.z);
        var coin_position = new Vector3(
           coin_prefab.transform.position.x,
           coin_prefab.transform.position.y +5.0f,
           coin_prefab.transform.position.z);
        var enemy_position = new Vector3(
           enemy_prefab.transform.position.x,
           enemy_prefab.transform.position.y +5.0f,
           enemy_prefab.transform.position.z);
        // position[0] = heart_position;
        // position[1] = coin_position;
        // position[2] = enemy_position;
        //という書き方をしたらassignされてないことになった。謎です
        position = new Vector3[]{heart_position,coin_position,enemy_position};
        //prefabの配列を作成 start()の中でやらないとエラーが出る.
        prefab = new GameObject[]{heart_prefab,coin_prefab,enemy_prefab};
    }
    void Update()
    {
        for(int i = 0;i<prefab.Length;i++){
            count += Time.deltaTime;
            appear_time = Random.Range(1.0f,3.0f);
            position_random = position[Random.Range(0,position.Length)];
            if(count > appear_time){
                //Quaternion.identityとは回転なしの状態のこと
                Instantiate(prefab[i],position_random,Quaternion.identity);
                count = 0.0f;
            }
        }
            
        
        //こっちでprefabを消そうとしたけどprefabの座標を参照できなかったのでOtherMove.csで消すことにした
        //多分prefabのほうにcomponent追加しないといけない
    }
}
