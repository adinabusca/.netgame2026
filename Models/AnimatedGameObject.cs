namespace TheAdventure.Models;

public class AnimatedGameObject: RenderableGameObject {
    protected SpriteSheet _sheet;
    protected int _frame;//frame index
    protected int _frames;//total nr of frames in the animation sequence
    protected double _time;//used to track when to switch frames

    //inittializes animation state
    //parameter frames  = nr of horizontal frames in the image
    public AnimatedGameObject(GameRenderer renderer, string file, int frames): base(renderer,file) {
        _frames = frames;

        //initializes SpriteSheet logic with a single row of animation
        _sheet = new SpriteSheet(_texData.Width, _texData.Height,_frames, 1);
    }

    //AI-generated
    //updates animation based on time since last update  with the speed being the duration each frame stays on screen
    public void UpdateAnimation(double deltaTime, double speed = 100){
        _time += deltaTime;

        //checks if enough time passed
        if (_time > speed){
            //increment frame 
            _frame = (_frame + 1) % _frames;
            //reset timer to be used for the next frame
            _time = 0;
        }
    }
    //end AI-generated

    public override void Render(){
        _renderer.RenderTexture(_texture, _sheet.GetFrame(_frame,0), Dest);
    }
}