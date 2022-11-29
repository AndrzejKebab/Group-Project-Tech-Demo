INCLUDE Globals.ink

{ Halim == "": ->Sklep | ->SklepEnd }

===Sklep
\*You enter through the glass door. A normal shop would be closed at this hour. Unless it’s owned by a Kindred. Shadows enveloping the room creates an eerie mood.* #speaker: Narrator #portrait: Narrator #layout: Left
\*Your senses go wild, as you are surrounded by dozens scents at once. A delicate sound of bells reaches your ears and colorful gleam of many crystals fills your vision, candles and other bric-a-brac standing on the shelves.* #speaker: Narrator #portrait: Narrator #layout: Left
\*Behind a counter, there is a young man. He’s looking through a bunch of boxes on the counter. When you enter the shop, he looks at you and wrinkles his nose.* #speaker: Narrator #portrait: Narrator #layout: Left
Ambrose, hi. It’s good to see you. How was LA? #speaker: Halim #portrait: Halim #layout: Right
* Good. Asylum’s looking better than it did a year ago. #speaker: Ambrose #portrait: Ambrose #layout: Left
    Ah, I really need to visit my old haunts… What brings you to me? #speaker: Halim #portrait: Halim #layout: Right
    ** Have you heard about what happened to Stephen? #speaker: Ambrose #portrait: Ambrose #layout: Left
        ->Stephen
    ** Was Astira here? #speaker: Ambrose #portrait: Ambrose #layout: Left
        ->Astira1
    ** How’s business? #speaker: Ambrose #portrait: Ambrose #layout: Left
        Not bad, sometimes there are clients, other times there aren’t any. But I do what I like, so I won’t complain. #speaker: Halim #portrait: Halim #layout: Right
        Oh, yeah, I’m glad you find fulfillment in here. And tell me… #speaker: Ambrose #portrait: Ambrose #layout: Left
        *** Have you heard about what happened to Stephen? #speaker: Ambrose #portrait: Ambrose #layout: Left
            ->Stephen
        *** Was Astira here? #speaker: Ambrose #portrait: Ambrose #layout: Left
            ->Astira1
* Fine. Have you heard about Stephen? #speaker: Ambrose #portrait: Ambrose #layout: Left
    ->Stephen
* Okay. Is Astira here? #speaker: Ambrose #portrait: Ambrose #layout: Left
    ->Astira1

===Stephen
Yeah, I have… I met with him a few days ago. We went to Salumy, got drunk a bit and then Astira came in. She said that there was some problem that needed an immediate meeting. And so Steph took his stuff and left. #speaker: Halim #portrait: Halim #layout: Right
You haven’t met later? #speaker: Ambrose #portrait: Ambrose #layout: Left
    With Stephen? No, I haven’t. I heard that he was at the banquet the day before but he didn’t contact me neither before, nor after it. #speaker: Halim #portrait: Halim #layout: Right
    Yeah, Astira mentioned that they were at the party. It’s weird that you weren’t there with Stephen. #speaker: Ambrose #portrait: Ambrose #layout: Left
    \*You see that young Tremere lower his eyes and focus on the boxes’ contents again. His hands catch your attention - his right hand’s middle finger is missing a ring he once got from Stephen.* #speaker: Narrator #portrait: Narrator #layout: Left
    I… Well, I don’t fancy this type of official meetings. Besides, you know that Stephen doesn’t like flashing our relationship. #speaker: Halim #portrait: Halim #layout: Right
    * Mhm, I see. #speaker: Ambrose #portrait: Ambrose #layout: Left
        ->Cisza
    * \*don't say anything* #speaker: Ambrose #portrait: Ambrose #layout: Left
        ->Cisza
    * Don't you want to tell me anything else, by any chance? #speaker: Ambrose #portrait: Ambrose #layout: Left
        ->Podejrzenia
    
=Cisza
Anything else? #speaker: Halim #portrait: Halim #layout: Right
* I don’t think you’re telling me everything. #speaker: Ambrose #portrait: Ambrose #layout: Left
    ->Podejrzenia
* I’ve never seen you without the ring. Have you had a fight with Stephen? #speaker: Ambrose #portrait: Ambrose #layout: Left
    ->Ring
* I feel like you don’t really care about his disappearance. #speaker: Ambrose #portrait: Ambrose #layout: Left
    ->Zaniedbanie

