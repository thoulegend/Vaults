using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Data.Linq;

public class DisplaySQLQuery : MonoBehaviour {
	public VaultsConnectDB initDBConnect;
	// Use this for initialization
	void Start () {

		List< string >[] list = initDBConnect.Select ();
	
		Debug.Log(list[1].Find(p => p.Contains ("Alevian")));
		string CardName = list [1].Find (p => p.Contains ("Alevian"));
		Text cardNameBox; 
		cardNameBox = GetComponent<Text> ();
	cardNameBox.text = CardName;
		
		cardNameBox.enabled = true;
	}


}
