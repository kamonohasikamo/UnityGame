using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Reflection;

public class ShortcutsControllerEditor : EditorWindow
{
	// Shift + F8
	[MenuItem("Tools/InputName #F8")]
	private static void shortCutInputName()
	{
		EditorSceneManager.OpenScene("Assets/Scenes/InputName.unity", OpenSceneMode.Single);
	}

	// Shift + F9
	[MenuItem("Tools/Description #F9")]
	private static void shortCutDescription()
	{
		EditorSceneManager.OpenScene("Assets/Scenes/Description.unity", OpenSceneMode.Single);
	}

	// Shift + F10
	[MenuItem("Tools/Game #F10")]
	private static void shortCutGame()
	{
		EditorSceneManager.OpenScene("Assets/Scenes/Game.unity", OpenSceneMode.Single);
	}

	// Shift + F11
	[MenuItem("Tools/Result #F11")]
	private static void shortCutResult()
	{
		EditorSceneManager.OpenScene("Assets/Scenes/Result.unity", OpenSceneMode.Single);
	}

	// Shift + F12
	[MenuItem("Tools/Start #F12")]
	private static void shortCutStart()
	{
		EditorSceneManager.OpenScene("Assets/Scenes/Start.unity", OpenSceneMode.Single);
	}

	// コンソール出力のクリア c (Cだけ単押しで消える)
	[MenuItem("Tools/ClearConsoleLogs _c")]
	private static void ClearConsoleLogs()
	{
		var type = Assembly
		.GetAssembly(typeof( SceneView ))
		#if UNITY_2017_1_OR_NEWER
			.GetType("UnityEditor.LogEntries")
		#else
			.GetType("UnityEditorInternal.LogEntries")
		#endif
			;
		var method = type.GetMethod("Clear", BindingFlags.Static | BindingFlags.Public);
		method.Invoke(null, null);
	}
}
