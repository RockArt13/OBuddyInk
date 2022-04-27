EXTERNAL ShowCharacter(characterName, position, mood) 
EXTERNAL HideCharacter(characterName)

// Charaters Are:
            //Player
            //CycloCat
            //Lizard
EXTERNAL ChangeMood(characterName, mood)

// Mood Are:
            //Good
            //Angry
            //Serious
            //Happy
            //Other
EXTERNAL ShowScene(sceneName, position)



// variables

// trusts
VAR lizardTrust = 0
VAR catTrust = 0

// curiosity for Easter Egg
VAR playerCuriosity = 0

// is CycloCat still in the cage?
VAR is_caged = true

-> start

=== start ===
{ShowCharacter("Player", "Left", "Serious")}
{ShowCharacter("CycloCat", "Right", "Good")}
//{ShowScene("TheHall", "Center")}
Player: Hey, Cyclocat. 
Cyclocat: Yes, sir. 
{ChangeMood("Player", "Good")}
Player: What question to ask, hmm?. #askQuestion
-> cage_question
=== cage_question ===
* How are you?
Cyclocat: Don't you see, sir?  
~playerCuriosity += 10
-> cage_question 
->DONE
* What time is now?
{ChangeMood("CycloCat", "Happy")}
Cyclocat: I really don't know? Maybe it's 2:95? 
{ChangeMood("Player", "Angry")}
~playerCuriosity += 20
-> cage_question
->DONE
* What the hell are you doing in the cage?
{ChangeMood("CycloCat", "Happy")}
Cyclocat: Huh.... After sipping Lizart's favorite smoothie, I'm on my vaccation, you know.
{ChangeMood("Player", "Angry")}
Player: Such a horrible day, and now you? Stop joking, you freak! 
Cyclocat: Why, sir? What did happen?
Player: I can't find my friend since early morning, the city is in chaos. And I have no idea why you're in a cage... See, everything is horrible!
Cyclocat: Maybe I can help you to find your buddy? I saw him yesterday at the party.

Player: This freak is kidding me. #askQuestion

->buddy_question
=== buddy_question ===
*** Tell me what you know about my buddy?
-> tell_about_buddy
*** Tell me who put you here?
-> tell_about_who
*** Tell me about the party yesterday?
-> tell_about_party



=== tell_about_party ===
{ChangeMood("CycloCat", "Other")}
Cyclocat: Your buddy was with us yesterday.
{ChangeMood("Player", "Happy")}
Player: With the freaks like you? Imposible!
Cyclocat: Yes, sir! And he was drinking his favourite whiskey with joogya!
Player: I don't beleive you.
Cyclocat: There is one thing I can say, and I after you will defeneitly beleive me.
Player: Okay, so say that!
{ChangeMood("CycloCat", "Serious")}
Cyclocat: At first, find a key, and let me out from this cage!
{ChangeMood("Player", "Angry")}
Player: Huh. Am I looking like a dumb? 
Cyclocat: Okay, then you will never know what your buddy told me.
~playerCuriosity += 5
-> buddy_question

=== tell_about_buddy ===
Player: So, what you know about him?
Cyclocat: This cage doesn't allow me to speak.
{ChangeMood("Player", "Other")}
Player: What have you been doing for the last 5 minutes? Meowing?
{ChangeMood("CycloCat", "Good")}
Cyclocat: I mean, it's hard to talk about your buddy under these circumstances.
~playerCuriosity += 10
-> buddy_question

=== tell_about_who ===
Player: So, Lizard put you here?
{ChangeMood("CycloCat", "Angry")}
Cyclocat: Yes, that freak!
{ChangeMood("Player", "Serious")}
Player: Because you drank his smoothie?
Cyclocat: Yes.
Player: Bastard!
{ChangeMood("CycloCat", "Serious")}
Cyclocat: Thank's for support, sir.
Player: I don't support you, freak! I'm angry because the only person in this city who can put someone in a cage is ME!
{ChangeMood("CycloCat", "Other")}
Cyclocat: Looks like Mr. Lizard too.
Player: This we will see!
-> lizart_story

=== lizart_story ===

{HideCharacter("CycloCat")}
{ShowCharacter("Lizard", "Right", "Good")}
{ChangeMood("Player", "Good")}
Lizart: Hey, sir!
Player: Let's ask him... #askQuestion
-> lizart_question

=== lizart_question ===
*** Do you know where my buddy is?
-> tell_about_buddy2
*** Why Cyclocat is caged?
-> tell_about_cage
*** Tell me about the party yesterday?
-> tell_about_party2


=== tell_about_buddy2 ===
Lizart: I don't know.
Player: Who knows?
Lizart: I don't know who knows?
{ChangeMood("Player", "Angry")}
Player: What you know?
{ChangeMood("Lizard", "Other")}
Lizart: I do no nothing.
~playerCuriosity += 10
-> lizart_question

=== tell_about_cage ===
{ChangeMood("Lizard", "Angry")}
Lizart: Because that freak drank my smoothie.
{ChangeMood("Player", "Serious")}
Player: Stop calling each other freaks! You, Freaks!
{ChangeMood("Lizard", "Other")}
Lizart: But...
{ChangeMood("Player", "Angry")}
Player: Give me the keys. Immidiatly.
{ChangeMood("Lizard", "Angry")}
Lizart: I threw the keys somewhere. I don't care about him.
Player: Where did you throw the keys?
Lizart: I don't know, somewhere near.
->END

===tell_about_party2===
{ChangeMood("Lizard", "Serious")}
Lizart: I wasn't at party.
Player: Why?
{ChangeMood("Lizard", "Happy")}
Lizart: Because I dont have QR!
{ChangeMood("Player", "Happy")}
Player: Oh, I see.
~playerCuriosity += 20
->lizart_question
// to be continued... 