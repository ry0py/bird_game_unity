using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPControl : MonoBehaviour
{
    // //ここをstaticにしないと A field initializer cannot reference the non-static field, method, or property 'HPControl.MAX_HP' というエラーが出る
    // [SerializeField] static int MAX_HP = 50;
    // [SerializeField] int HEAL_HP = 5;
    // [SerializeField] int DAMAGE_HP = 10;
    // private int NOW_HP = MAX_HP;

    // public void Recover(){
    //     if(NOW_HP>=50) return;
    //     NOW_HP += HEAL_HP;
    // }
    // public void Damage(){
    //     if(NOW_HP<=0) return;
    //     NOW_HP -= DAMAGE_HP;
    // }
    // public int GetHP(){
    //     return NOW_HP;
    // }
    // public void Death(){
    //     if(NOW_HP<=0) return;
    //     //TODO:ゲームオーバー用のUIとスコアを表示できるようにする

    // }
}
