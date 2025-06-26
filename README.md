# FF8-Utilities
A program designed to collate all the manipulation used into one easy to use program that doesn't require Ruby or command shell knowledge

The UI is written in WPF, utilising MAHApps Metro for a slick ui.
Manipulations are broken up into separate projects.  Currently the Zell Card Manip is a WIP and is not utilised (instead links to pingval script)

## Manipulation Guides
For explanations on how to perform FF8 manipulations, please visit https://www.speedrun.com/ff8/guides

## Features
- Manipulations supported
  - Quistis/Zell cards
  - Quezacotl Fish Fins
  - Caraway Code 
  - Ultimecia RTA Party
- One click downloading to download updates
- One click downloading/updating for CSR/Practice% mods

## Card Manipulations
Utilities supports 
- Early Quistis (Frames 1-10)
- Late Quistis
- Zell (1st and 2nd try)

![image](https://github.com/user-attachments/assets/de431263-6f8e-4ccb-ab39-e2e62549cdcc)

#### Quistis Pattern
If you are going for Early Quistis, you can select the appropriate frame that you got.  Clicking the button to the right of the dropdown will also show you the moves to play in order to win!
#### Custom
This can mostly be left blank as it is handled by other tools, but you have the ability to enter the RNG Hex code of the result of the quistis game

#### RNG Modifier
If you are attempting 1st try Zell Card, entering the RNG count into this box will allow you to attempt 1st try
If left blank, will assume you are doing 2nd try

### Start Countdown
**Only available on PC** Clicking this will start a countdown (Configurable in settings).  Once the countdown hits zero, this will automatically start the launched zell timer script.
This is useful for Remastered speedruns where background input is not possible.
Intended use:
1. Launch the zell script window via submit or via tracking
2. Tab out and click "Start Countdown" button
3. Tab back into game and watch the timer.
4. When it reaches zero, confirm the start of the battle in-game

## Card Manipulation Tracker
Click on the calculator button beside RNG Modifier box to launch the tracker.
![image](https://github.com/user-attachments/assets/5b7e4c23-f7aa-434b-ad7e-8a2992caab41)

This tracker supports both Early and Late Quistis.
If you click "Get Quistis Patterns" and later submit, the tracker will be aware of that index and update the Zell Tracking
Otherwise "Get Quistis Patterns" can be ignored for Early Quistis, simply track the entire way and click "Launch Zell"

The tracker remembers your last used settings, so this allows the runner to customise the tracker to their step count without needing programming knowledge.


## Settings / Tools
![image](https://github.com/user-attachments/assets/237cdbdc-dad6-4ec7-b057-83c8f90beb4f)

PC Users also have the ability to toggle various mods
- CSR
- Practice%
- PSX Music files
These can be reverted to default incase you you need to switch to regular any%.

Installing these mods detects your current language and installs the correct version depending.

