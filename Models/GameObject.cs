namespace TheAdventure.Models;

//base class for all entities
public class GameObject {
   public int Id {get; private set;}//unique identifier for every object created 
   private static int _nextId = -1;//static counter shared across all instances in order to track the last assigned Id

    //initializes new GameObject and assigns unique Id
    public GameObject(){
      //uses Interlocked.Increment to ensure thread safety (prevents two objects to have same Id if created at the same time)
      Id = System.Threading.Interlocked.Increment(ref _nextId);
    }

   
}