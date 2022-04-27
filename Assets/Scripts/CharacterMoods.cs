using Assets.Scripts;
using UnityEngine;

public class CharacterMoods : MonoBehaviour
{
    public CharacterName Name;

    public Sprite Good;
    public Sprite Angry;
    public Sprite Serious;
    public Sprite Happy;
    public Sprite Other;

    public Sprite GetMoodSprite(CharacterMood mood)
    {
        switch (mood)
        {
            case CharacterMood.Good:
                return Good;
            case CharacterMood.Angry:
                return Angry ?? Good;
            case CharacterMood.Happy:
                return Happy ?? Good;
            case CharacterMood.Serious:
                return Serious ?? Good;
            case CharacterMood.Other:
                return Other ?? Good;
            default:
                Debug.Log($"Didn't find Sprite for character: {Name}, mood: {mood}");
                return Good;
        }
    }
}
