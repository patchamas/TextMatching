using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class csBoyerMoore
{
    public class UnicodeSkipArray
    {
        private byte _patternLength;
        private byte[] _default;
        private byte[][] _skipTable;
        private const int BlockSize = 0x100;

        // เมื่อโยนค่าความยาวของข้อความต้องการ search มาให้ฟังก์ชั่นนี้
        public UnicodeSkipArray(int patternLength)
        {
            // จะให้ค่าเริ่มต้องของ byte pattern มีความงาวเท่ากับความยาวของข้อความต้องการ search
            _patternLength = (byte)patternLength;
            // จะให้ค่าเริ่มต้นของอเรย์ byte ที่ใช้เก็บ value มีค่าเป็น 0x100
            _default = new byte[BlockSize];
            // โยนค่าอเรย์ไบร์ให้ฟังก์ชั่น InitializeBlock
            InitializeBlock(_default);
            // กำหนดค่าให้ตารางหลัก โดยสร้าง อเรย์ไบร์สองมิติที่มี dimension เท่ากับ BlockSize และอีก dimension ไม่ได้กำหนด่า
            _skipTable = new byte[BlockSize][];
            // วนลูปให้ภายในตารางหลักเก็บ _default อีกที
            for (int i = 0; i < BlockSize; i++)
                _skipTable[i] = _default;
        }

        /// <summary>
        /// Sets/gets a value in the multi-stage tables.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public byte this[int index]
        {
            get
            {
                // Return value
                return _skipTable[index / BlockSize][index % BlockSize];
            }
            set
            {
                // Get array that contains value to set
                int i = (index / BlockSize);
                // Does it reference the default table?
                if (_skipTable[i] == _default)
                {
                    // Yes, value goes in a new table
                    _skipTable[i] = new byte[BlockSize];
                    InitializeBlock(_skipTable[i]);
                }
                // Set value
                _skipTable[i][index % BlockSize] = value;
            }
        }

        /// <summary>
        /// Initializes a block to hold the current "nomatch" value.
        /// </summary>
        /// <param name="block">Block to be initialized</param>
        private void InitializeBlock(byte[] block)
        {
            for (int i = 0; i < BlockSize; i++)
                block[i] = _patternLength;
        }
    }

    public class BoyerMoore
    {
        private string _pattern;
        private bool _ignoreCase;
        private UnicodeSkipArray _skipArray;

        // ค่าที่รีเทินเมื่อไม่พบข้อมูลที่ต้องการค้นหา
        public const int InvalidIndex = -1;

        // เมื่อเริ่ม new item BoyerMoore โปรแกรมจะสร้าง pattern จากคำที่เราต้องการค้นหา
        // เช่น csBoyerMoore.BoyerMoore BM = new csBoyerMoore.BoyerMoore(txtSearchValue.Text); 
        // pattern จะเป็นคำภายในกล่องข้อความ txtSearchValue
        public BoyerMoore(string pattern)
        {
            // จะทำการเรียกฟังก์ชั่น Initialize โดนโยนข้อความที่ต้องการ search พร้อมกับค่าบูลลิน false
            Initialize(pattern, false);
        }

        // เมื่อโยนข้อความที่ต้องการ search พร้อมกับค่าบูลลิน false จะสร้างและกำหนดค่าและข้อมูลต่างๆ
        public void Initialize(string pattern, bool ignoreCase)
        {
            // กำหนดค่า ข้อความที่เราต้องการ search ที่ส่งมาในตัวแปร pattern ให้ตัวแปร pattern ที่เป็น static มีค่าเดียวกันด้วย
            _pattern = pattern;
            // ส่งค่า false มาภายใน ignoreCase ให้ตัวแปร _ignoreCase ที่เป็น static มีค่าเดียวกันด้วย
            _ignoreCase = ignoreCase;

            // (Create multi-stage skip table) เรียก class UnicodeSkipArray 
            // โดยส่งความยาวของ string ของข้อความที่ต้องการ search ไปให้ รีเทินค่ากลับมาเป็น array 2 มิติ
            _skipArray = new UnicodeSkipArray(_pattern.Length);
            // ถ้ากำหนดให้ search แบบ non - case sensitive
            if (_ignoreCase)
            {
                // เก็บข้อความจาก pattern ที่เก็บข้อความที่ต้องการ search ไว้ภายในอเรย์ _skipArray 
                // โดยคอนเวิตให้เป็นทั้งตัวใหญ่และตัวเล็ก
                for (int i = 0; i < _pattern.Length - 1; i++)
                {
                    _skipArray[Char.ToLower(_pattern[i])] = (byte)(_pattern.Length - i - 1);
                    _skipArray[Char.ToUpper(_pattern[i])] = (byte)(_pattern.Length - i - 1);
                }
            }
            // ถ้ากำหนดให้ search แบบ case sensitive
            else
            {
                // เก็บข้อความจาก pattern ที่เก็บข้อความที่ต้องการ search ไว้ภายในอเรย์ _skipArray 
                // โดยไม่คอนเวิตให้เป็นทั้งตัวใหญ่และตัวเล็ก เก็บข้อความเดิมๆของมัน
                for (int i = 0; i < _pattern.Length - 1; i++)
                    _skipArray[_pattern[i]] = (byte)(_pattern.Length - i - 1);
            }
        }

        /// โยนค่าที่ต้องการหาเข้ามาให้ฟังก์ชั่นนี้
        public int Search(string text)
        {
            // ฟังก์ชั่นนี้จะไปเรียกฟังก์ชั่น search รับพารามิตเตอร์ 2 ตัวคือ string ที่เป็นข้อความที่ต้องการ search และ พารามิเตอร์ตำแหน่งของความที่จะให้เริ่ม search
            return Search(text, 0);
        }

        /// เมื่อโยนค่า string ข้อความต้องการ search กับ int ตำแหน่งข้อตัวที่ต้องการให้เริ่ม matching
        public int Search(string text, int startIndex)
        {
            // ให้ค่า i เท่ากับ ค่าที่เรากำหนดให้เป็นตำแหน่งตัวที่ต้องเริ่ม matching
            int i = startIndex;

            // วนลูปเพื่อหาจากข้อความต้องการ search
            while (i <= (text.Length - _pattern.Length))
            {              
                // เช็คตำแหน่งที่ข้อมูล matching กัน
                int j = _pattern.Length - 1;
                // ถ้าไม่สนใจ case sensitive ก็ลอง upper ให้เป็นตัวใหญ่เหมือนกันละเทียบกันไปเรื่อยๆ
                if (_ignoreCase)
                {
                    while (j >= 0 && Char.ToUpper(_pattern[j]) == Char.ToUpper(text[i + j]))
                        j--;
                }
                // ถ้าสนใจ case sensitive ก็ไม่ต้องลอง upper หรือ lower เอาข้อมูลเดิมๆมันเทียบ
                else
                {
                    while (j >= 0 && _pattern[j] == text[i + j])
                        j--;
                }

                if (j < 0)
                {
                    // ถ้าเจอข้อความที่ matching
                    return i;
                }

                // คำนวนการเปรียบเทียบรอบถัดจะไปเริ่มที่ตำแหน่งไหน
                i += Math.Max(_skipArray[text[i + j]] - _pattern.Length + 1 + j, 1);
            }
            // ถ้าไม่เจอก๊รีเทิน -1
            return InvalidIndex;
        }
    }
}
