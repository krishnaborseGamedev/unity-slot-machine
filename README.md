# 🎰 Unity Slot Machine

A classic 3-reel slot machine built in Unity 6 (URP) for a Game Developer Internship assignment.

## Game Overview
Click SPIN to spin 3 reels. Each reel randomly lands on one of 4 symbols (Cherry, Bell, Seven, Bar). Matching all 3 reels wins coins, tracked via a coin/payout system. Includes win/loss popups and smooth reel-stop animations.

## Play the Game
🎮 **Play the WebGL version:**
https://krishnaborsegamedev.github.io/unity-slot-machine/

## Instructions to Run
1: Run the link.
2. Clone or download this repository
3. Navigate to `Build/WebGL`
4. Serve the folder locally (e.g. `npx serve` or any local web server — required for WebGL to run in-browser)
5. Open the shown localhost URL in your browser

## Bonus Features
- Win/Loss popup panels
- Coin balance & payout system
- Smooth staggered reel-stop animation

## Approach
Three independent reels spin with randomized symbols and stop at different times.
A matching three-symbol combination triggers a 100-coin payout, while each spin costs 10 coins.
The game uses separate Reel and SlotMachine scripts for reel behaviour and overall game logic.

## Known Issue
Some UI element positions (lever, symbols) may appear slightly shifted depending on screen resolution — likely a Canvas Scaler/resolution mismatch between Editor and WebGL build.

## Tech Stack
Unity 6 (URP), C#, Unity UI (Canvas, Image, Mask, RectTransform)
