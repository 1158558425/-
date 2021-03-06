﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using 直方图均衡化.Controls;
using System.Runtime.InteropServices;

namespace 直方图均衡化
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //设置combox的初始项
            comboBox1.SelectedIndex = 0;
        }
        
        /// <summary>
        /// 存储原始图像
        /// </summary>
        Bitmap bitmap;
        /// <summary>
        /// 存储处理后图像
        /// </summary>
        Bitmap newbitmap;
        /// <summary>
        /// 打开文件按钮，点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                bitmap = (Bitmap)Image.FromFile(path);
                pictureBox1.Image = bitmap.Clone() as Image;
            }
        }
        /// <summary>
        /// 保存图片按钮，点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            bool isSave = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName.ToString();

                if (fileName != "" && fileName != null)
                {
                    string fileExtName = fileName.Substring(fileName.LastIndexOf(".") + 1).ToString();

                    System.Drawing.Imaging.ImageFormat imgformat = null;

                    if (fileExtName != "")
                    {
                        switch (fileExtName)
                        {
                            case "jpg":
                                imgformat = System.Drawing.Imaging.ImageFormat.Jpeg;
                                break;
                            case "bmp":
                                imgformat = System.Drawing.Imaging.ImageFormat.Bmp;
                                break;
                            case "gif":
                                imgformat = System.Drawing.Imaging.ImageFormat.Gif;
                                break;
                            default:
                                MessageBox.Show("只能存取为: jpg,bmp,gif 格式");
                                isSave = false;
                                break;
                        }

                    }

                    //默认保存为JPG格式   
                    if (imgformat == null)
                    {
                        imgformat = System.Drawing.Imaging.ImageFormat.Jpeg;
                    }

                    if (isSave)
                    {
                        try
                        {
                            this.pictureBox2.Image.Save(fileName, imgformat);
                            //MessageBox.Show("图片已经成功保存!");   
                        }
                        catch
                        {
                            MessageBox.Show("保存失败,你还没有截取过图片或已经清空图片!");
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 双击浏览原始图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            Showpicture showpicture = new Showpicture();
            showpicture.picture.Image = bitmap.Clone() as Image;
            showpicture.Height = bitmap.Height;
            showpicture.Width = bitmap.Width;
            showpicture.Show();
        }
        /// <summary>
        /// 双击浏览处理后图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {

            Showpicture showpicture = new Showpicture();
            showpicture.picture.Image = newbitmap.Clone() as Image;
            showpicture.Height = newbitmap.Height;
            showpicture.Width = newbitmap.Width;
            showpicture.Show();

        }
        /// <summary>
        /// 执行操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                newbitmap = Operation.Equalization(bitmap);
                if(newbitmap != null)pictureBox2.Image = newbitmap.Clone() as Image;//显示至pictureBox2
                else { MessageBox.Show("原始图片为空！", "提示："); }
            }
            if (radioButton2.Checked == true)
            {
                newbitmap = Operation.Darkangle(bitmap);
                if (newbitmap != null) pictureBox2.Image = newbitmap.Clone() as Image;//显示至pictureBox2
                else { MessageBox.Show("原始图片为空！", "提示："); }
            }
            if (radioButton3.Checked == true)
            {
                newbitmap = Operation.Mosaic(bitmap);
                if (newbitmap != null) pictureBox2.Image = newbitmap.Clone() as Image;//显示至pictureBox2
                else { MessageBox.Show("原始图片为空！", "提示："); }
            }
            if (radioButton4.Checked == true)
            {
                newbitmap = Operation.Decoloration(bitmap);
                if (newbitmap != null) pictureBox2.Image = newbitmap.Clone() as Image;//显示至pictureBox2
                else { MessageBox.Show("原始图片为空！", "提示："); }
            }
            if (radioButton5.Checked == true)
            {
                newbitmap = Operation.Cameo(bitmap);
                if (newbitmap != null) pictureBox2.Image = newbitmap.Clone() as Image;//显示至pictureBox2
                else { MessageBox.Show("原始图片为空！", "提示："); }
            }
            if (radioButton6.Checked == true)
            {
                newbitmap = Operation.Spread(bitmap);
                if (newbitmap != null) pictureBox2.Image = newbitmap.Clone() as Image;//显示至pictureBox2
                else { MessageBox.Show("原始图片为空！", "提示："); }
            }
            if (radioButton7.Checked == true)
            {
                newbitmap = Operation.Light_Reduction(bitmap);
                if (newbitmap != null) pictureBox2.Image = newbitmap.Clone() as Image;//显示至pictureBox2
                else { MessageBox.Show("原始图片为空！", "提示："); }
            }
            if (radioButton8.Checked == true)
            {
                newbitmap = Operation.RotateFlip(bitmap);
                if (newbitmap != null) pictureBox2.Image = newbitmap.Clone() as Image;//显示至pictureBox2
                else { MessageBox.Show("原始图片为空！", "提示："); }
            }
        }
        /// <summary>
        /// 版本和git地址标签
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/1158558425/picequalization.git");
        }
        /// <summary>
        /// 清理视图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString() == "全部")
            {
                bitmap = null;
                newbitmap = null;
                Operation.newbitmap = null;
                pictureBox1.Image = null;
                pictureBox2.Image = null;
                MessageBox.Show("已全部清空！", "提示：");
            }
            else if (comboBox1.SelectedItem.ToString() == "原始图")
            {
                bitmap = null;
                pictureBox1.Image = null;
                MessageBox.Show("原始图已清空！", "提示：");
            }
            else
            {
                newbitmap = null;
                pictureBox2.Image = null;
                Operation.newbitmap = null;
                MessageBox.Show("处理图已清空！", "提示：");
            }


        }
        /// <summary>
        /// 将这个界面设置为主界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();//退出应用程序
        }
        //设置一个渐出动画
        [DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        private const int AW_HOR_POSITIVE = 0x0001;//自左向右显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_HOR_NEGATIVE = 0x0002;//自右向左显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_VER_POSITIVE = 0x0004;//自顶向下显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_VER_NEGATIVE = 0x0008;//自下向上显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志该标志
        private const int AW_CENTER = 0x0010;//若使用了AW_HIDE标志，则使窗口向内重叠；否则向外扩展
        private const int AW_HIDE = 0x10000;//隐藏窗口
        private const int AW_ACTIVE = 0x20000;//激活窗口，在使用了AW_HIDE标志后不要使用这个标志
        private const int AW_SLIDE = 0x40000;//使用滑动类型动画效果，默认为滚动动画类型，当使用AW_CENTER标志时，这个标志就被忽略
        private const int AW_BLEND = 0x80000;//使用淡入淡出效果
        private void Form1_Load(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 1500, AW_BLEND);
        }
    }
}
