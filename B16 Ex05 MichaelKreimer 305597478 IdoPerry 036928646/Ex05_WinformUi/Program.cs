using B16_Ex05;

namespace Ex05_WinformUi
{
    public class Program
    {
        public static void Main()
        {
            FormGame f = new FormGame(4, 4);
            f.ShowDialog();
            GameManager gameManager = new GameManager();
            gameManager.Start();
        }
    }
}