===Astira1
Yeah, she left a few minutes ago. It’s weird you didn’t bump into each other. #speaker: Halim #portrait: Halim #layout: Right
What were you talking about? #speaker: Ambrose #portrait: Ambrose #layout: Left
She said that Stephen was missing and the Primogen are going crazy about it. #speaker: Halim #portrait: Halim #layout: Right
Yeah… The situation is pretty tense. #speaker: Ambrose #portrait: Ambrose #layout: Left
Well, Astira said that she had everything under control. #speaker: Halim #portrait: Halim #layout: Right
No doubt, Astira likes to “control” everything and everyone… Well, I’ll look around. #speaker: Ambrose #portrait: Ambrose #layout: Left
I hope everything will clarify. #speaker: Halim #portrait: Halim #layout: Right
\*You watch the young Tremere. He’s surprisingly calm as for someone who just got to know that his lover was missing.* #speaker: Narrator #portrait: Narrator #layout: Left
So.. Have you seen with Stephen lately? #speaker: Ambrose #portrait: Ambrose #layout: Left
    * ->Stephen

===Podejrzenia
What? Where did the idea come from? #speaker: Halim #portrait: Halim #layout: Right
You had a fight with Stephen, right? #speaker: Ambrose #portrait: Ambrose #layout: Left
What are you drawing this conclusion from? #speaker: Halim #portrait: Halim #layout: Right
* If it wasn’t like that, you would’vebeen the first one at this banquet. We all know that you want the Prince to devote every moment to you. And you surely wouldn’t pass up an opportunity to show yourself by Prince’s side among all the flower of Camarilla. (Dominate) #speaker: Ambrose #portrait: Ambrose #layout: Left
    I think you should shut your mouth. Stephen wouldn’t be pleased hearing words like these from his own childe. #speaker: Halim #portrait: Halim #layout: Right
    I think Stephen wouldn’t be pleased seeinghow little you care about his disappearance. Unless... #speaker: Ambrose #portrait: Ambrose #layout: Left
    ** ...You’re behind this. #speaker: Ambrose #portrait: Ambrose #layout: Left
        ->Prowokacja
    ** [\*say nothing*] #speaker: Ambrose #portrait: Ambrose #layout: Left
        ... #speaker: Ambrose #portrait: Ambrose #layout: Left
        Unless what? #speaker: Halim #portrait: Halim #layout: Right
        *** Unless you’re behind this. #speaker: Ambrose #portrait: Ambrose #layout: Left
            ->Prowokacja
        *** Nevermind. I should meet with Astira.Vivienne was mentioning something about her in the club. #speaker: Ambrose #portrait: Ambrose #layout: Left
            Vivienne? What does this bitch has to do with Stephen’s disappearance? #speaker: Halim #portrait: Halim #layout: Right
            Nothing. I don’t think she even knows about it. Astira said it was top secret. #speaker: Ambrose #portrait: Ambrose #layout: Left
            Vivienne and Astira apparently were scheming something together, I don’t remember what it was about. And Stephen was promising himself that it wasn’t true. #speaker: Halim #portrait: Halim #layout: Right
            Vivienne is Ventrue. I doubt she would scheme anything with Lasombra. #speaker: Ambrose #portrait: Ambrose #layout: Left
            I don’t know, Ambrose, I don’t like all those acts on the court. Until Steph is found, someone has to keep an eye on Astira and the rest of that lying fellowship. #speaker: Halim #portrait: Halim #layout: Right
            ... #speaker: Ambrose #portrait: Ambrose #layout: Left
            Anyway, I don’t want to talk about this... #speaker: Halim #portrait: Halim #layout: Right
                ->END
                ~ Halim = "true"
            //TUTAJ DIALOG SIĘ KOŃCZY NA DOBRYCH WARUNKACH, NIE DOSZŁO DO KŁÓTNI. KIEDY PODEJDZIESZ DO HALIMA PO RAZ DRUGI POWIE "I don’t want to talk about this."
* You don’t wear the ring he gave you. And we all know how important this gift was to you. You wouldn’t take it off without anything serious happening between you two. #speaker: Ambrose #portrait: Ambrose #layout: Left
    ->Ring
* I feel like you don’t really care about his disappearance. #speaker: Ambrose #portrait: Ambrose #layout: Left
    ->Zaniedbanie

