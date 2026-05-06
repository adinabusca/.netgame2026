using Silk.NET.Maths;

namespace TheAdventure.Models;

public class RenderableGameObject: GameObject {
    protected int _texture;
    protected TextureData _texData;

    public Rectangle<int> Source;//which part of texture to crop
    public Rectangle<int> Dest;//location on screen to draw the object at + the size

    protected GameRenderer _renderer;

    public RenderableGameObject(GameRenderer renderer, string file) {
        _renderer = renderer;

        //LoadTexture return the GPU texture ID and outputs its dimensions into _texData
        _texture = renderer.LoadTexture(file, out _texData);

        //default==> set Source and Dest to full size of loaded texture
        Source = new Rectangle<int>(0,0, _texData.Width, _texData.Height);
        Dest = new Rectangle<int>(0,0, _texData.Width, _texData.Height);
    }

    public virtual void Render(){
        //instructs renderer to drwa the specific texture slice Source at the target screen position Dest
        _renderer.RenderTexture(_texture, Source, Dest);
    }
}