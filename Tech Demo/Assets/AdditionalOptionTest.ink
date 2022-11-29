INCLUDE Dialogues/Globals.ink

-> main

=== main
AAAAAA
    * no chomp
    * {circlesPicked > 2}chomp
    ~ circlesPicked = circlesPicked + 1
            **{circlesPicked >= 5}mnom
            ->END
            **disgusting
- amen
->END