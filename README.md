2D Top-Down Survival Shooter
A fast-paced, top-down 2D arena shooter built in Unity (C#).
The core mechanic subverts traditional shooter combat: your health is your ammunition. Every shot you fire costs a fraction of your life, forcing aggressive, precision-oriented play to siphon health back from defeated enemies before running dry.

Core Gameplay & Mechanics
Health-as-Ammo Economy: Firing weapons chips away at your remaining health bar. Vanquishing enemies restores health, creating a relentless risk-reward loop where playing defensively guarantees defeat.
Dynamic Wave Scaling: An automated wave manager tracks alive entities, pacing, and difficulty curves. Each consecutive wave ramps up enemy count, movement speed, and spawn frequency.Proximity Radius Spawning: Enemies instantiate dynamically within an annular radius around the player, ensuring immediate tension without unfair direct collisions upon spawning.
Modular Prefab Pipeline: Decoupled prefabs for player projectiles, distinct enemy archetypes, visual hit effects, and pickups, allowing rapid balance tuning via ScriptableObjects and Inspector fields.
Reactive HUD: Real-time UI feedback loop tracking health/ammo depletion, current wave progress, score, and kill counters using Unity's UI Canvas system.

Architecture & What I Learned

Building this project focused on structuring clean, decoupled systems that interact predictably under high-entity stress:
1. Interconnected System ArchitectureConnecting the player's life total directly to weapon actuation required tight decoupling between combat, health, and audio/visual managers. Utilizing C# events/delegates ensured the weapon controller didn't tightly couple to the player's death state or UI updates, preventing cascading null references when states transition rapidly.
2. Enemy Behavior & Spatial AwarenessDesigned custom 2D chase behaviors and steering logic. Enemies compute normalized vectors toward the player's current transform, incorporating collision avoidance routines and calculated spawn locations relative to the camera viewport to keep encounters fair and focused.
3. Prefab-Driven DesignLeveraged Unity's nested prefab workflows to create reusable, variant-friendly enemy templates. This streamlined tweaking baseline parameters (e.g., speed, health pool, damage radius, drop rates) across multiple archetypes without breaking base prefab definitions.
4. Event-Driven UI SystemsImplemented an observer pattern between game data and the UI layer. Rather than updating UI elements inside expensive update loops, UI bars and counters subscribe directly to health and wave change events, preserving performance even during intense combat waves.

Getting Started

Built With
Engine: Unity
Language: C#
Version Control: Git & GitHub
