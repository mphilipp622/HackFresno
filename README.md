# HackFresno
Hack Fresno Hackathon 2018 Project

Winner: Best in Education Category

Our project is called "Wendy's Colors". The idea for the application came from a modern approach that many dyslexic and autistic kids are using to help them read more effectively. This modern approach uses color overlays to help them colorize words and letters. This colorization is supposed to help dyslexic and autistic children process words much easier than usual.

My portion of the project was to try and develop a program that could perform text recognition on a page from a book, create a color palette for every letter, and output the text using the new color palette.

We were given 36 hours to come up with an idea and implement as much as we could.

# Implementation Notes
This project utilizes Unity3D. The reason I chose Unity3D was because of my familiarity with the program and because Unity has a new, built-in AR library called Vuforia, which has text recognition features. Unity made it easy for me to implement a simple UI and text tracking within a 36 hour period.

I was not able to get an Android build to work correctly, although the project does have an APK file that will run on a phone. Typically, the phone will crash upon recognizing text.

To use the program, I would recommend opening it in Unity and playing it. Hold a page with digitized text on it up to the camera and wait for the recognition to happen. You will see blue boxes outline the words on the page that it detects. Once that's done, click "Display Text" to see the output with the custom colors.

# Problems and Challenges
The biggest challenge was, by far, getting text recognition to work even remotely well. This is still an outstanding issue. Although the program can detect word positions rather well, it does not always grab the right string for the word, resulting in an inaccurate translation from the real world to the digital world.

Additionally, word positions do not always maintain a top-left to bottom-right order. This is likely due to the simple math I used to try and perform this calculation.