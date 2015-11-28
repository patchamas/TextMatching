using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ARRAY LIST
using System.Collections;
// TextReader
using System.IO; 
public class csReaderText
{
    // โยน textbox ที่เก็บ path ของไฟล์
    public static ArrayList Compute(System.Windows.Forms.TextBox txtFullName)
    {
        // สร้างอเรย์ลิสมาเก็บข้อมูลที่่อ่านจาก textfile
        ArrayList arr_PipeLine = new ArrayList();

        try
        {
            // ใช้ text reader อ่านค่าจาก textfile ที่เข้ารหัส windowse 874 จะได้อ่านภาษาไทยได้
            TextReader file = new StreamReader(txtFullName.Text, Encoding.GetEncoding("windows-874"));
            string read = null;
            // ถ้าอ่านแล้วเจอข้อมูล
            while ((read = file.ReadLine()) != null)
            {
                // ลอกบรรทัดนั้นใส่อเรย์ลิส
                arr_PipeLine.Add(read);
            }
            // ปิดไฟล์
            file.Close();
        }
        catch
        {
            Console.WriteLine("พบข้อผิดพลาด: ไม่พบข้อมูลภายในไฟล์ข้อมูลที่คุณเลือก");
        }
        return arr_PipeLine;
    }
}
