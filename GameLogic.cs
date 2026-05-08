using Silk.NET.Maths;
using TheAdventure.Models;

namespace TheAdventure;

public class GameLogic{
    private readonly GameRenderer _renderer;

    //entity instances 
    private PlayerObject _fox = null!;
    private BirdObject _bird = null!;

    //background texture and source dimensions
    private int _bgTex;
    private Rectangle<int> _bgSrc;

    private bool _gameOver = false;
    private int _groundY;

    private double _timeRemaining = 60_000;
    private bool _won = false;
    private bool _hurryUpShown = false;

    public GameLogic(GameRenderer renderer){
        _renderer = renderer;
    }

    public void Initialize(){
        //load background image and store dimensions
        _bgTex = _renderer.LoadTexture(@"Assets\hd.png",out var bg);
        _bgSrc = new Rectangle<int>(0,0,bg.Width, bg.Height);

        //determine ground level based on window size
        var screen = _renderer.GetWindowSize();
        _groundY = screen.Height - 50;

       //create player and NPC instances
        _fox = new PlayerObject(_renderer, _groundY);
        _bird = new BirdObject(_renderer);
    }

    public void Update(bool left, bool right, bool jump, double deltaTime){
        if (!_gameOver){

            //update entities state
            _fox.Update(left,right,jump,deltaTime);
           
           //update timer
           _timeRemaining -= deltaTime;

           if (!_hurryUpShown && _timeRemaining <= 30_000){
            _hurryUpShown = true;
            Console.WriteLine("Hurry up!");
           }
           if (_timeRemaining <= 0){
            _timeRemaining = 0;
            _gameOver = true;
             Console.WriteLine("You ran out of time! You did not caught the wren.");
           }

            //collision detection: check if player touches bird
            if (Collides(_fox.Dest,_bird.Dest)){
                _bird.Kill();
                _won = true;
                _gameOver = true;
                Console.WriteLine("Game over! You caught the wren.");
            }
        }

        _bird.Update(deltaTime);

    }

    public void RenderFrame(double deltaTime){
        var screen = _renderer.GetWindowSize();
        var dst = new Rectangle<int>(0,0,screen.Width,screen.Height);

        //clears previous frame
        _renderer.Clear();
        //draw background 
        _renderer.RenderTextureUI(_bgTex,_bgSrc,dst);

        //draw entities on top of background
        _fox.Render();
        _bird.Render();
        
        //swap buffers to display new frame
        _renderer.Present();
    }

    //checks if two rectanles overlap in 2D space 
    private bool Collides(Rectangle<int> a, Rectangle<int> b){
        return a.Origin.X < b.Origin.X + b.Size.X && a.Origin.X + a.Size.X > b.Origin.X && a.Origin.Y < b.Origin.Y + b.Size.Y && a.Origin.Y + a.Size.Y > b.Origin.Y;
    }

   
       
}