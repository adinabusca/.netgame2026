using Silk.NET.SDL;


namespace TheAdventure;

public class InputLogic {
   private readonly Sdl _sdl;
   private readonly GameLogic _logic;

   private DateTime _last = DateTime.Now;
   private bool _wasJumpPressed = false;//tracks down the state of Space key in previous frame (ensures one jump per press)

   public InputLogic(Sdl sdl, GameLogic logic){
    _sdl = sdl;
    _logic = logic;
   }
  
   
   public unsafe bool Process(){
     Event ev = new();
     
     //chekcs for system events
     while (_sdl.PollEvent(ref ev) != 0){
        if (ev.Type == (uint)EventType.Quit) {
            return true;
        }

     }
     
     //computes amount of times since last frame
     var now = DateTime.Now;
     double deltaTime = (now - _last).TotalMilliseconds;
     _last = now;

     //get Keyboard State
     var keys = _sdl.GetKeyboardState(null);
 
     //movement keys for left right
     bool left = keys[(int)KeyCode.A] == 1 ? true : false;
     bool right =  keys[(int)KeyCode.D] == 1 ? true : false;

     //edge detection for jumping
     bool jumpNow = keys[(int)KeyCode.Space] == 1 ? true : false;
     bool jump = jumpNow && !_wasJumpPressed;//

     _wasJumpPressed = jumpNow;

     //sends input and timig data to GameLogic
     _logic.Update(left,right,jump,deltaTime);

     return false;
   }

}