namespace checkers
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Settings FormSetting = new Settings();
            Application.Run(FormSetting);
            if (FormSetting.isCorrect == true)
            {
                AppForm checkersForm = new AppForm(FormSetting.isWhiteTurn, FormSetting.Player1Name, FormSetting.Player2Name,FormSetting.showMoves, FormSetting.isAiPlay);
                checkersForm.ShowDialog();
            }
        }
    }
}