using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RESPAWN_TYPE
{
    UP,//上
    RIGHT,//右
    DOWN,//下
    LEFT,//左
    SIZEOF,//敵の出現位置
}

//敵を制御するコンポーネント
public class Enemy : MonoBehaviour
{
    public Vector2 m_respawnPosInside;//敵の出現位置（内側）
    public Vector2 m_respawnPosOutside;//敵の出現位置（外側）
    public int m_hpMax;//HPの最大値
    public int m_downspeed;//この敵に当たるとプレイヤーの速度が下がる量

    private int m_hp;//ＨＰ
    private Vector3 m_direction; // 進行方向
    //敵が生成されたときに呼び出される関数
    private void Start()
    {
        //ＨＰを初期化する
        m_hp = m_hpMax;
    }
    //マイフレーム呼び出される関数
    private void Update()
    {

    }
    //敵が出現すると時に初期化する関数
    public void Init(RESPAWN_TYPE respawnType)
    {
        var pos = Vector3.zero;
        // 指定された出現位置の種類に応じて、
        // 出現位置と進行方向を決定する
        switch (respawnType)
        {
            // 出現位置が上の場合
            case RESPAWN_TYPE.UP:
                pos.x = Random.Range(
                    -m_respawnPosInside.x, m_respawnPosInside.x);
                pos.y = m_respawnPosOutside.y;
                m_direction = Vector2.down;
                break;

            // 出現位置が右の場合
            case RESPAWN_TYPE.RIGHT:
                pos.x = m_respawnPosOutside.x;
                pos.y = Random.Range(
                    -m_respawnPosInside.y, m_respawnPosInside.y);
                m_direction = Vector2.left;
                break;

            // 出現位置が下の場合
            case RESPAWN_TYPE.DOWN:
                pos.x = Random.Range(
                    -m_respawnPosInside.x, m_respawnPosInside.x);
                pos.y = -m_respawnPosOutside.y;
                m_direction = Vector2.up;
                break;

            // 出現位置が左の場合
            case RESPAWN_TYPE.LEFT:
                pos.x = -m_respawnPosOutside.x;
                pos.y = Random.Range(
                    -m_respawnPosInside.y, m_respawnPosInside.y);
                m_direction = Vector2.right;
                break;
        }

        // 位置を反映する
        transform.localPosition = pos;
    }
}
