namespace ICG2020.Instance
{
  public class ParkingGamePointsInstance
  {
    private static ParkingGamePointsInstance _instance;
    public static ParkingGamePointsInstance Instance
    {
      get
      {
        if (_instance == null) _instance = new ParkingGamePointsInstance();
        return _instance;
      }
    }
    private ParkingGamePointsInstance () {}

    float _points;
    public float Points { get { return _points; } }
    public float INITIAL_POINTS = 100;

    public void reset ()
    {
        _points = INITIAL_POINTS;
    }

    public void gainPoints (float points)
    {
        _points += points;
    }
    
    public void losePoints (float points)
    {
        _points -= points;
    }
  }
}