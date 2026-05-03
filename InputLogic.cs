using Silk.NET.SDL;


namespace TheAdventure;

public class InputLogic {
   private readonly Sdl _sdl;
   private readonly GameLogic _logic;

   private DateTime _last = DateTime.Now;
   private bool _wasJumpPressed = false;

   public InputLogic(Sdl sdl, GameLogic logic){
    _sdl = sdl;
    _logic = logic;
   }

   public unsafe bool Process(){
     Event ev = new();

     while (_sdl.PollEvent(ref ev) != 0){
        if (ev.Type == (uint)EventType.Quit) {
            return true;
        }

     }

     var now = DateTime.Now;
     double deltaTime = (now - _last).TotalMilliseconds;
     _last = now;

     var keys = _sdl.GetKeyboardState(null);

     bool left = keys[(int)KeyCode.A] == 1 ? true : false;
     bool right =  keys[(int)KeyCode.D] == 1 ? true : false;

     bool jumpNow = keys[(int)KeyCode.Space] == 1 ? true : false;
     bool jump = jumpNow && !_wasJumpPressed;

     _wasJumpPressed = jumpNow;
     _logic.Update(left,right,jump,deltaTime);

     return false;
   }

}