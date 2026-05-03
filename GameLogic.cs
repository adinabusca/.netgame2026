using Silk.NET.Maths;
using TheAdventure.Models;

namespace TheAdventure;

public class GameLogic{
    private readonly GameRenderer _renderer;

    private PlayerObject _fox = null!;
    private BirdObject _bird = null!;

    private int _bgTex;
    private Rectangle<int> _bgSrc;

    private bool _gameOver = false;
    private int _groundY;

    public GameLogic(GameRenderer renderer){
        _renderer = renderer;
    }

    public void Initialize(){
        _bgTex = _renderer.LoadTexture(@"Assets\hd.png",out var bg);
        _bgSrc = new Rectangle<int>(0,0,bg.Width, bg.Height);

        var screen = _renderer.GetWindowSize();
        _groundY = screen.Height - 50;

        _fox = new PlayerObject(_renderer, _groundY);
        _bird = new BirdObject(_renderer);
    }

    public void Update(bool left, bool right, bool jump, double deltaTime){
        if (_gameOver) return;

        _fox.Update(left,right,jump,deltaTime);
        _bird.Update(deltaTime);

        if (Collides(_fox.Dest,_bird.Dest)){
            _gameOver = true;
            Console.WriteLine("Game over! You caught the wren.");
        }

    }

    public void RenderFrame(double deltaTime){
        var screen = _renderer.GetWindowSize();
        var dst = new Rectangle<int>(0,0,screen.Width,screen.Height);

        _renderer.Clear();
        _renderer.RenderTextureUI(_bgTex,_bgSrc,dst);

        _fox.Render();
        _bird.Render();

        _renderer.Present();
    }

    private bool Collides(Rectangle<int> a, Rectangle<int> b){
        return a.Origin.X < b.Origin.X + b.Size.X && a.Origin.X + a.Size.X > b.Origin.X && a.Origin.Y < b.Origin.Y + b.Size.Y && a.Origin.Y + a.Size.Y > b.Origin.Y;
    }

   
       
}