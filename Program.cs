using TheAdventure;
using Silk.NET.SDL;

//core initialization
var sdl = new Sdl(new TheAdventure.SdlContext());
sdl.Init(Sdl.InitVideo);

//components setup
var window = new GameWindow(sdl);
var renderer = new GameRenderer(sdl,window);
var logic = new GameLogic(renderer);
var input = new InputLogic(sdl,logic);

//load textures, set ground levels, spawn objects
logic.Initialize();

bool quit = false;

//main game loop (runs till user closes window)
while (!quit){
    quit = input.Process();//processes input, handles physics and checks for collision
    logic.RenderFrame(16);//draw current state to the screen
    System.Threading.Thread.Sleep(13);// frame rate control (pauses execution slightly)
}

renderer.Dispose();
//cleanup (shutdown SDL and release hardware resources before exit)
sdl.Quit();