using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public int width = 51;   // 奇数推奨
    public int height = 51;  // 奇数推奨
    public GameObject wallPrefab;  // 壁プレハブ

    private int[,] maze;

    void Start()
    {
        GenerateMaze();
        DrawMaze();
    }

    void GenerateMaze()
    {
        maze = new int[width, height];

        // 1:壁で初期化
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                maze[x, y] = 1;
            }
        }

        // スタート地点
        Carve(1, 1);
    }

    void Carve(int x, int y)
    {
        int[] dirs = new int[] { 0, 1, 2, 3 }; // 上下左右
        Shuffle(dirs);

        foreach (int dir in dirs)
        {
            int dx = 0, dy = 0;

            switch (dir)
            {
                case 0: dx = 0; dy = -1; break; // 上
                case 1: dx = 1; dy = 0; break;  // 右
                case 2: dx = 0; dy = 1; break;  // 下
                case 3: dx = -1; dy = 0; break; // 左
            }

            int nx = x + dx * 2;
            int ny = y + dy * 2;

            if (nx > 0 && nx < width && ny > 0 && ny < height && maze[nx, ny] == 1)
            {
                maze[x + dx, y + dy] = 0;
                maze[nx, ny] = 0;
                Carve(nx, ny);
            }
        }
    }

    void Shuffle(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int j = Random.Range(i, array.Length);
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }

    void DrawMaze()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (maze[x, y] == 1)
                {
                    Vector3 pos = new Vector3(x, y, 0);
                    Instantiate(wallPrefab, pos, Quaternion.identity);
                }
            }
        }
    }
}
