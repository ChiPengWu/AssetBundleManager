using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;

public class CreateAssetBundles : MonoBehaviour 
{
	static AssetBundleManifest assetBundleManifest;
	static AssetBundle bundle;

	#if UNITY_EDITOR
	[MenuItem ("Assets/Build AssetBundles")]
	static void BuildAllAssetBundles ()
	{
		assetBundleManifest = BuildPipeline.BuildAssetBundles ("Assets//StreamingAssets/bundle");
		AssetDatabase.Refresh();
		string[] allAssetBundles = assetBundleManifest.GetAllAssetBundles();
		foreach(var assetBundle in allAssetBundles){
			print("AssetBundleName: " + assetBundle);
//			string[] allDependencies = assetBundleManifest.GetAllDependencies(assetBundle);
//			foreach(var dependencie in allDependencies){
//				print("DependAssetBundleName: " + dependencie);
//			}
//			string[] directDependencies = assetBundleManifest.GetDirectDependencies(assetBundle);
//			foreach(var direct in directDependencies){
//				print("DirectDependAssetBundleName: " + direct);
//			}

			string assetsBundlePath = Application.streamingAssetsPath + "/bundle/" + assetBundle;

			if(bundle != null)
				bundle.Unload(true);
			bundle = AssetBundle.LoadFromFile(assetsBundlePath);

			string[] allAssetNames = bundle.GetAllAssetNames();
			foreach(var assetName in allAssetNames){
				print("AssetName: " + assetName);
//				string[] assetPath = AssetDatabase.GetAssetPathsFromAssetBundleAndAssetName(assetBundle, assetName);
//				foreach(var aPath in assetPath){
//					print("AssetPath: " + aPath);
//					string[] dependencie = AssetDatabase.GetDependencies(aPath);
//					foreach(var dep in dependencie){
//						print("Dependencie: " + dep);
//					}
//				}
			}
		}

	}
	#endif

}