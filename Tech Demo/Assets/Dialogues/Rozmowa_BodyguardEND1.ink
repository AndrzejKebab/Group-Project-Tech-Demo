INCLUDE Globals.ink

{ Bubi == "": ->Bodyguard | ->BodyguardEnd }

===Bodyguard
Mr Ambrose, good evening. #speaker: Bodyguard #portrait: Bodyguard #layout: Right
Good evening. May I come in? #speaker: Ambrose #portrait: Ambrose #layout: Left
Of course. #speaker: Bodyguard #portrait: Bodyguard #layout: Right
WARNING! Your decision leads to irreversible progress in the plot. You won’t be able to come back to the dialogues and locations - make sure you’ve done everything you wanted to. #speaker: Warning #portrait: Warning #layout: Left
//TO JEST KOMUNIKAT DLA GRACZA, NIE OD NARRATORA ANI DIALOG, WIĘC SIĘ W TEN SPOSÓB WYŚWIETLA
* \*enter the office* #speaker: Ambrose #portrait: Ambrose #layout: Left
    ->END
        //WCHODZISZ TU DO NOWEJ LOKACJI
* I want to look around the city. #speaker: Ambrose #portrait: Ambrose #layout: Left
~ Bubi = "true"
    ->END
    
===BodyguardEnd
Mr Ambrose, hello again. Welcome. #speaker: Bodyguard #portrait: Bodyguard #layout: Right
* \*enter the office* #speaker: Ambrose #portrait: Ambrose #layout: Left
    ->END
        //WCHODZISZ TU DO NOWEJ LOKACJI
* I want to look around the city. #speaker: Ambrose #portrait: Ambrose #layout: Left
    ->END
