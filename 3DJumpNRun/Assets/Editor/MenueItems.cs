using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.SceneManagement;

public class MenueItems : MonoBehaviour {

    [MenuItem("OpenScene/Start Screen %0")]
	static void StartScreen() {

        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/StartScreen.unity");
    }

    [MenuItem("OpenScene/Level1 %1" )]
    static void Level01() {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/Level1.unity");
    }
}
