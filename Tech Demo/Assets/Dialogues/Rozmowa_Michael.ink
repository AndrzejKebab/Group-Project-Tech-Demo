INCLUDE Globals.ink

{ Michael == "": ->Michau | ->MichauEnd }

===Michau
Michael. Have you finished discussing things with Astira? #speaker: Ambrose #portrait: Ambrose #layout: Left
Ambrose. Yes I have, some time ago. I don’t know where she went, if that’s what you wanted to ask. #speaker: Michael #portrait: Michael #layout: Right
No, actually... #speaker: Ambrose #portrait: Ambrose #layout: Left
* What are you doing here? #speaker: Ambrose #portrait: Ambrose #layout: Left
    I was just wondering about selling this building. #speaker: Michael #portrait: Michael #layout: Right
    Selling? Why? #speaker: Michael #portrait: Michael #layout: Right
    You know, kid, I feel like there’s no place for me in New Orlean. I’m thinking about moving out and I don’t want to leave any unfinished business. #speaker: Michael #portrait: Michael #layout: Right
    Then it’s good you haven’t started to prepare the grand opening. #speaker: Ambrose #portrait: Ambrose #layout: Left
    Yeah. Have you found anything out about my childe’s missing? #speaker: Michael #portrait: Michael #layout: Right
    Not much. #speaker: Ambrose #portrait: Ambrose #layout: Left
    Oh? #speaker: Michael #portrait: Michael #layout: Right
    ** Tell me, how did the meeting with Astira go? #speaker: Ambrose #portrait: Ambrose #layout: Left
        ->Astira
    ** We haven’t got a chance to talk in a while, so maybe you could tell me anything about it? #speaker: Ambrose #portrait: Ambrose #layout: Left
        ->Talk
    
* We haven’t got a chance to talk in a while. #speaker: Ambrose #portrait: Ambrose #layout: Left
    ->Talk
* What were you discussing with Astira? #speaker: Ambrose #portrait: Ambrose #layout: Left
    ->Astira

===Talk
You’re right. So, what would you like to talk about? #speaker: Michael #portrait: Michael #layout: Right
Your relationship with Stephen... I don’t think you two were close. #speaker: Ambrose #portrait: Ambrose #layout: Left
We were. Once. Years ago. I never would have thought at that time that this young, inexperienced kid would take such a high place in Camarilla. #speaker: Michael #portrait: Michael #layout: Right
No. I’ve never wanted to be even a part of Primogen. I wanted to support Stephen’s ambitions. But I surely know that these weren’t his ambitions. #speaker: Michael #portrait: Michael #layout: Right
Then whose? #speaker: Ambrose #portrait: Ambrose #layout: Left
Astira’s. She’s the one who wants to be on top. But she knows well that no one would place a lying Lasombra on the throne. And now she can freely manipulate Stephen. #speaker: Michael #portrait: Michael #layout: Right
... #speaker: Ambrose #portrait: Ambrose #layout: Left
I don’t know why he’s so obedient to her. #speaker: Michael #portrait: Michael #layout: Right
* Friendship. #speaker: Ambrose #portrait: Ambrose #layout: Left
    ->Friendship
* Love. #speaker: Ambrose #portrait: Ambrose #layout: Left
    ->Love
* Bond. #speaker: Ambrose #portrait: Ambrose #layout: Left
    ->Crone

===Astira
Astira tries to silence us. A Prince’s disappearance is not just a Primogen’s case. It’s a case of a whole of Camarilla - Kindred here, in the city, as well as our allies from other domains. #speaker: Michael #portrait: Michael #layout: Right
What do others think about it? #speaker: Ambrose #portrait: Ambrose #layout: Left
What do you think? No one trusts Astira. If you’ve ever wondered why Primogen frown upon Stephen’s place, it’s because of her. #speaker: Michael #portrait: Michael #layout: Right
* She’s his friend, it would be hard to explain it to him. #speaker: Ambrose #portrait: Ambrose #layout: Left
    ->Friendship
* Maybe there’s something more... #speaker: Ambrose #portrait: Ambrose #layout: Left
    ->Love
* Hmm... Do you know the legend of Crone? #speaker: Ambrose #portrait: Ambrose #layout: Left
    ->Crone

