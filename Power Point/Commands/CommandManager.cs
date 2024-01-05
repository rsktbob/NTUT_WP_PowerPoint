using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_Point
{
    public class CommandManager
    {
        private Stack<ICommand> _redoStack;
        private Stack<ICommand> _undoStack;

        public CommandManager()
        {
            _redoStack = new Stack<ICommand>();
            _undoStack = new Stack<ICommand>();
        }

        // Execute command
        public void ExecuteCommand(ICommand command)
        {
            _redoStack.Clear();
            command.Execute();
            _undoStack.Push(command);
        }

        // Redo command
        public void Redo()
        {
            if (_redoStack.Count > 0)
            {
                ICommand command = _redoStack.Pop();
                command.Execute();
                _undoStack.Push(command);
            }
        }

        // Undo command
        public void Undo()
        {
            if (_undoStack.Count > 0)
            {
                ICommand command = _undoStack.Pop();
                command.ReverseExecute();
                _redoStack.Push(command);
            }
        }
        
        // Reset
        public void Clear()
        {
            _redoStack.Clear();
            _undoStack.Clear();
        }

        // Get redo enable
        public bool RedoEnable
        {
            get
            {
                return _redoStack.Count > 0;
            }
        }

        // Get undo enable
        public bool UndoEnable
        {
            get
            {
                return _undoStack.Count > 0;
            }
        }
    }
}
