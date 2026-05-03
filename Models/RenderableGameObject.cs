using Silk.NET.Maths;

namespace TheAdventure.Models;

public class RenderableGameObject: GameObject {
    protected int _texture;
    protected TextureData _texData;

    public Rectangle<int> Source;
    public Rectangle<int> Dest;

    protected GameRenderer _renderer;

    public RenderableGameObject(GameRenderer renderer, string file) {
        _renderer = renderer;
        _texture = renderer.LoadTexture(file, out _texData);

        Source = new Rectangle<int>(0,0, _texData.Width, _texData.Height);
        Dest = new Rectangle<int>(0,0, _texData.Width, _texData.Height);
    }

    public virtual void Render(){
        _renderer.RenderTexture(_texture, Source, Dest);
    }
}