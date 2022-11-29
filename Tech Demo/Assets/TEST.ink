INCLUDE Dialogues/Globals.ink

{ something_name == "": -> main | -> alredy_chose}
-> main

=== main ===
What do you choose?
    +[CockAndBalls]
        -> chosen("CockAndBalls")
    +[Kartofel]
        -> chosen("Kartofel")
    +[AnimeTiddies]
        -> chosen("AnimeTiddies")
        
=== chosen(something) ===
~ something_name = something
You choosed {something}!
-> END

=== alredy_chose ===
You already chose {something_name}
->END