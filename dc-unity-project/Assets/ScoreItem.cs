[System.Serializable]
public class ScoreItem
{
    public string name;
    public float time;

    public ScoreItem(string name, float time)
    {
        this.name = name;
        this.time = time;
    }
}