===Friendship
But he’s a Prince. He should prioritize the court’s welfare over everything. #speaker: Michael #portrait: Michael #layout: Right
And yet, he’s really close with her. You know that their relationship reaches times when they were still mortal. #speaker: Ambrose #portrait: Ambrose #layout: Left
That’s true. #speaker: Michael #portrait: Michael #layout: Right
Or maybe... #speaker: Ambrose #portrait: Ambrose #layout: Left
* ...maybe there’s something more. #speaker: Ambrose #portrait: Ambrose #layout: Left
    ->Love1
* ...maybe Astira’s playing Crone? #speaker: Ambrose #portrait: Ambrose #layout: Left 
    ->Crone


===Love
Love? I don’t think so. Stephen treats Astira as his sister, not as a potential lover. Besides, he has this Tremere of his. #speaker: Michael #portrait: Michael #layout: Right
Yeah, but if you think about it, he spends more time with Astira. #speaker: Ambrose #portrait: Ambrose #layout: Left
But there’s other reason for it. #speaker: Michael #portrait: Michael #layout: Right
* Just friendship. #speaker: Ambrose #portrait: Ambrose #layout: Left
    ->Friendship1
* Maybe Crone? #speaker: Ambrose #portrait: Ambrose #layout: Left
    ->Crone
    
===Love1
Love? I don’t think so. Stephen treats Astiraas his sister, not as a potential lover. Besides, he has this Tremere of his. #speaker: Michael #portrait: Michael #layout: Right
Yeah, but if you think about it, he spends more time with Astira. #speaker: Ambrose #portrait: Ambrose #layout: Left
But there’s other reason for it. #speaker: Michael #portrait: Michael #layout: Right
* Maybe Crone? #speaker: Ambrose #portrait: Ambrose #layout: Left
    ->Crone

===Friendship1
But he’s a Prince. He should prioritize the court’s welfare over everything. #speaker: Michael #portrait: Michael #layout: Right
And yet, he’s really close with her. You know that their relationship reaches times when they were still mortal. #speaker: Ambrose #portrait: Ambrose #layout: Left
That’s true. #speaker: Michael #portrait: Michael #layout: Right
Or maybe... #speaker: Ambrose #portrait: Ambrose #layout: Left
* ...maybe Astira’s playing Crone? #speaker: Ambrose #portrait: Ambrose #layout: Left 
    ->Crone
    
===Crone
Crone? #speaker: Michael #portrait: Michael #layout: Right
Yes, the legend of Crone. It tells that she was the one who taught Caine of power of the Blood bond. #speaker: Ambrose #portrait: Ambrose #layout: Left
Do you... Do you suggest that Astira... #speaker: Michael #portrait: Michael #layout: Right
...That she feeds Stephen with her blood. #speaker: Ambrose #portrait: Ambrose #layout: Left
It’s not impossible. And completely changes the situation. #speaker: Michael #portrait: Michael #layout: Right
What do you mean? #speaker: Ambrose #portrait: Ambrose #layout: Left
It makes her not only a schemer that manipulates a Prince, but a real threat to the structure of a whole Camarilla. What do we need a Prince for, when he can’t even rule according to his own ideals? #speaker: Michael #portrait: Michael #layout: Right
Remember, Michael, we don’t know for sure. I was just thinking out loud. #speaker: Ambrose #portrait: Ambrose #layout: Left
Then we need to make sure. #speaker: Michael #portrait: Michael #layout: Right
I’ll contact who I need to, maybe we’ll be able to catch Astira in a trap of her own schemes. #speaker: Michael #portrait: Michael #layout: Right
You sound like you care more about getting rid of her than finding Stephen. #speaker: Ambrose #portrait: Ambrose #layout: Left
Think what you want. As a Prince’s sire, I feel responsible for the court’s downfall under this cursed Lasombra’s “direction”. I won’t leave this city as long as this bitch manipulates my childe. #speaker: Michael #portrait: Michael #layout: Right
I won’t stop you, I don’t even think I want. I’ll be going, I need to check on a few tracks. #speaker: Ambrose #portrait: Ambrose #layout: Left
Sure, good luck. #speaker: Michael #portrait: Michael #layout: Right
//KOLEJNA ROZMOWA Z MICHAŁEM SKUTKUJE KOMUNIKATEM "I need to think about a few things, let’s talk later." #speaker: Michael #portrait: Michael #layout: Right
~ Michael = "true"
->END

===MichauEnd
I need to think about a few things, let’s talk later." #speaker: Michael #portrait: Michael #layout: Right
->END

