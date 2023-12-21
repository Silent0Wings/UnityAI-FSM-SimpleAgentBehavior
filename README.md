# UnityAI-FSM-SimpleEnemyBehavior

An easy-to-integrate Unity FSM for basic enemy AI behaviors, utilizing ScriptableObject for customizable and reusable AI states like Idle, Chase, and Attack.

This repository contains the implementation of a simple finite state machine (FSM) for an enemy AI in Unity. The FSM uses Unity's ScriptableObject to manage the states and behaviors of the enemy, allowing for easy customization and reusability in different game scenarios.

## Description

The enemy AI's behavior is governed by a basic FSM which is integrated with the Unity Engine. The FSM consists of states like "Idle", "Chase", and "Attack", managed through Unity's ScriptableObject:

- **Idle**: The default state where the enemy is not engaged in any activity.
- **Chase**: Triggered when the player is detected within a certain range. The enemy moves towards the player.
- **Attack**: Activated when the enemy is close enough to the player. The enemy performs an attack action.

Transitions between these states are based on player proximity and other game conditions.

## Implementation

The FSM is implemented using Unity's ScriptableObject, allowing for an efficient and modular approach. The state transitions and behaviors are handled within Unity, making it easy to integrate and modify for any Unity-based game project.

## Prerequisites

- Unity Engine (preferably the latest version)
- Basic understanding of Unity's interface and ScriptableObject

## Getting Started

To use this FSM in your Unity project, follow these steps:

1. Clone the repository:

2. Open your Unity project and import the cloned FSM assets.

3. Drag and drop the FSM ScriptableObject into your game objects to integrate the AI behavior.

4. Customize the FSM and its states as per your game's requirements.
