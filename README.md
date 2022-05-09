# Game Engines 2 2021-2022

[![Video](http://img.youtube.com/vi/KNymjRyr27A/0.jpg)](http://www.youtube.com/watch?KNymjRyr27A)

## Teams links for classes/labs:

- [Teams](https://teams.microsoft.com/l/meetup-join/19%3ameeting_YjJjZmIxNDQtZjMyMi00MmY5LWJkZDctZWUxYmE0MTVmYTc0%40thread.v2/0?context=%7b%22Tid%22%3a%22766317cb-e948-4e5f-8cec-dabc8e2fd5da%22%2c%22Oid%22%3a%2261aab78b-a857-4647-9668-83d4cca5de03%22%7d)

## Resources
- [Assignment](ca.md)
- [A build of Infinite Forms](https://drive.google.com/file/d/1w24BcMAi6P1XmPc9D9ss6Lkro4KBvsMS/view?usp=sharing)
- [All about Infinite Forms](http://bryanduggan.org/forms)
- [Infinite Forms Project](http://github.com/skooter500/forms)
- [ECS2020](http://github.com/skooter500/ECS2020)
- [A spotify playlist of music to listen to while coding](https://open.spotify.com/user/1155805407/playlist/5NYFsIFTgNOI93hONLbqNI)

## Contact me
* Email: bryan.duggan@tudublin.ie
* [My website & other ways to contact me](http://bryanduggan.org)

## Previous years courses
- https://github.com/skooter500/GE2-2020-2021
- https://github.com/skooter500/GE2-2019-2020
- https://github.com/skooter500/GE2-2018-2019

## Previous years lab tests
- https://github.com/skooter500/GE2-Test-2021-Starter/
- https://github.com/skooter500/GE2-Lab-Test-2019
- https://github.com/skooter500/GE2-Lab-Test-2019-Solution
- https://github.com/skooter500/GE2-LabTest2-2017
- https://github.com/skooter500/GAILabTest12017
	
## Assessment Schedule	
- Week 6 - CA proposal & Git repo
- Week 12 - Lab Test - 20%
- Week 13 - CA Submission - 50%
- End of year online test - 30%

## Week 12 - Obstacle Avoidance & Lab Test & ECS Boids

- [Tuesday Class](https://tudublin-my.sharepoint.com/:v:/g/personal/bryan_duggan_tudublin_ie/EWarYji5dOJErxvCJhKavNYBvo5xC2JJMOYWsYLRgC9h9A?e=tgWJkl)
- [Wednesday Class](https://tudublin-my.sharepoint.com/:v:/g/personal/bryan_duggan_tudublin_ie/EW6x38EKTgBEs6tCXdtzQA8BNSJbOkm--EZ2wfLDZDIFuA?e=CNy10n)


- Check out Avoidance scene
- How are the feelers calculated?
- What direction do they point?
- How many are there? Whys this number?
- How does the behaviour handle holes in the colliders?
- Does the speed of the boid matter?
- What direction is the force generated?
- WHat alternatives are there to this?
- How does the behaviour avoid certain obstacles while ignoring others?
- How often are the feelers calculated and why?
- How does the behaviour take priority over other behaviours?
- How would you improve the behaviour?
- How does it improve on Craig Reynolds avoidance behaviours?


Have a look at the PureECSScene in [this repo](http://github.com/skooter500/ECS2020) and answer the following questions:

1. What are Entities, Components, Systems and Jobs?
5. What is the purpose of the class BoidBootstrap?
2. In the previous examples, we explored two approaches to creating Entities. Describe them. Which approach was used in the PureECSScene Scene?
3. How many systems are there running in PureECSScene? What are they and what do they do?
4. In the previous examples we looked at two different types of jobs. What were they and what were they for? 
4. BoidSystem schedules IJobEntityBatch jobs. What are these and how does this approach differ from using Entities.ForEach? 
4. How do these jobs selects Entities to iterate over? How are the Components on these Entities accessed? 
6. What is a Native Container? Give some examples. What Native Containers does the BoidSystem create and what is their purpose?
7. What Jobs does the BoidSystem schedule and in what order. Is this order significant?
8. PartitionSpaceJob uses an algorithm called Cell Space Partitioning. How can this algorithm reduce the computational complexity the Flocking?
9. What is the limitation of this algorithm?
9. How are Boids assigned cells?
10. PartitionSpaceJob uses a NativeMultiHashMap. What is the purpose of this data structure? What is the computational complexity of retrieving a value from a key in this data structure?
10. How do Boids access the positions and rtotations of other Boids?
11. In CountNeighboursJob, how does the algorithm determine how many cells are surrounding a boid that it needs to check for neighbours?
12. What is the design pattern for retrieving all the values that match a given key in a NativeMultiHashMapIterator?
13. Where does the algorithm store the neighbours for each Boid?
14. What happens if a Boid has too many neighbours?
15. In SeperationJob, what can cause the force to be NAN? How does the code check for this?
16. How does Cohesion work?
17. In AlignmentJob how are the forward vectors for each boid calculated?
17. How is the desired forward vector calculated?
18. How is the force generated?
18. What algorithm does BoidJob use to combine the forces from the various behaviours together?
19. How is the Boids rotation evaluated?
20. In SpineSystem, what is the purpose of the WithNativeDisableParallelForRestriction annotation on the Entities.ForEach lambda?
21. What jobs does SpineSystem schedule and what do they do?
21. What parameters control the damping on the spine and what effect will changing these parameters have on the spines?
21. What Native Containers does this job create?
22. In HeadAndtailsSystem, what controls the speed of the procedural animation?
22. How does the Head Animation work? Draw a diagram. What Unity API call is this system similar to?

## Week 11 - ECS Creational Strategies - Psytrance Spiral generator

- [Tuesday Class](https://tudublin-my.sharepoint.com/:v:/g/personal/bryan_duggan_tudublin_ie/EawdDWKwXM9Knk5zb_u9oQABfH3xew7r0DYoHR0t73nAFw?e=FI7tgj)
- [Wednesday Class](https://tudublin-my.sharepoint.com/:v:/g/personal/bryan_duggan_tudublin_ie/ESi5d9ZpY_ZPle9gnfh0mB4BhGfXBE41duwf8kF7JbzieA?e=tICXwI)

- When are the entities created?
- How do the entities get the mesh assigned?
- What is the purpose of ParticleController and ParticleSystem?
- What components does entity have and what is their purpose?
- How does an entity get components?
- Why does the onUpdate method copy fields into local variables?
- What is a NativeArray? Why not use a normal array?
- What does ref mean?
- What is the difference between scale and NonUniformScale?
- What does WithNativeDisableParallelForRestriction mean?
- What is the difference between Schedule and ScheduleParalell?
- What is the purpose of the entityInQueryIndex parameter?
- What is a lambda?
- Why does the function use math.cos instead of Math.Cos?

## Week 10 - ECS - Perlin Noise Voxel Terrain
- [Tuesday Class](https://tudublin-my.sharepoint.com/:v:/g/personal/bryan_duggan_tudublin_ie/EY8PqhkjMTBOlskEMGisvf0BMO7L2EbiubV6SiBEb8s2CA?e=99rAcx)
- [Wednesday Class](https://tudublin-my.sharepoint.com/:v:/g/personal/bryan_duggan_tudublin_ie/ESpjH6aLwV9CiMfqH95R1RgB59CgIloCQKQIvat4EHPYng?e=tn8hzU)

## Week 9 - ECS - Introduction
- No Recording of Tuesday Class :-(
- [Wednesday Class](https://tudublin-my.sharepoint.com/:v:/g/personal/bryan_duggan_tudublin_ie/EXXB0BqVyWlJt1AvccQCrqcBKAjib2PcwQRQs64BsToQkA?e=y9VDJ8)
- [Slides about ECS](https://tudublin-my.sharepoint.com/:p:/g/personal/bryan_duggan_tudublin_ie/Eer4jfOpwlVFrD5tCY8MmacB8wxGtg7fubOzOJz7aOBwTQ?e=rIPSPH)

## Week 8 - Review Week
## Lab

You can find the Finite State Machine code in repo! Check it out and see if you can incorporate it into your assignment 

## Week 7
- [Tuesday Class - Finite State Machines](https://tudublin-my.sharepoint.com/:v:/g/personal/bryan_duggan_tudublin_ie/EQ28znAiANdEh07bdKBafsQBpCsgZ26pssl4kUYdxx7_UA?e=cPFjpg)
- [Wednesday Class - Finite State Machine Design Pattern](https://tudublin-my.sharepoint.com/:v:/g/personal/bryan_duggan_tudublin_ie/EUaae4M6jwtJqg8obHoEJgUB2srzxTWSPgKJf3dzBOjorA?e=Nm84rj)
- [Slides about FSM's](https://tudublin-my.sharepoint.com/:p:/g/personal/bryan_duggan_tudublin_ie/EZeIQO50Y0FAvG3xQrAmuYIBamLVqbMGNQohhxwwnD64MA?e=kBf15L)


### Lab
I put the code for all the steering behaviours in seperate classes into the repo. There are the following Steering Behaviours:

- Seek
- Arrive
- Pursue
- Offset Pursue
- Flee
- Obstacle Avoidance
- Jitter Wander
- Noise Wander
- Harmonic

There is also a scene called Components that shows how to add the behaviours to a Boid

In todays lab, you can try and attach some of these behaviours to the Boids in your assignment

## Week 6
- [Tuesday Class - SOLID Principles](https://tudublin-my.sharepoint.com/:v:/g/personal/bryan_duggan_tudublin_ie/EZgbMeI4JbhBsdy6EPt6NhwBB74x1Ohlk7ydzxOZhrmf0A?e=gSOklc)
- [Wednesday Class - WPTRS](https://tudublin-my.sharepoint.com/:v:/g/personal/bryan_duggan_tudublin_ie/EUdZJZxfthVGlkSdDRQA55gB0rOwJRTHoPOqWSJkQ7KksA?e=QngqAX)
- [Combining steering behaviours](https://alastaira.wordpress.com/2013/03/13/methods-for-combining-autonomous-steering-behaviours/)

## Lab
- [Try this lab test from 2019](https://github.com/skooter500/GE2-Lab-Test-2019)
- [Submit your assignment](https://forms.office.com/Pages/ResponsePage.aspx?id=yxdjdkjpX06M7Nq8ji_V2ou3qmFXqEdGlmiD1Myl3gNUNzAyR1pVMjkwNThLUFdRWFk2SUFPQjFaOC4u)

## Week 5 - Offset Pursue, Refactoring

- [Tuesday Class - Offset Pursue](https://tudublin-my.sharepoint.com/:v:/g/personal/bryan_duggan_tudublin_ie/EVNg4DhVh0NBriV2xtO0Od8BN3TfMJ3OgDsJV9QzJy8KhQ?e=rTKvl1)
- [Wednesday Class - More Offset Pursue](https://tudublin-my.sharepoint.com/:v:/g/personal/bryan_duggan_tudublin_ie/EVY5nDzdxNFCqrpv4SB5HLcBNoBUnsb5EutGAsFWv8xsgg?e=xREtEa) 

You could use the lab class to work on your assignment - get 3D models imported and flying around or here is an exercise you can do that uses the pursue behaviour we worked on last week: 

Update your fork of the course repo to get the Pursue code we wrote in the class last week.

Detect if the pursuer catches the target and also if the target goes out of range and print appropriate messages to the console. Use colliders for this. Try changing the maxSpeed for both boids and see what effect this has on the ability for the pursuer to reach the target boid.

## Week 4 - Banking, PlayerSteering, Pursure, Offset Pursue

- [Tuesday Class - Banking & Player Steering](https://tudublin-my.sharepoint.com/:v:/g/personal/bryan_duggan_tudublin_ie/Ef9lvU4Qr5RNp2hUScMT7roBSQhZ59N0xom_Uj0ad06ldg?e=IWa2nQ)
- [Wednesday Class - Pursue](https://tudublin-my.sharepoint.com/:v:/g/personal/bryan_duggan_tudublin_ie/EWNEs1_bTjJOsfO64a1NpZ0BTTE43a7MNnfTJ_X7zd7sXQ?e=cLLoQj)

- [Recording of Tuesday's class - Arrive, Banking, PlayerSteering](https://tudublin-my.sharepoint.com/:v:/g/personal/bryan_duggan_tudublin_ie/Ef9lvU4Qr5RNp2hUScMT7roBSQhZ59N0xom_Uj0ad06ldg?e=4Z910F)
- [Recording of Wednesday's class - Pursue](https://tudublin-my.sharepoint.com/:v:/g/personal/bryan_duggan_tudublin_ie/EWNEs1_bTjJOsfO64a1NpZ0BTTE43a7MNnfTJ_X7zd7sXQ?e=h2fHZh)


### Lab 
- Work on last weeks lab!

## Week 3 - Physics, Arrive

### Lectures
- [Tuesday class - Physics](https://tudublin-my.sharepoint.com/:v:/g/personal/bryan_duggan_tudublin_ie/EYLOqYUSkTBAkPOUZUo8j98BSueQVAOsXNrdOUhQPzELrA?e=FiIlJW)
- [Wednesdday class - Arrive Steering behaviour](https://tudublin-my.sharepoint.com/:v:/g/personal/bryan_duggan_tudublin_ie/Ef8cVWYIlgZDoIXHJaUJoAYB9g_jO18r8Gs1DYr2BCbT-A?e=2bSAuJ)

### Lab

The implementation of BigBoid has been improved to implement "banking" - rotating around the local forward vector: 

[![Video](http://img.youtube.com/vi/ofb9syLwAQc/0.jpg)](http://www.youtube.com/watch?v=ofb9syLwAQc)

The technique is discussed in Craig Reynolds papers. We will learn how it works in the class later :-)

Also there are method prototypes for several other behaviours you can try to implement in today's lab:

- Arrive - Slow down as the boid reaches the target
- Pursue - Intercept the target's future position
- PlayerSteering - Take input from the Input system to steer the boid  

Update your forks to get the code! 

## Week 2 - Boids, Seek, Path Following

## Lectures
- [Tuesday  - Path Following](https://tudublin-my.sharepoint.com/:v:/g/personal/bryan_duggan_tudublin_ie/EcpaiMOskndBoCt1WCmTqXMBKcgs9lgltEaB0tFroced8Q?e=tcDueS) 
- [Wednesday - Physics](https://tudublin-my.sharepoint.com/:v:/g/personal/bryan_duggan_tudublin_ie/ERq2JlsP7rtCkgCbPcqSI78BRKA8Pno97ZpWm0GzW-3Fvw?e=1kz5RD)

## Lab

### Path following

Update your fork of the repo with the latest code from the master branch of this repo. To do this, cd to the folder where you have your fork cloned and type:

```
git checkout master
git pull upstream master
```

This will get the code we wrote last week. Open the Seek scene and you will see a boid that implements seek in the BigBoid.cs class. Today you can implement a path following behaviour for the boid.

Check out this video:

[![Video](http://img.youtube.com/vi/eAfpnWI5jEI/0.jpg)](http://www.youtube.com/watch?v=eAfpnWI5jEI)

The scene contains a game object object with a script called ```Path``` attached. The path script implements the method ```OnDrawGizmos``` to draw lines between the waypoints on the path and to draw a sphere at each of the waypoints. The blue box is following the path. Today you can try and program this behaviour. 

- Implement the ```Path``` script that contains a ```public List<Vector3> waypoints``` containing the waypoints. The 0th waypoint should be the position of the path gameobject itself and the positions of the attached children should be used to set the subsequent waypoints. You can populate this list in ```Awake```. 
- Add a bool flag on the ```Path``` class called ```IsLooped``` to indicate whether the path should loop back to the 0th waypoint when the Boid reaches the last waypoint. If this flag is set to be false, then don't draw a line gizmo back to the 0th waypoint.
- In the scene, create a path using the ```Path``` script you made.
- Add a a public field to the BigBoid class for the Path and drag the Path you made onto this in the Unity editor. 
- Now write code for a behaviour in BigBoid called ```FollowPath``` to get the Boid to move from waypoint to waypoint on the path using Seek and Arrive. If the ```IsLooped``` flag is true on the path, then the Boid should Seek the 0th waypoint again when it reaches the last waypoint. If this flag is set to be false, then the Boid should Arrive at the last waypoint. You will need to add a method called FollowPath and a boolean flag to indicate that the FollowPath behaviour is enabled. 

## Week 1 - Introduction to the course. Introduction to steering behaviours

## Lab
- No lab this week

## Lecture
- [Recording of the Tuesday class](https://tudublin-my.sharepoint.com/:v:/g/personal/bryan_duggan_tudublin_ie/EfemBBy2hsNIv5BpPNtfjs0BGBaku7AHcH8YRpsPUbJaSw)
- [Recording of Wednesday class](https://tudublin-my.sharepoint.com/personal/bryan_duggan_tudublin_ie/_layouts/15/onedrive.aspx?id=%2Fpersonal%2Fbryan%5Fduggan%5Ftudublin%5Fie%2FDocuments%2FRecordings%2FGame%20Engines%202%20Class%2D20220126%5F130312%2DMeeting%20Recording%2Emp4&parent=%2Fpersonal%2Fbryan%5Fduggan%5Ftudublin%5Fie%2FDocuments%2FRecordings)

- [Introduction slides](https://tudublin-my.sharepoint.com/:p:/g/personal/bryan_duggan_tudublin_ie/EVB8iHL_Cy1DvVT1BW5SSd8BiP7R3pY7lBQoMN8Tmq0isw?e=s1TB2n)
- [Steering Behaviours Slides (a bit out of date)](https://drive.google.com/file/d/1nQeVLqhNY1JvAZQK_BgMxUoVr7w1VPUE/view?usp=sharing)
- [Craig Reynolds original paper](https://www.red3d.com/cwr/papers/1999/gdc99steer.pdf)
- [Steering behaviours in Java](https://www.red3d.com/cwr/steer/)