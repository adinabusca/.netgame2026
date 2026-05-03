using Silk.NET.Maths;

namespace TheAdventure.Models;

public class BirdObject: AnimatedGameObject {
    public int X;
    public int Y;

    private int _direction = 1;
    private const int speed = 120;

    private int _screenWidth = 800;


    public BirdObject(GameRenderer renderer): base(renderer, @"Assets\8 Bird 2\Walk.png",6){
        X = 300;
        Y = 100;

        Dest = new Rectangle<int>(X,Y,_sheet.FrameWidth, _sheet.FrameHeight);
    }

    public void Update(double deltaTime){
        X += (int)(speed * (deltaTime / 1000.0) * _direction);

       
        if (X < 0 || X + _sheet.FrameWidth > _screenWidth){
            _direction *= - 1;
        }

        UpdateAnimation(deltaTime,80);
        Dest = new Rectangle<int>(X,Y, _sheet.FrameWidth, _sheet.FrameHeight);
    }
}