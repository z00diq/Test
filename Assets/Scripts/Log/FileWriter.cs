using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FileWriter
{
    private string _folder;
    private string _filePath;
    private const string _dateFormat = "dd-MM-yyyy";
    private const string LogTimeFormat = "{0:dd/MM/yyyy HH:mm:ss:ffff} [{1}]: {2}\r";
    public FileWriter(string folder)
    {
        _folder = folder;
        ManagePath();
    }

    private void ManagePath()
    {
        _filePath = $"{_folder}/{DateTime.UtcNow.ToString(_dateFormat)}.log";
    }

    public void Write(LogMessage message)
    {
        var messageToWrite = string.Format(LogTimeFormat, message.Time, message.Type, message.Message);
        FileStream fileStream = File.Open(_filePath, FileMode.Append,FileAccess.Write,FileShare.Read );
        var bytes = Encoding.UTF8.GetBytes(messageToWrite);
        fileStream.Write(bytes,0,bytes.Length);

    }
}

