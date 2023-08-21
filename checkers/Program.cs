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
            HelloForm FormSetting = new HelloForm();
            Application.Run(FormSetting);
            if (FormSetting.isCorrect == true)
            {
                AppForm checkersForm = new AppForm(FormSetting.boardSize, FormSetting.firstStart, FormSetting.Player1Name, FormSetting.Player2Name);
                checkersForm.ShowDialog();
            }
        }
    }
}