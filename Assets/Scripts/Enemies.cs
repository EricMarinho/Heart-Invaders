using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemies : MonoBehaviour
{
    Transform enemyHolder;
    PlayerController player;
    int moveDirection = 1;
    float moveTimer;
    Vector3 movePosition;
    StageControler stageControler;
    float speed = 1f;
    void Start()
    {
        enemyHolder = GetComponent<Transform>();
        stageControler = GameObject.Find("StageController").GetComponent<StageControler>();
        player = GameObject.Find("MainCharacter").GetComponent<PlayerController>();
        InvokeRepeating("MoveEnemy",0.1f,0.75f);
    }

    void MoveEnemy(){

        enemyHolder.position += Vector3.right * speed;
        foreach(Transform enemy in enemyHolder){
            if(enemy.position.x < -7.5 || enemy.position.x > 8.5){
                speed = -speed;
                enemyHolder.position += Vector3.down * 0.5f;
                return;
            }
            if(enemy.position.y <= -3.3){

                if(stageControler.stage != 4){
                    SceneManager.LoadScene(stageControler.stage -1);
                }
                else{
                    SceneManager.LoadScene(stageControler.stage);
                }
            }
        }
        
        if(enemyHolder.childCount==1){
            CancelInvoke();
            InvokeRepeating("MoveEnemy", 0.1f, 0.25f);
        }
    }
        
 

}
