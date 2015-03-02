using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;

public class GrowthbeatCore {
	
	public static void Initialize(string applicationId, string credentialId) {
				#if UNITY_ANDROID
					GrowthbeatCoreAndroid.Initialize(applicationId, credentialId);
				#elif UNITY_IPHONE
					GrowthbeatCoreIOS.Initialize(applicationId, credentialId); 
				#endif

		}
		
}
