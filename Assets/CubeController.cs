using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    //キューブの移動速度
    private float speed = -12;

    //消滅位置
    private float deadLine = -10;

    private GameObject ground;

    public AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        this.ground = GameObject.Find("ground");

        this.audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        //画面外に出たら破棄する
        if(transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
       if(other.gameObject.tag == "ground" || other.gameObject.tag == "cube")
        {
            this.audioSource.Play();
        }
    }
}
