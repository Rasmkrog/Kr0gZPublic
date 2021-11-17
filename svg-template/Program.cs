using System;
using System.IO;

namespace svg_template
{
    class Artist
    {
        public string style = "fill=\"none\" stroke-width=\"10px\" opacity=\"1\"";
        private string draw_svg(int width, int height, string shapes)
        {
            
            string viewbox = "viewBox=\"0 0 " + width.ToString() + " " + height.ToString() + "\"";
            string xmlns = "xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" ";
            string header = "<svg width=\"" + width.ToString() + "\"     " + xmlns + viewbox + ">";
            string footer = "</svg>";
            return header + shapes + footer;
        }

        private string draw_circle(int x, int y, double radius, string color)
        {
            string cx = $"cx=\"{x}\"";
            string cy = $"cy=\"{y}\"";
            string rad = $"r=\"{radius}\"";
            string strokeColor = $"stroke=\"{color}\"";
            return $"<circle {cx} {cy} {rad} {style} {strokeColor}/>";
        }

        private string draw_rect(int x, int y, int height, int width, string color)
        {
            string cx = $"x=\"{x}\"";
            string cy = $"y=\"{y}\"";

            string _width = $"width=\"{width}\"";
            string _height = $"height=\"{height}\""; 
            string strokeColor = $"stroke=\"{color}\"";

            return $"<rect {cx} {cy} {_width} {_height} {style} {strokeColor}/>";
        }

        private string draw_triangle(int x1, int y1, int x2, int y2, int x3, int y3, string color)
        {
            string strokeColor = $"stroke=\"{color}\"";
            
            string polygon = $"points=\"{x1}, {y1}, {x2}, {y2}, {x3}, {y3}\"";
            return $"<polygon {polygon} {style} {strokeColor}/>";
        }

        private void save(string svg, string filename)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                sw.WriteLine(svg);
            }
        }
        static void Main(string[] args)
        {
            Artist leo = new Artist();
            string shapes = "";
            
            shapes = shapes + leo.draw_rect(100,  300, 400, 375, "#Fcb450");
            shapes = shapes + leo.draw_triangle(850,500,490,300,490,700,"#43aa8b");

            shapes = shapes + leo.draw_circle(100, 500, 75, "#Ff006e");
            shapes = shapes + leo.draw_circle(850, 500, 75, "#Ff006e");
            
            string drawing = leo.draw_svg(1000, 1000, shapes);
            leo.save(drawing, @"test.svg");
        }
    }
}
