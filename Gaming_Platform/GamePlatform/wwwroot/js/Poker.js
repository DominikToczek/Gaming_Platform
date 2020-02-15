let cardClicked1 = false;
let cardClicked2 = false;
let cardClicked3 = false;
let cardClicked4 = false;
let cardClicked5 = false;

function newGame() {
    dealCards();
    resetChangeCardsButtons()
    changeCard1()
    changeCard2()
    changeCard3()
    changeCard4()
    changeCard5()
    resetChangeCardsButtons()
}

function checkGame() {
    $.ajax({
        type: "POST",
        url: "/Poker/CheckGame",
        success: function (response) {
            console.log(response)
        },
        error: function (response) {
            console.log("Coś poszło nie tak" + response)
        }
    })
}

function resetChangeCardsButtons() {
    cardClicked1 = false;
    cardClicked2 = false;
    cardClicked3 = false;
    cardClicked4 = false;
    cardClicked5 = false;
}

function changeCard1() {
    if (!cardClicked1) {
        changeCard(1);
        cardClicked1 = true;
    }
}

function changeCard2() {
    if (!cardClicked2) {
        changeCard(2);
        cardClicked2 = true;
    }
}

function changeCard3() {
    if (!cardClicked3) {
        changeCard(3);
        cardClicked3 = true;
    }
}

function changeCard4() {
    if (!cardClicked4) {
        changeCard(4);
        cardClicked4 = true;
    }
}

function changeCard5() {
    if (!cardClicked5) {
        changeCard(5);
        cardClicked5 = true;
    }
}

function dealCards() {
    $.ajax({
        type: "POST",
        url: "/Poker/DealCards",
        success: function (response) {
            console.log(response)
        },
        error: function (response) {
            console.log("Coś poszło nie tak" + response)
        }
    })
}

function getPlayerHand() {
    $.ajax({
        type: "POST",
        url: "/Poker/GetPlayerHand",
        success: function (response) {
            console.log(response)
        },
        error: function (response) {
            console.log("Coś poszło nie tak" + response)
        }
    })
}

function getComputerHand() {
    $.ajax({
        type: "POST",
        url: "/Poker/GetComputerHand",
        success: function (response) {
            displayCards(response)
            console.log(response)
        },
        error: function (response) {
            console.log("Coś poszło nie tak" + response)
        }
    })
}

function changeCard(Id) {
    $.ajax({
        type: "POST",
        data: { Id },
        url: "/Poker/changeCard",
        success: function (response) {
            console.log(response)
            displayCards(response)
        },
        error: function (response) {
            console.log("Coś poszło nie tak" + response)
        }
    })
}

function displayCards(response) {
    document.getElementById("card-suit-1").innerHTML = response.card1Suit;
    document.getElementById("card-value-1").innerHTML = response.card1Value;
    document.getElementById("card-suit-2").innerHTML = response.card2Suit;
    document.getElementById("card-value-2").innerHTML = response.card2Value;
    document.getElementById("card-suit-3").innerHTML = response.card3Suit;
    document.getElementById("card-value-3").innerHTML = response.card3Value;
    document.getElementById("card-suit-4").innerHTML = response.card4Suit;
    document.getElementById("card-value-4").innerHTML = response.card4Value;
    document.getElementById("card-suit-5").innerHTML = response.card5Suit;
    document.getElementById("card-value-5").innerHTML = response.card5Value;
}
