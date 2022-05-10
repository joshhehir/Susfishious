#FIRST
VAR priority = 1
->main

==main
Hi there, I'm Mayor Garth. Welcome to Susfishious!
You've arrived in time for the annual fishing competition!

*[Yeah, that why I'm here, for the competiton.] -> yescomp
*[What fishing competiton!?] -> compinfo

==yescomp
Excellent! I'm sure you'll have a wondeful time here. #RESUME:yescomp
->DONE

==comeback
Look's like you've been out fishing already. Have you had any luck yet?
*[That's right...] -> yesfish
*[No luck yet] -> nofish


==compinfo
Our little town prides itself on the wide variey of fish in our pristine lake.
We hold this competiton annually to celebrate and share our passion for fishing.
->fishask

==fishask
Look's like you've been fishing today. Have you had any luck yet?

*[That's right...] -> yesfish
*[No luck yet] -> nofish


==yesfish
Ah, wondeful. 
*[About the fish I caught...] -> fishy
*[There's something fishy going on here.] -> fishy

==nofish
No luck yet? Ah, well.
There's still plenty of time left in the day to head back out in the water.
Or you could ask some of our local fishing experts for some tips.
Anyway, I hope you enjoy your time here. #RESUME: fishask
->END

==fishy
Really? You caught an odd-looking fish.
Hmm... let me take a look.
Now tell me, what do you think this fish looks like?
*[A Spanner] -> megafish
*[A Megaphone] -> megafish
*[A weird fish] -> weirdfish
*[A fish] -> notsusfishious

==notsusfishious
A fish you say? Well, it looks like a fish to me too.
Were you expecting to catch something else? A frying pan perhaps?
I could go for some lovely fried fish right now, but I'm not planning to leave the festival just yet. Maybe later though.
That gives me an idea. Maybe later on you could ask our local barkeep Jamie to fry up that fish of yours for tea. Now wouldn't that be delicious.
*[Probably] -> megafish
*[Probably not] -> megafish

==yes
Excellent! Then I hope you enjoy your time here. #RESUME: yes
->END

==weirdfish
A weird-looking fish you say? I assure you that its just one of the local species. #RESUME: weird
->END

==megafish
You caught a megafish? Wow! It looks like this section isn't finished yet. #RESUME: megafish
->END
