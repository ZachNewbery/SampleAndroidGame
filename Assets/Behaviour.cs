using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine.SceneManagement;
using Random=UnityEngine.Random;
using UnityEngine;

public class Behaviour : MonoBehaviour
{
    public float maxX, minX, maxY, minY, speed;
    Vector2 target;
    
    // Start is called before the first frame update
    void Start()
    {
        target = getPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if((Vector2) transform.position != target)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        } else
        {
            target = getPosition();
        }
    }

    Vector2 getPosition()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);

        return new Vector2(x, y);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Tambourine") {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
