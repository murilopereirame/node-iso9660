using Bootsharp;
using DiscUtils.Iso9660;

namespace IsoReader;

public static partial class Reader
{
    public static void Main()
    {
        
    }

    [JSFunction]
    public static partial long StreamLength();
    
    [JSFunction]
    public static partial byte[] Read(int offset, int count);
    
    [JSFunction]
    public static partial void SetPosition(long position);

    [JSInvokable]
    public static byte[] ReadFileFromIso(string fileName)
    {
        var isoStream = new InterStream(Read, StreamLength, SetPosition);
        CDReader cd = new CDReader(isoStream, true);
        Stream fileStream = cd.OpenFile(fileName, FileMode.Open);
        return FileStreamToBytes(fileStream);
    }
    
    [JSInvokable]
    public static string[] ListFilesFromIso(string path)
    {
        var isoStream = new InterStream(Read, StreamLength, SetPosition);
        CDReader cd = new CDReader(isoStream, true);
        return cd.GetFiles(path);
    }
    
    [JSInvokable]
    public static string[] ListFilesTreeFromIso(string path)
    {
        var isoStream = new InterStream(Read, StreamLength, SetPosition);
        CDReader cd = new CDReader(isoStream, true);
        return cd.GetFileSystemEntries(path);
    }
    
    [JSInvokable]
    public static string[] ListDirectoriesFromIso(string path)
    {
        var isoStream = new InterStream(Read, StreamLength, SetPosition);
        CDReader cd = new CDReader(isoStream, true);
        return cd.GetDirectories(path);
    }

    private static byte[] FileStreamToBytes(Stream stream)
    {
        using(var memoryStream = new MemoryStream())
        {
            stream.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
