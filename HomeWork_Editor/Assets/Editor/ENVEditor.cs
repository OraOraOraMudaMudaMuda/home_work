using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class ENVEditor : EditorWindow
{
    static ENVEditor envEditor;
    static Rect windowRect1 = new Rect(10, 10, 350, 200);

    Manager manager;
    Enemy enemyScript;
    Player player;

    [MenuItem("Window/Editor/Env Editor")]
    static void OpenWindow()
    {
        if (envEditor == null)
            envEditor = GetWindow<ENVEditor>();
    }

    void OnGUI()
    {
        BeginWindows();
        //Color ccc = GUI.backgroundColor;
        //ccc = Color.red;
        GUI.contentColor = Color.red;

        GUI.color = Color.yellow;
        //var style = new GUIStyle(GUI.skin.window);
        //style.normal.textColor = Color.red;
        //style.active.textColor = Color.green;

        //windowRect1 = GUILayout.Window(0, windowRect1, ENVwindow, "Map Setting", style);
        //매니저, 적군 세팅
        if (manager == null)
            manager = FindObjectOfType<Manager>();
        if (enemyScript == null)
        {
            enemyScript = manager.GetEnemyPrefab().GetComponent<Enemy>();
        }
        EditorGUILayout.ObjectField("Enemy Prefab", manager.GetEnemyPrefab(), typeof(GameObject), true);
        manager.SetMaxEnemy(EditorGUILayout.IntField("Max Enemy Count", manager.GetMaxEnemy()));
        manager.SetRespawnTick(EditorGUILayout.Slider("Enemy Respawn Time", manager.GetRespawnTick(), 0.01f, 10f));

        EditorGUI.BeginChangeCheck();
        enemyScript.SetScore(EditorGUILayout.IntField("Enemy Kill Score", enemyScript.GetScore()));
        if (enemyScript.GetScore() <= 0)
            enemyScript.SetScore(1);
        if (EditorGUI.EndChangeCheck())
            EditorUtility.SetDirty(enemyScript);
        enemyScript.SetDestroyTime(EditorGUILayout.FloatField("Enemy Destroy Time", enemyScript.GetDestroyTime()));
        EditorUtility.SetDirty(manager);

        GUI.color = Color.green;
        //플레이어 세팅
        if (player == null)
            player = FindObjectOfType<Player>();

        GUILayout.Space(10f);
        GUILayout.Label("Player Setting");
        EditorGUILayout.ObjectField("player Prefab", player.gameObject, typeof(GameObject), true);
        player.SetMouseX(EditorGUILayout.Slider("Mouse Sanse X", player.GetMouseX(), 0.1f, 100f));
        player.SetMouseY(EditorGUILayout.Slider("Mouse Sanse Y", player.GetMouseY(), 0.1f, 100f));
        player.SetMoveSpeed(EditorGUILayout.Slider("Player Speed", player.GetMoveSpeed(), 0.1f, 50f));
        EndWindows();
        Repaint();
    }
    
    //void ENVwindow(int unusedWindowID)
    //{
    //    //매니저, 적군 세팅
    //    if (manager == null)
    //        manager = FindObjectOfType<Manager>();
    //    if (enemyScript == null)
    //    {
    //        enemyScript = manager.GetEnemyPrefab().GetComponent<Enemy>();
    //    }
    //    EditorGUILayout.ObjectField("Enemy Prefab", manager.GetEnemyPrefab(), typeof(GameObject), true);
    //    manager.SetMaxEnemy(EditorGUILayout.IntField("Max Enemy Count", manager.GetMaxEnemy()));
    //    manager.SetRespawnTick(EditorGUILayout.Slider("Enemy Respawn Time", manager.GetRespawnTick(), 0.01f, 10f));

    //    EditorGUI.BeginChangeCheck();
    //    enemyScript.SetScore(EditorGUILayout.IntField("Enemy Kill Score", enemyScript.GetScore()));
    //    if (enemyScript.GetScore() <= 0)
    //        enemyScript.SetScore(1);
    //    if (EditorGUI.EndChangeCheck())
    //        EditorUtility.SetDirty(enemyScript);
    //    enemyScript.SetDestroyTime(EditorGUILayout.FloatField("Enemy Destroy Time", enemyScript.GetDestroyTime()));
    //    EditorUtility.SetDirty(manager);

    //    //플레이어 세팅
    //    if (player == null)
    //        player = FindObjectOfType<Player>();

    //    GUILayout.Space(10f);
    //    GUILayout.Label("Player Setting");
    //    EditorGUILayout.ObjectField("player Prefab", player.gameObject, typeof(GameObject), true); 
    //    player.SetMouseX(EditorGUILayout.Slider("Mouse Sanse X", player.GetMouseX(), 0.1f, 100f));
    //    player.SetMouseY(EditorGUILayout.Slider("Mouse Sanse Y", player.GetMouseY(), 0.1f, 100f));

    //    player.SetMoveSpeed(EditorGUILayout.Slider("Player Speed", player.GetMoveSpeed(), 0.1f, 50f));
    //}
}
