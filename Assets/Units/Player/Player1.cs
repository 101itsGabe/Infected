using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : BasePlayer
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "infected")
        {
            Debug.Log("Collided with Infected");
            GameManager.Instance.ChangeState(GameState.GameEnd);
        }
        if(collision.tag == "Burger")
        {
            Debug.Log("ZOOWEEE MAMA");
        }
    }
}
