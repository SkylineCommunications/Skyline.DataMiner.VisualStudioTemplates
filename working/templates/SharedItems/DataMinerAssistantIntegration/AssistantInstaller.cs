using System.IO;

using Skyline.AppInstaller;
using Skyline.DataMiner.Utils.SecureCoding.SecureIO;

/// <summary>
/// Installs the DataMiner Assistant integration files.
/// </summary>
internal static class AssistantInstaller
{
	private const string AssistantContextDirectory = @"C:\ProgramData\Skyline Communications\DataMiner Assistant\Synced Documents\Context\Custom";

	/// <summary>
	/// Copies the adhocs, scripts, skills, and agents Markdown files from the SetupContent folder into the
	/// DataMiner Assistant custom context folder, so the Assistant can discover them.
	/// Call this from the package's Install method, e.g. AssistantInstaller.InstallAssistantFiles(installer);
	/// </summary>
	/// <param name="installer">The installer used to locate the SetupContent directory and to log progress.</param>
	public static void InstallAssistantFiles(AppInstaller installer)
	{
		string setupContentDirectory = installer.GetSetupContentDirectory();
		if (setupContentDirectory == null)
		{
			return;
		}

		CopyFiles(installer, SecurePath.ConstructSecurePath(setupContentDirectory, "adhocs"), SecurePath.ConstructSecurePath(AssistantContextDirectory, "Adhoc"));
		CopyFiles(installer, SecurePath.ConstructSecurePath(setupContentDirectory, "scripts"), SecurePath.ConstructSecurePath(AssistantContextDirectory, "Scripts"));
		CopySubFolders(installer, SecurePath.ConstructSecurePath(setupContentDirectory, "skills"), SecurePath.ConstructSecurePath(AssistantContextDirectory, "Skills"));
		CopySubFolders(installer, SecurePath.ConstructSecurePath(setupContentDirectory, "agents"), SecurePath.ConstructSecurePath(AssistantContextDirectory, "Agents"));
	}

	private static void CopySubFolders(AppInstaller installer, string sourceDirectory, string targetDirectory)
	{
		if (!sourceDirectory.IsPathValid() || !Directory.Exists(sourceDirectory))
		{
			return;
		}

		foreach (string subDirectory in Directory.GetDirectories(sourceDirectory))
		{
			if (!subDirectory.IsPathValid())
			{
				continue;
			}

			CopyFiles(installer, subDirectory, SecurePath.ConstructSecurePath(targetDirectory, Path.GetFileName(subDirectory)));
		}
	}

	private static void CopyFiles(AppInstaller installer, string sourceDirectory, string targetDirectory)
	{
		if (!sourceDirectory.IsPathValid() || !targetDirectory.IsPathValid() || !Directory.Exists(sourceDirectory))
		{
			return;
		}

		Directory.CreateDirectory(targetDirectory);
		foreach (string file in Directory.GetFiles(sourceDirectory, "*.md"))
		{
			if (!file.IsPathValid())
			{
				continue;
			}

			string targetFile = SecurePath.ConstructSecurePath(targetDirectory, Path.GetFileName(file));
			File.Copy(file, targetFile, true);
			installer.Log($"[AssistantInstaller]: Copied {Path.GetFileName(file)} to {targetDirectory}");
		}
	}
}
