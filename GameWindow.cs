using Silk.NET.SDL;

namespace TheAdventure;

public class GameWindow{
    private readonly Sdl _sdl;
    private readonly IntPtr _window;

    public GameWindow(Sdl sdl){
        _sdl = sdl;

        unsafe {
            _window = (IntPtr)sdl.CreateWindow(
                "Hunting the Wren",
                Sdl.WindowposUndefined,
                Sdl.WindowposUndefined,
                800,
                450,
                (uint)WindowFlags.Resizable
            );
        }

        if (_window == IntPtr.Zero){
            throw new Exception("Creating window failed.");
        }
    }

    public unsafe IntPtr CreateRenderer(){
        return (IntPtr)_sdl.CreateRenderer((Window*)_window,-1,0);
    }

    public unsafe (int Width, int Height) Size {
        get {
            int w = 0, h = 0;
            _sdl.GetWindowSize((Window*)_window,ref w, ref h);
            return (w,h);
        }
    }
    
}
