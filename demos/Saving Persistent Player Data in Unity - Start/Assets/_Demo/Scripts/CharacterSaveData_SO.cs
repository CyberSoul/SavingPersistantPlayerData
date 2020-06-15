using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character Save Data", menuName = "Character/Data", order = 1)]
public class CharacterSaveData_SO : ScriptableObject
{
    [Header("Stats")]

    [SerializeField]
    int currentHealth;

    [Header("Leveling")]

    [SerializeField]
    int currentLevel = 1;

    [SerializeField]
    int maxLevel = 30;

    [SerializeField]
    int basisPoints = 200;

    [SerializeField]
    int pointTillNextLevel;
    
    [SerializeField]
    float levelBuff = 0.1f;

    public float LevelMultiplier
    {
        get { return 1 + (currentLevel - 1) * levelBuff; }
    }

    public int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }

    public void AggregateAttackPoints(int points)
    {
        pointTillNextLevel -= points;
        if(pointTillNextLevel <= 0)
        {
            currentLevel = Mathf.Clamp(currentLevel + 1, 0, maxLevel);

            pointTillNextLevel += (int)(basisPoints * LevelMultiplier);

            Debug.Log($"LELVE UP! NEW level: {currentLevel}");
        }
    }

    private void OnEnable()
    {
        if (pointTillNextLevel == 0)
        {
            pointTillNextLevel = (int)(basisPoints * LevelMultiplier);
        }
    }
}
