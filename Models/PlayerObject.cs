using Silk.NET.Maths;

namespace TheAdventure.Models;

public class PlayerObject: AnimatedGameObject {
   public float X;
   public float Y;

   private float _velocityY = 0;
   private int _jumpCount = 0;

   private const float gravity = 2000f;
   private const float jumpForce = -800f;
   private const int speed = 200;

   private int _groundY;

   private string _idleTex;
   private string _walkTex;

   private int _idleFrames;
   private int _walkFrames;

   private bool _isMoving = false;

   

   public PlayerObject(GameRenderer renderer, int groundY): base(renderer, @"Assets\3 Cat\Idle.png", 4){
    _groundY = groundY;

    _idleTex = @"Assets\3 Cat\Idle.png";
    _walkTex = @"Assets\3 Cat\Walk.png";

    _idleFrames = 4;
    _walkFrames = 6;

    X = 0;
    Y = groundY - _sheet.FrameHeight;

    Dest = new Rectangle<int>((int)X,(int)Y, _sheet.FrameWidth, _sheet.FrameHeight);

   }

   public void Update(bool left, bool right, bool jump, double deltaTime){
    double move = speed * (deltaTime/ 1000.0);

    _isMoving = false;

    if (left){
        X -=(float)move;
        _isMoving= true;
    }

    if (right){
        X +=(float)move;
        _isMoving = true;
    }

    if (jump && _jumpCount < 2){
        _velocityY = jumpForce;
        _jumpCount++;
    }

    // gravity
    _velocityY += gravity * (float)(deltaTime/ 1000.0);
    Y += (float)(_velocityY * (deltaTime / 1000.0));

    //ground check
    if (Y + _sheet.FrameHeight >= _groundY){
        Y = _groundY - _sheet.FrameHeight;
        _velocityY = 0;
        _jumpCount = 0;
    }

    HandleAnimation();
    UpdateAnimation(deltaTime);

    Dest = new Rectangle<int>((int)X,(int)Y,_sheet.FrameWidth,_sheet.FrameHeight);
   }

   private void HandleAnimation(){
    string desiredTex = _isMoving ? _walkTex: _idleTex;
    int desiredFrames = _isMoving ? _walkFrames : _idleFrames;

    if (_frames != desiredFrames){
        _texture = _renderer.LoadTexture(desiredTex, out var tex);
        _sheet = new SpriteSheet(tex.Width, tex.Height, desiredFrames, 1);
        _frames = desiredFrames;
        _frame = 0;
    }
   }
}