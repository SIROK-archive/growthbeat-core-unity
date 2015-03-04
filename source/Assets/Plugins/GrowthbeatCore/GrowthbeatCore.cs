using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class GrowthbeatCore
{
	private static GrowthbeatCore instance = new GrowthbeatCore ();

	#if UNITY_IPHONE
	[DllImport("__Internal")] static extern void initializeWithApplicationId(string applicationId, string credentialId);
	#endif

	public static GrowthbeatCore GetInstance ()
	{
		return GrowthbeatCore.instance;
	}

	public void Initialize (string applicationId, string credentialId)
	{
		#if UNITY_ANDROID
		using(AndroidJavaClass gbcclass = new AndroidJavaClass( "com.growthbeat.GrowthbeatCore" )) {
			AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
			AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"); 
			gbcclass.CallStatic<AndroidJavaObject>("getInstance").Call("initialize", activity, applicationId, credentialId);
		}
		#elif UNITY_IPHONE && !UNITY_EDITOR
		initializeWithApplicationId(applicationId, credentialId);
		#endif

	}
}
