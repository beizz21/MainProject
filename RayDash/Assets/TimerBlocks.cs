using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TimerBlocks : MonoBehaviour
{
    //I can have two floats, one boolean isCounting(). one is value of timer. one is value of timer at the start. or just one. in update, if iscounting = true, timer-= time.deltatime. if timer<= 0, Destroytrap. if collision is player, then set iscounting to true. 
    [SerializeField] GameObject trap;
    [SerializeField] float timer = 2f;
    bool IsCounting = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsCounting == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Destroy(trap);
                Debug.Log("trap");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IsCounting = true;
            //Destroy(trap);
        }
    }
}
//coroutine