using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

public class MainGameCharacter : MonoBehaviour
{
    public int Level = 20;


    [SerializeField] public ItemInventory ItemInventory;
    public AchievementSpec AchievementSpec;
    public CharacterTypeSpec CharacterTypeSpec;


    public EquipItemPlatform EquipItemPlatform;

    public BattleClass BattleClass { get; set; } = new WarriorBattleClass();

    public void Start()
    {
        EquipItemPlatform = new EquipItemPlatform();
        CharacterTypeSpec = new CharacterTypeSpec();
        AchievementSpec = new AchievementSpec();
        ItemInventory = new ItemInventory();
    }


    [Button]
    public void AttackFunc()
    {
        BattleEventProcessor.TryAttackProcess(new CharacterAttacker(this), new CharacterDefender(this));
    }

    public void DelayMsg(float delay, Action action)
    {
        StartCoroutine(PrintAfterDelay(delay, action));
    }

    IEnumerator PrintAfterDelay(float delay, Action action)
    {
        // Play Animation
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }
}