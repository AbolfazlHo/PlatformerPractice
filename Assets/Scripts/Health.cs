using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	int _numberOfHealth = 2;

	[SerializeField]
	Image[] healthImages;

	Die _die = new Die ();

	// Use this for initialization
	void Start () {
		//_numberOfHealth = healthImages.Length;
		_numberOfHealth = 2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void reduceHealth(){
		Debug.Log ("REDUCE HEALTH");
		if (_numberOfHealth > 0) {
			Debug.Log("RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR");
			healthImages [_numberOfHealth].gameObject.SetActive (false);
			_numberOfHealth--;
		} else {
			_die.PlayerIsDead ();
		}

	}
}
