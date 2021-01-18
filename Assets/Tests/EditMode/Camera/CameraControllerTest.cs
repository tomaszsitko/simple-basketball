using NUnit.Framework;
using UnityEngine;

namespace SimpleBasketball.Tests
{
    public class CameraControllerTest : CameraController
    {
        [Test]
        public void StartDrawShootLineTest()
        {
            StartDrawShootLine(Vector3.one);
            Assert.IsTrue(draw);
            Assert.AreEqual(Vector3.one, startLinePosition);
        }

        [Test]
        public void StopShootDrawLineTest()
        {
            draw = true;
            StopShootDrawLine();
            Assert.IsFalse(draw);
        }
    }
}