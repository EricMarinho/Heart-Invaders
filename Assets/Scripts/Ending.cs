using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position;
        position = transform.position;
        position.x += 1f * Time.deltaTime;
        transform.position = position;
        timer += Time.deltaTime * Time.timeScale;
        if(timer>=9f){
            Destroy(gameObject);
        }
    }
}
