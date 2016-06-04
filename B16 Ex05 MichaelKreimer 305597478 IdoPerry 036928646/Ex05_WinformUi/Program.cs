using System.Windows.Forms;

namespace Ex05_WinformUi
{
    public class Program
    {
        public static void Main()
        {
            FormGame game = new FormGame();
            if (game.DialogResult == DialogResult.OK)
            {
                game.ShowDialog();
            }
        }
    }
}
