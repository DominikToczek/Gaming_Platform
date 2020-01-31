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
            var expected = new Player(1, "", "kamil", 1000, new Pawn("Red", 1, 0));
            Assert.NotNull(expected);
        }

        [Test]
        public void Player_AddMony()
        {
            var player = new Player(1, "", "kamil", 1000, new Pawn("Red", 1, 0));
            player.AddMoney(1000);
            Assert.AreEqual(player.Money, 2000);
        }

        [Test]
        public void Player_SpendMony_DontHaveEnoughtMoney_dontSpendMony()
        {
            var player = new Player(1, "", "kamil", 1000, new Pawn("Red", 1, 0));
            player.spendMoney(10000);
            Assert.AreEqual(player.Money, 1000);
        }

        [Test]
        public void Player_SpendMony_DontHaveEnoughtMoney_spendMoneyReturnFales()
        {
            var player = new Player(1, "", "kamil", 1000, new Pawn("Red", 1, 0));
            Assert.False(player.spendMoney(10000));
        }

        [Test]
        public void Player_SpendMony_HaveEnoughtMoney_spendMoneyReturnTrue()
        {
            var player = new Player(1, "", "kamil", 1000, new Pawn("Red", 1, 0));
            Assert.True(player.spendMoney(1000));
        }

        [Test]
        public void Player_SpendMony_HaveEnoughtMoney_spendMony()
        {
            var player = new Player(1, "", "kamil", 1000, new Pawn("Red", 1, 0));
            player.spendMoney(1000);
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
        public void Pawn_SetOnField_InNumberOfField_MovePawn()
        {
            var pawn = new Pawn("Red", 1, 0);
            pawn.SetOnField(9, 10);
            Assert.AreEqual(pawn.ActualPosition, 9);
        }

        [Test]
        public void Pawn_SetOnField_InNumberOfField_MovePawn_SetOnFieldReturnTrue()
        {
            var pawn = new Pawn("Red", 1, 0);
            Assert.True(pawn.SetOnField(9, 10));
        }

        [Test]
        public void Pawn_SetOnField_OverNumberOfField_dontMovePawn()
        {
            var pawn = new Pawn("Red", 1, 0);
            pawn.SetOnField(10, 10);
            Assert.AreEqual(pawn.ActualPosition, 0);
        }

        [Test]
        public void Pawn_SetOnField_OverNumberOfField_MovePawn_SetOnFieldReturnFalse()
        {
            var pawn = new Pawn("Red", 1, 0);
            Assert.False(pawn.SetOnField(10, 10));
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
            var expected = new FieldWithCity("Brazylia", 1000, 1000);
            Assert.IsNotNull(expected);
        }

        [Test]
        public void FieldWithCity_SetOwer_OwerIsNull_SetOwer()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player(1, "", "kamil", 1000, new Pawn("Red", 1, 0));
            field.SetOwer(player);
            Assert.AreSame(field.Ower, player);
        }

        [Test]
        public void FieldWithCity_SetOwer_OwerIsNull()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player(1, "", "kamil", 1000, new Pawn("Red", 1, 0));
            Assert.IsNull(field.Ower);

        }

        [Test]
        public void FieldWithCity_SetOwer_OwerIsNull_SetOwerReturTrue()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player(1, "", "kamil", 1000, new Pawn("Red", 1, 0));
            Assert.True(field.SetOwer(player));

        }

        [Test]
        public void FieldWithCity_SetOwer_OwerIsNotNull()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player(1, "", "kamil", 1000, new Pawn("Red", 1, 0));
            field.SetOwer(player);
            Assert.False(field.SetOwer(player));

        }

        [Test]
        public void FieldWithCity_BuyField()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player(1, "", "kamil", 1000, new Pawn("Red", 1, 0));
            Assert.True(field.BuyField(player));

        }

        [Test]
        public void FieldWithCity_BuyField_PlayerDontHaveEnoughtMoney()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player(1, "", "kamil", 500, new Pawn("Red", 1, 0));
            Assert.False(field.BuyField(player));
        }

        [Test]
        public void FieldWithCity_BuyField_OwerIsPlayer()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player(1, "", "kamil", 1000, new Pawn("Red", 1, 0));
            field.SetOwer(player);
            Assert.False(field.BuyField(player));
        }

        [Test]
        public void FieldWithCity_SellField_PlayerIsNotOwer()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player(1, "", "kamil", 1000, new Pawn("Red", 1, 0));
            field.SellField(player);
            Assert.AreEqual(player.Money, 1000);
        }

        [Test]
        public void FieldWithCity_SellField_PlayerIsNotOwer_SellfieldReturFalse()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player(1, "", "kamil", 1000, new Pawn("Red", 1, 0));
            Assert.False(field.SellField(player));
        }


        [Test]
        public void FieldWithCity_SellField_PlayerIsOwer__SellfieldReturTrue()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player(1, "", "kamil", 1000, new Pawn("Red", 1, 0));
            field.SetOwer(player);
            Assert.True(field.SellField(player));

        }
        [Test]
        public void FieldWithCity_SellField_PlayerIsOwer()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player(1, "", "kamil", 1000, new Pawn("Red", 1, 0));
            field.SetOwer(player);
            field.SellField(player);
            Assert.AreEqual(player.Money, 2000);
        }
        [Test]
        public void FieldWithCity_PayForStay_PlayerHaveEnoughtMoney()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player(1, "", "kamil", 1000, new Pawn("Red", 1, 0));
            field.SetOwer(new Player(2, "", "Kuba", 1000, new Pawn("Red", 1, 0)));
            field.PayForStay(player);
            Assert.AreEqual(player.Money, 0);
        }

        [Test]
        public void FieldWithCity_PayForStay_PlayerHaveEnoughtMoney_PayForStayPeturnTrue()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player(1, "", "kamil", 1000, new Pawn("Red", 1, 0));
            field.SetOwer(new Player(2, "", "Kuba", 1000, new Pawn("Red", 1, 0)));
            Assert.True(field.PayForStay(player));
        }

        [Test]
        public void FieldWithCity_PayForStay_PlayerDontHaveEnoughtMoney()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player(1, "", "kamil", 500, new Pawn("Red", 1, 0));
            field.SetOwer(new Player(2, "", "Kuba", 1000, new Pawn("Red", 1, 0)));
            field.PayForStay(player);
            Assert.AreEqual(player.Money, 500);
        }

        [Test]
        public void FieldWithCity_PayForStay_PlayerDontHaveEnoughtMoney_PayForStayReturFalse()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player(1, "", "kamil", 500, new Pawn("Red", 1, 0));
            field.SetOwer(new Player(2, "", "Kuba", 1000, new Pawn("Red", 1, 0)));
            Assert.False(field.PayForStay(player));
        }


        [Test]
        public void FieldWithCity_BuyHome_PlayerHaveEnoughtMoney_BuyHomeReturnTrue()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player(1, "", "kamil", 2000, new Pawn("Red", 1, 0));
            field.BuyField(player);
            Assert.True(field.BuyHome(player));
        }

        [Test]
        public void FieldWithCity_BuyHome_PlayerHaveEnoughtMoney_PlayerSpendMony()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player(1, "", "kamil", 2000, new Pawn("Red", 1, 0));
            field.BuyField(player);
            field.BuyHome(player);
            Assert.AreEqual(player.Money, 0);
        }

        [Test]
        public void FieldWithCity_BuyHome_PlayerHaveEnoughtMoney_FieldCostIncrease()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player(1, "", "kamil", 2000, new Pawn("Red", 1, 0));
            field.BuyField(player);
            field.BuyHome(player);
            Assert.AreEqual(field.FieldCost, 2000);
        }
        [Test]
        public void FieldWithCity_BuyHome_PlayerHaveNotEnoughtMoney_BuyHomeReturnFalse()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player(1, "", "kamil", 1000, new Pawn("Red", 1, 0));
            field.BuyField(player);
            Assert.False(field.BuyHome(player));

        }

        [Test]
        public void FieldWithCity_BuyHome_PlayerHaveNotEnoughtMoney_PlayerSpendMony()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player(1, "", "kamil", 1000, new Pawn("Red", 1, 0));
            field.BuyField(player);
            field.BuyHome(player);
            Assert.AreEqual(player.Money, 0);

        }


        [Test]
        public void FieldWithCity_BuyHome_PlayerHaveNotEnoughtMoney_FieldCostNotIncrease()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player(1, "", "kamil", 1000, new Pawn("Red", 1, 0));
            field.BuyField(player);
            field.BuyHome(player);
            Assert.AreEqual(field.FieldCost, 1000);
        }

        [Test]
        public void FieldWithCity_BuyHome_PlayerHaveNotEnoughtMoney_FieldIsEmptyField()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player(1, "", "kamil", 1000, new Pawn("Red", 1, 0));
            field.BuyField(player);
            field.BuyHome(player);
            Assert.AreEqual(field.GetFieldState, FieldState.EmptyField);
        }



        [Test]
        public void FieldWithCity_BuyHotel_PlayerHaveEnoughtMoney_PlayerSpendMoney()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player(1, "", "kamil", 11000, new Pawn("Red", 1, 0));
            field.BuyField(player);
            field.BuyHome(player);
            field.BuyHome(player);
            field.BuyHome(player);
            field.BuyHotel(player);
            Assert.AreEqual(player.Money, 0);
        }

        [Test]
        public void FieldWithCity_BuyHotel_PlayerHaveEnoughtMoney_BuyHotelReturnTrue()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player(1, "", "kamil", 15000, new Pawn("Red", 1, 0));
            field.BuyField(player);
            field.BuyHome(player);
            field.BuyHome(player);
            field.BuyHome(player);
            Assert.True(field.BuyHotel(player));

        }

        [Test]
        public void FieldWithCity_BuyHotel_PlayerHaveEnoughtMoney_fieldCostIncreas()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player(1, "", "kamil", 11000, new Pawn("Red", 1, 0));
            field.BuyField(player);
            field.BuyHome(player);
            field.BuyHome(player);
            field.BuyHome(player);
            field.BuyHotel(player);
            Assert.AreEqual(field.FieldCost, 5000);
        }

        [Test]
        public void FieldWithCity_BuyHotel_PlayerHaveEnoughtMoney_FieldIsNotHotel()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player(1, "", "kamil", 11000, new Pawn("Red", 1, 0));
            field.BuyField(player);
            field.BuyHome(player);
            field.BuyHome(player);
            field.BuyHome(player);
            field.BuyHotel(player);
            Assert.AreEqual(field.GetFieldState, FieldState.Hotel);
        }


        [Test]
        public void FieldWithCity_BuyHotel_PlayerHaveNotEnoughtMoney_BuyHotelReturnFalse()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player(1, "", "kamil", 1000, new Pawn("Red", 1, 0));
            field.BuyField(player);
            field.BuyHome(player);
            field.BuyHome(player);
            field.BuyHome(player);
            field.BuyHotel(player);
            Assert.False(field.BuyHotel(player));
        }

        [Test]
        public void FieldWithCity_BuyHotel_PlayerHaveNotEnoughtMoney()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player(1, "", "kamil", 1000, new Pawn("Red", 1, 0));
            field.BuyField(player);
            field.BuyHome(player);
            field.BuyHome(player);
            field.BuyHome(player);
            field.BuyHotel(player);
            Assert.AreEqual(player.Money, 0);
        }

        [Test]
        public void FieldWithCity_BuyHotel_PlayerHaveNotEnoughtMoney_FieldCostNotIncrease()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player(1, "", "kamil", 1000, new Pawn("Red", 1, 0));
            field.BuyField(player);
            field.BuyHome(player);
            field.BuyHome(player);
            field.BuyHome(player);
            field.BuyHotel(player);
            Assert.AreEqual(field.FieldCost, 1000);
        }

        [Test]
        public void FieldWithCity_BuyHotel_PlayerHaveNotEnoughtMoney_FieldIsNotHotel()
        {
            var field = new FieldWithCity("Brazylia", 1000, 1000);
            var player = new Player(1, "", "kamil", 1000, new Pawn("Red", 1, 0));
            field.BuyField(player);
            field.BuyHome(player);
            field.BuyHome(player);
            field.BuyHome(player);
            field.BuyHotel(player);
            Assert.AreNotEqual(field.GetFieldState, FieldState.Hotel);
        }


        ///StartField
        [Test]
        public void CreateStartField()
        {
            var expected = new StartField();
            Assert.IsNotNull(expected);
        }
        [Test]
        public void StartField_AddMoneyForStaty()
        {
            var startField = new StartField();
            var player = new Player(1, "", "kamil", 1000, new Pawn("Red", 1, 0));
            startField.AddMoneyForStaty(player);
            Assert.AreEqual(player.Money, 2000);
        }
        ///Board
        [Test]
        public void CreateBoard()
        {
            var expected = new Board();
            Assert.IsNotNull(expected);
        }

        [Test]
        public void CreateBoardCreateFields()
        {
            var board = new Board();
            Assert.IsNotNull(board.GetAllField);
        }

        [Test]
        public void CreateBoardGetFieldId()
        {
            var board = new Board();
            var expected = (board.GetAllField)[1];
            Assert.AreEqual(expected, board.GetFiels(1));
        }


        [Test]
        public void CreateBoardGetFieldPlayerId()
        {
            var board = new Board();
            var player = new Player(1, "", "kamil", 1000, new Pawn("Red", 1, 0));
            (board.GetFiels(1) as FieldWithCity).SetOwer(player);
            var tmp = board.GetFiels(1);
            Assert.AreEqual(1, (board.GetAllFields(player)).Count);
        }


    }
}
