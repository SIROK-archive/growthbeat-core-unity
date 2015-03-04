using UnityEngine;
using System;
using System.Collections;

public class GrowthbeatCoreAndroid {

		private static GrowthbeatCoreAndroid instance = new GrowthbeatCoreAndroid();

		#if UNITY_ANDROID
			private static AndroidJavaObject growthbeatCore;
		#endif

		private GrowthbeatCoreAndroid() {
				#if UNITY_ANDROID
					using(AndroidJavaClass gbcclass = new AndroidJavaClass( "com.growthbeat.GrowthbeatCore" )) {
							growthbeatCore = gbcclass.CallStatic<AndroidJavaObject>("getInstance"); 
					}
				#endif
		}

		public static void Initialize(string applicationId, string credentialId) {
			instance.PrivateInitialize(applicationId, credentialId);
		}

		private void PrivateInitialize(string applicationId, string credentialId) {
				#if UNITY_ANDROID
					if (growthbeatCore == null)
						return;
					AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
					AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"); 
					growthbeatCore.Call("initialize", activity, applicationId, credentialId);
				#endif
		}

}
