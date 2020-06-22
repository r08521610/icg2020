### Attack Behavior

```mermaid
classDiagram
	class AttackBehavior {
		float m_ChargeTime
		float m_ChargeIncreaseRatio
		
		Attack()
		ChargedAttack()
		+OnAttackEnd()
	}
	
	class SwordAttackBehavior {
		-SwordEntity m_Sword
	}
	class GunAttackBehavior {
		-Transform m_FirePoint
		-GameObject m_BulletPrefab
		-GameObject m_ChargedBulletPrefab
	}
	
	AttackBehavior <|-- SwordAttackBehavior
	AttackBehavior <|-- GunAttackBehavior
	
```

### Entity

* 在 Weapon Entity, 我試著使用設計模式 Hooks and Anchors 使其在繼承的子物件去決定各個函式的行為；而上層物件決定函示執行的邏輯及時機。

```mermaid
classDiagram
	class	Entity {
	 +Interact()
	}
	
	class WeaponEntity {
		int m_Damage
		GameObject m_ImapctEffect
		bool m_IsReusable
		Initial()
		Trigger()
	}
	class SwordEntity {
		float m_WieldRadius
		LayerMask m_AttackObject
		+WieldRadius() float
		+AttackObject() LayerMask
	}
	class BulletEntity {
		float m_Speed
		Rigidbody2D m_RB
	}
	
	Entity <|-- WeaponEntity
	WeaponEntity <|-- SwordEntity
	WeaponEntity <|-- BulletEntity
```

### Game, GameScene, Player and Player Behavior

* 遊戲及玩家使用設計模式 Observer 以達到介面跟遊戲邏輯分離，降低程式間依賴性。

#### Game and GameScene

```mermaid
classDiagram
	class Game {
		List<Player> m_Players
		
		+delegate GameEvent(Game game)
		+GameEvent OnGameStarted(g)
		+GameEvent OnGameEnded(g)
		+MakeGame()
		+EnrollPlayer(Player player)
		+End()
	}
	
	class GameScene {
	 Game m_Game
	 HandleOnGameStarted(Game game)
	 HandleOnGameEnded(Game game)
	}
	
	Game <|-- GameScene : Notify
```



#### Player and PlayerBehavior

```mermaid
classDiagram
	class Player {
		string m_Prefab
		+Prefab() string
		Game m_Game
		+Game() Game
		
		+delegate PlayerEvent(Player player)
		+PlayerEvent OnEnable(p)
		+PlayerEvent OnDisable(p)
		+PlayerEvent OnDead(p)
		
		+Die()
	}
	
	class PlayerBehavior {
		Player m_Player
		+UpdatePlayer(Player player)
		
		HandleOnEnable(Player player)
		HandleOnDisable(Player player)
		HandleOnDead(Player player)
	}
	
	Player <|-- PlayerBehavior : Notify
```

