using Silk.NET.Maths;

namespace TheAdventure.Models;

public class PlayerObject: AnimatedGameObject {
   public float X;
   public float Y;

   private float _velocityY = 0;
   private int _jumpCount = 0;// tracks jumps fro the double-jump functionality

   private const float gravity = 2000f;// downward acceleration
   private const float jumpForce = -800f;//initial upward velocity
   private const int speed = 200;// horizontal movement speed

   private int _groundY;

   private string _idleTex;
   private string _walkTex;

   private int _idleFrames;
   private int _walkFrames;

   private bool _isMoving = false;//flag for which animation to play

   

   public PlayerObject(GameRenderer renderer, int groundY): base(renderer, @"Assets\3 Cat\Idle.png", 4){
    _groundY = groundY;

    _idleTex = @"Assets\3 Cat\Idle.png";
    _walkTex = @"Assets\3 Cat\Walk.png";

    _idleFrames = 4;
    _walkFrames = 6;

    X = 0;
    Y = groundY - _sheet.FrameHeight;

    //initialize Dest rectangle 
    Dest = new Rectangle<int>((int)X,(int)Y, _sheet.FrameWidth * 2, _sheet.FrameHeight * 2);

   }

   public void Update(bool left, bool right, bool jump, double deltaTime){
    double move = speed * (deltaTime/ 1000.0);

    _isMoving = false;

    // horizontal movement logic left right
    if (left){
        X -=(float)move;
        _isMoving= true;
    }

    if (right){
        X +=(float)move;
        _isMoving = true;
    }

    // jump logic with double jumping
    if (jump && _jumpCount < 2){
        _velocityY = jumpForce;
        _jumpCount++;
    }

    // gravity: update velocity then position
    _velocityY += gravity * (float)(deltaTime/ 1000.0);
    Y += (float)(_velocityY * (deltaTime / 1000.0));

    //ground collision check
    if (Y + _sheet.FrameHeight >= _groundY){
        Y = _groundY - _sheet.FrameHeight;// snap to ground
        _velocityY = 0;// reset vertical velocity
        _jumpCount = 0;// reset jump counter
    }

    HandleAnimation();
    UpdateAnimation(deltaTime);

    //update drwaing rectangle for the new coordinates
    Dest = new Rectangle<int>((int)X,(int)Y,_sheet.FrameWidth * 2,_sheet.FrameHeight * 2);
   }

   private void HandleAnimation(){
    //chack if player is moving or is idle
    string desiredTex = _isMoving ? _walkTex: _idleTex;
    int desiredFrames = _isMoving ? _walkFrames : _idleFrames;

    //reload texture if state changed
    if (_frames != desiredFrames){
        _texture = _renderer.LoadTexture(desiredTex, out var tex);
        _sheet = new SpriteSheet(tex.Width, tex.Height, desiredFrames, 1);
        _frames = desiredFrames;
        _frame = 0;// reset animation for first frame
    }
   }
}