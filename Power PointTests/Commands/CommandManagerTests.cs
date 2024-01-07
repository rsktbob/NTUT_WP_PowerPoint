using Microsoft.VisualStudio.TestTools.UnitTesting;
using Power_Point;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Power_Point.Tests
{
    [TestClass()]
    public class CommandManagerTests
    {
        // CommandManager constructor test
        [TestMethod()]
        public void CommandManagerTest()
        {
            CommandManager commandManager = new CommandManager();

            Stack<ICommand> redoStack = (Stack<ICommand>)GetPrivateField(commandManager, "_redoStack");
            Stack<ICommand> undoStack = (Stack<ICommand>)GetPrivateField(commandManager, "_undoStack");

            Assert.AreEqual(0, redoStack.Count);
            Assert.AreEqual(0, undoStack.Count);
        }

        // Execute command test
        [TestMethod()]
        public void ExecuteCommandTest()
        {
            Shapes shapes = new Shapes();
            CommandManager commandManager = new CommandManager();
            ICommand command = new AddCommand(shapes, Symbol.CIRCLE, 3, 14, 6, 18);

            commandManager.ExecuteCommand(command);

            Assert.AreEqual(1, shapes.ShapeManager.Count);
        }

        // Redo command test
        [TestMethod()]
        public void RedoTest()
        {
            Shapes shapes = new Shapes();
            CommandManager commandManager = new CommandManager();
            ICommand command = new AddCommand(shapes, Symbol.RECTANGLE, 3, 14, 6, 18);
            commandManager.Redo();

            commandManager.ExecuteCommand(command); ;
            commandManager.Undo();

            Assert.AreEqual(0, shapes.ShapeManager.Count);

            commandManager.Redo();

            Assert.AreEqual(1, shapes.ShapeManager.Count);
        }

        // Undo command test
        [TestMethod()]
        public void UndoTest()
        {
            Shapes shapes = new Shapes();
            CommandManager commandManager = new CommandManager();
            ICommand command = new AddCommand(shapes, Symbol.CIRCLE, 3, 14, 6, 18);
            commandManager.Undo();

            commandManager.ExecuteCommand(command);

            Assert.AreEqual(1, shapes.ShapeManager.Count);

            commandManager.Undo();

            Assert.AreEqual(0, shapes.ShapeManager.Count);
        }

        // Get private field
        private object GetPrivateField(object obj, string fieldName)
        {
            Type type = obj.GetType();
            FieldInfo fieldInfo = type.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
            if (fieldInfo != null)
            {
                return fieldInfo.GetValue(obj);
            }
            else
            {
                return null;
            }
        }
    }
}