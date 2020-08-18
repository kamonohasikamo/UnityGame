public class WorldOrMyScore
{
	public static int changeNum = 0;

	public static void addChangeNum()
	{
		changeNum++;
	}

	public static int WorldOrMyScoreNum
	{
		set
		{
			changeNum = value;
		}
		get
		{
			return changeNum;
		}
	}
}
