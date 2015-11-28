using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Directory
using System.IO;
// OpenFileDialog
using System.Windows.Forms;
public class csFileBrowse
{
    // เปิด browse file diaglog ของ windowse
    public string Browse_ChooseFile(string opt) 
    {
        //ให้ทุกครั้งที่เปิด Browse file ไปที่ drive C ก่อน
        string Path = @"C:\"; 
        string FullPath = ""; 
        // เช็คว่ามี drive C มั้ย
        if (System.IO.Directory.Exists(Path)) 
        { 
            // ถ้าส่งค่า option ว่าจะเปิด CFILE --> จะเห็นแต่ textfile
            if (opt == "CFILE") 
            { 
                OpenFileDialog fdlg = new OpenFileDialog(); 
                fdlg.Title = "Select Text Source File"; 
                fdlg.InitialDirectory = @"c:\"; 
                fdlg.Filter = "TEXT Source File|*.txt"; 
                fdlg.FilterIndex = 2; 
                fdlg.RestoreDirectory = true; 
                // ถ้ากดเลือกไฟล์แล้วจะดึงชื่อ path ของไฟล์มาใส่ในกล่องข้อความ
                if (fdlg.ShowDialog() == DialogResult.OK)
                {
                    string dirName = System.IO.Path.GetFullPath(fdlg.FileName);
                    FullPath = dirName;
                }
            }
            // ถ้า option ว่าจะเปิด CFLODER --> จะเห็นแต่โฟลเดอร์ไม่ให้เห็นไฟล์
            /* ---- ไม่ได้ใช้สร้างไว้ใช้ในวิชา PSP
            else if (opt == "CFLODER")
            {
                FolderBrowserDialog fdlg = new FolderBrowserDialog();
                DialogResult result = fdlg.ShowDialog();
                try
                {
                    // ถ้ากดเลือกไฟล์แล้วจะดึงชื่อ path ของไฟล์มาใส่ในกล่องข้อความ
                    string[] files = Directory.GetFiles(fdlg.SelectedPath, "*.txt", SearchOption.AllDirectories); // M
                    FullPath = fdlg.SelectedPath;
                    foreach (string file in files)
                    {
                        FullPath += "|" + System.IO.Path.GetFileName(file);
                    }                         
                }
                catch { }
            }
             * */
        }
        return FullPath;
    }
}