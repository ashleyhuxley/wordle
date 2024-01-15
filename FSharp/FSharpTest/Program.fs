// For more information see https://aka.ms/fsharp-console-apps
open Game
open WordSource

let src = RandomWordSource("D:\Code\Wordle\words.txt")
let game = Game(src)

for i = 0 to 5 do
    