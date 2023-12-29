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
            Model model = new Model();
            CommandManager commandManager = (CommandManager)GetPrivateField(model, "_commandManager");
            ICommand command = new AddCommand(model, Symbol.CIRCLE);

            commandManager.ExecuteCommand(command);

            Assert.AreEqual(1, model.CurrentShapeManager.Count);
        }

        // Redo command test
        [TestMethod()]
        public void RedoTest()
        {
            Model model = new Model();
            CommandManager commandManager = (CommandManager)GetPrivateField(model, "_commandManager");
            ICommand command = new AddCommand(model, Symbol.RECTANGLE);
            commandManager.Redo();

            commandManager.ExecuteCommand(command);;
            commandManager.Undo();

            Assert.AreEqual(0, model.CurrentShapeManager.Count);

            commandManager.Redo();

            Assert.AreEqual(1, model.CurrentShapeManager.Count);
        }

        // Undo command test
        [TestMethod()]
        public void UndoTest()
        {
            Model model = new Model();
            CommandManager commandManager = (CommandManager)GetPrivateField(model, "_commandManager");
            ICommand command = new AddCommand(model, Symbol.CIRCLE);
            commandManager.Undo();

            commandManager.ExecuteCommand(command);

            Assert.AreEqual(1, model.CurrentShapeManager.Count);

            commandManager.Undo();

            Assert.AreEqual(0, model.CurrentShapeManager.Count);
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