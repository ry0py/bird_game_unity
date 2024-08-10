using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(HPControl))]
[RequireComponent(typeof(Score))]
public class BirdMove : MonoBehaviour
{
    Transform bird;
    float height=0;
    int high_count = 0;
    [SerializeField] int add_score = 5;
    private int all_score = 0;

    //HP用
    //ここをstaticにしないと A field initializer cannot reference the non-static field, method, or property 'HPControl.MAX_HP' というエラーが出る
    [SerializeField] static int MAX_HP = 50;
    [SerializeField] int HEAL_HP = 5;
    [SerializeField] int DAMAGE_HP = 10;
    private int NOW_HP = MAX_HP;
    public void Recover(){
        if(NOW_HP>=50) return;
        NOW_HP += HEAL_HP;
    }
    public void Damage(){
        if(NOW_HP<=0) return;
        if(NOW_HP-DAMAGE_HP<=0) {
            NOW_HP = 0;
            return;
        }
        NOW_HP -= DAMAGE_HP;
    }
    // public int GetHP(){
    //     return NOW_HP;
    // }
    public int GetHP{
        get {return NOW_HP;}
    }
    public void Death(){
        if(NOW_HP<=0) return;
        //TODO:ゲームオーバー用のUIとスコアを表示できるようにする

    }
    //スコア用
    public void AddScore(){
        all_score +=add_score;
    }
    // public int GetScore(){
    //     return all_score;
    // }
    public int GetScore  //public 戻り値 プロパティ名
    { 
        get { return all_score; } //get {return フィールド名;}
        //set { num = value; } //set {フィールド名 = value;}
    }

    void Start()
    {
        bird = transform;
        height = 0;
    }

    void Update()
    {
        height = this.transform.position.y;
        if(high_count <1){
            if(Input.GetKeyDown("w")){
                high_count++;
                height+= 3.0f;
            }
        }
        if(high_count > -1){
            if(Input.GetKeyDown("s")){
                high_count--;
                height -= 3.0f;
            }
        }
        bird.position = new Vector3(bird.position.x, height, bird.position.z);
    }
    void OnTriggerEnter2D(Collider2D other){
        //Debug.Log("hit");
        Destroy(other.gameObject);
        if(other.gameObject.tag == "coin"){
            AddScore();
            // Debug.Log(GetScore);//ここまではいけてる.UIcontrolのほうでGetScoreすると値が返ってこない
        } 
        if(other.gameObject.tag == "heart"){
            Recover();
            // Debug.Log(GetHP);
        }
        if(other.gameObject.tag == "enemy"){
            Damage();
        }
    }
}
