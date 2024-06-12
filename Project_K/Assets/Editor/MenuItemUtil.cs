using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public static class MenuItemUtil
{
    private const string Ctrl = "%";
    private const string Alt = "&";
    private const string Shift = "#";


    [MenuItem("Util/ObjectOnOff " + Alt + "a", false, 0)]
    private static void ObjectOnOff()
    {
        Selection.activeGameObject.SetActive(!Selection.activeGameObject.activeSelf);
    }

    [MenuItem("Util/OpenLogoScene " + Shift + Alt + "1", false, 10)]
    private static void OpenLogoScene()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/LogoScene.unity");
    }

    [MenuItem("Util/OpenTitleScene " + Shift + Alt + "2", false, 11)]
    private static void OpenTitleScene()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/TitleScene.unity");
    }

    [MenuItem("Util/OpenTownScene " + Shift + Alt + "3", false, 12)]
    private static void OpenTownScene()
    {
        EditorSceneManager.OpenScene("Assets/Scenes/TownScene.unity");
    }


}
