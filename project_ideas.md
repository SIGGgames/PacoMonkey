# Project Details

## Conceptualization

### Main Idea 
<!-- Define the basic premise of the game (story, main concept) -->
The game follows the story of Pacomonkey's life, a mandrill who, since childhood, seeks the killer of his mother to 
avenge her. Throughout his adventure, he faces several monkeys from different lands, looks for clues to find out more 
about the identity and the location of the killer, all while trying to grow and survive in a hostile world.

### General Aesthetics
Pixel Art requires colorful characters and backgrounds. The characters, specially the important ones, should also have a
recognizable shape.

- Tiles size: 32x32
- Screen size: 360x640

(...) <- General_Aesthetics.md

### Game Genre
Adventure, platform and survival.

### Mechanics
<!-- Identify principal mechanics and players' interactions -->

#### Movement:
  - **Move right:** can direct the player to 'right' direction with one little press, with a longer press the player moves
  towards 'right' direction with a 'walking' velocity.
  

  - **Move left:** can direct the player to 'left' direction with one little press, with a longer press the player moves
    towards 'left' direction with a 'walking' velocity.
  

  - **Crouch:** player must maintain the button pressed to remain crouched; when crouching, the player's hit-box and the 
  velocity reduces to half.
  

  - **Up:** when pressing the button, the player looks-up (camera shows top of the screen that was hidden before that) and
  if the player is on 'hold', ends up climbing the surface. 
  

  - **Run:** player must maintain the button pressed to keep running and choose a direction to move ('move_right' or 'move_left');
    when running, the player's velocity doubles.
    - YoungVersion (YV): YV velocity gives the sensation of speed.
    - GrownVersion (GV): velocity is 2/5 slower than the YV. 
  

  - **Jump:** the height of the jump depends on the intensity/time of the button press; the longer the pressing, the higher
    the jump.
    - YV: YV jumping gives the sensation of lightness.
    - GV: maximum height is 2/5 lower than the YV.


  - **Double jump (YoungVersion):** can redo 'jump' with the same intensity as the previous, but can't repeat until next rest
    (when touching the ground with feet or 'hold').
  
    
  - **Hold (PassiveMechanic):** when facing a 'holding tile', the player automatically grabs the surface; when holding, the 
  previous jump resets.


#### States:
  - Show butt (stealth/incognito)

#### Survival:
  - Eat
  - Sleep/Find refugee

#### Combat:
  - Melee attack (punch)
  - Ranged poop attack
  - Passive abilities:
    - Block attacks
    - (...)

#### Interaction:
  - Items: automatic (when entering in contact)
  - NPCs:
    - Important NPCs: manual (button)
    - Non-important NPCs: automatic (when entering in contact)

#### Death:
  - Respawn bounded to the checkpoints. When the player dies, reappears at the last checkpoint, resetting all the 
enemies, bounties, experience, etc., that he gained after the checkpoint. 
  
## Game Design
### World Design
<!-- Design the environments and scenarios where the action takes place -->
The world of the game is based on the real environments that can be inhabited by different species of monkeys.
There are 6 different biomes incorporated, sorted by the chronological order of the story:

1. **Tropical forest**
2. **Forest**
3. **Rocky mountain**
4. **Snowy mountain**
5. **Island**
6. **Volcano mountain (inside the Island)**

Extra biome (_easter egg_): **Zoo**

---

#### 1. Tropical forest
- Pacomonkey's house:
- Pongo's house:
- Langur's palace:
- Burned sea port:
- (...)

#### 2. Forest
- (...)

#### 3. Rocky mountain
- (...)

#### 4. Snowy mountain
- (...)

#### 5. Island
- Volcano path
- (...)

#### 6. Volcano mountain
- (TBD)'s lair: 
- (...)

#### *. Zoo
- (...)



### Characters and Roles
<!-- Design the main and secondary characters, assign them roles and abilities -->

#### INSPIRATIONS
The designed characters are based on the real species of the existing primates. The chosen species are:

