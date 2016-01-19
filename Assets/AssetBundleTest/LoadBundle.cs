using UnityEngine;
using System.Collections;

public class LoadBundle : MonoBehaviour {

	AssetBundle bundle;

	// Use this for initialization
	void Start () {
		string assetsBundlePath = Application.streamingAssetsPath + "/bundle/";

		if(bundle != null)
			bundle.Unload(false);
		bundle = AssetBundle.LoadFromFile(assetsBundlePath + "bundle");

		string[] allAssetNames = bundle.GetAllAssetNames();
		foreach(var assetName in allAssetNames){
			print("AssetName: " + assetName);
			AssetBundleManifest assetBundleManifest = bundle.LoadAsset(assetName) as AssetBundleManifest;
			string[] allAssetBundles = assetBundleManifest.GetAllAssetBundles();
			foreach(var assetBundle in allAssetBundles){
				print("AssetBundleName: " + assetBundle);
				bundle = AssetBundle.LoadFromFile(assetsBundlePath + assetBundle);
				GameObject go = bundle.LoadAsset(assetBundle) as GameObject;
				Instantiate(go);
			}

		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
