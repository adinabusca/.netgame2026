using Silk.NET.Maths;

namespace TheAdventure.Models;

//automated bird NPC
public class BirdObject: AnimatedGameObject {
    public int X;
    public int Y;

    private int _direction = 1;// direction movement: 1 for right, -1 for left
    private const int speed = 120;


    //boundary for flying area (width of game window)
    private int _screenWidth = 800;

    private bool _isDead = false;

    private float _velocityY = 0;
    private const float gravity = 1200f;
    private bool _hasLanded = false;

    private string _deadTex = @"Assets\8 Bird 2\Death.png";
    private int _deadFrames = 4;
    
    public BirdObject(GameRenderer renderer): base(renderer, @"Assets\8 Bird 2\Walk.png",6){
       //starting position
        X = 300;
        Y = 100;
  
        Dest = new Rectangle<int>(X,Y,_sheet.FrameWidth , _sheet.FrameHeight);
    }

    public void Kill(){
        if (_isDead) return;

        _isDead = true;

        //switches sprite sheet 
        _texture = _renderer.LoadTexture(_deadTex,out var tex);
        _sheet = new SpriteSheet(tex.Width, tex.Height, _deadFrames, 1);

        _frames = _deadFrames;
        _frame = 0;

        _velocityY = -250f;

        Dest = new Rectangle<int>(X,Y,_sheet.FrameWidth , _sheet.FrameHeight);


    }

    public void Update(double deltaTime){
       if (!_isDead){
        //compute horizontal movement 
        X += (int)(speed * (deltaTime / 1000.0) * _direction);
        // screen boundary collision 
        if (X < 0 || X + _sheet.FrameWidth > _screenWidth){
            _direction *= - 1;// flip direction
        }
       }else {

        if (!_hasLanded){
           // falling animation
            _velocityY += gravity * (float)(deltaTime/1000.0);
            Y += (int)(_velocityY * (float)(deltaTime/1000.0));

            int groundY = 400 - _sheet.FrameHeight;

            if (Y >= groundY){
                Y = groundY;
                _velocityY = 0;
                _hasLanded = true;
            }
        }
       
       }
      
        if (!_hasLanded){
           UpdateAnimation(deltaTime,80);
        }else {
            _frame = _frames - 1; //freze animation to last frame
        }
           

        //update destination rectangle for new position
        Dest = new Rectangle<int>(X,Y, _sheet.FrameWidth, _sheet.FrameHeight );
    }
}