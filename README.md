<div align="center">

# To The Top

### Collect the keys. Dodge the enemies. Find your way to the top.

[![Unity](https://img.shields.io/badge/Unity-6000.0.38f1-222222?logo=unity&logoColor=white)](https://unity.com/releases/editor/whats-new/6000.0.38)
[![C#](https://img.shields.io/badge/Language-C%23-512BD4)](Assets/Scripts)
[![2D](https://img.shields.io/badge/Genre-2D%20Platformer-54A85B)](#about)

</div>

https://github.com/user-attachments/assets/f2b9f4b4-ad1e-4388-9ba6-65ab6b487289


## About

To The Top is a pixel-art 2D platformer built with Unity and C# as a project for a multimedia and interfaces course.

Explore the level, collect all three keys and reach the exit. Pick up bonuses to increase your score, collect hearts to recover lives and jump on patrolling enemies to defeat them. Falling or running into an enemy sends you back to the starting point and costs a life.

## Features

- 🦊 Animated player movement and jumping across a pixel-art level
- 🔑 Three collectible keys required to unlock the level exit
- 🍒 Bonus pickups and a score bonus for remaining lives at the finish
- ❤️ Lives, heart pickups and respawning at the starting point
- 🐸 Patrolling enemies that can be defeated by jumping on them
- ⏱️ On-screen score, lives, key collection and elapsed time
- 🏆 A local best score saved between sessions using Unity PlayerPrefs
- ⌨️ Main menu and an in-game menu with resume, restart and return options

## Controls

| Action | Input |
| --- | --- |
| Move left | `A` or `←` |
| Move right | `D` or `→` |
| Jump | `Space` or left mouse button |
| Open / close the pause menu | `Esc` |

Jumping requires the player to be on the ground.

## Quick Start

Requires **Unity Hub**, **Unity Editor 6000.0.38f1** and Git.

```bash
git clone https://github.com/maciejdrywa/ToTheTop-UnityGame.git
cd ToTheTop-UnityGame
```

1. In Unity Hub, choose **Add project from disk** and select the cloned project folder.
2. Open the project with **Unity 6000.0.38f1** and wait for Unity to import the assets and restore the packages.
3. Open `Assets/Scenes/MainMenu.unity` in the Project window.
4. Press **Play** in the Unity Editor, then select the first level from the main menu.

The project includes a main menu and one playable level, `Level1`. To work on the level directly, open `Assets/Scenes/Level1.unity` and press **Play**.

## Tech Stack

| Technology | Purpose |
| --- | --- |
| Unity 6000.0.38f1 | Game engine and editor |
| C# | Gameplay and menu logic |
| Universal Render Pipeline (URP) 17.0.3 | 2D rendering |
| Unity Physics 2D | Rigidbody movement, ground detection and collision triggers |
| Unity Animator | Player and enemy animations |
| Unity UI and TextMesh Pro | Menus, HUD and score displays |
| Unity PlayerPrefs | Local best-score persistence |

## Project Structure

```text
Assets/
├── Scenes/                 # MainMenu and Level1
├── Scripts/                # Player, enemies, camera and game/menu managers
├── Prefabs/                # Reusable game objects
├── Animations/             # Animation clips
├── Animator Controllers/   # Player and enemy animation state machines
├── Settings/               # Rendering settings and scene template
├── SunnyLand Artwork/      # Pixel-art environment and character assets
└── 2D Pixel Item Pack/      # Item sprites
Packages/                   # Unity package dependencies
ProjectSettings/            # Unity editor and project configuration
```

The gameplay scripts cover player input and pickups (`PlayerControler`), enemy patrols (`EnemyController`), camera tracking (`CameraFollow`), game state and scoring (`GameManager`), and level selection (`MainMenuManager`).

## Authors

- [Maciej Drywa](https://github.com/maciejdrywa) — Lead programmer
- [Hubert Citko](https://github.com/HubertCitko) — Responsible for the project's graphics

## License

This project is licensed under the [MIT License](LICENSE.md).
