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


    public BirdObject(GameRenderer renderer): base(renderer, @"Assets\8 Bird 2\Walk.png",6){
       //starting position
        X = 300;
        Y = 100;
  
        Dest = new Rectangle<int>(X,Y,_sheet.FrameWidth , _sheet.FrameHeight);
    }

    public void Update(double deltaTime){
        //compute horizontal movement 
        X += (int)(speed * (deltaTime / 1000.0) * _direction);

       
       // screen boundary collision 
        if (X < 0 || X + _sheet.FrameWidth > _screenWidth){
            _direction *= - 1;// flip direction
        }

        UpdateAnimation(deltaTime,80);

        //update destination rectangle for new position
        Dest = new Rectangle<int>(X,Y, _sheet.FrameWidth, _sheet.FrameHeight );
    }
}