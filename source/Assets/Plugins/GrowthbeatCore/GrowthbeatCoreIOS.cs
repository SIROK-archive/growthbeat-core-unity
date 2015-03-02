using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;

public class GrowthbeatCoreIOS {

		#if UNITY_IPHONE
			[DllImport("__Internal")]
				private static extern void growthbeatCoreinitializeWithApplicationId(string applicationID, string credentialId);
		#endif

		public static void Initialize(string applicationID, string credentialId) {
				#if UNITY_IPHONE && !UNITY_EDITOR
					growthbeatCoreinitializeWithApplicationId(applicationID, credentialId);
				#endif
		}

};
