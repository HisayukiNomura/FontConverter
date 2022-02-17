using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;




namespace FontConverter
{

    public partial class Form1 : Form
    {
        FontZenN zenFont; 
        Font fntSelected;       // ユーザー選択フォント
        Font fntActual;         // 実際のフォント
        String strFilename;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            DialogResult dr = fontDialog1.ShowDialog(this);
            if (dr == DialogResult.OK) {
                fntSelected = fontDialog1.Font;
                lblFontName.Text = fontDialog1.Font.Name;
                chkBold.Checked = fontDialog1.Font.Bold;
                chkItalic.Checked = fontDialog1.Font.Bold;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            zenFont = new FontZenN(strFilename, chkHankaku.Checked);
        }

        private Bitmap ResizeBitmap(Bitmap original, int width, int height, System.Drawing.Drawing2D.InterpolationMode interpolationMode)
        {
            Bitmap bmpResize;
            Bitmap bmpResizeColor;
            Graphics graphics = null;

            try {
                System.Drawing.Imaging.PixelFormat pf = original.PixelFormat;

                if (original.PixelFormat == System.Drawing.Imaging.PixelFormat.Format8bppIndexed) {
                    // モノクロの時は仮に24bitとする
                    pf = System.Drawing.Imaging.PixelFormat.Format24bppRgb;
                }

                bmpResizeColor = new Bitmap(width, height, pf);
                var dstRect = new RectangleF(0, 0, width, height);
                var srcRect = new RectangleF(-0.5f, -0.5f, original.Width, original.Height);
                graphics = Graphics.FromImage(bmpResizeColor);
                graphics.Clear(Color.Transparent);
                graphics.InterpolationMode = interpolationMode;
                graphics.DrawImage(original, dstRect, srcRect, GraphicsUnit.Pixel);

            } finally {
                if (graphics != null) {
                    graphics.Dispose();
                }
            }

            if (original.PixelFormat == System.Drawing.Imaging.PixelFormat.Format8bppIndexed) {
                // モノクロ画像のとき、24bit→8bitへ変換

                // モノクロBitmapを確保
                bmpResize = new Bitmap(
                    bmpResizeColor.Width,
                    bmpResizeColor.Height,
                    System.Drawing.Imaging.PixelFormat.Format8bppIndexed
                    );

                var pal = bmpResize.Palette;
                for (int i = 0; i < bmpResize.Palette.Entries.Length; i++) {
                    pal.Entries[i] = original.Palette.Entries[i];
                }
                bmpResize.Palette = pal;

                // カラー画像のポインタへアクセス
                var bmpDataColor = bmpResizeColor.LockBits(
                        new Rectangle(0, 0, bmpResizeColor.Width, bmpResizeColor.Height),
                        System.Drawing.Imaging.ImageLockMode.ReadWrite,
                        bmpResizeColor.PixelFormat
                        );

                // モノクロ画像のポインタへアクセス
                var bmpDataMono = bmpResize.LockBits(
                        new Rectangle(0, 0, bmpResize.Width, bmpResize.Height),
                        System.Drawing.Imaging.ImageLockMode.ReadWrite,
                        bmpResize.PixelFormat
                        );

                int colorStride = bmpDataColor.Stride;
                int monoStride = bmpDataMono.Stride;

                unsafe {
                    var pColor = (byte*)bmpDataColor.Scan0;
                    var pMono = (byte*)bmpDataMono.Scan0;
                    for (int y = 0; y < bmpDataColor.Height; y++) {
                        for (int x = 0; x < bmpDataColor.Width; x++) {
                            // R,G,B同じ値のため、Bの値を代表してモノクロデータへ代入
                            pMono[x + y * monoStride] = pColor[x * 3 + y * colorStride];
                        }
                    }
                }

                bmpResize.UnlockBits(bmpDataMono);
                bmpResizeColor.UnlockBits(bmpDataColor);

                //　解放
                bmpResizeColor.Dispose();
            } else {
                // カラー画像のとき
                bmpResize = bmpResizeColor;
            }

            return bmpResize;
        }
        bool Convert()
        {
            zenFont = new FontZenN(strFilename, chkHankaku.Checked); // ファイルを読み込む
            if (zenFont.isHankaku == false) {
                if (zenFont.bBlockCount == 0 || zenFont.bufFont.Count == 0) {
                    MessageBox.Show(this, "FontX2の形式が不正です。\r\n半角フォントを指定している場合、半角のチェックボックスを\r\nオンにしてください。", "エラー");
                    return false;
                }
            } else {
                

            }
            if (fntSelected == null) {
                MessageBox.Show(this, "フォントが選択されていません。\r\nフォントの選択ボタンを押して、使用したいフォントを選択してください。", "エラー");
                return false;
            }

            Encoding srcEncoding = Encoding.GetEncoding("shift_jis");
            Encoding dstEncoding = Encoding.UTF8;

            int iMargine = (int)spinMargine.Value;

            // まず、お勧めの大きさを調べる。
            double bestSize = 20.0;
            while (true) {
                Bitmap bmpBuf = new Bitmap(100, 100);
                Graphics g = Graphics.FromImage(bmpBuf);
                FontStyle style = 0;
                if (chkBold.Checked) style |= FontStyle.Bold;
                if (chkItalic.Checked) style |= FontStyle.Italic;


                Font fontwk = new Font(fntSelected.FontFamily.Name, (float)bestSize, style);
                StringFormat sf = new StringFormat();
                SizeF stringSize;
                if (zenFont.isHankaku) {
                    stringSize = g.MeasureString("A", fontwk, 1000, StringFormat.GenericTypographic);
                } else {
                    stringSize = g.MeasureString("鬱", fontwk, 1000, StringFormat.GenericTypographic);
                }
                if (stringSize.Width <= zenFont.bWidth - iMargine && stringSize.Height <= zenFont.bHeight - iMargine) {
                    fntActual = new Font(fntSelected.FontFamily.Name, (float)bestSize, style);
                    break;
                }
                bestSize = bestSize - 0.1;
            }

            int count = 0;
            Dictionary<ushort, byte[]> updateFont = new Dictionary<ushort, byte[]>();

            int iXOffset = (int)spinXOffset.Value;
            int iYOffset = (int)spinYOffset.Value;

            foreach (KeyValuePair<ushort, byte[]> buf in zenFont.bufFont) {
                pictActual.Width = zenFont.bWidth + 2;
                pictActual.Height = zenFont.bHeight + 2;


                Bitmap bmpBuf = new Bitmap(zenFont.bWidth, zenFont.bHeight);
                Graphics g = Graphics.FromImage(bmpBuf);
                String strText;
                if (zenFont.isHankaku) {
                    byte[] ansi = new byte[1];
                    ansi[0] = (byte)buf.Key;
                    strText = new String((char)buf.Key, 1);
                } else {
                    byte[] sJis = BitConverter.GetBytes(buf.Key);
                    byte wk = sJis[0];
                    sJis[0] = sJis[1];
                    sJis[1] = wk;
                    strText = srcEncoding.GetString(sJis);
                }
                //strText = "A";
                StringFormat sf = new StringFormat();
                SizeF stringSize = g.MeasureString(strText, fntActual, 1000, sf);

                g.DrawString(strText, fntActual, Brushes.Black, iXOffset, iYOffset);
                g.Dispose();
                pictActual.Image = bmpBuf;
                pictActual.Update();

                Bitmap bigOne = ResizeBitmap(bmpBuf, pictZoomed.Width, pictZoomed.Height, System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor);
                pictZoomed.Image = bigOne;
                pictZoomed.Update();


                // フォントデータを更新する

                BitmapData bmpData = bmpBuf.LockBits(new Rectangle(0, 0, zenFont.bWidth, zenFont.bHeight), ImageLockMode.ReadOnly, bmpBuf.PixelFormat);
                IntPtr ptr = bmpData.Scan0;
                byte[] pixels = new byte[bmpData.Stride * bmpBuf.Height];
                System.Runtime.InteropServices.Marshal.Copy(ptr, pixels, 0, pixels.Length);

                int byteCnt = buf.Value.Length;
                byte[] NewData = new byte[byteCnt];
                int modShift = (8 - (zenFont.bWidth & 0x7))&0x7;
                int xBytes = 0;
                for (int y = 0; y < zenFont.bHeight; y++) {
                    for (int x = 0; x < zenFont.bWidth; x++) {
                        int pos = y * bmpData.Stride + x * 4;
                        byte posOR = (byte)(pixels[pos] | pixels[pos + 1] | pixels[pos + 2] | pixels[pos + 3]);
                        NewData[xBytes] = (byte)(NewData[xBytes] << 1);

                        NewData[xBytes] = (byte)(NewData[xBytes] | ((posOR != 0) ? 1 : 0));
                        Console.Write((posOR != 0) ? "■" : "・");
                        if (x % 8 == 7) {
                            xBytes++;
                        }
                    }
                    NewData[xBytes] = (byte)(NewData[xBytes] << modShift);

                    xBytes++;
                    Console.WriteLine("");
                }


                count++;
                bmpBuf.UnlockBits(bmpData);
                updateFont[buf.Key] = NewData;
                lblConvertCount.Text = count.ToString();

            }
            if (zenFont.isHankaku) {
                zenFont.bufFont = updateFont;
            } else {

                foreach (KeyValuePair<ushort, byte[]> buf in updateFont) {
                    bool isSkip = true;
                    if ((buf.Key >=0x8140 && buf.Key <= 0x829e) || 
                        (buf.Key >=0x838f && buf.Key <= 0x84bf) ||
                        (buf.Key >= 0x8740 && buf.Key <= 0x079c)) {
                        if (chkAlpha.Checked) {
                            isSkip = false;
                        }
                    } else if (buf.Key >= 0x829f && buf.Key <=0x8396) {
                        if (chkKana.Checked) {
                            isSkip = false;
                        }
                    } else if (buf.Key >= 0x8890 && buf.Key <= 0xfc4c) {
                        if (chkKanji.Checked) {
                            isSkip = false;
                        }
                    }

                    if (isSkip == false) {
                        zenFont.bufFont[buf.Key] = buf.Value;
                    }
                }
            }
                    return true;


        }
        private void button2_Click(object sender, EventArgs e)
        {
            bool ret = Convert();
            if (ret == false) return;
            // Path.GetDirectoryName(strFilename) + "\\";
            string strNewFilename = Path.GetDirectoryName(strFilename) + "\\"+Path.GetFileNameWithoutExtension(strFilename) + "_UPDATE" + Path.GetExtension(strFilename);
            zenFont.Write(strNewFilename);
            MessageBox.Show(this, "新しいフォントを\r\n" + strNewFilename + "\r\nに保存しました");
        }