- **Mandrill** <br>
![mandrill_child_adult](https://github.com/SIGGgames/PacoMonkey/assets/150971528/6545a328-d28c-44fa-bd9d-74cc56d174cb)

- **Baboon** <br>
![baboon_white_black_adult](https://github.com/SIGGgames/PacoMonkey/assets/150971528/acdd3e34-a86b-4de4-a876-2c059c7d6023)

- **Orangutan** <br>
![orangutan_child_adult](https://github.com/SIGGgames/PacoMonkey/assets/150971528/09edf24c-3fa0-4fda-bfe6-3805e5de9d71)

- **Langur de François** <br>
![langur-de-francois_child-adult](https://github.com/SIGGgames/PacoMonkey/assets/150971528/6ebbca20-2d6c-4b31-847f-9ab8dd2aa7f4)

- **Gorilla** <br>
![gorilla_child_adult](https://github.com/SIGGgames/PacoMonkey/assets/150971528/c611465f-c7a9-4aaa-94b3-bb5cc70d43bd)

- **Japanese Macaque** <br>
![japanese-macaque](https://github.com/SIGGgames/PacoMonkey/assets/150971528/4488fab4-b943-4ea9-a222-8067b57fad34)

- **Golden Snub-Nosed Monkey** <br>
![golden-snub-nosed-monkey](https://github.com/SIGGgames/PacoMonkey/assets/150971528/f3103f59-dfcd-48eb-9468-d592b806fc23)

- **Lemur** <br>
![lemurs](https://github.com/SIGGgames/PacoMonkey/assets/150971528/d7518dc0-1888-41eb-bd33-c0ca7e4dfdce)


#### CHARACTERS DESCRIPTION:
Basic description of every character that appears in the story, chronologically sorted.

- **PACOMONKEY**
  - <u>Role</u>: main character
  - <u>Species/Appearance</u>: mandrill as a baby, child, adolescent, young, adult, old
  - <u>Location</u>: initially tropical, but can travel around the world
  - <u>Abilities</u>: non initially, during the game can acquire all
  - <u>Story</u>: Since his mom was killed, pacomonkey seeks vengeance and will travel around the world to find the 
killer.


- **(name to be determined)**
  - <u>Role</u>: pacomonkey's mom
  - <u>Species/Appearance</u>: white baboon (very gentle, with big boobs)
  - <u>Location</u>: tropical
  - <u>Abilities</u>: breast-feed pacomonkey
  - <u>Story</u>: Gets killed.


- **(name to be determined)**
  - <u>Role</u>: killer
  - <u>Species/Appearance</u>: black evil baboon
  - <u>Location</u>: 1st appearance tropical, next and final appearance volcano mountain
  - <u>Abilities</u>: all abilities
  - <u>Story</u>: He appeared in the village seeking for revenge. He killed (TBD), Pacomonkey's mom. After doing so, he
was still furious and destroyed houses and killed many villagers, Pongo's dad among them. After that, he continued his 
path through the next lands until he arrived to what is now his lair, volcano mountain.


- **Pongo**
  - <u>Role</u>: pacomonkey's best friend and his guide through the game
  - <u>Species/Appearance</u>: orangutan with big belly and smart (wears glasses and a little briefcase)
  - <u>Location</u>: initially tropical, but can travel around the world
  - <u>Abilities</u>: provides information
  - <u>Story</u>: Since Pongo and Pacomonkey were kids they have been together. Pongo is a loyal friend that will 
accompany Pacomonkey through his journey.


- **Langur de François**
  - <u>Role</u>: town-leader and 1st Enemy Boss
  - <u>Species/Appearance</u>: langur de françois, wears a monocle, a top-hat and a fancy cane.
  - <u>Location</u>: tropical
  - <u>Abilities</u>: blocking attacks (acquirable)
  - <u>Story</u>: Langur de François is the leader of Pacomonkey's hometown. When Pacomonkey comes to ask for his
permission to leave the town he denies it, unless Pacomonkey brings him a Diamond. Since there's no diamond in the
village and only him and his subordinate knows that, he will keep lying to Pacomonkey to make him stay until he finds 
out and they fight. After he is defeated and dethroned, his subordinate (TBD) will occupy his place.


- **(name to be determined)**
  - <u>Role</u>: Langur de François' subordinate.
  - <u>Species/Appearance</u>: Langur de François, young, small and cute, with a little pink bow on top.
  - <u>Location</u>: tropical
  - <u>Abilities</u>: provides information
  - <u>Story</u>: After Pacomonkey's visit to the leader, (TBD), Langur's subordinate, will feel sorry for him because 
she knows that the leader is lying. There are no diamonds. If Pacomonkey interacts with her, she will reveal the truth
and will encourage him to fight for everyone's freedom.


- **(name to be determined)**
  - <u>Role</u>: -
  - <u>Species/Appearance</u>: -
  - <u>Location</u>: -
  - <u>Abilities</u>: -
  - <u>Story</u>: -


- (...)


### Story and Narrative
<!-- Develop the game narrative, including introduction, build-up and resolution -->
#### Introduction
The story begins with a baby mandrill that can only crawl, <u>Pacomonkey</u>, living in a tropical paradise only with
his mom, <u>(TBD)</u>, a white baboon female who breastfeeds him. When Pacomonkey wasn't born yet, his father <u>(TBD)</u>
was kidnapped by some human hunters and has not been seen since.

A few years pass by and now he is a restless happy child who can run, climb and jump (and double jump), but the dark day
arrives. A big black mandrill named <u>(TBD)</u> arrives to the village searching for <u>(TBD)</u>, Pacomonkey's mom, 
to kill her for her past crimes and make justice (or complete his vengeance). After killing her, he still doesn't feel
satisfied enough and a feeling of frustration and uncontrolled anger possesses him: burns the trees and houses and kills
many villagers, leaving most of the kids orphans. Among those kids there's Pacomonkey's best friend <u>Pongo</u>, a
smart but coward orangutan, and Pacomonkey.

As the months pass by, Pacomonkey's rage dominates him and decides to leave the village to seek vengeance against the
monster who destroyed everything he loved.

#### Build-up
Pacomonkey's village, <u>(TBD)</u>, is ruled by a greedy and smug monkey named <u>Langur de François</u>, and his only
desire is power, and fashion. When Pacomonkey goes to see him to ask for his permission to leave the village, Langur
refuses. But as Pacomonkey insists he decides to offer him a way out: 

> "Only if a diamond is brought up to me, I will grant my permission to leave. The diamond is somewhere hidden in this 
village, if you find it and bring it to me, you will have my permission to leave."

But the true intentions of the leader are way darker: he knows that no diamonds exist in this village, he only wants to
trap the remaining population here and dominate all of them.

- If Pacomonkey talks to <u>(TBD)</u>, Langur's subordinate, she will tell him the real plans of the leader:

  > "There are no diamonds in this land, he only tells you that so you won't leave this place. He is an evil and
selfish monkey corrupted by power and his will to dominate everything and everyone. Don't let yourself be fooled!"
  
  > "There's only one way you can make it out of here. Fight Langur for yours and everyone's freedom!"

  After that, Pacomonkey will return to Langur to face him and fight for his friend's and his freedom.


- If Pacomonkey doesn't talk to her, he will keep searching for the diamond until he visits Langur again. When Langur
sees him again he will laugh at him and say:

  >"Hahaha. Keep looking for the diamond, Pacomonkey. Hahahaha!".

  Then Pacomonkey will be offered to choose between fighting him or keep searching for the diamond. If he chooses to
  keep searching, (TBD) will scream:
  
  >"He is lying to you! He doesn't want anyone to leave! There are no diamonds in this place!".

  After her confession, Langur will beat her badly and Pacomonkey will start to fight him to protect (TBD) and to leave
  this place. Also he starts fighting because he's angry for being played and lied to.

(...)

#### Resolution
After a long journey, Pacomonkey finally finds <u>(TBD)</u>, his mom's killer, inside the volcano mountain. But a lot of
time has past since he left his little village, and now the black baboon who destroyed everything is nothing more than a
tired old monkey. Pacomonkey will have to decide between forgiveness and compassion or complete his revenge.

When Pacomonkey starts fighting him, after the first hit he throws, a young mandrill named <u>(TBD)</u>, (TBD)'s grandson,
will throw his granddad a (to be determined: magic cane, potion, idk) and he will become a young baboon again for the
last time. (TBD) will be overpowered, with every ability that Pacomonkey has acquired through the entire game. When Pacomonkey
finally defeats him, he will have to decide whether to kill him or spare his live.

- If Pacomonkey decides to kill him, after doing so he will see through the eyes of the little (TBD) how he has become
what he swore to destroy, the very monster itself, and the perpetuator of this endless cycle of violence. 
After doing so he will have to decide to commit one last atrocity, killing the little boy, the only other living being
in this area, to end the cycle or forgive his life, leave and live in fear waiting for his moment to come, just like
(TBD) did.


- If Pacomonkey decides to spare his live, (...)


#### Replay
(...)

### Flowchart
<!-- Create a diagram that shows how the player progresses through the game and how the different levels or scenarios 
are related. -->

Tropical forest > Forest > *(Extra_Zoo)* > Rocky mountain > Snowy mountain > Island > Volcano mountain

(...)

### Levels and Progression
<!-- Define the structure of the game, the levels and how the difficulty progresses, specially challenges, enemies and
key elements. -->

(...)


### User Interface
<!-- Design the interface that the player will see during the game, including menus, indicators and any other relevant 
information. -->

(...)


## Art and Graphic Style
### Graphic style
#### Pixel Art
Pixel Art requires colorful characters and backgrounds. The characters, specially the important ones, should also have a
recognizable shape.

- Tiles size: 32x32
- Screen size: 360x640

(...)


### Concept Art
<!-- Create concept illustrations for characters, settings and game elements. -->
(...)


## Sound and Music
### Sound Effects
<!-- List of all the necessary sound effects -->
(...)


### Music
<!-- Decide the musical style and compose or select the music for the game -->
(...)


## Development
### Used Programs
- <u>Unity</u> *(2022.3.14f1)*: Motor engine.
- <u>JetBrains Rider</u> *(2023.2.3)*: Code refactoring tool in C# for Unity.
- <u>GitHub</u> and <u>GitHub Desktop</u>: Distributed revision control and source code administration.
- <u>Trello</u>: Project Management and collaboration tool to organize teams and work with an Agile Board.
- <u>LibreSprite</u> *(v1.2-973d0e3d-SDL)*: Animated sprite editor & pixel art tool.
- <u>ChatGPT4</u>: AI system used for design and structural guidance.