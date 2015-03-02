using UnityEngine;
using System.Collections;
using System;

public class GrowthbeatCoreAndroid {

		private static GrowthbeatCoreAndroid instance = new GrowthbeatCoreAndroid();

		#if UNITY_ANDROID && !UNITY_EDITOR
			private static AndroidJavaObject growthbeatCore;
		#endif

		private GrowthbeatCoreAndroid() {
				#if UNITY_ANDROID && !UNITY_EDITOR
					using(AndroidJavaClass gbcclass = new AndroidJavaClass( "com.growthbeatCore.GrowthbeatCore" )) {
							growthbeatCore = gbcclass.CallStatic<AndroidJavaObject>("getInstance"); 
					}
				#endif
		}

		public static void Initialize(string applicationId, string credentialId) {
			instance.PrivateInitialize(applicationId, credentialId);
		}

		private void PrivateInitialize(string applicationId, string credentialId) {
				#if UNITY_ANDROID && !UNITY_EDITOR
					if (growthbeatCore == null)
						return;
					AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
					AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"); 
					growthbeatCore.Call<AndroidJavaObject>("initialize", activity, applicationId, credentialId);
				#endif
		}

}
