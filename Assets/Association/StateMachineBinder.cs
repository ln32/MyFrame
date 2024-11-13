using AnimationState;
using System;

// 상태머신쪽에서 하위 인터페이스 객체를 대상으로 애니메이션 호출 할 예정.
public interface CharacterStateMachineBinder : IIdle, IAttack, IMove, IDamaged, IDead { }
public interface MonsterStateMachineBinder : IIdle, IAttack, IMove, IGroggy, IDead { }
public interface PetStateMachineBinder : IIdle, IAttack, IMove, IReact { }