        private void pictActual_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog(this);
            if (dr == DialogResult.OK) {
                strFilename = openFileDialog1.FileName;
                textBox1.Text = strFilename;
                btnRead_Click(sender, e);
            }


        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            strFilename = textBox1.Text;
            if (File.Exists(strFilename) == false) {
                MessageBox.Show(this, "更新対象のFontX2ファイルが見つかりません。\r\n既存のFontX2ファイルに対して更新を行うプログラムです。\r\n存在するファイルを指定してください。", "エラー");
                return;
            }
            if (FontZenN.isZenkakku(strFilename)) {
                chkHankaku.Checked = false;
            } else {
                chkHankaku.Checked = true;
            }
        }
    }

    class FontZenN{
        public bool isHankaku;
        public byte[] cSigniture;
        public byte[] cFontName;
        public byte bWidth;
        public byte bHeight;
        public byte bCodeFlag;
        public byte bBlockCount;
        List<ushort[]> codeArea;
        public Dictionary <ushort , byte[]> bufFont;

        public static bool isZenkakku(String strFn)
        {
            if (File.Exists(strFn) == false) return false;

            System.IO.FileInfo fi = new System.IO.FileInfo(strFn);
            if (fi.Length <= 8192) {
                return false;
            } else {
                return true;
            }
        }

        public FontZenN(String strFn,bool a_isHankaku)
        {
            isHankaku = a_isHankaku;
            cSigniture = new byte[6];
            cFontName = new byte[8];
            codeArea = new List<ushort[]>();
            bufFont = new Dictionary<ushort, byte[]>();

            using (FileStream fs = new FileStream(strFn, FileMode.Open, FileAccess.Read)) {
                fs.Read(cSigniture, 0, 6);
                fs.Read(cFontName, 0, 8);
                bWidth = (byte)fs.ReadByte();
                bHeight = (byte)fs.ReadByte();
                bCodeFlag = (byte)fs.ReadByte();
                if (isHankaku) {
                    int ByteCnt = bHeight * (((bWidth - 1) >> 3) + 1);
                    for (int i = 0;i<256;i++) {
                        byte[] fontBuf = new byte[ByteCnt];
                        fs.Read(fontBuf, 0, ByteCnt);
                        bufFont.Add((ushort)i, fontBuf);
                    }
                } else { 
                    bBlockCount = (byte)fs.ReadByte();

                    for (byte i = 0; i < bBlockCount; i++) {
                        ushort[] codeRange = new ushort[2];
                        codeRange[0] = ReadWord(fs);
                        codeRange[1] = ReadWord(fs);
                        codeArea.Add(codeRange);
                    }
                    int ByteCnt = bHeight * (((bWidth - 1) >> 3) + 1);

                    // readBuffer
                    foreach (ushort[] area in codeArea) {
                        for (ushort code = area[0]; code <= area[1]; code++) {
                            byte[] fontBuf = new byte[ByteCnt];
                            fs.Read(fontBuf, 0, ByteCnt);
                            bufFont.Add(code, fontBuf);
                        }
                    }
                }
            }

        }

        public bool Write(string strFn)
        {
            using (FileStream fs = new FileStream(strFn, FileMode.Create, FileAccess.Write)) {
                fs.Write(cSigniture, 0, cSigniture.Length);
                fs.Write(cFontName, 0, cFontName.Length);
                fs.WriteByte(bWidth);
                fs.WriteByte(bHeight);
                fs.WriteByte(bCodeFlag);
                if (isHankaku) {
                    for (int i = 0; i < 256; i++) {
                        fs.Write(bufFont[(ushort)i], 0, bufFont[(ushort)i].Length);
                    }
                } else {
                    fs.WriteByte(bBlockCount);
                    foreach (ushort[] values in codeArea) {
                        WriteWord(fs, values[0]);
                        WriteWord(fs, values[1]);
                    }

                    foreach (KeyValuePair<ushort, byte[]> buf in bufFont) {
                        fs.Write(buf.Value, 0, buf.Value.Length);
                    }
                }
            }
            return true;
        }

        ushort ReadWord(FileStream fs)
        {
            byte lb = (byte)fs.ReadByte();
            byte hb = (byte)fs.ReadByte();
            ushort ans = (ushort)( (hb << 8) | lb);
            return ans;
        }
        void WriteWord(FileStream fs,ushort value)
        {
            byte lb = (byte)(value & 0x00FF);
            byte hb = (byte)((value >> 8) & 0xFF);
            fs.WriteByte(lb);
            fs.WriteByte(hb);

        }
    };
}
