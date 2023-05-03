using NUnit.Framework;
using Pong;
using UnityEngine;

namespace Testing.EditMode
{
    public class GameHandlerTests
    {
        private GameHandler handler = new GameHandler();

        [Test]
        public void CreateBall()
        {
            GameObject ball = new GameObject();
            Rigidbody2D ballRb = ball.AddComponent<Rigidbody2D>();
            
            handler.InitializeBall(ballRb);
            
            Assert.AreEqual(ballRb.transform.position, Vector3.zero);
            Assert.AreNotEqual(ballRb.velocity, Vector2.zero);
        }
        
        [Test]
        public void ScoreLeft()
        {
            var currentScoreLeft = handler.scoreLeft;

            handler.ScorePoint(true);
            
            Assert.AreEqual(handler.scoreLeft, currentScoreLeft + 1);
        }
        
        [Test]
        public void ScoreRight()
        {
            var currentScoreRight = handler.scoreRight;

            handler.ScorePoint(false);
            
            Assert.AreEqual(handler.scoreRight, currentScoreRight + 1);
        }
        
        [Test]
        public void CheckPaddlePrefab()
        {
            var paddle = handler.PaddlePrefab;
            
            Assert.AreNotEqual(paddle, null);
        }
        
        [Test]
        public void CreateLeftPaddle()
        {
            var (left, right) = handler.CreatePaddles();
            
            Assert.AreEqual(left.transform.position, new Vector3(-8, 0, 0));
            Assert.AreEqual(left.GetComponent<PaddleManager>().isLeft, true);
        }
        
        [Test]
        public void CreateRightPaddle()
        {
            var (left, right) = handler.CreatePaddles();
            
            Assert.AreEqual(right.transform.position, new Vector3(8, 0, 0));
            Assert.AreEqual(right.GetComponent<PaddleManager>().isLeft, false);
        }
        
        [Test]
        public void TestMoveUp()
        {
            var (left, right) = handler.CreatePaddles();

            var curPosY = left.transform.position.y;
            left.GetComponent<PaddleManager>().MoveUp();
            
            Assert.AreEqual(left.transform.position.y > curPosY, true);
        }
        
        [Test]
        public void TestMoveUpTop()
        {
            var (left, right) = handler.CreatePaddles();

            left.transform.position += new Vector3(0, 4, 0);
            var curPosY = left.transform.position.y;
            left.GetComponent<PaddleManager>().MoveUp();
            
            Assert.AreEqual(left.transform.position.y == 4f, true);
        }
        
        [Test]
        public void TestMoveDownBottom()
        {
            var (left, right) = handler.CreatePaddles();

            left.transform.position += new Vector3(0, -4, 0);
            var curPosY = left.transform.position.y;
            left.GetComponent<PaddleManager>().MoveDown();
            
            Assert.AreEqual(left.transform.position.y == -4f, true);
        }
    }
}
