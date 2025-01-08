using Sirenix.OdinInspector;
using SkillAffactCase;
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
        _GetStateMachine.IdleState.SwitchState.Invoke();
    }

    [Button]
    public void AttackFunc()
    {
        ISkill skill = new DefaultAttack();
        CharacterBattleRole temp = new CharacterBattleRole(this, skill);
        IAttacker attacker = temp;
        IDefender defender = temp;

        BattleEventProcessor.TryBattleActionProcess(attacker, defender);
    }

    [Button]
    public void SkillFunc()
    {
        ISkill skill = new Fireball();
        CharacterBattleRole temp = new CharacterBattleRole(this, skill);
        IAttacker attacker = temp;
        IDefender defender = temp;

        BattleEventProcessor.TryBattleActionProcess(attacker, defender);
    }
}