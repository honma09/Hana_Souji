using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTitle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Jump"))
        {
            Application.LoadLevel("Game");
        }
	}
    //GUI描画
    void OnGUI()
    {
        GUI.Label(new Rect(0, 0
            , 100, 20), "タイトル");
    }
}
