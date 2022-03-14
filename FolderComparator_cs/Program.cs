using FolderComparator_cs.FoldersDiff;
Console.WriteLine("Code me daddy!");

const string FOLDERMAIN = "path";
const string FOLDERSECOND = "path";

const string OUTPUTPATH = "path";

StartComparator();

 
static void StartComparator()
{
    Console.WriteLine("Comparator Started...");

    var allFilesMain = GetAllSubFiles(FOLDERMAIN);
    var allFilesSecond = GetAllSubFiles(FOLDERSECOND);

    Console.WriteLine((allFilesMain.Length + allFilesSecond.Length).ToString() + " Files founds");

    var foldersDiff = new FoldersDiff() { FilesNumberDiff = Math.Abs(allFilesMain.Length - allFilesSecond.Length) };

    CompareTwoFolders(ref foldersDiff, allFilesMain, allFilesSecond);
    CompareTwoFolders(ref foldersDiff, allFilesSecond, allFilesMain);

    foldersDiff.SaveToFile(OUTPUTPATH);
}

static void CompareTwoFolders(ref FoldersDiff foldersDiff, string[] allFilesMain, string[] allFilesSecond)
{
    foreach (var file in allFilesMain)
    {
        if (!ElemExistsInArray(file, allFilesSecond))
        {
            foldersDiff.FilesDiff.Add(file);
        }
    }
}

static string[] GetAllSubFiles(string path)
{
    return Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
}

static bool ElemExistsInArray(string elem, string[] array)
{
    return Array.Exists(array, cell => cell == elem);
}