using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    PlayerController player;
    Vector2 position;
    float speed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("MainCharacter").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;
        position.y = position.y + speed * Time.deltaTime;
        transform.position = position;
        if(transform.position.y >= 6){
            Destroy(gameObject);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D other){
        player.enemiesCount();
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
