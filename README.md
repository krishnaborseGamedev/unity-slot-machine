# 🎰 Unity Slot Machine

A classic 3-reel slot machine built in Unity 6 (URP) for a Game Developer Internship assignment.

## Game Overview
Click SPIN to spin 3 reels. Each reel randomly lands on one of 4 symbols (Cherry, Bell, Seven, Bar). Matching all 3 reels wins coins, tracked via a coin/payout system. Includes win/loss popups and smooth reel-stop animations.

## Play the Game
🎮 **Play the WebGL version:**
https://krishnaborsegamedev.github.io/unity-slot-machine/

## Instructions to Run
1. Clone or download this repository
2. Navigate to `Build/WebGL`
3. Serve the folder locally (e.g. `npx serve` or any local web server — required for WebGL to run in-browser)
4. Open the shown localhost URL in your browser

## Bonus Features
- Win/Loss popup panels
- Coin balance & payout system
- Smooth staggered reel-stop animation

## Approach
Built the core reel mechanic first (RNG-based symbol landing, tracked via Sprite reference to avoid indexing bugs across reels), then layered UI (Canvas, Mask-based reel windows), win-check logic, and finally coin/payout + popup feedback. Used AI assistance to speed up scripting and debug logic issues, while handling all Unity setup, UI wiring, and design decisions myself.

## Known Issue
Some UI element positions (lever, symbols) may appear slightly shifted depending on screen resolution — likely a Canvas Scaler/resolution mismatch between Editor and WebGL build.

## Tech Stack
Unity 6 (URP), C#, Unity UI (Canvas, Image, Mask, RectTransform)
