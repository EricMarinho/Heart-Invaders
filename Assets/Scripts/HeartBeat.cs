using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeat : MonoBehaviour
{
    public GameObject prefab;
    public GameObject obj;
    Animation anim;
    float timer;
    float time;
    float timer2;
    Quaternion angle;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * Time.timeScale;
        if(timer>=9f){
            anim.Play();
            time = Random.Range(0.25f,1.0f);
            angle =  Quaternion.Euler(Random.Range(0.0f, 0.0f), Random.Range(0.0f, 0.0f), Random.Range(0.0f, 360.0f));
            timer2 += Time.deltaTime * Time.timeScale;
            if(timer2>=time){
                Instantiate(prefab, transform.position, angle);
                timer2 = 0f;
            }
        }
        if(timer>=16f){
            obj.SetActive(true);
        }
        
    }
}
