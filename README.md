# hack-a-thing-1-doh

## Roll a Ball
This Unity application is a game in which the user controls a ball and attempts to collect the yellow cubes. Since neither team member has had prior experience working with Unity or using C\#, we followed a tutorial provided by Unity at https://unity3d.com/learn/tutorials/projects/roll\-ball\-tutorial. We chose to also add additional features such as allowing the ball to jump and having a timer for the game.

### Controls
Movement: Arrow keys
Jumping: Space bar

### Goal
Collect all the cubes within the time limit, jumping and moving around on the platforms

### Potential Issues
Jumping is only allowed when the ball has no y\-velocity. Thus, even when the ball has seemingly no y\-velocity, the ball may still not jump, even when the space bar has been pressed. A potential fix is to allow jumping when the y\-velocity is under a certain range, rather than when it is 0.
