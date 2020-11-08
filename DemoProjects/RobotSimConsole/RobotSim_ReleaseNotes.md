
Robot Sim
=====
This console application is a simulation of a toy robot moving on a square tabletop, of dimensions 5 units x 5 units. The assumption is that there are no obstructions on the table surface when placing the robot on the table. The robot is free to roam around the surface of the table, and is prevented from falling off the table. Any movement that would result in the robot falling from the table is ingored.

Console application requires user input (see available commands below). 


Deployment Requirements
=====
	- Docker
	- robotsim image

Installation
=====

  - Docker image is available for pull through the following registry:

  	[% docker pull riverajem/robotsim:1.0]

  - After image has been pulled: RUN container in 'interactive' mode since user input is required to function.
  	Ex: [%docker run -i "riverajem/robotsim:1.0" or <image id> ]

Commands:

	PLACE X,Y,F:
		-- PLACE will put the toy robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST.
		-- The origin (0,0) can be considered to be the SOUTH WEST most corner.
		-- The first valid command to the robot is a PLACE command, after that, any sequence of commands may be issued, in any order, including another PLACE command. The application will discard all commands in the sequence until a valid PLACE command has been executed.
    MOVE
    	-- MOVE will move the toy robot one unit forward in the direction it is currently facing.
    LEFT
    	-- LEFT will rotate the robot 90 degrees in counter-clockwise direction without changing the position of the robot.
    RIGHT
    	-- RIGHT will rotate the robot 90 degrees in clockwise direction without changing the position of the robot

    REPORT
    	-- REPORT will announce the X,Y and F 

What's New
=====
	New command "Q" supported to exit/terminate application



