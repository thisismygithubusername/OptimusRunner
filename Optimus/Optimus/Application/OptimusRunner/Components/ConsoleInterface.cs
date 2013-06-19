using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimus.Application.OptimusRunner.Components
{
    public abstract class ConsoleInterface
    {
        private ConsoleColor _defaultColor;

        protected ConsoleInterface()
        {
            SaveOldConsoleColor();
        }

        public ConsoleInterface SetConsoleErrorColor()
        {
            return ChangeConsoleColor(ConsoleColor.Red);
        }

        public ConsoleInterface SetConsoleHelpColor()
        {
            return ChangeConsoleColor(ConsoleColor.Gray);
        }

        public ConsoleInterface SetConsoleTaskColor()
        {
            return ChangeConsoleColor(ConsoleColor.Green);
        }

        public void SaveOldConsoleColor()
        {
            _defaultColor = Console.ForegroundColor;
        }
        public void SetConsoleDefaultColor()
        {
            ChangeConsoleColor(_defaultColor);
        }

        private ConsoleInterface ChangeConsoleColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
            return this;
        }
    }
}
