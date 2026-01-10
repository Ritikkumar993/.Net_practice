
class FileInfoExample
{
    FileInfo file = new FileInfo("sample.txt");

    public void Create()
    {
        
        if(!file.Exists){
            using (StreamWriter writer = file.CreateText()){
                writer.WriteLine("Hello FileIIInfo ");

            }

        }
        Console.WriteLine("File Name: "+file.Name);
        Console.WriteLine("File Size: "+file.Length+"bytes");
        Console.WriteLine("Created on: "+file.CreationTime);
    }
}