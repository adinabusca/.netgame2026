namespace TheAdventure.Models;

public static class SaveManager {
    private const string fileName = "wins.txt";

    //loades saved win count from disk
    public static int LoadWins(){
        if (!File.Exists(fileName)){
            return 0;
        }

        string text = File.ReadAllText(fileName);

      
        if (int.TryParse(text, out int value))//check if parsing succedes
            return value;
        return 0;
    }
    
    //saves new win count to disk
    //after game is over, save wins (+ 1 if player catches bird, otherwise the same wins as at loadig)
    public static void SaveWins(int wins){
        File.WriteAllText(fileName, wins.ToString());
    }
}