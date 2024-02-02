using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace MyFigures
{
    class Envelope : Rectangle // Класс "Конверт"
    {

        public List<Point> Location => GetLocation();

        public void Init(int _initX, int _initY, int _initW, int _initH, Color color, Control control)
        {
            base.Init(_initX, _initY, color, control);
            fWidth = _initW;
            fHeight = _initH;
        }

        public override void Draw()
        {
            int dotCenterX = fX + fWidth / 2;
            int dotCenterY = fY + fHeight / 2;
            fGraph.DrawRectangle(new Pen(fColor), fX, fY, fWidth, fHeight);
            fGraph.DrawLine(new Pen(fColor), fX, fY, dotCenterX, dotCenterY);
            fGraph.DrawLine(new Pen(fColor), fWidth+fX, fY, dotCenterX, dotCenterY);
        }


        public override void Hide()
        {
            int dotCenterX = fX + fWidth / 2;
            int dotCenterY = fY + fHeight / 2;
            fGraph.DrawRectangle(new Pen(fBackColor), fX, fY, fWidth, fHeight);
            fGraph.DrawLine(new Pen(fBackColor), fX, fY, dotCenterX, dotCenterY);
            fGraph.DrawLine(new Pen(fBackColor), fWidth + fX, fY, dotCenterX, dotCenterY);
        }

        //Функция заполняет всю данную фигуру точками для дальнейших операций
        public List<Point> GetLocation()
        {
            Point leftUpCorner = new Point(fX, fY);
            Point _leftUpCorner = new Point(fX, fY);
            Point rightDownCorner = new Point(fX+fWidth, fY+fHeight);
            List<Point> location = new List<Point>();

            while (leftUpCorner != rightDownCorner)
            {
                while (leftUpCorner.Y != rightDownCorner.Y)
                {
                    location.Add(new Point(leftUpCorner.X, leftUpCorner.Y));
                    leftUpCorner.Y++;
                }

                if (leftUpCorner.Y == rightDownCorner.Y && leftUpCorner.X != rightDownCorner.X)
                {
                    leftUpCorner.X++;
                    leftUpCorner.Y = _leftUpCorner.Y;
                }
            }

            return location;
        }

    }
}
