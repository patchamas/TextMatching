using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// ARRAY LIST
using System.Collections;
namespace TextMatching
{
    public partial class Form1 : Form
    {
        DataTable dtInput = new DataTable();
        DataTable dtResult = new DataTable();
        ArrayList arr_ReadLineStock = new ArrayList();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // ดึง path ไฟด์
            csFileBrowse fnBrowse = new csFileBrowse();
            txtPath.Text = fnBrowse.Browse_ChooseFile("CFILE");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // สร้าง column ชื่อ StockName ใน datatable -- > ถ้าใน datatable ยังไม่มี column อะไรเลย
            if (dtInput.Columns.Count == 0)
            { dtInput.Columns.Add("StockName", typeof(string)); }

            // อ่าน textfile และรีเทินค่ากลับมาใส่ในอเรย์ลิส
            arr_ReadLineStock = csReaderText.Compute(txtPath);

            // ถ้า browse ไฟล์แล้ว
            if (txtPath.Text != "")
            {
                // เพิ่ม row ใน datatable ไปเรื่อยๆจนสุดอเรย์ลิส
                foreach (string arr in arr_ReadLineStock)
                {
                    DataRow dr = dtInput.NewRow();
                    dr["StockName"] = arr;
                    dtInput.Rows.Add(dr);
                }
            }

            // แสดงข้อมูล datatable ที่ดึงค่าจาก textfile มาโชว์ใน datagridview
            gridInput.DataSource = dtInput.DefaultView;
            gridInput.Refresh();         
        }
        
        private void btnProcess_Click(object sender, EventArgs e)
        {
            // สร้าง coulumn ชื่อ StockName ใน datatable ที่เป็นฝั่ง result ถ้ายังไม่ได้สร้าง
            if (dtResult.Columns.Count == 0)
            { dtResult.Columns.Add("StockName", typeof(string)); }

            // เรียก class bayermore โยนค่าที่ต้องการ search เข้าไปใน class โปรแกรมจะรีเทินผลการค้นหาออกมาเป็นอเรย์ลิส
            csBoyerMoore.BoyerMoore BM = new csBoyerMoore.BoyerMoore(txtSearchValue.Text);            
            foreach (string arr in arr_ReadLineStock)
            {
                // ถ้าผลการค้นหามีค่ามากกว่า 0 แปลว่าเจอ
                if (BM.Search(arr) >= 0)
                {
                    // ให้เอาค่าที่ค้นหาได้เพิ่มใน row ของ datatable ฝั่ง result
                    DataRow dr = dtResult.NewRow();
                    dr["StockName"] = arr;
                    dtResult.Rows.Add(dr);
                }
            }

            // แสดงค่าที่หาได้ใน datagridview result
            gridFound.DataSource = dtResult.DefaultView;
            gridFound.Refresh();

            
        }
    }
}
