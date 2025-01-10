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
        ICastingSkill iCastingSkill = new DefaultAttack();
        var temp = new CharacterBattleRole(this, iCastingSkill);
        IAttacker attacker = temp;
        IDefender defender = temp;

        BattleEventProcessor.TryBattleActionProcess(attacker, defender);
    }

    [Button]
    public void SkillFunc()
    {
        ICastingSkill iCastingSkill = new Fireball();
        var temp = new CharacterBattleRole(this, iCastingSkill);
        IAttacker attacker = temp;
        IDefender defender = temp;

        BattleEventProcessor.TryBattleActionProcess(attacker, defender);
    }
}