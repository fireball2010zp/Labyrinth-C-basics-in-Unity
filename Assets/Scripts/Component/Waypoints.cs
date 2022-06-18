using System.IO;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR

public class Waypoints : MonoBehaviour
{
    public List<Transform> nodes = new List<Transform>();

    // Saving Path (dinamic)
    public string directoryName;
    private string savingPath;
    public string SceneName;

    public string SavingPath { get => savingPath; set => savingPath = value; }

    private void OnDrawGizmos()
    {
        SceneName = UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene().name;
        directoryName = "BonusData";
        SavingPath = Path.Combine((Application.dataPath + "/" + directoryName), "BonusMap_" + SceneName + ".xml");
    }

    
}

#endif

// скрипт действует, если находимся в редакторе