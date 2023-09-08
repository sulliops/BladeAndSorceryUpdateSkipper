using Microsoft.Win32;
using System.Diagnostics;
using System.Security.Policy;
using System.Text.RegularExpressions;
using static System.Windows.Forms.LinkLabel;

namespace Blade_and_Sorcery_Update_Skipper
{

    public partial class MainWindow : Form
    {

        public MainWindow()
        {

            InitializeComponent();

        }

        // Function that loads the main window and sets up environment
        private void MainWindow_Load(object sender, EventArgs e)
        {

            // Set ActiveControl to button to open SteamDB
            // Reference: https://stackoverflow.com/questions/6597196/how-do-i-put-focus-on-a-textbox-when-a-form-loads
            ActiveControl = LatestManifestIDOpenSteamDBButton;

            // Call helper method getSteamInstallationLocation to read Steam install location
            string steamLocation = getSteamInstallationLocation();

            // If return value stored in steamLocation is null, Steam is not installed
            if (steamLocation == null)
            {

                // Show error message
                // Reference: https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.messagebox.show?view=windowsdesktop-7.0#system-windows-forms-messagebox-show(system-windows-forms-iwin32window-system-string-system-string-system-windows-forms-messageboxbuttons-system-windows-forms-messageboxicon)
                MessageBox.Show(this,
                                "A valid Steam installation was not detected. Steam must be installed through the standard Windows installation method in order to use this tool.",
                                "ERROR: Steam not installed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                // Exit application
                // Reference: https://stackoverflow.com/questions/17222156/end-program-after-messagebox-is-closed
                Application.Exit();

            }

            // Call helper method getBladeAndSorceryInstallationLocation(), passing steamLocation, to read 
            // Blade and Sorcery install location
            string bladeAndSorceryLocation = getBladeAndSorceryInstallationLocation(steamLocation);

            // If return value stored in bladeAndSorceryLocation is null, Blade and Sorcery is not installed
            if (bladeAndSorceryLocation == null)
            {

                // Show warning message
                // Reference: https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.messagebox.show?view=windowsdesktop-7.0#system-windows-forms-messagebox-show(system-windows-forms-iwin32window-system-string-system-string-system-windows-forms-messageboxbuttons-system-windows-forms-messageboxicon)
                MessageBox.Show(this,
                                "A valid Steam installation of Blade and Sorcery was not detected automatically. You may continue using this tool at your own risk, but the application may not run correctly.",
                                "WARNING: Blade and Sorcery not detected",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                // Otherwise, set the GameLocationTextBox text to the stored location
            }
            else
            {

                GameLocationTextBox.Text = bladeAndSorceryLocation;

            }

            // Set the BackupLocationTextBox text to default location of C:\{currentUser}\Documents\Blade and Sorcery Update Skipper\
            // Reference: https://stackoverflow.com/questions/30872229/how-can-i-get-the-location-of-a-users-documents-directory
            BackupLocationTextBox.Text = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        }

        // Function that gets and returns the Steam installation location
        // Reference: https://stackoverflow.com/questions/34090258/find-steam-games-folder
        private string getSteamInstallationLocation()
        {

            // Set base registry search values
            string registryBase = "HKEY_LOCAL_MACHINE\\SOFTWARE\\";

            // Get location of Steam installation
            // Reference: https://stackoverflow.com/questions/9092160/check-if-a-folder-exist-in-a-directory-and-create-them-using-c-sharp
            // Reference: https://learn.microsoft.com/en-us/dotnet/api/microsoft.win32.registry.getvalue?view=net-7.0
            // If C:\Program Files (x86) exists, host machine is 64-bit
            if (System.IO.Directory.Exists(@"C:\Program Files (x86)"))
            {

                // Read and return registry value at HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Valve\Steam\InstallPath
                return (string)Microsoft.Win32.Registry.GetValue(registryBase + "Wow6432Node\\Valve\\Steam", "InstallPath", (string)null);

                // Else, host machine is 32-bit
            }
            else
            {

                // Read and return registry value at HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Steam\InstallPath
                return (string)Microsoft.Win32.Registry.GetValue(registryBase + "Valve\\Steam", "InstallPath", (string)null);

            }

        }

        // Function that gets and returns the Blade and Sorcery installation location
        private string getBladeAndSorceryInstallationLocation(string steamLocation)
        {

            // Count the number of opening and closing brackets to make sure libraryfolders.vdf is valid
            // Reference: https://www.codeproject.com/Questions/750004/How-to-count-the-occurrences-of-a-particular-word
            string entireFileText = File.ReadAllText(steamLocation + "\\steamapps\\libraryfolders.vdf");
            int numOpeningBrackets = Regex.Matches(entireFileText, @"{").Count;
            int numClosingBrackets = Regex.Matches(entireFileText, @"}").Count;

            // If number of opening and closing brackets are not equal, exit application (prevents infinite loop)
            if (numOpeningBrackets != numClosingBrackets)
            {

                // Show error message
                // Reference: https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.messagebox.show?view=windowsdesktop-7.0#system-windows-forms-messagebox-show(system-windows-forms-iwin32window-system-string-system-string-system-windows-forms-messageboxbuttons-system-windows-forms-messageboxicon)
                MessageBox.Show(this,
                                "File at \"" + steamLocation + "\\steamapps\\libraryfolders.vdf\" is malformed. Please verify that Steam was installed correctly.",
                                "ERROR: Malformed library file",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                // Exit application
                // Reference: https://stackoverflow.com/questions/17222156/end-program-after-messagebox-is-closed
                Application.Exit();

            }

            // Open libraryfolders.vdf file within Steam installation directory and parse
            // Reference: https://stackoverflow.com/questions/3709104/how-do-you-read-a-file-which-is-in-use
            using (FileStream libraryFolders = File.Open(steamLocation + "\\steamapps\\libraryfolders.vdf", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {

                using (StreamReader reader = new StreamReader(libraryFolders))
                {

                    // Variable to store the current path where the Blade and Sorcery app 
                    // ID might be found
                    string currentPath = null;
                    // Variable to store whether Blade and Sorcery's installation location 
                    // has been found
                    bool found = false;

                    // Read through file until EOF
                    while (!reader.EndOfStream)
                    {

                        // Store the current line being read
                        string currentLine = reader.ReadLine();

                        // If the current line in the file is the path
                        if (currentLine.Trim().Contains("\"path\""))
                        {

                            // Extract current library folder path
                            // Reference: https://stackoverflow.com/questions/6219454/efficient-way-to-remove-all-whitespace-from-string
                            // Reference: https://www.c-sharpcorner.com/blogs/remove-last-character-from-string-in-c-sharp1
                            currentPath = Regex.Replace(currentLine.Trim(), @"\s+", " ").Substring(7);
                            currentPath = Regex.Replace(currentPath, @"\\+", "\\");
                            currentPath = Regex.Replace(currentPath, "\"", "");

                        }

                        // If the current line in the file is the beginning of the apps array
                        if (currentLine.Trim().Contains("\"apps\""))
                        {

                            // Loop forever (loop will be broken by closing bracket)
                            while (true)
                            {

                                // Read the next line in the file
                                currentLine = reader.ReadLine();

                                // If the current line is a closing bracket, we've reached the end of the apps array
                                if (currentLine.Trim() == "}")
                                {

                                    break;

                                }

                                // If the current line is not an opening bracket (closing brackets handled already), check 
                                // for the correct app ID
                                if (currentLine.Trim() != "{")
                                {

                                    // If the current line contains the correct app ID, we've found the installation 
                                    // location
                                    if (currentLine.Trim().Contains("\"629730\""))
                                    {

                                        found = true;
                                        break;

                                    }

                                }

                            }

                        }

                        // If the correct app ID has been found, break the reader loop early
                        if (found)
                        {

                            break;

                        }

                    }

                    // If the correct app ID has been found, return the path to the app's steamapps location
                    if (found)
                    {

                        return currentPath + "\\steamapps\\common\\Blade & Sorcery";

                    }
                    else
                    {

                        return (string)null;

                    }

                }

            }

        }

        // Function that opens project repository URL on LinkLabel click
        private void DownloadLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            // Store URL
            string URL = "https://github.com/sulliops/BladeAndSorceryUpdateSkipper";

            // Open URL in browser
            // Reference: https://csharpforums.net/threads/net6-open-hyperlink-start-browser-with-url.7735/#post-28218
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo() { FileName = URL, UseShellExecute = true });

        }

        // Function that opens a FolderBrowserDialog and allows the user to manually select a game installation location
        private void GameLocationBrowseButton_Click(object sender, EventArgs e)
        {

            // Create a new FolderBrowserDialog and set the text value of GameLocationTextBox to the dialog result
            // Reference: https://stackoverflow.com/questions/11624298/how-do-i-use-openfiledialog-to-select-a-folder
            using (FolderBrowserDialog browser = new FolderBrowserDialog())
            {

                DialogResult result = browser.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(browser.SelectedPath))
                {

                    GameLocationTextBox.Text = browser.SelectedPath;

                }

            }

        }

        // Function that opens the SteamDB page for Blade and Sorcery
        private void LatestManifestIDOpenSteamDBButton_Click(object sender, EventArgs e)
        {

            // Store URL
            string URL = "https://steamdb.info/app/629730/depots/?branch=public#depots";

            // Open URL in browser
            // Reference: https://csharpforums.net/threads/net6-open-hyperlink-start-browser-with-url.7735/#post-28218
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo() { FileName = URL, UseShellExecute = true });

        }

        // Function that opens a FolderBrowserDialog and allows the user to manually select an appmanifest backup location
        private void BackupLocationBrowseButton_Click(object sender, EventArgs e)
        {

            // Create a new FolderBrowserDialog and set the text value of GameLocationTextBox to the dialog result
            // Reference: https://stackoverflow.com/questions/11624298/how-do-i-use-openfiledialog-to-select-a-folder
            using (FolderBrowserDialog browser = new FolderBrowserDialog())
            {

                DialogResult result = browser.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(browser.SelectedPath))
                {

                    BackupLocationTextBox.Text = browser.SelectedPath;

                }

            }

        }

