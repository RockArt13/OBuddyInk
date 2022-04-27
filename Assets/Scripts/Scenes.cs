using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scenes : MonoBehaviour
{
    public ScenePosition Position { get; private set; }
    public SceneName Name { get; private set; }
    public bool IsShowing { get; private set; }

   

    private float _offScreenX;
    private float _onScreenX;

    private readonly float _animationSpeed = 0.5f;

    private Scenes _scenes;

    public Sprite Forest;
    public Sprite Hall;

    public Sprite GetScene(SceneName scene)
    {
        switch (scene)
        {
            case SceneName.Hall:
                return Hall;
            case SceneName.Forest:
                return Forest ?? Hall;
               
            default:
                Debug.Log($"Didn't find Sprite for scene: {scene}");
                return Hall;
        }
    }


    public void Init(SceneName name, ScenePosition position)
    {
        Name = name;
        Position = position;

        Show();
    }

    public void Show()
    {
        SetAnimationValues();

        // Position outside of the screen
        transform.position = new Vector3(_offScreenX, transform.position.y, transform.localPosition.z);

        UpdateScene();

        LeanTween.moveX(gameObject, _onScreenX, _animationSpeed).setEase(LeanTweenType.linear).setOnComplete(() =>
        {
            IsShowing = true;
        });
    }
    public void Hide()
    {
        LeanTween.moveX(gameObject, _offScreenX, _animationSpeed).setEase(LeanTweenType.linear).setOnComplete(() =>
        {
            IsShowing = false;
        });
    }

   
    private void UpdateScene()
    {
        var sprite = _scenes.GetScene(Name);
        var image = GetComponent<Image>();

        image.sprite = sprite;
        image.preserveAspect = true;
    }

    private void SetAnimationValues()
    {
        switch (Position)
        {
            case ScenePosition.Left:
                _onScreenX = Screen.width * 0.25f;
                _offScreenX = -Screen.width * 0.25f;
                break;
            case ScenePosition.Center:
                _onScreenX = Screen.width * 0.5f;
                _offScreenX = -Screen.width * 0.25f;
                break;
            case ScenePosition.Right:
                _onScreenX = Screen.width * 0.75f;
                _offScreenX = Screen.width * 1.25f;
                break;
        }
    }

    public SceneData GetSceneData()
    {
        return new SceneData
        {
            Name = Name,
            Position = Position
        };
    }

}
