function newGame() {
    dealCards();
    getPlayerHand();
    getComputerHand();
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

function changeCard1() {
    changeCard(1);
}

function changeCard2() {
    changeCard(2);
}

function changeCard3() {
    changeCard(3);
}

function changeCard4() {
    changeCard(4);
}

function changeCard5() {
    changeCard(5);
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
        },
        error: function (response) {
            console.log("Coś poszło nie tak" + response)
        }
    })
}
