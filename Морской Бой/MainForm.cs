using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Морской_Бой
{
    public partial class MainForm : Form
    {
        //  Массив содержащий информацию о координатах клеток будующего корабля

        public static int[,] ClickedCells = new int[6,2]; // [количество клеток, количество координат]

        static int ClickCount = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        public static bool CheckNewCoordinates(int X, int Y, int ShipSize)
        {
            //сделать проверку "свободна ли клетка (cоседние корабли)"
            int i = 0;
            int j = 0;
            int Xm, Ym;

            if (X < 0 || X >= BattleField.SizeWidht || Y < 0 || Y >= BattleField.SizeHeith)
            {
                return false;
            }

            if (ClickCount == 0)
            {
                return true;
            }

            if (ClickCount == ShipSize)
            {
                return false;
            }

            while (i <= ClickCount)
            {
                Xm = ClickedCells[i, 0];
                Ym = ClickedCells[i, 1];

                if ((Xm == X && Ym == Y - 1) || (Xm == X - 1 && Ym == Y) || (Xm == X + 1 && Ym == Y) || (Xm == X && Ym == Y + 1))
                {
                    j = 0;
                    while (j <= ClickCount)
                    {
                        if (X == ClickedCells[j, 0] && Y == ClickedCells[j, 1])
                        {
                            return false;
                        }
                        j++;
                    }
                    return true;
                }
                i++;
            }
            return false;
        }

        public static bool CheckOldCoordinates(int X, int Y) //
        {

            int i = 0;
            while (i <= ClickCount)
            {
                if (X == ClickedCells[i, 0] && Y == ClickedCells[i, 1])
                {
                    return true;
                }
                i++;
            }
            return false;
        }

        public static void DeleteOldCoordinates(int X, int Y)
        {
            int Number;

            int i = 0;
            while (i <= ClickCount)
            {
                if (X == ClickedCells[i, 0] && Y == ClickedCells[i, 1])
                {
                    Number = i;
                    for (int j = Number; j < ClickedCells.GetLength(0) - 1; j++)
                    {
                        ClickedCells[j, 0] = ClickedCells[j + 1, 0];
                        ClickedCells[j, 1] = ClickedCells[j + 1, 1];
                    }
                    return;
                }
                i++;
            }
            Number = -1; // не нашли
        }

        private bool CheckingIntegrityShip(int[,] CheckCells)
        {
            int[,] Temp = CheckCells;
            int[,] ForDelete = new int[CheckCells.GetLength(0), CheckCells.GetLength(1)];

        }

        private bool AdjacentCells(int x1, int y1, int x2, int y2)
        {
            if ((x1 == x2 && y1 == y2 - 1) || (x1 == x2 - 1 && y1 == y2) || (x1 == x2 + 1 && y1 == y2) || (x1 == x2 && y1 == y2 + 1))
            {

            }
        }

        private void BattleFieldPB_MouseClick(object sender, MouseEventArgs e) // Обработка клика мыши по всему MainForm (окну)
        {
            // Переменные содержащие координаты нажатой клетки
            int CellNumberX;
            int CellNumberY;

            // Номер клетки на которую нажал пользователь по X и Y
            CellNumberX = (e.X - BattleField.LeftBatleFieldPositionX) / 30;
            CellNumberY = (e.Y - BattleField.LeftBatleFieldPositionY) / 30;

            //ClickCount++;
            switch(e.Button)
            {
                case MouseButtons.Left:
                    if (CheckNewCoordinates(CellNumberX, CellNumberY, 6))
                    {
                    ClickedCells[ClickCount, 0] = CellNumberX;
                    ClickedCells[ClickCount, 1] = CellNumberY;

                    ClickCount ++;

                    BattleField.BatleFieldLeftArr[CellNumberX, CellNumberY] = BattleField.CellStatus.Ship;
                    BattleField.BatleFieldDraw(BattleField.LeftBatleFieldPositionX, BattleField.LeftBatleFieldPositionY);
                    }break;
                case MouseButtons.Right:
                    if (CheckOldCoordinates(CellNumberX, CellNumberY))
                    {

                        //DeleteOldCoordinates(CellNumberX, CellNumberY);
                        //ClickCount--;
                       
                        BattleField.BatleFieldLeftArr[CellNumberX, CellNumberY] = BattleField.CellStatus.Water;
                        BattleField.BatleFieldDraw(BattleField.LeftBatleFieldPositionX, BattleField.LeftBatleFieldPositionY);
                    }
                    break;
            }
            

            //ClickedCells[Порядковый номер клика; координата, которую я хочу сейчас записать] = CellNumber соответствующей координаты;
            //ClickedCells[ClickCount - 1, 0] = CellNumberX;
            //ClickedCells[ClickCount - 1, 1] = CellNumberY;

            /*switch (e.Button)
            {
                case MouseButtons.Left:
                    if (CellNumberX < BattleField.SizeWidht && CellNumberY < BattleField.SizeHeith && CellNumberX >= 0 && CellNumberY >= 0)
                    {
                        //MessageBox.Show("Mew X:" + CellNumberX + " Y:" + CellNumberY);

                        BattleField.BatleFieldLeftArr[CellNumberX, CellNumberY] = BattleField.CellStatus.Ship;
                        BattleField.BatleFieldDraw(BattleField.LeftBatleFieldPositionX, BattleField.LeftBatleFieldPositionY);

                       
                        
                    }
                    break;

                case MouseButtons.Right:
                    if (CellNumberX < BattleField.SizeWidht && CellNumberY < BattleField.SizeHeith && CellNumberX >= 0 && CellNumberY >= 0)
                    {
                        //MessageBox.Show("Mew X:" + CellNumberX + " Y:" + CellNumberY);

                        BattleField.BatleFieldLeftArr[CellNumberX, CellNumberY] = BattleField.CellStatus.Water;
                        BattleField.BatleFieldDraw(BattleField.LeftBatleFieldPositionX, BattleField.LeftBatleFieldPositionY);
                    }
                    break;
            }*/


        }
    }

    public class BattleField
    {
        public enum CellStatus // Список того что может находится в клетках игрового поля
        {
            Water,
            WaterShot,
            Ship,
            ShipShot,
            ShipSink,
            Flag
        }

        // Координаты верхнего левого угла левого боевого поля
        public static int LeftBatleFieldPositionX = 59;
        public static int LeftBatleFieldPositionY = 59;

        // Подгрузка картинок
        static Bitmap WaterBmp = new Bitmap(@".\Textures\Water.png");
        static Bitmap ShipBmp = new Bitmap(@".\Textures\Ship.png");
        static Bitmap WaterShootBmp = new Bitmap(@".\Textures\WaterShoot.png");
        static Bitmap FlagBmp = new Bitmap(@".\Textures\Flag.png");
        static Bitmap ShipSinkBmp = new Bitmap(@".\Textures\ShipKilled.png");
        static Bitmap ShipShootBmp = new Bitmap(@".\Textures\ShipShoot.png");

        static public int SizeWidht = 10, SizeHeith = 10; // Задаются размеры игрового поля
        static public CellStatus[,] BatleFieldLeftArr  = new CellStatus[SizeWidht, SizeHeith]; // Этот массив хранит информацию о том, что находится в каждой клетке левого игрового поля
        static public CellStatus[,] BatleFieldRightArr = new CellStatus[SizeWidht, SizeHeith]; // Этот массив хранит информацию о том, что находится в каждой клетке правого игрового поля

        public BattleField()
        {
            // Заполнение массива водой
            for (int x = 0; x < SizeWidht; x++) // Перебор столбцов игрового поля
            {
                for (int y = 0; y < SizeHeith; y++) // Перебор строк игрового поля
                {
                    BatleFieldLeftArr[x, y]  = CellStatus.Water;
                    BatleFieldRightArr[x, y] = CellStatus.Water;
                }
            }

            BatleFieldDraw(59, 59); // Отрисовка игрового левого поля
        }

        // Отвечает за - Отрисовка игрового поля
        // Принимает - Два числа - Координаты верхнего левого угла игрового поля (клетки с координатами 0, 0)
        // Возвращает - Ничего
        public static void BatleFieldDraw(int startX, int startY) 
        {
            // Подготовка к рисованию
            Bitmap Field = new Bitmap(Program.GameForm.Size.Height, Program.GameForm.Size.Width);
            Graphics graph = Graphics.FromImage(Field);
            // Вывод на экран изображений каждой из клеток игрового поля
            for (int x = 0; x < SizeWidht; x++) // Перебор столбцов игрового поля x=0
            {
                for (int y = 0; y < SizeHeith; y++) // Перебор строк игрового поля x=0 y=2
                {   // Вывод изображения содержимого конкретной клетки игрового поля
                    Bitmap TitleBmp = new Bitmap(30, 30);
                    if (BatleFieldLeftArr[x, y] == CellStatus.Water) { TitleBmp = WaterBmp; }
                    if (BatleFieldLeftArr[x, y] == CellStatus.Ship) { TitleBmp = ShipBmp; }
                    if (BatleFieldLeftArr[x, y] == CellStatus.WaterShot) { TitleBmp = WaterShootBmp; }
                    if (BatleFieldLeftArr[x, y] == CellStatus.Flag) { TitleBmp = FlagBmp; }
                    if (BatleFieldLeftArr[x, y] == CellStatus.ShipSink) { TitleBmp = ShipSinkBmp; }
                    if (BatleFieldLeftArr[x, y] == CellStatus.ShipShot) { TitleBmp = ShipShootBmp; }
                    graph.DrawImage(TitleBmp, startX + x * TitleBmp.Width, startY + y * TitleBmp.Height, TitleBmp.Width, TitleBmp.Height);
                }
            }
            Program.GameForm.BattleFieldPB.Image = Field;
        }
    }
}
