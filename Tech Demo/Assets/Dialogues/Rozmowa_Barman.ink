INCLUDE Globals.ink

{ Bartender == "": ->Barman | ->BarmanEnd }

===Barman

* Have you heard about Stephen? #speaker: Ambrose #portrait: Ambrose #layout: Left
    Yeah, I have… They were asking about him. I work for him, after all. #speaker: Jeremiah #portrait: Jeremiah #layout: Right
    What did you tell them? Where could he be? #speaker: Ambrose #portrait: Ambrose #layout: Left
    How am I supposed to know? The boss pays me, brings some girls, sometimes comes to boss around or get drunk - I don’t ask questions. I don’t get paid enough to care. I just work here. #speaker: Jeremiah #portrait: Jeremiah #layout: Right
    Don’t you know someone that could know something? Was he in here with someone in particular? #speaker: Ambrose #portrait: Ambrose #layout: Left
    I’ve already told you, I don’t know anything. You either order something or stop bothering me, clients are waiting. #speaker: Jeremiah #portrait: Jeremiah #layout: Right
    ... #speaker: Ambrose #portrait: Ambrose #layout: Left
    -> Barman
* What’s new? #speaker: Ambrose #portrait: Ambrose #layout: Left
    What is there to be new? Something is always happening, but in the same routine - someone comes, orders something, talks about stuff and leaves. I don’t think that clients’ whining is something you’d like to hear. #speaker: Jeremiah #portrait: Jeremiah #layout: Right
    ... #speaker: Ambrose #portrait: Ambrose #layout: Left
    -> Barman
* Pour me something strong… #speaker: Ambrose #portrait: Ambrose #layout: Left
    You need to be more specific, son. #speaker: Jeremiah #portrait: Jeremiah #layout: Right
    ** Bloodlimes. #speaker: Ambrose #portrait: Ambrose #layout: Left
        \*Pouring sounds can be heared.*
        ->Barman
    ** I’ve changed my mind. #speaker: Ambrose #portrait: Ambrose #layout: Left
    ->Barman
* ->
... #speaker: Jeremiah #portrait: Jeremiah #layout: Right
Check the VIP area, maybe one of those gentlemen will sell you more information. And stop bothering me with that already. #speaker: Jeremiah #portrait: Jeremiah #layout: Right
    ~ Bartender = "true"
-> END

=== BarmanEnd
Don't bother me. #speaker: Jeremiah #portrait: Jeremiah #layout: Right
->END
