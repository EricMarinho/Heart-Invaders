using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunflowerProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    float timer;
    float speed = 1f;
    float time;
    Rigidbody2D rbBody;

    // Start is called before the first frame update
    void Start()
    {
        rbBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        time = Random.Range(4.0f,7.0f);
        timer += Time.deltaTime * Time.timeScale;
        if(timer>=time){
            Destroy(gameObject);
        }
        rbBody.AddForce(transform.up * speed, ForceMode2D.Force);
    }
}
