﻿using UnityEngine;
using System.Collections;

public class GrowthbeatCoreComponent : MonoBehaviour {

	void Awake () {
		GrowthbeatCore.GetInstance().Initialize("APPLICATION_ID", "CREDENTIAL_ID");
	}

	void Start () {
	
	}
	
	void Update () {
	
	}
}
