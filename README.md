# UnityAI-FSM-SimpleEnemyBehavior
An easy-to-integrate Unity FSM for basic enemy AI behaviors, utilizing ScriptableObject for customizable and reusable AI states like Idle, Attack, Chase, Run, Die, Revive, Patrol, Wander, and Follow. This AI system also includes a Health Manager for managing the enemy's health.

This repository contains the implementation of a simple finite state machine (FSM) for an enemy AI in Unity. The FSM uses Unity's ScriptableObject to manage the states and behaviors of the enemy, allowing for easy customization and reusability in different game scenarios.

## Description
The enemy AI's behavior is governed by a comprehensive FSM with various states:

- **Idle (0)**: The default state where the enemy is not engaged in any activity.
- **Attack (1)**: Activated when the enemy is close enough to the player. The enemy performs an attack action.
- **Chase (2)**: Triggered when the player is detected within a certain range. The enemy moves towards the player.
- **Run (3)**: A state where the enemy flees from a threat or danger.
- **Die (4)**: The state when the enemy's health reaches zero, resulting in death.
- **Revive (5)**: If the enemy can be revived, this state handles the revival process.
- **Patrol (6)**: The enemy follows a predefined patrol route or path.
- **Wander (7)**: A state where the enemy roams around randomly.
  
Transitions between these states are based on various game conditions, including player proximity and the enemy's health.

## Implementation
The FSM is implemented using Unity's ScriptableObject, allowing for an efficient and modular approach. Additionally, a Health Manager is integrated into the system to manage the enemy's health. The state transitions and behaviors are handled within Unity, making it easy to integrate and modify for any Unity-based game project.

## Prerequisites
- Unity Engine (preferably the latest version)
- Basic understanding of Unity's interface and ScriptableObject

## Getting Started
To use this FSM in your Unity project, follow these steps:

1. Clone the repository:
2. Open your Unity project and import the cloned FSM assets.
3. Drag and drop the FSM ScriptableObject into your game objects to integrate the AI behavior.
4. Customize the FSM, its states, and the Health Manager as per your game's requirements.
