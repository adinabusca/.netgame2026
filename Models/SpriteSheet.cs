using Silk.NET.Maths;

namespace TheAdventure.Models;

//handles slicing texture into animation frames
public class SpriteSheet {
    //use readonly because grid structure of sprite sheet should not change after loading
    private readonly int _columns;
    private readonly int _rows;
    private readonly int _frameWidth;
    private readonly int _frameHeight;

    public SpriteSheet(int texW, int texH, int c, int r){
        _columns = c;
        _rows = r;

        //divides total texture size by number of cells to get size of one individual sprite
        _frameWidth = texW/c;
        _frameHeight = texH / r;
    }

    // f- frame index, r - row index 
    public Rectangle<int> GetFrame(int f, int r){
        int col = f % _columns;

        //width and height stay the same for all the frames in the sheet
        return new Rectangle<int>(col*_frameWidth, r * _frameHeight, _frameWidth, _frameHeight);

    }
    
    //properties used by GameRenderer to access frame dimensions
    public int FrameWidth => _frameWidth;
    public int FrameHeight => _frameHeight;
}