===Ring
Well... Yes, we did have a fight. Then, at the club, when Astira came. #speaker: Halim #portrait: Halim #layout: Right
Why? #speaker: Ambrose #portrait: Ambrose #layout: Left
I got angry that he’s on her beck and call. He’s the freaking Prince, not she. #speaker: Halim #portrait: Halim #layout: Right
You’re right, but someone has to stand watch when he’s enjoying himself. Especially when the Primogen are waiting for his mistake just to undermine his authority. #speaker: Ambrose #portrait: Ambrose #layout: Left
They should be undermining Astira’s authority. Especially, as Steph said, they don’t trust her. #speaker: Halim #portrait: Halim #layout: Right
Hmm... #speaker: Ambrose #portrait: Ambrose #layout: Left
    * ->Konkluzje

===Zaniedbanie
How can you say that? I do care, surely more than Astira. #speaker: Halim #portrait: Halim #layout: Right
What? #speaker: Ambrose #portrait: Ambrose #layout: Left
Well, I wouldn’t like to gossip, but Astira seems pleased with that turn of events. Everything is finally the way she wanted. And when she was in here, she didn’t sound upset. #speaker: Halim #portrait: Halim #layout: Right
* You’re imagining things. Astira and Stephen have knowneach other for decades. They’re friends. Stephen would go through fire and water for her. #speaker: Ambrose #portrait: Ambrose #layout: Left
    Stephen for Astira surely. But would she do that for him? I highly doubt it. #speaker: Halim #portrait: Halim #layout: Right
    ... #speaker: Ambrose #portrait: Ambrose #layout: Left
    \*Your mind is filled with memories of many situations when the Prince was protecting his friend and was spending time with her. You remember his face when he was talking about her - pure pride and joy that she’s in his unlife.* #speaker: Narrator #portrait: Narrator #layout: Left
    I think we’re starting to freak out. We should focus on looking for Stephen. #speaker: Ambrose #portrait: Ambrose #layout: Left
    Yes, it’s the highest priority. We can’t leave the court in Astira’s hands for too long. Let me know if I can help you with anything. #speaker: Halim #portrait: Halim #layout: Right
    Sure. #speaker: Ambrose #portrait: Ambrose #layout: Left
    //TUTAJ DIALOG SIĘ KOŃCZY NA DOBRYCH WARUNKACH, NIE DOSZŁO DO KŁÓTNI. KIEDY PODEJDZIESZ DO HALIMA PO RAZ DRUGI POWIE "I don’t want to talk about this."
        -> END
        ~ Halim = "true"
* Maybe you’re right, but you better don’t jump to conclusions like these in front of Primogen. They don’t trust Astira and Stephen at all. #speaker: Ambrose #portrait: Ambrose #layout: Left
    ->Konkluzje

===Prowokacja
How dare you?! I would never hurt Stephen! #speaker: Halim #portrait: Halim #layout: Right
I'm not saying that you hurt him. #speaker: Ambrose #portrait: Ambrose #layout: Left
I don’t want to hear your voice anymore. Drop the subject. #speaker: Halim #portrait: Halim #layout: Right
//DOSZŁO DO KŁÓTNI, HALIM JEST ZŁY. PONOWNA PRÓBA ROZMOWY SKUTKUJE W "Don't talk to me now."
~ Halim = "true"
    ->END

===Konkluzje
Think about it, Ambrose. If they don’t trust her, they surely have their reasons. It’s a Lasombra, she’s as obsessed with power as this Ventrue bitch. #speaker: Halim #portrait: Halim #layout: Right
Vivienne? #speaker: Ambrose #portrait: Ambrose #layout: Left
Yeah. I’ve heard from Stephen multiple times that she was playing her creator off against him. And you know well that Finley is a respected member of Primogen. #speaker: Halim #portrait: Halim #layout: Right
And Vivienne is a Ventrue. She has hatred for everything but her Clan in her blood. #speaker: Ambrose #portrait: Ambrose #layout: Left
Perhaps. I don’t know, Ambrose, I don’t like all those acts on the court. Until Steph is found, someone has to keep an eye on Astira and the rest of that lying fellowship. #speaker: Halim #portrait: Halim #layout: Right
... #speaker: Ambrose #portrait: Ambrose #layout: Left
Anyway, I don’t want to talk about this now... #speaker: Halim #portrait: Halim #layout: Right
~ Halim = "true"
    ->END
    //TUTAJ DIALOG SIĘ KOŃCZY NA DOBRYCH WARUNKACH, NIE DOSZŁO DO KŁÓTNI. KIEDY PODEJDZIESZ DO HALIMA PO RAZ DRUGI POWIE "I don’t want to talk about this."

===SklepEnd
I don’t want to talk about this." #speaker: Halim #portrait: Halim #layout: Right
->END






