        // Function that checks runtime conditions and applies changes to appmanifest
        private void ApplyChangesButton_Click(object sender, EventArgs e)
        {

            // Make sure that a Blade and Sorcery installation location has been provided
            if (string.IsNullOrWhiteSpace(GameLocationTextBox.Text))
            {

                // Show error message
                // Reference: https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.messagebox.show?view=windowsdesktop-7.0#system-windows-forms-messagebox-show(system-windows-forms-iwin32window-system-string-system-string-system-windows-forms-messageboxbuttons-system-windows-forms-messageboxicon)
                MessageBox.Show(this,
                                "A Blade and Sorcery installation location was not provided. Please select the correct installation location and try again.",
                                "ERROR: Missing installation location",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                // Return function early
                return;

            }

            // Store the location of the parent steamapps folder path
            string steamAppsParentPath = GameLocationTextBox.Text.Trim();
            // If the path still contains "\common\Blade & Sorcery" at the end, remove it
            // Reference: https://stackoverflow.com/questions/4101539/c-sharp-removing-substring-from-end-of-string
            if (steamAppsParentPath.EndsWith("\\common\\Blade & Sorcery"))
            {

                steamAppsParentPath = steamAppsParentPath.Remove(steamAppsParentPath.Length - ("\\common\\Blade & Sorcery").Length);

            }

            // Store the full path to the app manifest file
            string appManifestPath = steamAppsParentPath + "\\appmanifest_629730.acf";

            // Make sure that a valid Blade and Sorcery app manifest file exists, show error if not
            // Reference: https://learn.microsoft.com/en-us/dotnet/api/system.io.file.exists?view=net-7.0
            if (!System.IO.File.Exists(appManifestPath))
            {

                // Show error message
                // Reference: https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.messagebox.show?view=windowsdesktop-7.0#system-windows-forms-messagebox-show(system-windows-forms-iwin32window-system-string-system-string-system-windows-forms-messageboxbuttons-system-windows-forms-messageboxicon)
                MessageBox.Show(this,
                                "The appmanifest file at \"" + appManifestPath + "\" does not exist. Please select the correct installation location and try again.",
                                "ERROR: Missing appmanifest file",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                // Return function early
                return;

            }

            // Make sure that a manifest ID has been provided
            if (string.IsNullOrWhiteSpace(LatestManifestIDTextBox.Text))
            {

                // Show error message
                // Reference: https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.messagebox.show?view=windowsdesktop-7.0#system-windows-forms-messagebox-show(system-windows-forms-iwin32window-system-string-system-string-system-windows-forms-messageboxbuttons-system-windows-forms-messageboxicon)
                MessageBox.Show(this,
                                "A manifest ID was not provided. Please copy/paste the latest manifest ID from SteamDB and try again.",
                                "ERROR: Missing manifest ID",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                // Return function early
                return;

            }

            // Create a variable to store the converted manifest ID
            long manifestID;
            // Try to convert the manifest ID from a string to an integer
            // Reference: https://stackoverflow.com/questions/1019793/how-can-i-convert-string-to-int
            // Reference: https://learn.microsoft.com/en-us/dotnet/api/system.int64.parse?view=net-7.0
            try
            {

                manifestID = Int64.Parse(LatestManifestIDTextBox.Text.Trim());

                // If conversion fails
            }
            catch
            {

                // Show error message
                // Reference: https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.messagebox.show?view=windowsdesktop-7.0#system-windows-forms-messagebox-show(system-windows-forms-iwin32window-system-string-system-string-system-windows-forms-messageboxbuttons-system-windows-forms-messageboxicon)
                MessageBox.Show(this,
                                "The manifest ID provided contains non-integer characters. Please copy/paste the latest manifest ID from SteamDB and try again.",
                                "ERROR: Malformed manifest ID",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                // Return function early
                return;

            }

            // Make sure a valid manifest ID was provided, if not show error
            // Reference: https://stackoverflow.com/questions/10845820/check-the-length-of-integer-variable
            if (!(manifestID.ToString().Length >= 16 && manifestID.ToString().Length <= 19))
            {

                // Show error message
                // Reference: https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.messagebox.show?view=windowsdesktop-7.0#system-windows-forms-messagebox-show(system-windows-forms-iwin32window-system-string-system-string-system-windows-forms-messageboxbuttons-system-windows-forms-messageboxicon)
                MessageBox.Show(this,
                                "The manifest ID provided is too short. Please copy/paste the latest manifest ID from SteamDB and try again.",
                                "ERROR: Malformed manifest ID",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                // Return function early
                return;

            }

            // Make sure that an appmanifest backup location was provided
            if (string.IsNullOrWhiteSpace(BackupLocationTextBox.Text))
            {

                // Show error message
                // Reference: https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.messagebox.show?view=windowsdesktop-7.0#system-windows-forms-messagebox-show(system-windows-forms-iwin32window-system-string-system-string-system-windows-forms-messageboxbuttons-system-windows-forms-messageboxicon)
                MessageBox.Show(this,
                                "An appmanifest backup location was not provided. Please select a backup location and try again.",
                                "ERROR: Missing backup location",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                // Return function early
                return;

            }

            // Store the appmanifest backup location
            string backupLocationPath = BackupLocationTextBox.Text.Trim() + "\\Blade and Sorcery Update Skipper";

            // Determine if a sub-folder for appmanifest backups already exists, and create one if not
            // Reference: https://stackoverflow.com/questions/9065598/if-a-folder-does-not-exist-create-it
            System.IO.Directory.CreateDirectory(backupLocationPath);

            // Copy the existing appmanifest to the backup location, appending a timestamp to the file name
            // Reference: https://learn.microsoft.com/en-us/dotnet/api/system.io.file.copy?view=net-7.0
            // Reference: https://stackoverflow.com/questions/17632584/how-to-get-the-unix-timestamp-in-c-sharp
            File.Copy(appManifestPath, backupLocationPath + "\\appmanifest_629730_" + ((uint)DateTimeOffset.Now.ToUnixTimeSeconds()).ToString() + ".acf");

            // Show warning message before continuing and store result of click
            // Reference: https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.messagebox.show?view=windowsdesktop-7.0#system-windows-forms-messagebox-show(system-windows-forms-iwin32window-system-string-system-string-system-windows-forms-messageboxbuttons-system-windows-forms-messageboxicon)
            DialogResult proceedResult = MessageBox.Show(this,
                                                  "Using this tool may break your Blade and Sorcery installation, your Steam installation, or worse. The developer of this tool is not responsible for damages caused by incorrect parameters. Click \"OK\" to proceed, or \"Cancel\" to abort the operation.",
                                                  "WARNING: Confirm action",
                                                  MessageBoxButtons.OKCancel,
                                                  MessageBoxIcon.Warning);

            // If result of dialog box button click is "Cancel", return early
            // Reference: https://www.codeproject.com/Questions/68682/How-to-know-the-user-Click-OK-on-MessageBox
            if (proceedResult == DialogResult.Cancel) {

                return;

            }

            // Check if Steam is currently running
            // Reference: https://stackoverflow.com/questions/18015193/how-to-check-if-application-is-running
            if (System.Diagnostics.Process.GetProcessesByName("steam").Length > 0)
            {

                // Show warning message and store result of click
                // Reference: https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.messagebox.show?view=windowsdesktop-7.0#system-windows-forms-messagebox-show(system-windows-forms-iwin32window-system-string-system-string-system-windows-forms-messageboxbuttons-system-windows-forms-messageboxicon)
                DialogResult steamKillResult = MessageBox.Show(this,
                                                      "Steam appears to be running, and this tool cannot proceed until Steam is exited. Click \"OK\" to attempt to exit Steam, or click \"Cancel\" to abort the operation.",
                                                      "WARNING: Steam still running",
                                                      MessageBoxButtons.OKCancel,
                                                      MessageBoxIcon.Warning);

                // If result of dialog box button click is "OK"
                // Reference: https://www.codeproject.com/Questions/68682/How-to-know-the-user-Click-OK-on-MessageBox
                if (steamKillResult == DialogResult.OK)
                {

                    // Kill Steam process
                    // Reference: https://stackoverflow.com/questions/3345363/kill-some-processes-by-exe-file-name
                    foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcessesByName("steam"))
                    {

                        process.Kill();

                    }

                }

            }

            // Count the number of opening and closing brackets to make sure appmanifest is valid
            // Reference: https://www.codeproject.com/Questions/750004/How-to-count-the-occurrences-of-a-particular-word
            string entireFileText = File.ReadAllText(appManifestPath);
            int numOpeningBrackets = Regex.Matches(entireFileText, @"{").Count;
            int numClosingBrackets = Regex.Matches(entireFileText, @"}").Count;

            // If number of opening and closing brackets are not equal
            if (numOpeningBrackets != numClosingBrackets)
            {

                // Show error message
                // Reference: https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.messagebox.show?view=windowsdesktop-7.0#system-windows-forms-messagebox-show(system-windows-forms-iwin32window-system-string-system-string-system-windows-forms-messageboxbuttons-system-windows-forms-messageboxicon)
                MessageBox.Show(this,
                                "File at \"" + appManifestPath + "\" is malformed. Please verify the game integrity through Steam, or uninstall and reinstall Blade and Sorcery and try again.",
                                "ERROR: Malformed appmanifest file",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                // Return function early
                return;

            }

            // Replace all instances of the Windows-style new line sequence "\r\n" with the Unix-style '\n' character
            // Reference: https://learn.microsoft.com/en-us/dotnet/api/system.string.replacelineendings?view=net-7.0
            entireFileText = entireFileText.ReplaceLineEndings("\n");

            // Split existing file contents by new line
            // Reference: https://www.techiedelight.com/split-string-on-newlines-csharp/
            string[] lines = Regex.Split(entireFileText, "\n");

            // Loop through each line to be written
            for (int line = 0; line < lines.Length; line++)
            {

                // If the line contains the StateFlags entry, replace it with a new entry
                if (lines[line].Contains("\"StateFlags\"")) {

                    // Extra spaces here to match existing file structure
                    lines[line] = "    \"StateFlags\"        \"4\"";

                }

                // If the line contains the LastUpdated entry, replace it with a new entry
                if (lines[line].Contains("\"LastUpdated\"")) {

                    // Extra spaces here to match existing file structure
                    // Reference: https://stackoverflow.com/questions/17632584/how-to-get-the-unix-timestamp-in-c-sharp
                    lines[line] = "    \"LastUpdated\"        \"" + ((uint)DateTimeOffset.Now.ToUnixTimeSeconds()).ToString() + "\"";

                }

                // If the line contains the AutoUpdateBehavior entry, replace it with a new entry
                if (lines[line].Contains("\"AutoUpdateBehavior\"")) {

                    // Extra spaces here to match existing file structure
                    lines[line] = "    \"AutoUpdateBehavior\"        \"1\"";

                }

                // If the line contains the ScheduledAutoUpdate entry, replace it with a new entry
                if (lines[line].Contains("\"ScheduledAutoUpdate\"")) {

                    // Extra spaces here to match existing file structure
                    lines[line] = "    \"ScheduledAutoUpdate\"        \"0\"";

                }

                // If the line contains the manifest entry, replace it with a new entry
                if (lines[line].Contains("\"manifest\""))
                {

                    // Extra spaces here to match existing file structure
                    lines[line] = "            \"manifest\"      \"" + manifestID.ToString() + "\"";

                }

            }

            // Write lines array to appmanifest file
            // Reference: https://stackoverflow.com/questions/7569904/easiest-way-to-read-from-and-write-to-files
            File.WriteAllLines(appManifestPath, lines);

            // Show success message
            // Reference: https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.messagebox.show?view=windowsdesktop-7.0#system-windows-forms-messagebox-show(system-windows-forms-iwin32window-system-string-system-string-system-windows-forms-messageboxbuttons-system-windows-forms-messageboxicon)
            MessageBox.Show(this,
                            "The changes were applied successfully.",
                            "SUCCESS: Operation completed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            // Exit application
            // Reference: https://stackoverflow.com/questions/17222156/end-program-after-messagebox-is-closed
            Application.Exit();

        }

    }

}