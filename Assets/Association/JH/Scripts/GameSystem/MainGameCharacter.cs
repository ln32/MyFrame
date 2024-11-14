using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

public class MainGameCharacter : MonoBehaviour, IStateMachine
{
    public int Level = 20;

    public CharacterStateMachine _GetStateMachine;

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

    public CharacterStateMachine GetStateMachine => _GetStateMachine;

    [Button]
    public void IdleFunc()
    {
        _GetStateMachine.Event_TimeToIdle();
        //BattleEventProcessor.TryBattleActionProcess(new CharacterAttacker(this, new DefaultAttack()), new CharacterDefender(this));
    }

    [Button]
    public void AttackFunc()
    {
        _GetStateMachine.Event_Attack();
        BattleEventProcessor.TryBattleActionProcess(new CharacterBattleRole(this, new DefaultAttack()),
            new CharacterBattleRole(this));
    }

    [Button]
    public void SkillAttackFunc()
    {
        BattleEventProcessor.TryBattleActionProcess(new CharacterBattleRole(this), new CharacterBattleRole(this));
    }

    public void DelayedAction(float delay, Action<IDefender> callback)
    {
        StartCoroutine(PrintAfterDelay(delay, () => callback(new CharacterBattleRole(this))));
    }

    private IEnumerator PrintAfterDelay(float delay, Action callback)
    {
        // Play Animation
        yield return new WaitForSeconds(delay);
        callback?.Invoke();
    }
}