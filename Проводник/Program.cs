using System;
using System.IO;
using System.Diagnostics;
using System.ComponentModel.Design;
using Проводник;
using System.Reflection;

class Program
{ 
    static void Main()
    {

        while (true)
        {
            Console.Clear();

            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {

                Console.WriteLine($"        Диск: {drive.Name}  Общий размер: {drive.TotalSize / (1024 * 1024 * 1024)}  Доступное пространство: {drive.AvailableFreeSpace / (1024 * 1024 * 1024)} GB");
            }

            int selectedDisk = Arrow.Show(0,1,0);

            if (selectedDisk == -1)
            {
                Main();
            }
            
            if (selectedDisk == 1)
            {
                ShowPapkaD("D:\\");
            }
            else if (selectedDisk == 0)
            {
                ShowPapkaC("C:\\");
            }
        }
        



         static void ShowPapkaD(string s)
         {


            while (true)
            {
                Console.Clear();
                Console.WriteLine($"--------------------------------------------------------- Вы ноходитесь в {s}");

                
                string[] paths = Directory.GetDirectories(s);
                foreach (string path in paths)
                {
                    DirectoryInfo pathinfo = new DirectoryInfo(path);
                    Console.WriteLine($"         {path}                   {pathinfo.CreationTime}  {pathinfo.Extension}");
                }



                
                string[] files = Directory.GetFiles(s);
                foreach (string file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    Console.WriteLine($"         {file}                    {fileInfo.CreationTime}    {fileInfo.Extension}");
                }

                int pos = Arrow.Show(0, paths.Length + files.Length, -1);
                if (pos == -1)
                {
                    return;
                }
                if (pos < paths.Length)
                {
                    ShowPapkaD(paths[pos-1]);
                }
                else 
                {
                    Process.Start(new ProcessStartInfo { FileName = files[paths.Length], UseShellExecute = true });
                }


                
                
            }
         }

        void ShowPapkaC(string s)
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"--------------------------------------------------------- Вы ноходитесь в {s}");


                string[] paths = Directory.GetDirectories(s);
                foreach (string path in paths)
                {
                    DirectoryInfo pathinfo = new DirectoryInfo(path);
                    Console.WriteLine($"         {path}                   {pathinfo.CreationTime}  {pathinfo.Extension}");
                }




                string[] files = Directory.GetFiles(s);
                foreach (string file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    Console.WriteLine($"         {file}                    {fileInfo.CreationTime}    {fileInfo.Extension}");
                }

                int pos = Arrow.Show(0, paths.Length + files.Length, -1);
                if (pos == -1)
                {
                    return;
                }
                if (pos < paths.Length)
                {
                    ShowPapkaC(paths[pos - 1]);
                }
                else
                {
                    Process.Start(new ProcessStartInfo { FileName = files[paths.Length], UseShellExecute = true });
                }
            }
        }


    }


}
