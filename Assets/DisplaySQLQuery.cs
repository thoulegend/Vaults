using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DisplaySQLQuery : MonoBehaviour {
	public VaultsConnectDB initDBConnect;
	// Use this for initialization
	void Start () {

		List< string >[] list = initDBConnect.Select ();
	
	}

}
