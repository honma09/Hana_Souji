using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour {

    public float speed = 5;
    public GameObject bullet;

    private Vector2 player_pos;
    // Use this for initialization
    void Start()
    {

    }
	
	// Update is called once per frame
	void Update () {
        // 右・左
        float x = Input.GetAxisRaw("Horizontal");

        // 上・下
        float y = Input.GetAxisRaw("Vertical");

        // 移動する向きを求める
        Vector2 direction = new Vector2(x, y).normalized;

        // 移動する向きとスピードを代入する
        GetComponent<Rigidbody2D>().velocity = direction * speed;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }

        Clamp();
    }

    void Clamp()
    {
        player_pos = transform.position; //プレイヤーの位置を取得

        player_pos.x = Mathf.Clamp(player_pos.x, -2.2f, 2.2f); //x位置が常に範囲内か監視]
        player_pos.y = Mathf.Clamp(player_pos.y, -4.0f, 4.0f);
        transform.position = new Vector2(player_pos.x, player_pos.y); //範囲内であれば常にその位置がそのまま入る
    }
}

