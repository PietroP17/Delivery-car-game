# 🚚 Delivery car game
**Delivery car** is a 2D game developed with **Unity 2021.3.45f1 LTS**, where the player must collect packages and deliver them as quickly as possible.

## 🎮 Features v2.0
- Main Menu with navigation to:
  - Start Game
  - Instructions
  - Leaderboard
- Player name input before starting the game
- Package pickup and delivery via object interactions
- In-game timer tracking delivery completion time
- Victory screen displaying final time and leaderboard
- Local leaderboard saved as JSON file
- Leaderboard accessible from both the menu and victory screen

## 🛠️ Technologies Used
- **Engine:** Unity 2021.3.45f1 LTS
- **Language:** C#
- **UI:** TextMeshPro (TMP)
- **Data Persistence:** `JsonUtility` with `Application.persistentDataPath`

## 🚀 How to Run
1. Clone the repository:
   ```bash
   git clone https://github.com/PietroP17/delivery-rush.git
2. Open the project in Unity Hub using version 2021.3.45f1 LTS.
3. Launch the MainMenu.unity scene.
4. Optionally, build the project for your platform using File > Build Settings.

## 💾 Score Saving
- Scores are saved in a file called leaderboard.json located in the persistent data path of the system:
**Windows:** C:\Users\YourName\AppData\LocalLow\Pietro Petti\Delivery car\leaderboard.json
**Mac:** ~/Library/Application Support/Pietro Petti/Delivery car/leaderboard.json

## 📋 To Do
- Add sound effects
- Create multiple levels
- Polish and improve UI and UX
- Other ...

## 🧾 License
This project is for educational use.
