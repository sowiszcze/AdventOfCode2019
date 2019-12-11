using Day11Task1Solution.Enums;
using Day11Task1Solution.Models;
using IntcodeInterpreter;
using IntcodeInterpreter.Enums;
using Shared.Models;

namespace Day11Task1Solution
{
    public static class Solution
    {
        public static Canvas RunRobot(long[] program, Color startingColor)
        {
            var interpreter = new Interpreter(program);
            var robot = new Robot();
            var canvas = new Canvas();
            canvas.PaintPixel(new Point(0, 0), startingColor);

            for (var i = 0; interpreter.Status != Status.RanToCompletion; i++)
            {
                interpreter.AddInput(canvas.GetPixelColor(robot));
                interpreter.Run();
                canvas.PaintPixel(robot, (Color)interpreter.Output[i * 2]);
                robot.RoateAndMove((Rotation)interpreter.Output[i * 2 + 1]);
            }

            return canvas;
        }
    }
}
