using Silk.NET.Maths;

namespace TheAdventure.Models;

public class SpriteSheet {
    private readonly int _columns;
    private readonly int _rows;
    private readonly int _frameWidth;
    private readonly int _frameHeight;

    public SpriteSheet(int texW, int texH, int c, int r){
        _columns = c;
        _rows = r;
        _frameWidth = texW/c;
        _frameHeight = texH / r;
    }

    public Rectangle<int> GetFrame(int f, int r){
        int col = f % _columns;
        return new Rectangle<int>(col*_frameWidth, r * _frameHeight, _frameWidth, _frameHeight);

    }

    public int FrameWidth => _frameWidth;
    public int FrameHeight => _frameHeight;
}