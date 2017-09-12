using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;




public class Jump : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.W))
        {
            Vector3 playerPos;
            playerPos = this.transform.position;
            Vector3 dest = new Vector3(playerPos.x + 3, playerPos.y, playerPos.z);
            transform.DOJump(dest, 3.0f, 1, 1, false);
            //powerUpSlider.gameObject.SetActive(true);
            //powerUpSlider.value -= 0.05f;
        }
		
	}
}
