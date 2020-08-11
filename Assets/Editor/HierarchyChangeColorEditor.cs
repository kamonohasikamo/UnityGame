using System.Linq;
using UnityEngine;
using UnityEditor;

public static class HierarchyChangeColorEditor
{
	// 横幅
	private const int width = 16;


	[InitializeOnLoadMethod]
	private static void HierarchyChangeColor()
	{
		EditorApplication.hierarchyWindowItemOnGUI += changeGUI;
		EditorApplication.hierarchyWindowItemOnGUI += setActiveBoxView;
	}

	private static void changeGUI(int instanceId, Rect selectionRect)
	{
		//=============================================
		// 一行おきに色を変えてHierarchyを見やすくする
		//=============================================
		var index = (int)(selectionRect.y - 4) / 16;
		if(index % 2 == 0)
		{
			return;
		}

		var colorPos = selectionRect;
		colorPos.x = 0;
		colorPos.xMax = selectionRect.xMax;

		var color = GUI.color;
		GUI.color = new Color(0, 0, 0, 0.1f);
		GUI.Box(colorPos, string.Empty);
		GUI.color = color;

		//=============================================
		// 無効なコンポーネントが
		// アタッチされているかどうかを表示
		//=============================================
		var atach = EditorUtility.InstanceIDToObject(instanceId) as GameObject;
		if (atach == null)
		{
			return;
		}

		var isWarning = atach.GetComponents<MonoBehaviour>().Any(c => c == null);

		if (!isWarning)
		{
			return;
		}

		var warningPos = selectionRect;
		warningPos.x = warningPos.xMax - width;
		warningPos.width = width;
		GUI.Label(warningPos, "!?");
	}

	private static void setActiveBoxView(int instanceId, Rect selectionRect)
	{
		//=============================================
		// SetActive
		// チェックボックスを表示
		//=============================================
		var atach = EditorUtility.InstanceIDToObject(instanceId) as GameObject;

		if (atach == null)
		{
			return;
		}

		var setActivePos = selectionRect;
		setActivePos.x = setActivePos.xMax - width - 10;
		setActivePos.width = width;

		var newActiveBox = GUI.Toggle(setActivePos, atach.activeSelf, string.Empty);

		if(newActiveBox == atach.activeSelf)
		{
			return;
		}

		atach.SetActive(newActiveBox);
	}
}
