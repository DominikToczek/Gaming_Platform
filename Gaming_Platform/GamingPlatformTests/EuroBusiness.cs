using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using GamingPlatformTests;
using GamePlatform.Models;

namespace GamingPlatformTests
{
    [TestFixture]
    class EuroBusiness
    {
        ///Dice
        [Test]
        public void CreateDice()
        {
            var expected = new Dice(1, 6);
            Assert.NotNull(expected);
        }

        [Test]
        public void CreateDice_Roll()
        {
            var dice = new Dice(1, 6);
            List<int> tmp = new List<int> { 1, 2, 3, 4, 5, 6 };
            Assert.Contains(dice.Rol(), tmp);
        }

        ///Player
        [Test]
        public void CreatePlayer()
        {
            var expected = new Player("kamil", "", 1000, new Pawn("Red", 1, 0));
            Assert.NotNull(expected);
        }

        [Test]
        public void Player_AddMony()
        {
            var player = new Player("kamil", "", 1000, new Pawn("Red", 1, 0));
            player.AddMoney(1000);
            Assert.AreEqual(player.Money, 2000);
        }

        [Test]
        public void Player_SpendMony_DontHaveEnoughtMoney()
        {
            var player = new Player("kamil", "", 1000, new Pawn("Red", 1, 0));
            Assert.False(player.spendMoney(10000));
            Assert.AreEqual(player.Money, 1000);
        }

        [Test]
        public void Player_SpendMony_HaveEnoughtMoney()
        {
            var player = new Player("kamil", "", 1000, new Pawn("Red", 1, 0));
            Assert.True(player.spendMoney(1000));
            Assert.AreEqual(player.Money, 0);
        }
        ///Pawn
        [Test]
        public void PawnCreate()
        {
            var expected = new Pawn("Red", 1, 0);
            Assert.NotNull(expected);
        }

        [Test]
        public void Pawn_Move()
        {
            var pawn = new Pawn("Red", 1, 0);
            pawn.Move(20, 10);
            Assert.AreEqual(pawn.ActualPosition, 0);
        }

        [Test]
        public void Pawn_SetOnField_InNumberOfField()
        {
            var pawn = new Pawn("Red", 1, 0);
            Assert.True(pawn.SetOnField(9, 10));
            Assert.AreEqual(pawn.ActualPosition, 9);
        }

        [Test]
        public void Pawn_SetOnField_OverNumberOfField()
        {
            var pawn = new Pawn("Red", 1, 0);
            Assert.False(pawn.SetOnField(10, 10));
            Assert.AreEqual(pawn.ActualPosition, 0);
        }

        ///EmptyField
        [Test]
        public void CreateEmptyField()
        {
            var expected = new EmptyField();
            Assert.IsNotNull(expected);
        }
        ///FieldWithCity
        [Test]
        public void CreateFieldWithCity()
        {
            var expected = new FieldWithCity("Brazylia",1000,1000);
            Assert.IsNotNull(expected);
        }

        [Test]
        public void FieldWithCity_SetOwer_OwerIsNull()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player("kamil", "", 1000, new Pawn("Red", 1, 0));
            Assert.True(field.SetOwer(player));
            Assert.IsNotNull(field.Ower);
            Assert.AreSame(field.Ower,player);
        }

        [Test]
        public void FieldWithCity_SetOwer_OwerIsNotNull()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player("kamil", "", 1000, new Pawn("Red", 1, 0));
            field.SetOwer(player);
            Assert.False(field.SetOwer(player));
            
        }

        [Test]
        public void FieldWithCity_BuyField()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player("kamil", "", 1000, new Pawn("Red", 1, 0));
            Assert.True(field.BuyField(player));
            
        }

        [Test]
        public void FieldWithCity_BuyField_PlayerDontHaveEnoughtMoney()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player("kamil", "", 500, new Pawn("Red", 1, 0));
            Assert.False(field.BuyField(player));
        }

        [Test]
        public void FieldWithCity_BuyField_OwerIsPlayer()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player("kamil", "", 1000, new Pawn("Red", 1, 0));
            field.SetOwer(player);
            Assert.False(field.BuyField(player)); 
        }

        [Test]
        public void FieldWithCity_SellField_PlayerIsNotOwer()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player("kamil", "", 1000, new Pawn("Red", 1, 0));
            Assert.False(field.SellField(player));
            Assert.AreEqual(player.Money, 1000);
        }

        [Test]
        public void FieldWithCity_SellField_PlayerIsOwer()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player("kamil", "", 1000, new Pawn("Red", 1, 0));
            field.SetOwer(player);
            Assert.True(field.SellField(player));
            Assert.AreEqual(player.Money, 2000);
        }

        [Test]
        public void FieldWithCity_PayForStay_PlayerHaveEnoughtMoney()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player("kamil", "", 1000, new Pawn("Red", 1, 0));
            Assert.True(field.PayForStay(player));
            Assert.AreEqual(player.Money, 0);
        }

        [Test]
        public void FieldWithCity_PayForStay_PlayerDontHaveEnoughtMoney()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player("kamil", "", 500, new Pawn("Red", 1, 0));
            Assert.False(field.PayForStay(player));
            Assert.AreEqual(player.Money, 500);
        }
        [Test]
        public void FieldWithCity_BuyHome_PlayerHaveEnoughtMoney()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player("kamil", "", 1000, new Pawn("Red", 1, 0));
            Assert.True(field.BuyHome(player));
            Assert.AreEqual(player.Money, 0);
            Assert.AreEqual(field.FieldCost, 2000);
        }
        [Test]
        public void FieldWithCity_BuyHome_PlayerHaveNotEnoughtMoney()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player("kamil", "", 500, new Pawn("Red", 1, 0));
            Assert.False(field.BuyHome(player));
            Assert.AreEqual(player.Money, 500);
            Assert.AreEqual(field.FieldCost, 1000);
        }


        [Test]
         public void FieldWithCity_BuyHotel_PlayerHaveEnoughtMoney()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player("kamil", "", 3000, new Pawn("Red", 1, 0));
            field.BuyHome(player);
            Assert.True(field.BuyHotel(player));
            Assert.AreEqual(player.Money, 0);
            Assert.AreEqual(field.FieldCost, 4000);
        }

        [Test]
        public void FieldWithCity_BuyHotel_PlayerHaveNotEnoughtMoney()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player("kamil", "", 2000, new Pawn("Red", 1, 0));
            field.BuyHome(player);
            Assert.False(field.BuyHotel(player));
            Assert.AreEqual(player.Money, 1000);
            Assert.AreEqual(field.FieldCost, 2000);
        }


        ///StartField
        [Test]
        public void CreateStartField()
        {
            var expected = new StartField();
            Assert.IsNotNull(expected);
        }

        public void StartField_AddMoneyForStaty()
        {
            var startField = new StartField();
            var player = new Player("kamil","", 1000, new Pawn("Red", 1, 0));
            startField.AddMoneyForStaty(player);
            Assert.AreEqual(player.Money, 2000);
        }
        ///Board

    }
}
