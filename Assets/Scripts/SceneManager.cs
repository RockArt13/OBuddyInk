    using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using Assets.Scripts;


public class SceneManager : MonoBehaviour
{
    private List<Scenes> _scenes;

    [SerializeField]
    private GameObject _scenePrefab;
    /*
    [SerializeField]
    private CharacterMoods _aliceMoods;
    [SerializeField]
    private CharacterMoods _playerMoods;
    */
    private static List<SceneData> _loadedScenes;

    private void Start()
    {
        _scenes = new List<Scenes>();

        if (_loadedScenes != null)
        {
            RestoreState();
        }
    }

    private void RestoreState()
    {
        foreach (var scene in _loadedScenes)
        {
            ShowScene(scene.Name, scene.Position);
        }

        _loadedScenes = null;
    }

    public void ShowScene(string name, string position)
    {
        if (!Enum.TryParse(name, out SceneName nameEnum))
        {
            Debug.LogWarning($"Failed to parse scene name to enum: {name}");
            return;
        }

        if (!Enum.TryParse(position, out ScenePosition positionEnum))
        {
            Debug.LogWarning($"Failed to parse character position to enum: {position}");
            return;
        }


        ShowScene(nameEnum, positionEnum);
    }

    public void ShowScene(SceneName name, ScenePosition position)
    {
        var scene = _scenes.FirstOrDefault(x => x.Name == name);

        if (scene == null)
        {
            var sceneObject = Instantiate(_scenePrefab, gameObject.transform, false);
            scene = sceneObject.GetComponent<Scenes>();

            _scenes.Add(scene);
        }
        else if (scene.IsShowing)
        {
            Debug.LogWarning($"Failed to show scene {name}. Scene already showing");
            return;
        }

        scene.Init(name, position);
    }

    public void HideScene(string name)
    {
        if (!Enum.TryParse(name, out SceneName nameEnum))
        {
            Debug.LogWarning($"Failed to parse scene name to character enum: {name}");
            return;
        }

        HideScene(nameEnum);
    }

    public void HideScene(SceneName name)
    {
        var scene = _scenes.FirstOrDefault(x => x.Name == name);

        if (scene?.IsShowing != true)
        {
            Debug.LogWarning($"Scene {name} is not currently shown. Can't hide it.");
            return;
        }
        else
        {
            scene.Hide();
        }
    }
   
    public List<SceneData> GetVisibleScenes()
    {
        var visibleScenes = _scenes.Where(x => x.IsShowing).ToList();

        var sceneDataList = new List<SceneData>();

        foreach (var scene in visibleScenes)
        {
            sceneDataList.Add(scene.GetSceneData());
        }

        return sceneDataList;
    }

    public static void LoadState(List<SceneData> scenes)
    {
        _loadedScenes = scenes;
    }
}
