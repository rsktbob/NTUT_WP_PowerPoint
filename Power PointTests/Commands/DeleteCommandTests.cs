﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Power_Point;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_Point.Tests
{
    [TestClass()]
    public class DeleteCommandTests
    {
        // DeleteCommand constructor test
        [TestMethod()]
        public void DeleteCommandTest()
        {
            Shapes shapes = new Shapes();
            shapes.AddShape(new Circle(0, 0, 0, 0));
            DeleteCommand command = new DeleteCommand(shapes, 0);

            command.Execute();

            Assert.AreEqual(0, shapes.ShapeManager.Count);
        }

        // Execute delete shape command test
        [TestMethod()]
        public void ExecuteTest()
        {
            Shapes shapes = new Shapes();
            shapes.AddShape(new Circle(0, 0, 0, 0));
            shapes.AddShape(new Rectangle(0, 0, 0, 0));
            DeleteCommand command = new DeleteCommand(shapes, 1);

            command.Execute();

            Assert.AreEqual(1, shapes.ShapeManager.Count);
        }

        // Unexecute delete shape command test
        [TestMethod()]
        public void ReverseExecuteTest()
        {
            Shapes shapes = new Shapes();
            shapes.AddShape(new Circle(0, 0, 0, 0));
            DeleteCommand command = new DeleteCommand(shapes, 0);

            command.Execute();

            Assert.AreEqual(0, shapes.ShapeManager.Count);

            command.ReverseExecute();

            Assert.AreEqual(1, shapes.ShapeManager.Count);
        }
    }
}