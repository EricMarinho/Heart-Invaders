using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    StageControler stageControler;
    public int enemiesCont;
    float horizontal;
    Vector3 characterPosition;
    float readyTime = 0.6f;
    float readyTimer = 0f;
    float speed = 4f;
    bool isPlayerReady = true;
    public int lifes;
    public GameObject projectilePrefab;
    AudioSource audioSource;
    public AudioClip clip;
    public AudioClip clip2;
    public AudioClip clip3;
    Rigidbody2D rbody;
    float maxBond = 8.4f;
    float minBond = -8.4f;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        stageControler = GameObject.Find("StageController").GetComponent<StageControler>();
        audioSource= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if(isPlayerReady == true){
            if(Input.GetKeyDown(KeyCode.Space)){
                isPlayerReady = false;
                Instantiate(projectilePrefab, transform.position + Vector3.up * 0.5f, Quaternion.identity);
                audioSource.PlayOneShot(clip);
            }
        }
        if(isPlayerReady == false){
            readyTimer += Time.deltaTime * Time.timeScale;
            if(readyTimer > readyTime){
                isPlayerReady = true;
                readyTimer = 0f;
                audioSource.PlayOneShot(clip3);
            }
        }

        if(enemiesCont == stageControler.enemiesLeft){
             SceneManager.LoadScene(stageControler.stage);
        }

    }

    void FixedUpdate() {
        if(rbody.transform.position.x < minBond && horizontal < 0){
            horizontal = 0;
        }
        else if(rbody.transform.position.x > maxBond && horizontal > 0){
            horizontal = 0;
        }
        characterPosition = rbody.transform.position;
        characterPosition.x = characterPosition.x + speed * Time.deltaTime * horizontal; 
        rbody.MovePosition(characterPosition);
    }

    public void enemiesCount(){
        audioSource.PlayOneShot(clip2);
        enemiesCont++;
    }

}
