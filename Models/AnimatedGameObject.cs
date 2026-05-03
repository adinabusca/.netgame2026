namespace TheAdventure.Models;

public class AnimatedGameObject: RenderableGameObject {
    protected SpriteSheet _sheet;
    protected int _frame;
    protected int _frames;
    protected double _time;

    public AnimatedGameObject(GameRenderer renderer, string file, int frames): base(renderer,file) {
        _frames = frames;
        _sheet = new SpriteSheet(_texData.Width, _texData.Height,_frames, 1);
    }

    public void UpdateAnimation(double deltaTime, double speed = 100){
        _time += deltaTime;

        if (_time > speed){
            _frame = (_frame + 1) % _frames;
            _time = 0;
        }
    }

    public override void Render(){
        _renderer.RenderTexture(_texture, _sheet.GetFrame(_frame,0), Dest);
    }
}